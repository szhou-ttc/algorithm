using System;
using System.Linq;


namespace Algorithm
{
    public class Tries
    {
        TrieNode root;

        public void CreateRoot()
        {
            root = new TrieNode();
        }

        public void Add(char[] chars)
        {
            TrieNode tempRoot = root;
           for (int i = 0; i < chars.Length; i++)
            {
               
                if (!tempRoot.Children.Keys.Contains(chars[i]))
                {
                  
                    tempRoot.Children.Add(chars[i], new TrieNode());
                    
                }
                tempRoot = tempRoot.Children[chars[i]];
                tempRoot.WordCount++;
            }
            tempRoot.EndOfWord = true;

        }
        public TrieNode AddWithNode(char[] chars)
        {
            TrieNode tempRoot = root;
            for (int i = 0; i < chars.Length; i++)
            {

                if (!tempRoot.Children.Keys.Contains(chars[i]))
                {

                    tempRoot.Children.Add(chars[i], new TrieNode());

                }
                tempRoot = tempRoot.Children[chars[i]];
                tempRoot.WordCount++;
            }
            tempRoot.EndOfWord = true;
            return tempRoot;
        }

        public bool FindPrefix(char[] chars)
        {
            TrieNode tempRoot = root;
            for (int i = 0; i < chars.Count(); i++)
            {
                if (tempRoot.Children.Keys.Contains(chars[i]))
                {
                    tempRoot = tempRoot.Children[chars[i]];
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool FindWord(char[] chars)
        {
            TrieNode tempRoot = root;
            int total = chars.Count() - 1;
            for (int i = 0; i < chars.Count(); i++)
            {
                if (tempRoot.Children.Keys.Contains(chars[i]))
                {
                    tempRoot = tempRoot.Children[chars[i]];

                    if (total == i)
                    {
                        if (tempRoot.EndOfWord == true)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public int FindPrefixCount(char[] chars)
        {
            TrieNode tempRoot = root;
            for (int i = 0; i < chars.Count(); i++)
            {
                if (tempRoot.Children.Keys.Contains(chars[i]))
                {
                    tempRoot = tempRoot.Children[chars[i]];
                }
                else
                {
                    return 0;
                }
            }
            return tempRoot.WordCount;
        }

       

    }
}
