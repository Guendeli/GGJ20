using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRandomSymbol : MonoBehaviour
{
    public SymbolRow symbolSet;
    public List<SymbolButton> selectedSymbols = new List<SymbolButton>();
    public int returnSize;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) 
        {
            StartCoroutine(RandomSelect());
        }
    }

    IEnumerator RandomSelect() 
    {
        selectedSymbols.Clear();
        int maxim = 0;
        while (selectedSymbols.Count < returnSize) 
        {
            maxim++;
            int rowID = Random.Range(0, symbolSet.column.Length);
            int columnID = Random.Range(0, symbolSet.column[rowID].symbols.Length);
            Debug.Log(rowID + " - " + columnID);

            if (!selectedSymbols.Contains(symbolSet.column[rowID].symbols[columnID])) 
            {
                selectedSymbols.Add(symbolSet.column[rowID].symbols[columnID]);
            }
            yield return new WaitForEndOfFrame();
        }

     //   DisplaySelectedSymbols();
    }

    void DisplaySelectedSymbols() 
    {
        string displayText = "";

        for (int i = 0; i < selectedSymbols.Count; i++)
        {
            displayText += selectedSymbols[i].id.ToString() + "-";
        }

        Debug.Log(displayText);
    }

}
