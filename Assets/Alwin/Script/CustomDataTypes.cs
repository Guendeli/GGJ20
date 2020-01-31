using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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