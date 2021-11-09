using System;
using System.Collections.ObjectModel;
using SimMetricsCore.API;
using SimMetricsCore.Utilities;

namespace SimMetricsCore.Metric
{
    public sealed class QGramsDistance : AbstractStringMetric
    {
        private const double defaultMismatchScore = 0.0;
        private double estimatedTimingConstant;
        private ITokeniser tokeniser;
        private TokeniserUtilities<string> tokenUtilities;

        public QGramsDistance() : this(new TokeniserQGram3Extended())
        {
        }

        public QGramsDistance(ITokeniser tokeniserToUse)
        {
            this.estimatedTimingConstant = 0.0001340000017080456;
            this.tokeniser = tokeniserToUse;
            this.tokenUtilities = new TokeniserUtilities<string>();
        }

        private double GetActualSimilarity(Collection<string> firstTokens, Collection<string> secondTokens)
        {
            Collection<string> collection = this.tokenUtilities.CreateMergedSet(firstTokens, secondTokens);
            int num = 0;
            foreach (string str in collection)
            {
                int num2 = 0;
                for (int i = 0; i < firstTokens.Count; i++)
                {
                    if (firstTokens[i].Equals(str))
                    {
                        num2++;
                    }
                }
                int num4 = 0;
                for (int j = 0; j < secondTokens.Count; j++)
                {
                    if (secondTokens[j].Equals(str))
                    {
                        num4++;
                    }
                }
                if (num2 > num4)
                {
                    num += num2 - num4;
                }
                else
                {
                    num += num4 - num2;
                }
            }
            return (double) num;
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if ((firstWord != null) && (secondWord != null))
            {
                double unnormalisedSimilarity = this.GetUnnormalisedSimilarity(firstWord, secondWord);
                int num2 = this.tokenUtilities.FirstTokenCount + this.tokenUtilities.SecondTokenCount;
                if (num2 != 0)
                {
                    return ((num2 - unnormalisedSimilarity) / ((double) num2));
                }
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
                double length = firstWord.Length;
                double num2 = secondWord.Length;
                return ((length * num2) * this.estimatedTimingConstant);
            }
            return 0.0;
        }

        public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
        {
            Collection<string> firstTokens = this.tokeniser.Tokenize(firstWord);
            Collection<string> secondTokens = this.tokeniser.Tokenize(secondWord);
            this.tokenUtilities.CreateMergedList(firstTokens, secondTokens);
            return this.GetActualSimilarity(firstTokens, secondTokens);
        }

        public override string LongDescriptionString
        {
            get
            {
                return "Implements the Q Grams Distance algorithm providing a similarity measure between two strings using the qGram approach check matching qGrams/possible matching qGrams";
            }
        }

        public override string ShortDescriptionString
        {
            get
            {
                return "QGramsDistance";
            }
        }
    }
}

