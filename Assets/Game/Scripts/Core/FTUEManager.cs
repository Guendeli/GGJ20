using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTUEManager : MonoBehaviour
{
    public static FTUEManager Instance;
    public List<FTUEStep> _steps;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitSteps();
        StartCoroutine(Execute());
    }

    private void InitSteps()
    {

    }

    public IEnumerator Execute()
    {
        foreach (FTUEStep step in _steps)
        {
            step.OnStepStart();
            StartCoroutine(step.OnExecute());
            while (!step.IsFinished)
            {
                yield return new WaitForEndOfFrame();
            }
        }    
    }
}