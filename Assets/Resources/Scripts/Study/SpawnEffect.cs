using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material mtrlOrg;
    [SerializeField] private Material mtrlDissolve;
    [SerializeField] private Material mtrlPhase;
    [SerializeField] private float fadeTime = 2f;

    private bool complete = false;
    private float finalValue;

    void Start()
    {
        if(Random.Range(0,100) < 50)
        {
            _renderer.material = mtrlDissolve;
            finalValue = 1.5f;
            DoFade(0, finalValue, fadeTime);
            // fade

        }
        else 
        {
            _renderer.material = mtrlPhase;
            finalValue = 2.3f;
            DoFade(0, finalValue, fadeTime);
            // fade
        }
    }

    // Value가 dest가 될 때까지 time초에 걸쳐서 실행
    void DoFade(float start, float dest, float time)
    {
        iTween.ValueTo(gameObject, iTween.Hash("from", start, "to", dest, "time", time, "onupdatetarget", gameObject, 
            "onupdate", "TweenOnUpdate", "oncomplete","TweenOnComplete",
            "easetype", iTween.EaseType.easeInOutCubic));
    }

    void TweenOnUpdate(float value)
    {
        _renderer.material.SetFloat("_SplitValue", value);
    }

    void TweenOnComplete()
    {
        if (!complete)
        {
            DoFade(finalValue, 0, fadeTime);
            complete = true;
        }
        else
        {
            DoFade(0, finalValue, fadeTime);
            complete = false;
        }
        //_renderer.material = mtrlOrg;
    }
}
