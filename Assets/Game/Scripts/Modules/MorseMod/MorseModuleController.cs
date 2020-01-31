using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

namespace Game
{
    public class MorseModuleController : MonoBehaviour
    {
        public MorseData MorseSettings;
        public SpriteRenderer BlinkTarget;

        public string TextToMorse;
        public string MorseToText;
        MorseToStringUtil _morseTranslator;


        private void Start()
        {
            _morseTranslator = new MorseToStringUtil();
            Debug.Log("TtM: " + _morseTranslator.TranslateTextToMorse(TextToMorse));
            Debug.Log("MtT: " + _morseTranslator.TranslateMorseToText(MorseToText));
            
        }

        public void StartTest()
        {
            StartCoroutine(ProcessLetter(TextToMorse));
        }



        #region Implementations
        private IEnumerator ProcessLetter(string humanText)
        {
            string morseText = _morseTranslator.TranslateTextToMorse(humanText);
            string[] morseLetters = morseText.Split('/');
            for (int i = 0; i < morseLetters.Length; i++)
            {
                string letter = morseLetters[i];
                foreach (char c in letter)
                {
                    if (c.Equals('.'))
                    {
                        StartCoroutine(Blink(MorseSettings.DotBlinkSpeed));
                        yield return new WaitForSeconds(MorseSettings.DotBlinkSpeed + MorseSettings.IntraLetterBlinkSpeed);
                    }
                    else if (c.Equals('-'))
                    {
                        StartCoroutine(Blink(MorseSettings.DashBlinkSpeed));
                        yield return new WaitForSeconds(MorseSettings.DashBlinkSpeed + MorseSettings.IntraLetterBlinkSpeed);
                    }
                }
                yield return new WaitForSeconds(MorseSettings.InterLetterBlinkSpeed);
            }
            
        }
        private IEnumerator Blink(float value)
        {
            BlinkTarget.color = MorseSettings.BlinkColor;
            yield return new WaitForSeconds(value);
            BlinkTarget.color = Color.white;
        }
        
        #endregion 

    }
}
