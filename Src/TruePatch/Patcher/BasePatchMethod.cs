using System;
using System.Collections.Generic;
using System.Text;
using TruePatch.Models;

namespace TruePatch.Patcher
{
    public abstract class BasePatchMethod : IOperationProgress
    {
        public int Percentage { get; }
        public string ProgressInfo { get; }


    }
}
