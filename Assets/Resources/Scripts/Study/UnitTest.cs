using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitTest : MonoBehaviour
{
    UnityEvent myEvent;

    // 함수 포인터
    delegate int Calc(int n1, int n2);
    Calc delegateCalc = null;

    delegate void FuncHandler();
    FuncHandler funcHandler;

    void Func1()
    {
        Debug.Log("Func 1");
    }
    void Func2()
    {
        Debug.Log("Func 2");
    }
    void Func3()
    {
        Debug.Log("Func 3");
    }

    int AddNum(int n1, int n2)
    {
        return n1 + n2;
    }
    int SubNum(int n1, int n2)
    {
        return n1 - n2;
    }
    int MulNum(int n1, int n2)
    {
        return n1 * n2;
    }
    int DivNum(int n1, int n2)
    {
        return n1 / n2;
    }

    private void Start()
    {
        if (myEvent == null)
            myEvent = new UnityEvent();

        myEvent.AddListener(Event1);
        myEvent.AddListener(Event2);
        myEvent.AddListener(Event3);

        delegateCalc = new Calc(AddNum);
        Debug.Log(delegateCalc(11, 33));
        delegateCalc = new Calc(SubNum);
        Debug.Log(delegateCalc(11, 33));

        funcHandler = new FuncHandler(Func1);
        funcHandler += new FuncHandler(Func2);
        funcHandler += new FuncHandler(Func3);
        funcHandler();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            myEvent.Invoke();
        }
    }

    void Event1()
    {
        Debug.Log("Event 1 !");
    }
    void Event2()
    {
        Debug.Log("Event 2 !");
    }
    void Event3()
    {
        Debug.Log("Event 3 !");
    }
}
