using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject wolfObj = null;
    [SerializeField]
    private GameObject bossObj = null;

    private uint Reduce_Cooltime = 1000;
    private float Cooltime = 2.0f;
    private int BossScore = 5000;

    private void Start()
    {
        InvokeRepeating(nameof(MakeObj), 1.0f, Cooltime);
    }

    private void FixedUpdate()
    {
        if (Cooltime > 1.0f && ShootingGameManager.Instance.Player_Score >= Reduce_Cooltime)
        { 
            Reduce_Cooltime += 1500;
            Cooltime -= 0.06f;
            StopInvoke();
            InvokeRepeating(nameof(MakeObj), 1.75f, Cooltime);
            print("잡몹 소환 쿨타임 : " + Cooltime);
        }

        if(ShootingGameManager.Instance.Player_Score >= BossScore && ShootingGameManager.Instance.Player_Score< BossScore+200
            && ShootingGameManager.Instance.isBoss == false)
        {
            ShootingGameManager.Instance.isBoss = true;
            StopInvoke();
            Vector3 curPos = new(440, 0, 0);
            Instantiate(bossObj, curPos, transform.rotation);
            ++ShootingGameManager.Instance.BossPhase;
            print("현재 보스 단계 : " + ShootingGameManager.Instance.BossPhase);
        }
        if(ShootingGameManager.Instance.isBoss && ShootingGameManager.Instance.Player_Score >= BossScore+2500)
        {
            InvokeRepeating(nameof(MakeObj), 1.75f, Cooltime);
            ShootingGameManager.Instance.isBoss = false;
            BossScore += 6000;
            ShootingGameManager.Instance.Player_Money += 2000;
        }
    }

    public void StopInvoke()
    {
        CancelInvoke(nameof(MakeObj));
        return;
    }

    void MakeObj()
    {
        if (wolfObj != null)
        {
            float random = Random.Range(-185, 91);
            Vector3 curPos = new(440, random, 0);
            Instantiate(wolfObj, curPos, transform.rotation);
        }
    }
}
