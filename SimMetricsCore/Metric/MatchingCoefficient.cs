using System;
using System.Collections.ObjectModel;
using SimMetricsCore.API;
using SimMetricsCore.Utilities;

namespace SimMetricsCore.Metric
{
    public sealed class MatchingCoefficient : AbstractStringMetric
    {
        private const double defaultMismatchScore = 0.0;
        private double estimatedTimingConstant;
        private ITokeniser tokeniser;
        private TokeniserUtilities<string> tokenUtilities;

        public MatchingCoefficient() : this(new TokeniserWhitespace())
        {
        }

        public MatchingCoefficient(ITokeniser tokeniserToUse)
        {
            this.estimatedTimingConstant = 0.00019999999494757503;
            this.tokeniser = tokeniserToUse;
            this.tokenUtilities = new TokeniserUtilities<string>();
        }

        private double GetActualSimilarity(Collection<string> firstTokens, Collection<string> secondTokens)
        {
            this.tokenUtilities.CreateMergedList(firstTokens, secondTokens);
            int num = 0;
            foreach (string str in firstTokens)
            {
                if (secondTokens.Contains(str))
                {
                    num++;
                }
            }
            return (double) num;
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if ((firstWord != null) && (secondWord != null))
            {
                double unnormalisedSimilarity = this.GetUnnormalisedSimilarity(firstWord, secondWord);
                int num2 = Math.Max(this.tokenUtilities.FirstTokenCount, this.tokenUtilities.SecondTokenCount);
                return (unnormalisedSimilarity / ((double) num2));
            }
            return 0.0;
        }

        public override string GetSimilarityExplained(string firstWord, string secondWord)
        {
            throw new NotImplementedException();
        }

        public override double GetSimilarityTimingEstimated(string firstWord, string secondWord)
        {
            if ((firstWord != null) && (secondWord != null))
            {
                double count = this.tokeniser.Tokenize(firstWord).Count;
                double num2 = this.tokeniser.Tokenize(secondWord).Count;
                return ((num2 * count) * this.estimatedTimingConstant);
            }
            return 0.0;
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
                return "Implements the Matching Coefficient algorithm providing a similarity measure between two strings";
            }
        }

        public override string ShortDescriptionString
        {
            get
            {
                return "MatchingCoefficient";
            }
        }
    }
}

