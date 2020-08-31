using System.Collections.Generic;

namespace Algorithm
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool EndOfWord;
        public int WordCount;
    }
}
