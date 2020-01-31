using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;

namespace Game
{
    public class MorseModuleController : MonoBehaviour
    {
        public MorseData MorseSettings;
        public SpriteRenderer BlinkTarget;
        public VRTK_BaseControllable Slider;
        public TMPro.TextMeshPro DisplayText;
        public string TextToMorse;
        
        private MorseToStringUtil _morseTranslator;
        private AudioSource _beepSource;
        private int _targetValue;

        private void Start()
        {
            _morseTranslator = new MorseToStringUtil();
            _beepSource = BlinkTarget.GetComponent<AudioSource>();
            Slider = (Slider == null ? GetComponentInChildren<VRTK_BaseControllable>() : Slider);
            Slider.ValueChanged += SliderToDisplayEvent;
            int rnd = UnityEngine.Random.Range(0, MorseSettings.Wordlist.Length);
            TextToMorse = MorseSettings.Wordlist[rnd].Word;
            _targetValue = MorseSettings.Wordlist[rnd].Value;
            StartCoroutine(ProcessLetter(TextToMorse));


        }

        private void SliderToDisplayEvent(object sender, ControllableEventArgs e)
        {
            DisplayText.text = e.value.ToString() + "Hz";
        }


        #region Public Methods
        public void OnValidate()
        {
            if ((int)Slider.GetValue() == _targetValue)
            {
                Debug.Log("GOOD");
            }
            else
            {
                Debug.Log("BAAD");
            }
        }
        #endregion 
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
            StartCoroutine(ProcessLetter(TextToMorse));

        }
        private IEnumerator Blink(float value)
        {
            Beep(_beepSource, true);
            BlinkTarget.color = MorseSettings.BlinkColor;
            yield return new WaitForSeconds(value);
            BlinkTarget.color = Color.white;
            Beep(_beepSource, false);
        }

        private void Beep(AudioSource target,bool value)
        {
            target.enabled = value;
        }
        
        #endregion 

    }
}
