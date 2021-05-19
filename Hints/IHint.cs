using FPSResultsAnalyzer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPSResultsAnalyzer.Hints
{
    public interface IHint
    {
        string HintString { get; set; }
        ClassTypeEnum ClassType { get; set; }
    }
}
