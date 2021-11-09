using System;
using SimMetricsCore.API;
using SimMetricsCore.Utilities;

namespace SimMetricsCore.Metric
{
    public sealed class DiceSimilarity : AbstractStringMetric
    {
        private double estimatedTimingConstant;
        private ITokeniser tokeniser;
        private TokeniserUtilities<string> tokenUtilities;

        public DiceSimilarity() : this(new TokeniserWhitespace())
        {
        }

        public DiceSimilarity(ITokeniser tokeniserToUse)
        {
            this.estimatedTimingConstant = 3.4457139008736704E-07;
            this.tokeniser = tokeniserToUse;
            this.tokenUtilities = new TokeniserUtilities<string>();
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if (((firstWord != null) && (secondWord != null)) && (this.tokenUtilities.CreateMergedSet(this.tokeniser.Tokenize(firstWord), this.tokeniser.Tokenize(secondWord)).Count > 0))
            {
                return ((2.0 * this.tokenUtilities.CommonSetTerms()) / ((double) (this.tokenUtilities.FirstSetTokenCount + this.tokenUtilities.SecondSetTokenCount)));
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
                return ((length + num2) * ((length + num2) * this.estimatedTimingConstant));
            }
            return 0.0;
        }

        public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
        {
            return this.GetSimilarity(firstWord, secondWord);
        }

        public override string LongDescriptionString
        {
            get
            {
                return "Implements the DiceSimilarity algorithm providing a similarity measure between two strings using the vector space of present terms";
            }
        }

        public override string ShortDescriptionString
        {
            get
            {
                return "DiceSimilarity";
            }
        }
    }
}

