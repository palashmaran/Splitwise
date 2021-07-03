using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.Models
{
    public class PercentSplit : Split
    {
        private double percent;

        public PercentSplit(User user, double percent) : base(user)
        {
            this.percent = percent;
        }

        public double Percent { get => percent; set => percent = value; }
    }
}
