using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "symbolRow", menuName ="Custom/SymbolObject")]
public class SymbolRow : ScriptableObject
{
    public SymbolColumn[] column;
}
