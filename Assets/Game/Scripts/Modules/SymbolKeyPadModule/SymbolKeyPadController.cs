using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class SymbolKeyPadController : MonoBehaviour
    {
        public SymbolData SymbolSettings;
        public int ButtonAmount;

        private SymbolColumn _targetColumn; // Used for final comparison
        private List<SymbolButton> _returnData;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(InitData(ButtonAmount));
        }

        // Update is called once per frame

        #region Init
        private IEnumerator InitData(int value)
        {
            _targetColumn = SymbolSettings.Column[Random.Range(0, SymbolSettings.Column.Length)];

            while(_returnData.Count < value)
            {
                SymbolButton symbolButton = _targetColumn.Symbols[Random.Range(0, _targetColumn.Symbols.Length)];

                if (!_returnData.Contains(symbolButton))
                {
                    _returnData.Add(symbolButton);
                }
                yield return new WaitForEndOfFrame();
            }
        }

        private void RenderSymbolData()
        {

        }


        #endregion 
    }
}
