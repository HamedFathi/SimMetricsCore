using System.Collections.ObjectModel;
using SimMetricsCore.API;

namespace SimMetricsCore.Utilities
{
    public sealed class TokeniserWhitespace : ITokeniser
    {
        private string delimiters = "\r\n\t \x00a0";
        private ITermHandler stopWordHandler = new DummyStopTermHandler();
        private TokeniserUtilities<string> tokenUtilities = new TokeniserUtilities<string>();

        public Collection<string> Tokenize(string word)
        {
            Collection<string> collection = new Collection<string>();
            if (word != null)
            {
                int length;
                for (int i = 0; i < word.Length; i = length)
                {
                    char c = word[i];
                    if (char.IsWhiteSpace(c))
                    {
                        i++;
                    }
                    length = word.Length;
                    for (int j = 0; j < this.delimiters.Length; j++)
                    {
                        int index = word.IndexOf(this.delimiters[j], i);
                        if ((index < length) && (index != -1))
                        {
                            length = index;
                        }
                    }
                    string termToTest = word.Substring(i, length - i);
                    if (!this.stopWordHandler.IsWord(termToTest))
                    {
                        collection.Add(termToTest);
                    }
                }
            }
            return collection;
        }

        public Collection<string> TokenizeToSet(string word)
        {
            if (word != null)
            {
                return this.tokenUtilities.CreateSet(this.Tokenize(word));
            }
            return null;
        }

        public string Delimiters
        {
            get
            {
                return this.delimiters;
            }
        }

        public string ShortDescriptionString
        {
            get
            {
                return "TokeniserWhitespace";
            }
        }

        public ITermHandler StopWordHandler
        {
            get
            {
                return this.stopWordHandler;
            }
            set
            {
                this.stopWordHandler = value;
            }
        }
    }
}

