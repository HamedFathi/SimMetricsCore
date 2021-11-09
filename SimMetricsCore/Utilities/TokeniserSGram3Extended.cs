using System;

namespace SimMetricsCore.Utilities
{
    public class TokeniserSGram3Extended : TokeniserQGram3Extended
    {
        public TokeniserSGram3Extended()
        {
            base.CharacterCombinationIndex = 1;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(base.SuppliedWord))
            {
                return string.Format("{0} : no word passed for tokenising yet.", this.ShortDescriptionString);
            }
            if (base.CharacterCombinationIndex == 0)
            {
                return string.Format("{0} - currently holding : {1}.{2}The method is using a QGram length of {3}.", new object[] { this.ShortDescriptionString, base.SuppliedWord, Environment.NewLine, Convert.ToInt32(base.QGramLength) });
            }
            return string.Format("{0} - currently holding : {1}.{2}The method is using a character combination index of {3} and {4}a QGram length of {5}.", new object[] { this.ShortDescriptionString, base.SuppliedWord, Environment.NewLine, Convert.ToInt32(base.CharacterCombinationIndex), Environment.NewLine, Convert.ToInt32(base.QGramLength) });
        }

        public override string ShortDescriptionString
        {
            get
            {
                return "TokeniserSGram3Extended";
            }
        }
    }
}

