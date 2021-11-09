using SimMetricsCore.API;

namespace SimMetricsCore.Utilities
{
    public sealed class AffineGapRange5To0Multiplier1 : AbstractAffineGapCost
    {
        private const int charExactMatchScore = 5;
        private const int charMismatchMatchScore = 0;

        public override double GetCost(string textToGap, int stringIndexStartGap, int stringIndexEndGap)
        {
            if (stringIndexStartGap >= stringIndexEndGap)
            {
                return 0.0;
            }
            return (double) (5 + ((stringIndexEndGap - 1) - stringIndexStartGap));
        }

        public override double MaxCost
        {
            get
            {
                return 5.0;
            }
        }

        public override double MinCost
        {
            get
            {
                return 0.0;
            }
        }

        public override string ShortDescriptionString
        {
            get
            {
                return "AffineGapRange5To0Multiplier1";
            }
        }
    }
}

