using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastEx : MonoBehaviour
{
    [Range(0, 50)]
    public float distance = 10.0f;
    private RaycastHit rayHit;
    private RaycastHit[] rayHits;
    private Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray(this.transform.position, this.transform.forward);
        //ray.origin = this.transform.position;
        //ray.direction = this.transform.forward;
        //ray = new Ray(ray.origin, ray.direction);
    }

    // Update is called once per frame
    void Update()
    {
        //Ray_1();
        //Ray_2();
        Ray_2();
    }

    // ������ ���� ���� ��ü üũ
    void Ray_1()
    {
        if(Physics.Raycast(ray, out rayHit, distance))
        {
            Debug.Log(rayHit.collider.gameObject.name + " " + rayHit.distance);            
        }
    }

    // ������ ����ִ� ���� ��ü üũ
    void Ray_2()
    {
        rayHits = Physics.RaycastAll(ray, distance);

        for (int index = 0; index < rayHits.Length; ++index)
        {
            Debug.Log(rayHits[index].collider.gameObject.name + " hit !!");
        }

        //rayHits = Physics.SphereCastAll(ray, 0.0f, distance);
        //string objName = "";
        //if(rayHits.Length != 0)
        //{
        //    foreach (RaycastHit hit in rayHits)
        //    {
        //        objName += hit.collider.name + " , ";
        //    }
        //    print(objName);
        //}
        
    }

    // �±׿� ���̾�� ���� ����
    void Ray_3()
    {
        rayHits = Physics.RaycastAll(ray, distance);

        for (int index = 0; index < rayHits.Length; ++index)
        {
            if(rayHits[index].collider.gameObject.tag == "Obstacle")
                Debug.Log(rayHits[index].collider.gameObject.name + " hit - Tag !!");

            if (rayHits[index].collider.gameObject.layer == LayerMask.NameToLayer("Second"))
                Debug.Log(rayHits[index].collider.gameObject.name + " hit - Layer !!");
        }
    }

    // ���� ���� �׷��ֱ�
    private void OnDrawGizmos()
    {
        OnDrawGizmos_2();
    }

    void OnDrawGizmos_1()
    {
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        // ����
        Gizmos.color = new Color32(255, 255, 0, 255);
        Gizmos.DrawSphere(ray.origin, 0.1f);

        // �浹�� ����Ʈ ��ġ
        Gizmos.color = new Color32(255, 255, 0, 255);
        Gizmos.DrawWireSphere(ray.origin, distance);        
    }

    void OnDrawGizmos_2()
    {
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        // ����
        Gizmos.color = new Color32(255, 255, 0, 255);
        Gizmos.DrawSphere(ray.origin, 0.1f);

        if (rayHits != null)
        {
            for (int i=0; i< rayHits.Length; ++i)
            {
                if (rayHits[i].collider != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(rayHits[i].point, 0.1f);

                    // �浹�� ����Ʈ����
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawLine(transform.position, 
                        transform.position + transform.forward * rayHits[i].distance);

                    // Normal
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawLine(rayHits[i].point, rayHits[i].point + rayHits[i].normal);

                    // Reflect
                    Gizmos.color = Color.white;
                    Vector3 reflect = Vector3.Reflect(this.transform.forward, rayHits[i].normal);
                    Gizmos.DrawLine(rayHits[i].point, rayHits[i].point + reflect);
                    
                }
            }            
        }
    }
}
