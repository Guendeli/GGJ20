using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "MorseDataSetting", menuName = "Data/MorseDataSetting", order = 1)]
    public class MorseData : ScriptableObject
    {
        public string[] Wordlist;
        public float DotBlinkSpeed;
        public float DashBlinkSpeed;
        public float InterLetterBlinkSpeed;
        public float IntraLetterBlinkSpeed;
        public Color BlinkColor;

    }
}
