using SimMetricsCore.API;

namespace SimMetricsCore.Utilities
{
    public sealed class SubCostRange1ToMinus2 : AbstractSubstitutionCost
    {
        private const int charExactMatchScore = 1;
        private const int charMismatchMatchScore = -2;

        public override double GetCost(string firstWord, int firstWordIndex, string secondWord, int secondWordIndex)
        {
            if ((firstWord == null) || (secondWord == null))
            {
                return -2.0;
            }
            if ((firstWord.Length <= firstWordIndex) || (firstWordIndex < 0))
            {
                return -2.0;
            }
            if ((secondWord.Length <= secondWordIndex) || (secondWordIndex < 0))
            {
                return -2.0;
            }
            return ((firstWord[firstWordIndex] != secondWord[secondWordIndex]) ? ((double) (-2)) : ((double) 1));
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
                return -2.0;
            }
        }

        public override string ShortDescriptionString
        {
            get
            {
                return "SubCostRange1ToMinus2";
            }
        }
    }
}

