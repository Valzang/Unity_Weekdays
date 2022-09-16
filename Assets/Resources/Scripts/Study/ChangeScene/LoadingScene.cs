using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{

    AsyncOperation async;

    private float delayTime = 0.0f;

    void Start()
    {
        StartCoroutine(LoadingNextScene(GameManager.Instance.nextSceneName));
    }


    IEnumerator LoadingNextScene(string _sceneName)
    {
        // LoadSceneAsync : ������ ��� ���� ������ �ٷ� �ҷ����� ����.
        async = SceneManager.LoadSceneAsync(_sceneName);
        async.allowSceneActivation = false;

        while(async.progress < 0.9f)
        {
            yield return true;
        }
            
        while(async.progress >= 0.9f)
        {
            yield return new WaitForSeconds(0.1f);
            if (delayTime > 2.0f)
                break;
        }

        async.allowSceneActivation = true;        
    }

    private void Update()
    {
        DelayTime();
    }

    void DelayTime()
    {
        delayTime += Time.deltaTime;
    }
}
