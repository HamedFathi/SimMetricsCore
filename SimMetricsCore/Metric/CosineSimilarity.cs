using System;
using SimMetricsCore.API;
using SimMetricsCore.Utilities;

namespace SimMetricsCore.Metric
{
    public sealed class CosineSimilarity : AbstractStringMetric
    {
        private double estimatedTimingConstant;
        private ITokeniser tokeniser;
        private TokeniserUtilities<string> tokenUtilities;

        public CosineSimilarity() : this(new TokeniserWhitespace())
        {
        }

        public CosineSimilarity(ITokeniser tokeniserToUse)
        {
            this.estimatedTimingConstant = 3.8337140040312079E-07;
            this.tokeniser = tokeniserToUse;
            this.tokenUtilities = new TokeniserUtilities<string>();
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if (((firstWord != null) && (secondWord != null)) && (this.tokenUtilities.CreateMergedSet(this.tokeniser.Tokenize(firstWord), this.tokeniser.Tokenize(secondWord)).Count > 0))
            {
                return (((double) this.tokenUtilities.CommonSetTerms()) / (Math.Pow((double) this.tokenUtilities.FirstSetTokenCount, 0.5) * Math.Pow((double) this.tokenUtilities.SecondSetTokenCount, 0.5)));
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
                return "Implements the Cosine Similarity algorithm providing a similarity measure between two strings from the angular divergence within term based vector space";
            }
        }

        public override string ShortDescriptionString
        {
            get
            {
                return "CosineSimilarity";
            }
        }
    }
}

