using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource curAudioSource = null;

    private float default_volume = 0.0f;

    void Start()
    {
        curAudioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        curAudioSource.volume = ShootingGameManager.Instance.volume / 2.0f + 0.5f;            
    }
}
