using System.Collections.ObjectModel;
using SimMetricsCore.API;

namespace SimMetricsCore.Utilities
{
    public sealed class SubCostRange5ToMinus3 : AbstractSubstitutionCost
    {
        private Collection<string>[] approx = new Collection<string>[7];
        private const int charApproximateMatchScore = 3;
        private const int charExactMatchScore = 5;
        private const int charMismatchMatchScore = -3;

        public SubCostRange5ToMinus3()
        {
            this.approx[0] = new Collection<string>();
            this.approx[0].Add("d");
            this.approx[0].Add("t");
            this.approx[1] = new Collection<string>();
            this.approx[1].Add("g");
            this.approx[1].Add("j");
            this.approx[2] = new Collection<string>();
            this.approx[2].Add("l");
            this.approx[2].Add("r");
            this.approx[3] = new Collection<string>();
            this.approx[3].Add("m");
            this.approx[3].Add("n");
            this.approx[4] = new Collection<string>();
            this.approx[4].Add("b");
            this.approx[4].Add("p");
            this.approx[4].Add("v");
            this.approx[5] = new Collection<string>();
            this.approx[5].Add("a");
            this.approx[5].Add("e");
            this.approx[5].Add("i");
            this.approx[5].Add("o");
            this.approx[5].Add("u");
            this.approx[6] = new Collection<string>();
            this.approx[6].Add(",");
            this.approx[6].Add(".");
        }

        public override double GetCost(string firstWord, int firstWordIndex, string secondWord, int secondWordIndex)
        {
            if ((firstWord != null) && (secondWord != null))
            {
                if ((firstWord.Length <= firstWordIndex) || (firstWordIndex < 0))
                {
                    return -3.0;
                }
                if ((secondWord.Length <= secondWordIndex) || (secondWordIndex < 0))
                {
                    return -3.0;
                }
                if (firstWord[firstWordIndex] == secondWord[secondWordIndex])
                {
                    return 5.0;
                }
                char ch = firstWord[firstWordIndex];
                string item = ch.ToString().ToLowerInvariant();
                char ch2 = secondWord[secondWordIndex];
                string str2 = ch2.ToString().ToLowerInvariant();
                for (int i = 0; i < this.approx.Length; i++)
                {
                    if (this.approx[i].Contains(item) && this.approx[i].Contains(str2))
                    {
                        return 3.0;
                    }
                }
            }
            return -3.0;
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
                return -3.0;
            }
        }

        public override string ShortDescriptionString
        {
            get
            {
                return "SubCostRange5ToMinus3";
            }
        }
    }
}

