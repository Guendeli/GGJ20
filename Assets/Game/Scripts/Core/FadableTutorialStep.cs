using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadableTutorialStep : FTUEStep
{

    public float FadeTime;
    public float WaitTime;
    private CanvasGroup canvasGroup;

    public override IEnumerator OnExecute()
    {
        Hashtable hash = iTween.Hash("from", 0, "to", 1, "time", FadeTime, "onupdate", "Fade");
        iTween.ValueTo(gameObject, hash);
        yield return new WaitForSeconds(WaitTime);
        hash = iTween.Hash("from", 1, "to", 0, "time", FadeTime, "onupdate", "Fade");
        iTween.ValueTo(gameObject, hash);
        yield return new WaitForSeconds(WaitTime);
        OnStepExit();
    }

    public override void OnStepExit()
    {
        base.OnStepExit();
    }

    public override void OnStepStart()
    {
        base.OnStepStart();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    #region Helper MEthods
    public void Fade(float newValue)
    {
        canvasGroup.alpha = newValue;
    }


    #endregion 
}
