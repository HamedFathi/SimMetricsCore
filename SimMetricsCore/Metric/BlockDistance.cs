using System;
using System.Collections.ObjectModel;
using SimMetricsCore.API;
using SimMetricsCore.Utilities;

namespace SimMetricsCore.Metric
{
    public sealed class BlockDistance : AbstractStringMetric
    {
        private double estimatedTimingConstant;
        private ITokeniser tokeniser;
        private TokeniserUtilities<string> tokenUtilities;

        public BlockDistance() : this(new TokeniserWhitespace())
        {
        }

        public BlockDistance(ITokeniser tokeniserToUse)
        {
            this.estimatedTimingConstant = 6.4457140979357064E-05;
            this.tokeniser = tokeniserToUse;
            this.tokenUtilities = new TokeniserUtilities<string>();
        }

        private double GetActualSimilarity(Collection<string> firstTokens, Collection<string> secondTokens)
        {
            Collection<string> collection = this.tokenUtilities.CreateMergedList(firstTokens, secondTokens);
            int num = 0;
            foreach (string str in collection)
            {
                int num2 = 0;
                int num3 = 0;
                if (firstTokens.Contains(str))
                {
                    num2++;
                }
                if (secondTokens.Contains(str))
                {
                    num3++;
                }
                if (num2 > num3)
                {
                    num += num2 - num3;
                }
                else
                {
                    num += num3 - num2;
                }
            }
            return (double) num;
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            Collection<string> firstTokens = this.tokeniser.Tokenize(firstWord);
            Collection<string> secondTokens = this.tokeniser.Tokenize(secondWord);
            int num = firstTokens.Count + secondTokens.Count;
            double actualSimilarity = this.GetActualSimilarity(firstTokens, secondTokens);
            return ((num - actualSimilarity) / ((double) num));
        }

        public override string GetSimilarityExplained(string firstWord, string secondWord)
        {
            throw new NotImplementedException();
        }

        public override double GetSimilarityTimingEstimated(string firstWord, string secondWord)
        {
            double count = this.tokeniser.Tokenize(firstWord).Count;
            double num2 = this.tokeniser.Tokenize(secondWord).Count;
            return ((((count + num2) * count) + ((count + num2) * num2)) * this.estimatedTimingConstant);
        }

        public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
        {
            Collection<string> firstTokens = this.tokeniser.Tokenize(firstWord);
            Collection<string> secondTokens = this.tokeniser.Tokenize(secondWord);
            return this.GetActualSimilarity(firstTokens, secondTokens);
        }

        public override string LongDescriptionString
        {
            get
            {
                return "Implements the Block distance algorithm whereby vector space block distance is used to determine a similarity";
            }
        }

        public override string ShortDescriptionString
        {
            get
            {
                return "BlockDistance";
            }
        }
    }
}

