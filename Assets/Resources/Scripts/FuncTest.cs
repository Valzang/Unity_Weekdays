using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncTest : MonoBehaviour
{
    // Awake가 Start보다 먼저 시작됨.
    private void Awake()
    {
        print("Awake~~");

    }

    // 컴포넌트가 활성화되어 있을 때
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

    // Update에서 이동 관련 작업들이 다 끝났다면,
    // 그 끝난 상태 기준으로 LateUpdate에서 바꿔줌. ( 주로 카메라를 여기서 담당하기도 함 )
    private void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }

    // 일정한 시간으로 Update하기 위한 함수
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }


    // 컴포넌트가 비활성화 될 때
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }


    // 카메라에게 보이지 않을 때의 상태
    private void OnBecameInvisible()
    {
        Debug.Log("OnBecameInvisible");
    }

    private void OnBecameVisible()
    {
        Debug.Log("OnBecameVisible");
    }
}
