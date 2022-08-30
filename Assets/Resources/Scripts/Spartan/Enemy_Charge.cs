using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Charge : MonoBehaviour
{
    public GameObject swordCollider = null;

    private float moveSpeed = 4.5f;
    private bool FrontofDefense = false;
    private bool isDead = false;

    Animation enemy_Spartan;
    // Start is called before the first frame update
    void Start()
    {
        enemy_Spartan = gameObject.GetComponentInChildren<Animation>();
        enemy_Spartan.wrapMode = WrapMode.Loop;
        enemy_Spartan.CrossFade("run", 0.3f);
        moveSpeed += (float)SpartanGameManager.Instance.Difficulty * 0.2f;
        print("현재 적 속도 : " + moveSpeed.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy_Spartan.IsPlaying("die") && !isDead)
        {
            isDead = true;
            float delayTime = enemy_Spartan.GetClip("die").length - 0.3f;
            FrontofDefense = true;
            Destroy(this.gameObject, delayTime);
        }
        if (FrontofDefense)
            return;
        Vector3 nextPos = this.transform.position;
        nextPos.z -= moveSpeed * Time.deltaTime;
        this.transform.position = new Vector3(nextPos.x, nextPos.y, nextPos.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!FrontofDefense)
        {
            switch (other.tag)
            {
                case "Obstacle":
                    FrontofDefense = true;
                    print("장애물 만나서 공격 시전");
                    StartCoroutine("BackToRun");
                    Destroy(other.gameObject);
                    break;
                case "Player":
                    FrontofDefense = true;
                    enemy_Spartan.wrapMode = WrapMode.Loop;
                    enemy_Spartan.CrossFade("idle", 0.3f);
                    break;
                case "LINE":
                    print("끝 도달");
                    SpartanGameManager.Instance.ChangeScene("#4_Spartan_Ending");
                    Destroy(this.gameObject);
                    break;
            }
        }        
    }

    IEnumerator BackToRun()
    {
        if (enemy_Spartan.IsPlaying("attack") != true)
        {
            enemy_Spartan.wrapMode = WrapMode.Once;
            enemy_Spartan.CrossFade("attack", 0.3f);

            float delayTime = enemy_Spartan.GetClip("attack").length - 0.3f;

            yield return new WaitForSeconds(delayTime);

            enemy_Spartan.wrapMode = WrapMode.Loop;
            enemy_Spartan.CrossFade("run", 0.3f);
            FrontofDefense = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (FrontofDefense)
        {
            switch (other.tag)
            {                
                case "Player":
                    if(!isDead)
                    {
                        FrontofDefense = false;
                        enemy_Spartan.wrapMode = WrapMode.Loop;
                        enemy_Spartan.CrossFade("run", 0.3f);
                    }                    
                    break;
            }
        }
    }
}
