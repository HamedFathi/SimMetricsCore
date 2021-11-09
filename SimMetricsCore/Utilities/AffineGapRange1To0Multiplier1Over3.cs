using SimMetricsCore.API;

namespace SimMetricsCore.Utilities
{
    public sealed class AffineGapRange1To0Multiplier1Over3 : AbstractAffineGapCost
    {
        private const int charExactMatchScore = 1;
        private const int charMismatchMatchScore = 0;

        public override double GetCost(string textToGap, int stringIndexStartGap, int stringIndexEndGap)
        {
            if (stringIndexStartGap >= stringIndexEndGap)
            {
                return 0.0;
            }
            return (double) (1f + (((stringIndexEndGap - 1) - stringIndexStartGap) * 0.3333333f));
        }

        public override double MaxCost
        {
            get
            {
                return 1.0;
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
                return "AffineGapRange1To0Multiplier1Over3";
            }
        }
    }
}

