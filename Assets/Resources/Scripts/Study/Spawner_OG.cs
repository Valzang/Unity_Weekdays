using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_OG : MonoBehaviour
{
    public GameObject obstacleObj = null;
    private int count = 0;
        
    public void StopInvoke()
    {
        CancelInvoke("MakeObj");
        return;
    }


    //IEnumerator로 코루틴화
    /*IEnumerator Start()
    {
        while(true)
        {
            GameObject obj = null;
            if( obstacleObj != null)
            {
                obj = Instantiate(obstacleObj, transform.position, transform.rotation);
            }

            Destroy(obj, 1.0f);
            // 1.5초 동안 "이 함수"를 정지해두고 1.5초 후에 시스템에서 이 함수를 다시 부름
            yield return new WaitForSeconds(1.5f);
        }        
    }*/

    IEnumerator enumerator;

    private void Start()
    {
        // 1초 지연 후 MakeObj를 발생시킴
        //Invoke("MakeObj", 1.0f);
        // 1초 지연 후 0.5초 단위로 반복 호출
        //InvokeRepeating("MakeObj", 1.0f, 1.2f);

        //enumerator = CountTime(1.0f);
        //StartCoroutine(enumerator);
        StartCoroutine("CountTime",1.0f);
    }

    private void Update()
    {
        //if (count > 10)

    }

    void MakeObj()
    {
        GameObject obj = null;
        if (obstacleObj != null)
        {
            float random = Random.Range(-3.6f, 3.61f);
            Vector3 curPos = transform.position;
            curPos.y += random + 2.5f;
            curPos.z = 18.5f;
            obj = Instantiate(obstacleObj, curPos, transform.rotation);
            //Invoke("MakeObj", 1.0f);
        }
    }


    IEnumerator CountTime(float delayTime)
    {
        // >> Case 1 :
        while(true)
        {

            yield return new WaitForSeconds(delayTime);
            yield return null;

            ++count;
            if (count > 10)
                yield break;
            print(count.ToString());
            yield return new WaitForSeconds(delayTime);
        }

        // >> Case 2 :
        /*
        yield return new WaitForSeconds(delayTime);
        ++count;
        print(count.ToString());
        StartCoroutine("CountTime", 1.0f);
        */

    }
}
