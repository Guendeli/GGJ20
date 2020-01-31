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
}
