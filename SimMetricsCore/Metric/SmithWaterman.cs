using System;
using SimMetricsCore.API;
using SimMetricsCore.Utilities;

namespace SimMetricsCore.Metric
{
    public sealed class SmithWaterman : AbstractStringMetric
    {
        private AbstractSubstitutionCost dCostFunction;
        private const double defaultGapCost = 0.5;
        private const double defaultMismatchScore = 0.0;
        private const double defaultPerfectMatchScore = 1.0;
        private const double estimatedTimingConstant = 0.0001610000035725534;
        private double gapCost;

        public SmithWaterman() : this(0.5, new SubCostRange1ToMinus2())
        {
        }

        public SmithWaterman(AbstractSubstitutionCost costFunction) : this(0.5, costFunction)
        {
        }

        public SmithWaterman(double costG) : this(costG, new SubCostRange1ToMinus2())
        {
        }

        public SmithWaterman(double costG, AbstractSubstitutionCost costFunction)
        {
            this.gapCost = costG;
            this.dCostFunction = costFunction;
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if ((firstWord == null) || (secondWord == null))
            {
                return 0.0;
            }
            double unnormalisedSimilarity = this.GetUnnormalisedSimilarity(firstWord, secondWord);
            double num2 = Math.Min(firstWord.Length, secondWord.Length);
            if (this.dCostFunction.MaxCost > -this.gapCost)
            {
                num2 *= this.dCostFunction.MaxCost;
            }
            else
            {
                num2 *= -this.gapCost;
            }
            if (num2 == 0.0)
            {
                return 1.0;
            }
            return (unnormalisedSimilarity / num2);
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
                return ((((length * num2) + length) + num2) * 0.0001610000035725534);
            }
            return 0.0;
        }

        public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
        {
            if ((firstWord == null) || (secondWord == null))
            {
                return 0.0;
            }
            int length = firstWord.Length;
            int num2 = secondWord.Length;
            if (length == 0)
            {
                return (double) num2;
            }
            if (num2 == 0)
            {
                return (double) length;
            }
            double[][] numArray = new double[length][];
            for (int i = 0; i < length; i++)
            {
                numArray[i] = new double[num2];
            }
            double num4 = 0.0;
            for (int j = 0; j < length; j++)
            {
                double thirdNumber = this.dCostFunction.GetCost(firstWord, j, secondWord, 0);
                if (j == 0)
                {
                    numArray[0][0] = MathFunctions.MaxOf3(0.0, -this.gapCost, thirdNumber);
                }
                else
                {
                    numArray[j][0] = MathFunctions.MaxOf3(0.0, numArray[j - 1][0] - this.gapCost, thirdNumber);
                }
                if (numArray[j][0] > num4)
                {
                    num4 = numArray[j][0];
                }
            }
            for (int k = 0; k < num2; k++)
            {
                double num8 = this.dCostFunction.GetCost(firstWord, 0, secondWord, k);
                if (k == 0)
                {
                    numArray[0][0] = MathFunctions.MaxOf3(0.0, -this.gapCost, num8);
                }
                else
                {
                    numArray[0][k] = MathFunctions.MaxOf3(0.0, numArray[0][k - 1] - this.gapCost, num8);
                }
                if (numArray[0][k] > num4)
                {
                    num4 = numArray[0][k];
                }
            }
            for (int m = 1; m < length; m++)
            {
                for (int n = 1; n < num2; n++)
                {
                    double num11 = this.dCostFunction.GetCost(firstWord, m, secondWord, n);
                    numArray[m][n] = MathFunctions.MaxOf4(0.0, numArray[m - 1][n] - this.gapCost, numArray[m][n - 1] - this.gapCost, numArray[m - 1][n - 1] + num11);
                    if (numArray[m][n] > num4)
                    {
                        num4 = numArray[m][n];
                    }
                }
            }
            return num4;
        }

        public AbstractSubstitutionCost DCostFunction
        {
            get
            {
                return this.dCostFunction;
            }
            set
            {
                this.DCostFunction = value;
            }
        }

        public double GapCost
        {
            get
            {
                return this.gapCost;
            }
            set
            {
                this.gapCost = value;
            }
        }

        public override string LongDescriptionString
        {
            get
            {
                return "Implements the Smith-Waterman algorithm providing a similarity measure between two string";
            }
        }

        public override string ShortDescriptionString
        {
            get
            {
                return "SmithWaterman";
            }
        }
    }
}

