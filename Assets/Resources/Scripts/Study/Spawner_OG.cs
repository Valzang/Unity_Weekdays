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


    //IEnumerator�� �ڷ�ƾȭ
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
            // 1.5�� ���� "�� �Լ�"�� �����صΰ� 1.5�� �Ŀ� �ý��ۿ��� �� �Լ��� �ٽ� �θ�
            yield return new WaitForSeconds(1.5f);
        }        
    }*/

    IEnumerator enumerator;

    private void Start()
    {
        // 1�� ���� �� MakeObj�� �߻���Ŵ
        //Invoke("MakeObj", 1.0f);
        // 1�� ���� �� 0.5�� ������ �ݺ� ȣ��
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
