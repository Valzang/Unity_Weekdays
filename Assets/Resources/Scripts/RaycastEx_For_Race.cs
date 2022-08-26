using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastEx_For_Race : MonoBehaviour
{
    [Range(0, 100)]
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
        ray = new Ray(this.transform.position, this.transform.forward);
        Ray_1();
        //Ray_2();
        //Ray_2();
    }

    // ������ ���� ���� ��ü üũ
    void Ray_1()
    {
        Physics.Raycast(ray, out rayHit, distance);
        //if (Physics.Raycast(ray, out rayHit, distance))
        //{
        //    //if (rayHit.collider.gameObject.tag == "Obstacle")
        //    //    Debug.Log(this.name + "�� ������ " + rayHit.collider.gameObject.name + " " + rayHit.distance + " �Ÿ����� �浹");            
        //}
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
        //Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        // ����
        Gizmos.color = new Color32(255, 255, 0, 255);
        Gizmos.DrawSphere(ray.origin, 0.1f);

        // �浹 ����
        //Gizmos.color = new Color32(255, 255, 0, 255);
        //Gizmos.DrawWireSphere(ray.origin, distance);


        Gizmos.color = Color.red;
        Gizmos.DrawSphere(rayHit.point, 0.1f);

        // �浹�� ����Ʈ����
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position,
            transform.position + transform.forward * rayHit.distance);

        // Normal
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(rayHit.point, rayHit.point + rayHit.normal);

        // Reflect
        Gizmos.color = Color.white;
        Vector3 reflect = Vector3.Reflect(this.transform.forward, rayHit.normal);
        Gizmos.DrawLine(rayHit.point, rayHit.point + reflect);

    }
}
