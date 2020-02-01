using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoundowTutorialStep : FTUEStep
{

    public float GameTime;
    public TMPro.TextMeshProUGUI Display;
    private CanvasGroup _canvasGroup;

    public override IEnumerator OnExecute()
    {
        Hashtable hash = iTween.Hash("from", 0, "to", 1, "time", 1.0f, "onupdate", "Fade");
        iTween.ValueTo(gameObject, hash);
        while(GameTime >= 0 && GameManager.Instance.GetStatus() == GameStatus.None)
        {
            GameTime -= Time.deltaTime;
            System.TimeSpan timespan = System.TimeSpan.FromSeconds(GameTime);
            int minutes = timespan.Minutes;
            int seconds = timespan.Seconds;
            int milli = timespan.Milliseconds;
            string s = "{0} : {1} : {2}";
            Display.SetText(string.Format(s, minutes, seconds, milli));
            yield return new WaitForEndOfFrame();
        }
        if (GameTime <= 0)
        {
            GameManager.Instance.SetDead();
        }
        hash = iTween.Hash("from", 1, "to", 0, "time", 1.0f, "onupdate", "Fade");
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
