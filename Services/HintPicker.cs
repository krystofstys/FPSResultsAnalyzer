using FPSResultsAnalyzer.Enums;
using FPSResultsAnalyzer.Hints;
using FPSResultsAnalyzer.Results;
using System;
using System.Collections.Generic;

namespace FPSResultsAnalyzer.Services
{
    /*
    * 
    * The Hintpicker class encapsules the functionality needed to find the right hint depending on both the
    * match results and player performance and their past game knowledge and the character they played in the
    * last game.
    * 
    */

    public class HintPicker
    {
        private readonly GameResult GameResult;
        private readonly GameKnowledgeLevelEnum GameKnowledgeLevel;
        private readonly ClassTypeEnum ClassType;

        /*
         * 
         * The constructor of HintPicker takes game result of type GameResult and character from CharactersEnum
         * and game knowledge of a player from GameKnowledgeEnum.
         * 
         */

        public HintPicker(GameResult gameResult, GameKnowledgeLevelEnum gameKnowledgeLevel)
        {
            this.GameResult = gameResult;
            this.GameKnowledgeLevel = gameKnowledgeLevel;
            this.ClassType = CharactersToClassTypeEnum(gameResult.Character);
        }

        /*
         * 
         * The PickHint method is the only public method in the HintPicker class, which starts the chain of
         * determining which hint is the most appropriate for the last game performance. This method picks
         * the right hints according to played ClassType.
         * 
         */

        public string PickHint() 
        {
            DefaultHints defaultHints = new DefaultHints();
            List<IHint> hints;

            switch (this.ClassType)
            {
                case ClassTypeEnum.Duelist:
                    hints = defaultHints.GetDuelistsHints();
                    break;
                case ClassTypeEnum.Controller:
                    hints = defaultHints.GetControllersHints();
                    break;
                case ClassTypeEnum.Initiator:
                    hints = defaultHints.GetInitiatorsHints();
                    break;
                case ClassTypeEnum.Sentinel:
                    hints = defaultHints.GetSentinelsHints();
                    break;
                default:
                    throw new ArgumentException("Invalid or a not updated character type");
            }

            return GetHintString(hints);
        }

        /*
         * 
         * The only static method in the HintPicker class which converts the characters to class type which is
         * needed to find the right hints.
         * 
         */

        private static ClassTypeEnum CharactersToClassTypeEnum(CharactersEnum character)
        {
            switch (character)
            {
                case CharactersEnum.Astra:
                case CharactersEnum.Omen:
                case CharactersEnum.Brimstone:
                case CharactersEnum.Viper:
                    return ClassTypeEnum.Controller;
                case CharactersEnum.Sage:
                case CharactersEnum.Cypher:
                case CharactersEnum.Killjoy:
                    return ClassTypeEnum.Sentinel;
                case CharactersEnum.Breach:
                case CharactersEnum.Skye:
                case CharactersEnum.Sova:
                    return ClassTypeEnum.Initiator;
                case CharactersEnum.Jett:
                case CharactersEnum.Phoenix:
                case CharactersEnum.Raze:
                case CharactersEnum.Reyna:
                case CharactersEnum.Yoru:
                    return ClassTypeEnum.Duelist;                                   
            }

            throw new ArgumentException("Invalid or a not updated character");
        }

        /*
         * 
         * The GetHintString method takes the correct hints supplied by the PickHint method as a parameter
         * and calculates the index of the string according to the GameKnowledgeLevel. As you can see in
         * the DefaultHints.cs, the structure of the list is sorted as follows. For each GameKnowledgeLevel 
         * for each class there are three hints depending on the players performance. Therefore we have to
         * add 3 * gameKnowledgeEnum to determine the hint's index.
         * 
         */

        private string GetHintString(List<IHint> hints)
        {
            IHint resultHint = hints[0 + 3 * (int) this.GameKnowledgeLevel];
            IHint checkedHint = hints[1 + 3 * (int) this.GameKnowledgeLevel];
            int i = 1;

            while ((i < 3) && this.HintAttributesCheck(checkedHint))
            {
                checkedHint = hints[i + 1 + 3 * (int) this.GameKnowledgeLevel];
                resultHint = hints[i + 3 * (int) this.GameKnowledgeLevel];
                i += 1;
            }

            return resultHint.HintString;
        }

        /*
         * 
         * The HintAttributesCheck method takes the checkedHint from GetHintString and compares it with the
         * this.GameResult by calling methods specific to the class type. If the results fit with all the 
         * parameters important to the character type then the method return True, otherwise it returns
         * False.
         * 
         */

        private bool HintAttributesCheck(IHint checkedHint)
        {
            switch (checkedHint.ClassType)
            {
                case ClassTypeEnum.Duelist:
                    return this.DuelistsHintAtributesCheck((DuelistsHint) checkedHint);
                case ClassTypeEnum.Controller:
                    return this.ControllersHintAtributesCheck((ControllersHint) checkedHint);
                case ClassTypeEnum.Initiator:
                    return this.InitiatorsHintAtributesCheck((InitiatorsHint) checkedHint);
                case ClassTypeEnum.Sentinel:
                    return this.SentinelsHintAtributesCheck((SentinelsHint) checkedHint);
            }

            throw new ArgumentException("Invalid class type.");
        }

        /*
         * 
         * Check if the game results and player performance satisfy the needs of the hint from parameter 
         * that is being checked. The important attributes for controller are number of assits in getting
         * a kill, number of deaths in game and number of first kills as well as the win loss ratio of the
         * rounds.
         * 
         */

        private bool ControllersHintAtributesCheck(ControllersHint checkedHint)
        {
            return (checkedHint.MinAssists <= this.GameResult.Assists) &&
                (checkedHint.MaxDeaths >= this.GameResult.Deaths) &&
                (checkedHint.MinFirstKills <= this.GameResult.FirstKills) &&
                (checkedHint.MinWinLoss <= this.GameResult.Score.GetWinLossRatio());
        }

        /*
         * 
         * Check if the game results and player performance satisfy the needs of the hint from parameter 
         * that is being checked. The important attributes for duelists are the kill death ratio, number
         * of first kills and the win loss ratio of the rounds.
         * 
         */

        private bool DuelistsHintAtributesCheck(DuelistsHint checkedHint)
        {
            return (checkedHint.minKillDeathRatio <= this.GameResult.GetKillDeathRatio()) &&
                (checkedHint.minFirstKills <= this.GameResult.FirstKills) &&
                (checkedHint.MinWinLoss <= this.GameResult.Score.GetWinLossRatio());
        }

        /*
         * 
         * Check if the game results and player performance satisfy the needs of the hint from parameter 
         * that is being checked. The important attributes for initiators are the number of first kills, 
         * number of assists and the win loss ratio of the rounds.
         * 
         */

        private bool InitiatorsHintAtributesCheck(InitiatorsHint checkedHint)
        {
            return (checkedHint.MinFirstKills <= this.GameResult.FirstKills) &&
                (checkedHint.MinAssists <= this.GameResult.Assists) &&
                (checkedHint.MinWinLoss <= this.GameResult.Score.GetWinLossRatio());
        }

        /*
         * 
         * Check if the game results and player performance satisfy the needs of the hint from parameter 
         * that is being checked. The important attributes for sentinels are the number of deaths, assists  
         * and the win loss ratio of the rounds.
         * 
         */

        private bool SentinelsHintAtributesCheck(SentinelsHint checkedHint)
        {
            return (checkedHint.MaxDeaths >= this.GameResult.Deaths) &&
                (checkedHint.MinAssists <= this.GameResult.Assists) &&
                (checkedHint.MinWinLoss <= this.GameResult.Score.GetWinLossRatio());
        }
    }
}