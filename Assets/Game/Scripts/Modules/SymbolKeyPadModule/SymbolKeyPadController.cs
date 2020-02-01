using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

namespace Game
{
    public class SymbolKeyPadController : MonoBehaviour
    {
        public SymbolData SymbolSettings;
        public TMPro.TextMeshPro DisplayText;
        public int ButtonAmount;

        private List<VRTK_InteractableObject> _buttonsList;

        private SymbolColumn _targetColumn; // Used for final comparison
        private List<SymbolButton> _returnData;
        private int _lastValid = -1;
        private int _success = 0;
        // Start is called before the first frame update
        void Start()
        {
            _returnData = new List<SymbolButton>();
            StartCoroutine(InitData(ButtonAmount));
            TextUtils.Display(DisplayText, "Warpdrive depleted !");
        }

        // Update is called once per frame

        #region Init
        private IEnumerator InitData(int value)
        {
            _buttonsList = new List<VRTK_InteractableObject>();
            VRTK_InteractableObject[] buttons = GetComponentsInChildren<VRTK_InteractableObject>();
            foreach (VRTK_InteractableObject button in buttons)
            {
                _buttonsList.Add(button);
            }

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
            RenderSymbolData();
        }

        private void RenderSymbolData()
        {
            for(int i = 0; i < _buttonsList.Count; i++)
            {
                SpriteRenderer spr = _buttonsList[i].GetComponentInChildren<SpriteRenderer>();
                if(spr != null)
                {
                    spr.sprite = _returnData[i].Image;
                }
            }
        }

        public void ValidateData(VRTK_InteractableObject self)
        {
            string imageName = self.GetComponentInChildren<SpriteRenderer>().sprite.name;
            int id = _targetColumn.GetIdByImageName(imageName);
            if (id <= _lastValid)
            {
                _lastValid = -1;
                _success = 0;
                TextUtils.Display(DisplayText, "Critical ! Warpdrive jammed");

            }
            else
            {
                _lastValid = id;
                _success++;
                TextUtils.Display(DisplayText, "Injecting Repair Payload " + _success);
            }

            if(_success >= _buttonsList.Count)
            {
                LockOperation();
            }
        }

        private void LockOperation()
        {
            TextUtils.Display(DisplayText, "Warp Drive Repaired");
            for (int i = 0; i < _buttonsList.Count; i++)
            {
                _buttonsList[i].GetComponent<Collider>().enabled = false;
            }
            GameManager.Instance.ValidateStep();
        }

        #endregion 
    }
}
