using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [System.Serializable]
    public struct WordlistWave
    {
        public string Word;
        public int Value;
    }
    [CreateAssetMenu(fileName = "MorseDataSetting", menuName = "Data/MorseDataSetting", order = 1)]
    public class MorseData : ScriptableObject
    {
        public WordlistWave[] Wordlist;
        public float DotBlinkSpeed;
        public float DashBlinkSpeed;
        public float InterLetterBlinkSpeed;
        public float IntraLetterBlinkSpeed;
        public Color BlinkColor;

    }
}
