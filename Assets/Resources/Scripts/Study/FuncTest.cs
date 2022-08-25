using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncTest : MonoBehaviour
{
    // Awake�� Start���� ���� ���۵�.
    private void Awake()
    {
        print("Awake~~");

    }

    // ������Ʈ�� Ȱ��ȭ�Ǿ� ���� ��
    private void OnEnable()
    {
        print("OnEnable");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Move Start");
    }

    // Update is called once per frame
    void Update()
    {
        print("Update~~");
    }

    // Update���� �̵� ���� �۾����� �� �����ٸ�,
    // �� ���� ���� �������� LateUpdate���� �ٲ���. ( �ַ� ī�޶� ���⼭ ����ϱ⵵ �� )
    private void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }

    // ������ �ð����� Update�ϱ� ���� �Լ�
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }


    // ������Ʈ�� ��Ȱ��ȭ �� ��
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }


    // ī�޶󿡰� ������ ���� ���� ����
    private void OnBecameInvisible()
    {
        Debug.Log("OnBecameInvisible");
    }

    private void OnBecameVisible()
    {
        Debug.Log("OnBecameVisible");
    }
}
