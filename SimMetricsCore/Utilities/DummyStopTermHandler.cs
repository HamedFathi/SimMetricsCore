using System.Text;
using SimMetricsCore.API;

namespace SimMetricsCore.Utilities
{
    public sealed class DummyStopTermHandler : ITermHandler
    {
        public void AddWord(string termToAdd)
        {
        }

        public bool IsWord(string termToTest)
        {
            return false;
        }

        public void RemoveWord(string termToRemove)
        {
        }

        public int NumberOfWords
        {
            get
            {
                return 0;
            }
        }

        public string ShortDescriptionString
        {
            get
            {
                return "DummyStopTermHandler";
            }
        }

        public StringBuilder WordsAsBuffer
        {
            get
            {
                return new StringBuilder();
            }
        }
    }
}

