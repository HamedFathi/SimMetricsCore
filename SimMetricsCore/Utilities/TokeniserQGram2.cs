using System;
using System.Collections.ObjectModel;
using SimMetricsCore.API;

namespace SimMetricsCore.Utilities
{
    public class TokeniserQGram2 : AbstractTokeniserQGramN
    {
        public TokeniserQGram2()
        {
            base.StopWordHandler = new DummyStopTermHandler();
            base.TokenUtilities = new TokeniserUtilities<string>();
            base.CharacterCombinationIndex = 0;
            base.QGramLength = 2;
        }

        public override Collection<string> Tokenize(string word)
        {
            return base.Tokenize(word, false, base.QGramLength, base.CharacterCombinationIndex);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(base.SuppliedWord))
            {
                return string.Format("{0} : not word passed for tokenising yet.", this.ShortDescriptionString);
            }
            return string.Format("{0} - currently holding : {1}.{2}The method is using a QGram length of {3}.", new object[] { this.ShortDescriptionString, base.SuppliedWord, Environment.NewLine, Convert.ToInt32(base.QGramLength) });
        }

        public override string ShortDescriptionString
        {
            get
            {
                return "TokeniserQGram2";
            }
        }
    }
}

