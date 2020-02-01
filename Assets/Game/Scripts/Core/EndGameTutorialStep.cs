using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTutorialStep : FTUEStep
{
    public TMPro.TextMeshProUGUI SucessDisplay;
    public TMPro.TextMeshProUGUI FailDisplay;

    private CanvasGroup _canvasGroup;
    public override IEnumerator OnExecute()
    {
        switch (GameManager.Instance.GetStatus())
        {
            case GameStatus.Dead:
                FailDisplay.enabled = true;
                break;
            case GameStatus.Success:
                SucessDisplay.enabled = true;
                break;
        }

        Hashtable hash = iTween.Hash("from", 0, "to", 1, "time", 1.0f, "onupdate", "Fade");
        iTween.ValueTo(gameObject, hash);
        yield return new WaitForSeconds(1.0f);
        OnStepExit();

    }

    public override void OnStepExit()
    {
        base.OnStepExit();
    }

    public override void OnStepStart()
    {
        base.OnStepStart();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Fade(float newValue)
    {
        _canvasGroup.alpha = newValue;
    }
}
