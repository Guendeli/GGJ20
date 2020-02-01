using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoundTutorialStep : FTUEStep
{
    public float FadeTime;
    public float WaitTime;
    private CanvasGroup canvasGroup;

    public override IEnumerator OnExecute()
    {
        Hashtable hash = iTween.Hash("from", 0, "to", 1, "time", FadeTime, "onupdate", "Fade");
        iTween.ValueTo(gameObject, hash);

        while (!(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || Input.GetKeyDown(KeyCode.Space)))
        {
            yield return new WaitForEndOfFrame();
        }

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

    public void Fade(float newValue)
    {
        canvasGroup.alpha = newValue;
    }
}
