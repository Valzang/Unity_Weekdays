using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacleObj = null;

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

    private void Start()
    {
        // 1�� ���� �� MakeObj�� �߻���Ŵ
        //Invoke("MakeObj", 1.0f);
        // 1�� ���� �� 0.5�� ������ �ݺ� ȣ��
        InvokeRepeating(nameof(MakeObj), 1.0f, 1.2f);
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
}
