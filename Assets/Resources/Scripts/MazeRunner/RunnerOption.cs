using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunnerOption : MonoBehaviour
{

    [SerializeField]
    private Slider _slider = null;
    [SerializeField]
    private Image _Mute = null;

    void Start()
    {
        _Mute.enabled = false;
    }
    void Resume()
    {
        Time.timeScale = 1.0f;
        MazeManager.Instance.isTimeStop = false;
        this.gameObject.SetActive(false);
    }

    void ShowMute()
    {
        MazeManager.Instance.volume = _slider.value;
        if (_slider.value == -1.0f)
            _Mute.enabled = true;
        else if (_Mute.enabled == true)
            _Mute.enabled = false;
    }
}
