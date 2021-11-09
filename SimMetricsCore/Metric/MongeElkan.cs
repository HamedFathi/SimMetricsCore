using System;
using System.Collections.ObjectModel;
using SimMetricsCore.API;
using SimMetricsCore.Utilities;

namespace SimMetricsCore.Metric
{
    public class MongeElkan : AbstractStringMetric
    {
        private const double defaultMismatchScore = 0.0;
        private double estimatedTimingConstant;
        private AbstractStringMetric internalStringMetric;
        internal ITokeniser tokeniser;

        public MongeElkan() : this(new TokeniserWhitespace())
        {
        }

        public MongeElkan(AbstractStringMetric metricToUse)
        {
            this.estimatedTimingConstant = 0.034400001168251038;
            this.tokeniser = new TokeniserWhitespace();
            this.internalStringMetric = metricToUse;
        }

        public MongeElkan(ITokeniser tokeniserToUse)
        {
            this.estimatedTimingConstant = 0.034400001168251038;
            this.tokeniser = tokeniserToUse;
            this.internalStringMetric = new SmithWatermanGotoh();
        }

        public MongeElkan(ITokeniser tokeniserToUse, AbstractStringMetric metricToUse)
        {
            this.estimatedTimingConstant = 0.034400001168251038;
            this.tokeniser = tokeniserToUse;
            this.internalStringMetric = metricToUse;
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if ((firstWord == null) || (secondWord == null))
            {
                return 0.0;
            }
            Collection<string> collection = this.tokeniser.Tokenize(firstWord);
            Collection<string> collection2 = this.tokeniser.Tokenize(secondWord);
            double num = 0.0;
            for (int i = 0; i < collection.Count; i++)
            {
                string str = collection[i];
                double num3 = 0.0;
                for (int j = 0; j < collection2.Count; j++)
                {
                    string str2 = collection2[j];
                    double similarity = this.internalStringMetric.GetSimilarity(str, str2);
                    if (similarity > num3)
                    {
                        num3 = similarity;
                    }
                }
                num += num3;
            }
            return (num / ((double) collection.Count));
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
            return this.GetSimilarity(firstWord, secondWord);
        }

        public override string LongDescriptionString
        {
            get
            {
                return "Implements the Monge Elkan algorithm providing an matching style similarity measure between two strings";
            }
        }

        public override string ShortDescriptionString
        {
            get
            {
                return "MongeElkan";
            }
        }
    }
}

