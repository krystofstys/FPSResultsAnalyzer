using System;
using System.Collections.Generic;
using System.Text;

namespace FPSResultsAnalyzer.Hints
{
    public class DefaultHints
    {
        private readonly List<IHint> SentinelsHints = new List<IHint>();
        private readonly List<IHint> DuelistsHints = new List<IHint>();
        private readonly List<IHint> ControllersHints = new List<IHint>();
        private readonly List<IHint> InitiatorsHints = new List<IHint>();

        public DefaultHints()
        {
            this.DefaultSentinelsHintsSetup();
            this.DefaultDuelistsHintsSetup();
            this.DefaultControllersHintsSetup();
            this.DefaultInitiatorsHintsSetup();
        }

        private void DefaultSentinelsHintsSetup() {
            this.SentinelsHints.Add(new SentinelsHint("Make sure you understand the basics, aim at the headlevel, preaim. Know all the maps and communicate", 1, 0, int.MaxValue, Enums.GameKnowledgeLevelEnum.Low));
            this.SentinelsHints.Add(new SentinelsHint("Your performance was ok, to get better try practicing your aim more and try to watch some videos with ideas how to play this agent.", 1.2, 3, 25, Enums.GameKnowledgeLevelEnum.Low));
            this.SentinelsHints.Add(new SentinelsHint("Great job keep it up, you did really well! You will rank up in no time!", double.MaxValue, int.MaxValue, 15, Enums.GameKnowledgeLevelEnum.Low));
            this.SentinelsHints.Add(new SentinelsHint("Your performance was not up to par, try watching some agent guides to get better idea how to play this agent.", 1, 0, int.MaxValue, Enums.GameKnowledgeLevelEnum.Mediocre));
            this.SentinelsHints.Add(new SentinelsHint("Your performance was ok, do not get stale and try new ideas in game.", 1.2, 3, 25, Enums.GameKnowledgeLevelEnum.Mediocre));
            this.SentinelsHints.Add(new SentinelsHint("Great job keep it up, you did really well! Road to Radiant?", double.MaxValue, int.MaxValue, 15, Enums.GameKnowledgeLevelEnum.Mediocre));
            this.SentinelsHints.Add(new SentinelsHint("Your performance was not up to par, try switching up your strategies, inspire by players such as Steel, Dapr.", 1, 0, int.MaxValue, Enums.GameKnowledgeLevelEnum.High));
            this.SentinelsHints.Add(new SentinelsHint("Your performance was ok, to get better try practicing your aim more and try to think of new approaches to your game.", 1.2, 3, 25, Enums.GameKnowledgeLevelEnum.High));
            this.SentinelsHints.Add(new SentinelsHint("Great job keep it up, you did really well! Ever thought of going pro?", double.MaxValue, int.MaxValue, 15, Enums.GameKnowledgeLevelEnum.High));
        }

        public IHint GetSentinelsHint(int index)
        {
            if (SentinelsHints.Count == 0) {
                this.DefaultSentinelsHintsSetup();
            }

            if (SentinelsHints.Count <= index)
            {
                throw new ArgumentException("Index out of range of sentinels list");
            }

            return SentinelsHints[index];
        }

        public List<IHint> GetSentinelsHints()
        {
            return SentinelsHints;
        }

        private void DefaultDuelistsHintsSetup()
        {
            this.DuelistsHints.Add(new DuelistsHint("Make sure you understand the basics, aim at the headlevel, preaim. Know all the maps and communicate. If you pick duelist you have to be aggresive and get information", 0, 0, 0, Enums.GameKnowledgeLevelEnum.Low));
            this.DuelistsHints.Add(new DuelistsHint("Your performance was ok, to get better try practicing your aim more and try to cooperate with your teammates to get useful openings.", 1, 1, 3, Enums.GameKnowledgeLevelEnum.Low));
            this.DuelistsHints.Add(new DuelistsHint("Great job keep it up, you did really well! You will rank up in no time!", 1, 1.2, 5, Enums.GameKnowledgeLevelEnum.Low));
            this.DuelistsHints.Add(new DuelistsHint("Your performance was not up to par, try watching some agent guides to get better idea how to play this agent. Try to ask your initiators to help you get advantage when taking duels.", 0, 0, 0, Enums.GameKnowledgeLevelEnum.Mediocre));
            this.DuelistsHints.Add(new DuelistsHint("Your performance was ok, do not get stale and you should mainly focus on getting more opening kills as a duelist.", 1, 1, 3, Enums.GameKnowledgeLevelEnum.Mediocre));
            this.DuelistsHints.Add(new DuelistsHint("Great job keep it up, you did really well! Do not get too cocky tho!", 1, 1.2, 5, Enums.GameKnowledgeLevelEnum.Mediocre));
            this.DuelistsHints.Add(new DuelistsHint("Your performance was not up to par, try switching up your strategies, inspire by players such as Scream, Wardell, Subroza.", 0, 0, 0, Enums.GameKnowledgeLevelEnum.High));
            this.DuelistsHints.Add(new DuelistsHint("Your performance was ok, to get better try practicing your aim more and try to think of combining both of yours and yours teammates abilities.", 1, 1, 3, Enums.GameKnowledgeLevelEnum.High));
            this.DuelistsHints.Add(new DuelistsHint("Great job keep it up, you did really well! Challenge yourself to learn also the more team oriented characters!", 1, 1.2, 5, Enums.GameKnowledgeLevelEnum.High));
        }

        public IHint GetDuelistHint(int index)
        {
            if (DuelistsHints.Count == 0)
            {
                this.DefaultDuelistsHintsSetup();
            }

            if (DuelistsHints.Count <= index)
            {
                throw new ArgumentException("Index out of range of duelists list");
            }

            return DuelistsHints[index];
        }

        public List<IHint> GetDuelistsHints()
        {
            return DuelistsHints;
        }

        private void DefaultControllersHintsSetup()
        {
            this.ControllersHints.Add(new ControllersHint("Make sure you understand the basics, aim at the headlevel, preaim. Know all the maps and communicate. Try to use your utility as much as possible when needed.", 0, 0, int.MaxValue, 0, Enums.GameKnowledgeLevelEnum.Low));
            this.ControllersHints.Add(new ControllersHint("Your performance was ok, to get better try practicing your aim more and use your utility to help your team get sites or stall the enemies.", 1, 3, 20, 3, Enums.GameKnowledgeLevelEnum.Low));
            this.ControllersHints.Add(new ControllersHint("Great job keep it up, you did really well! You will rank up in no time!", 1.2, 5, int.MaxValue, 5, Enums.GameKnowledgeLevelEnum.Low));
            this.ControllersHints.Add(new ControllersHint("Your performance was not up to par, try watching some agent guides to get better idea how to play this agent. Try to help your teammate more with your utility.", 0, 0, int.MaxValue, 0, Enums.GameKnowledgeLevelEnum.Mediocre));
            this.ControllersHints.Add(new ControllersHint("Your performance was ok, do not get stale and you should abuse your utility more to decrease opponents option to get an opening.", 1, 3, 20, 3, Enums.GameKnowledgeLevelEnum.Mediocre));
            this.ControllersHints.Add(new ControllersHint("Great job keep it up, you did really well! Try switching up to other controllers and master them all!", 1.2, 5, int.MaxValue, 5, Enums.GameKnowledgeLevelEnum.Mediocre));
            this.ControllersHints.Add(new ControllersHint("Your performance was not up to par, try switching up your strategies, inspire by players such as Nitr0, Wedid, Jcruel.", 0, 0, int.MaxValue, 0, Enums.GameKnowledgeLevelEnum.High));
            this.ControllersHints.Add(new ControllersHint("Your performance was ok, to get better try practicing your aim more and try to think of combining both of yours and yours teammates abilities, can your agent do any oneway smokes.", 1, 3, 20, 3, Enums.GameKnowledgeLevelEnum.High));
            this.ControllersHints.Add(new ControllersHint("Great job keep it up, you did really well! If you like a more structured and ability heavy gameplay try sentinels!", 1.2, 5, int.MaxValue, 5, Enums.GameKnowledgeLevelEnum.High));
        }

        public IHint GetControllersHint(int index)
        {
            if (ControllersHints.Count == 0)
            {
                this.DefaultControllersHintsSetup();
            }

            if (ControllersHints.Count <= index)
            {
                throw new ArgumentException("Index out of range of controllers list");
            }

            return ControllersHints[index];
        }

        public List<IHint> GetControllersHints()
        {
            return ControllersHints;
        }

        private void DefaultInitiatorsHintsSetup()
        {
            this.InitiatorsHints.Add(new InitiatorsHint("Make sure you understand the basics, aim at the headlevel, preaim. Know all the maps and communicate. Try to use your utility as much as possible when needed to get an opening.", 0, 0, 0, Enums.GameKnowledgeLevelEnum.Low));
            this.InitiatorsHints.Add(new InitiatorsHint("Your performance was ok, to get better try practicing your aim more and try to learn some lineups and other trained utility usage.", 1, 5, 3, Enums.GameKnowledgeLevelEnum.Low));
            this.InitiatorsHints.Add(new InitiatorsHint("Great job keep it up, you did really well! You will rank up in no time!", 1.2, 7, 5, Enums.GameKnowledgeLevelEnum.Low));
            this.InitiatorsHints.Add(new InitiatorsHint("Your performance was not up to par, try watching some agent guides to get better idea how to play this agent. Try practicing utility usage alone before games, it might help you. Communicate what you are doing to your team.", 0, 0, 0, Enums.GameKnowledgeLevelEnum.Mediocre));
            this.InitiatorsHints.Add(new InitiatorsHint("Your performance was ok, do not get stale and you should abuse your utility to get more space for your team.", 1, 3, 3, Enums.GameKnowledgeLevelEnum.Mediocre));
            this.InitiatorsHints.Add(new InitiatorsHint("Great job keep it up, you did really well! Initiators are very diverse, try to learn multiple, some are more useful for different maps!", 1.2, 5, 5, Enums.GameKnowledgeLevelEnum.Mediocre));
            this.InitiatorsHints.Add(new InitiatorsHint("Your performance was not up to par, try switching up your strategies, inspire by players such as Shahzam and Hiko.", 0, 0, 0, Enums.GameKnowledgeLevelEnum.High));
            this.InitiatorsHints.Add(new InitiatorsHint("Your performance was ok, to get better try practicing your aim more and try to help your teammates as much as possible to get the openings.", 1, 3, 3, Enums.GameKnowledgeLevelEnum.High));
            this.InitiatorsHints.Add(new InitiatorsHint("Great job keep it up, you did really well! Are you this good also on the other types?", 1.2, 5, 5, Enums.GameKnowledgeLevelEnum.High));
        }

        public IHint GetInitiatorsHint(int index)
        {
            if (ControllersHints.Count == 0)
            {
                this.DefaultControllersHintsSetup();
            }

            if (ControllersHints.Count <= index)
            {
                throw new ArgumentException("Index out of range of initiators list");
            }

            return InitiatorsHints[index];
        }

        public List<IHint> GetInitiatorsHints()
        {
            return InitiatorsHints;
        }
    }
}
