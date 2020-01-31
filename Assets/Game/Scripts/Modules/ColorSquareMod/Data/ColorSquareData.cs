using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorPuzzleType
{
    Normal,
    ShipName
}

[System.Serializable]
public struct ColorSquareButtonConf
{
    public Color ButtonColor;
    public Color TargetColor;
}

[System.Serializable]
public class ColorSquaredPuzzleSettings
{
    public ColorPuzzleType Id;
    public ColorSquareButtonConf[] ButtonsConf;
    public int SequenceNbr;
}

[CreateAssetMenu(fileName = "ColorSquareDataSetting", menuName = "Data/ColorSquareDataSetting", order = 1)]
public class ColorSquareData : ScriptableObject
{
    public ColorSquaredPuzzleSettings[] Data;

    public ColorSquaredPuzzleSettings GetSettingById(string id)
    {
        foreach(ColorSquaredPuzzleSettings setting in Data)
        {
            if (setting.Id.ToString().Equals(id))
            {
                return setting;
            }
        }
        return null;
    }

    public Color GetTargetBySource(Color source, ColorSquaredPuzzleSettings setting)
    {
        foreach(ColorSquareButtonConf button in setting.ButtonsConf)
        {
            if(button.ButtonColor == source)
            {
                return button.TargetColor;
            }
        }
        return Color.black;
    }

    public Color GetSourceByTarget(Color target, ColorSquaredPuzzleSettings setting)
    {
        foreach (ColorSquareButtonConf button in setting.ButtonsConf)
        {
            if (button.TargetColor == target)
            {
                return button.ButtonColor;
            }
        }
        return Color.black;
    }
}
