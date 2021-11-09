using System;
using System.Collections.ObjectModel;
using SimMetricsCore.API;
using SimMetricsCore.Utilities;

namespace SimMetricsCore.Metric
{
    public sealed class EuclideanDistance : AbstractStringMetric
    {
        private const double defaultMismatchScore = 0.0;
        private double estimatedTimingConstant;
        private ITokeniser tokeniser;
        private TokeniserUtilities<string> tokenUtilities;

        public EuclideanDistance() : this(new TokeniserWhitespace())
        {
        }

        public EuclideanDistance(ITokeniser tokeniserToUse)
        {
            this.estimatedTimingConstant = 7.4457137088757008E-05;
            this.tokeniser = tokeniserToUse;
            this.tokenUtilities = new TokeniserUtilities<string>();
        }

        private double GetActualDistance(Collection<string> firstTokens, Collection<string> secondTokens)
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
                num += (num2 - num3) * (num2 - num3);
            }
            return Math.Sqrt((double) num);
        }

        public double GetEuclidDistance(string firstWord, string secondWord)
        {
            if ((firstWord != null) && (secondWord != null))
            {
                Collection<string> firstTokens = this.tokeniser.Tokenize(firstWord);
                Collection<string> secondTokens = this.tokeniser.Tokenize(secondWord);
                return this.GetActualDistance(firstTokens, secondTokens);
            }
            return 0.0;
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if ((firstWord != null) && (secondWord != null))
            {
                double unnormalisedSimilarity = this.GetUnnormalisedSimilarity(firstWord, secondWord);
                double num2 = Math.Sqrt((double) (this.tokenUtilities.FirstTokenCount + this.tokenUtilities.SecondTokenCount));
                return ((num2 - unnormalisedSimilarity) / num2);
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
                return ((((count + num2) * count) + ((count + num2) * num2)) * this.estimatedTimingConstant);
            }
            return 0.0;
        }

        public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
        {
            return this.GetEuclidDistance(firstWord, secondWord);
        }

        public override string LongDescriptionString
        {
            get
            {
                return "Implements the Euclidean Distancey algorithm providing a similarity measure between two stringsusing the vector space of combined terms as the dimensions";
            }
        }

        public override string ShortDescriptionString
        {
            get
            {
                return "EuclideanDistance";
            }
        }
    }
}

