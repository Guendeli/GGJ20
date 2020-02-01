using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FTUEStep : MonoBehaviour
{
    public bool IsFinished;

    #region Implementation
    public virtual void OnStepStart()
    {
        IsFinished = false;
    }

    public virtual IEnumerator OnExecute()
    {
        yield return null;
    }


    public virtual void OnStepExit()
    {
        IsFinished = true;
    }

    #endregion 
}
