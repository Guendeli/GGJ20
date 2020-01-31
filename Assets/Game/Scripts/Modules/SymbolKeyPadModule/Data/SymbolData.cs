using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [System.Serializable]
    public class SymbolButton
    {
        public Sprite image;
        public int id;
    }

    [System.Serializable]
    public class SymbolColumn
    {
        public SymbolButton[] symbols;
    }

    [CreateAssetMenu(fileName = "SymbolDataSetting", menuName = "Data/SymbolDataSetting")]
    public class SymbolData : ScriptableObject
    {
        public SymbolColumn[] column;
    }


}
