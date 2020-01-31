using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [System.Serializable]
    public class SymbolButton
    {
        public Sprite Image;
        public int Id;
    }

    [System.Serializable]
    public class SymbolColumn
    {
        public SymbolButton[] Symbols;

        public int GetIdByImageName(string image)
        {
            foreach(SymbolButton button in Symbols)
            {
                if (button.Image.name.Equals(image))
                {
                    return button.Id;
                }
            }
            return 666;
        }
    }

    [CreateAssetMenu(fileName = "SymbolDataSetting", menuName = "Data/SymbolDataSetting")]
    public class SymbolData : ScriptableObject
    {
        public SymbolColumn[] Column;
    }


}
