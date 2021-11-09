using System;
using SimMetricsCore.API;
using SimMetricsCore.Utilities;

namespace SimMetricsCore.Metric
{
    public sealed class OverlapCoefficient : AbstractStringMetric
    {
        private const double defaultMismatchScore = 0.0;
        private double estimatedTimingConstant;
        private ITokeniser tokeniser;
        private TokeniserUtilities<string> tokenUtilities;

        public OverlapCoefficient() : this(new TokeniserWhitespace())
        {
        }

        public OverlapCoefficient(ITokeniser tokeniserToUse)
        {
            this.estimatedTimingConstant = 0.00014000000373926014;
            this.tokeniser = tokeniserToUse;
            this.tokenUtilities = new TokeniserUtilities<string>();
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if ((firstWord != null) && (secondWord != null))
            {
                this.tokenUtilities.CreateMergedSet(this.tokeniser.Tokenize(firstWord), this.tokeniser.Tokenize(secondWord));
                return (((double) this.tokenUtilities.CommonSetTerms()) / ((double) Math.Min(this.tokenUtilities.FirstSetTokenCount, this.tokenUtilities.SecondSetTokenCount)));
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
                return ((count * num2) * this.estimatedTimingConstant);
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
                return "Implements the Overlap Coefficient algorithm providing a similarity measure between two string where it is determined to what degree a string is a subset of another";
            }
        }

        public override string ShortDescriptionString
        {
            get
            {
                return "OverlapCoefficient";
            }
        }
    }
}

