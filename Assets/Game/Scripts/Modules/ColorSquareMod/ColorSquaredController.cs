using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ColorSquaredController : MonoBehaviour
{
    public ColorSquareData ColorButtonSettings;
    public TMPro.TextMeshPro DisplayText;
    private List<VRTK_InteractableObject> _buttonsList;
    private VRTK_InteractableObject _blinkableButton;
    private Color _sourceColor;
    private Color _targetColor;
    private int _sequenceNbr;
    // Start is called before the first frame update
    void Start()
    {
        InitKeyPad();
    }

    #region Init Data
    private void InitKeyPad()
    {
        _buttonsList = new List<VRTK_InteractableObject>();
        VRTK_InteractableObject[] buttons = GetComponentsInChildren<VRTK_InteractableObject>();
        foreach(VRTK_InteractableObject button in buttons)
        {
            button.GetComponentInChildren<Renderer>().material = Instantiate<Material>(button.GetComponentInChildren<Renderer>().material);
            _buttonsList.Add(button);
        }
        InitButtonColor(ColorButtonSettings.GetSettingById("Normal"));
        StartBlink();
        TextUtils.Display(DisplayText, "Thrusters Overloaded");
    }

    private void InitButtonColor(ColorSquaredPuzzleSettings setting)
    {
        for(int i = 0; i < setting.ButtonsConf.Length; i++)
        {
            ColorSquareButtonConf colorSquareButtonConf = setting.ButtonsConf[i];
            _buttonsList[i].GetComponentInChildren<Renderer>().material.color = colorSquareButtonConf.ButtonColor;
        }
    }

    private void StartBlink()
    {
        int blinkable = UnityEngine.Random.Range(0, _buttonsList.Count);
        _blinkableButton = _buttonsList[blinkable];
        _sourceColor = _blinkableButton.GetComponentInChildren<Renderer>().material.color;
        _targetColor = ColorButtonSettings.GetTargetBySource(_sourceColor, ColorButtonSettings.GetSettingById("Normal"));
        iTween.ColorTo(_blinkableButton.gameObject, iTween.Hash("name","blink","color", Color.white, "looptype", iTween.LoopType.pingPong, "time", 0.3f));
    }
    public void OnValidateButton(VRTK_InteractableObject self)
    {
        Color selfCol = self.GetComponentInChildren<Renderer>().material.color;
        Color sourceCol = ColorButtonSettings.GetSourceByTarget(selfCol, ColorButtonSettings.GetSettingById("Normal"));
        if (sourceCol == _sourceColor)
        {

            iTween.StopByName("blink");
            _blinkableButton.GetComponentInChildren<Renderer>().material.color = sourceCol;
            StartBlink();
            if (_sequenceNbr <= ColorButtonSettings.GetSettingById("Normal").SequenceNbr)
            {
                TextUtils.Display(DisplayText, "Next Operation...");
                _sequenceNbr++;
            } else
            {
                LockOperation();
            }

        } else
        {
            TextUtils.Display(DisplayText, "Nyet !");
        }
    }

    private void LockOperation()
    {
        TextUtils.Display(DisplayText, "Thrusters operational.");
        for (int i = 0; i < _buttonsList.Count; i++)
        {
            _buttonsList[i].GetComponentInChildren<Renderer>().material.color = Color.white;
            _buttonsList[i].GetComponent<Collider>().enabled = false;
        }
    }


    #endregion
}
