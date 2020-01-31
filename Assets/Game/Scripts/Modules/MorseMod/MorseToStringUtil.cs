using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Game
{
    public class MorseToStringUtil
    {
        private Dictionary<char, string> _morseAlphabetDictionary;

        public MorseToStringUtil()
        {
            InitializeDictionary(_morseAlphabetDictionary);
        }

        #region Private Methods
        private void InitializeDictionary(Dictionary<char, string> dict)
        {
            _morseAlphabetDictionary = new Dictionary<char, string>()
                                   {
                                       {'a', ".-"},
                                       {'b', "-..."},
                                       {'c', "-.-."},
                                       {'d', "-.."},
                                       {'e', "."},
                                       {'f', "..-."},
                                       {'g', "--."},
                                       {'h', "...."},
                                       {'i', ".."},
                                       {'j', ".---"},
                                       {'k', "-.-"},
                                       {'l', ".-.."},
                                       {'m', "--"},
                                       {'n', "-."},
                                       {'o', "---"},
                                       {'p', ".--."},
                                       {'q', "--.-"},
                                       {'r', ".-."},
                                       {'s', "..."},
                                       {'t', "-"},
                                       {'u', "..-"},
                                       {'v', "...-"},
                                       {'w', ".--"},
                                       {'x', "-..-"},
                                       {'y', "-.--"},
                                       {'z', "--.."},
                                       {'0', "-----"},
                                       {'1', ".----"},
                                       {'2', "..---"},
                                       {'3', "...--"},
                                       {'4', "....-"},
                                       {'5', "....."},
                                       {'6', "-...."},
                                       {'7', "--..."},
                                       {'8', "---.."},
                                       {'9', "----."}
                                   };
        }

        #endregion

        #region Helper Methods
        public string TranslateTextToMorse(string input)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char character in input)
            {
                if (_morseAlphabetDictionary.ContainsKey(character))
                {
                    stringBuilder.Append(_morseAlphabetDictionary[character] + "/");
                }

            }

            return stringBuilder.ToString();
        }

        public string TranslateMorseToText(string input)
        {
            StringBuilder stringBuilder = new StringBuilder();

            string[] splitted = input.Split('/');
            foreach (string str in splitted)
            {
                if (_morseAlphabetDictionary.ContainsValue(str))
                {
                    string letter = GetKeyByValue(str).ToString();
                    stringBuilder.Append(letter);
                }
            }

            return stringBuilder.ToString();
        }

        private char GetKeyByValue(string value)
        {
            foreach (KeyValuePair<char, string> key in _morseAlphabetDictionary)
            {
                if (key.Value.Equals(value))
                {
                    return key.Key;
                }
            }
            return '0';
        }
        #endregion
    }
}