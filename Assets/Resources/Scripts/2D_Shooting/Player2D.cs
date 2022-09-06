using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class Player2D : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField]
    private Object ItemUI = null;
    [SerializeField]
    private float maxSpeed = 250.0f;
    [SerializeField]
    private GameObject Fireball = null;
    [SerializeField]
    private Image HPBar;
    [SerializeField]
    private GameObject DamageSound = null;


    private float curSpeed = 0.0f;
    private float Fireball_Cooltime = 1.0f;
    private float DoubleMoney_Time = 0.0f;

    
    void Start()
    {
        curSpeed = maxSpeed;
        rigidBody = GetComponent<Rigidbody2D>();
        ShootingGameManager.Instance.ItemUI = ItemUI;
        ShootingGameManager.Instance.HPBar = HPBar;
    }

    
    void Update()
    {
        if(ShootingGameManager.Instance.Player_HP<100.0f)
        { 
            ShootingGameManager.Instance.Player_HP += ShootingGameManager.Instance.selfHeal;
            if (ShootingGameManager.Instance.Player_HP > 100.0f)
                ShootingGameManager.Instance.Player_HP = 100.0f;
            HPBar.fillAmount = (float)(ShootingGameManager.Instance.Player_HP / 100.0f);
        }
        if (ShootingGameManager.Instance.Getting_Money != 100)
        {
            DoubleMoney_Time += Time.deltaTime;
            if (DoubleMoney_Time > 60.0f)
            { 
                DoubleMoney_Time = 0.0f;
                ShootingGameManager.Instance.Getting_Money = 100;
            }
        }
            
        Attack();
        ShootingGameManager.Instance.PlayTime += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        curSpeed = maxSpeed * ShootingGameManager.Instance.Player_SpeedRatio;
        if(ShootingGameManager.Instance.Player_Life)
            HPBar.color = new Color(0, 242, 255, 255);
        else if(HPBar.color != new Color(77,255,0, 255))
            HPBar.color = new Color(77, 255, 0, 255);
        Move_2D();
    }

    void Move_2D()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 position = rigidBody.transform.position;
        if ((position.x > -426.0f && x < 0)
            || position.x < 417.0f && x > 0)
            position.x += (x * curSpeed * Time.deltaTime);

        if ((position.y < 150.0f && y > 0)
            || (position.y > -225.0f && y < 0))
            position.y += (y * curSpeed * Time.deltaTime);

        rigidBody.MovePosition(position);
    }

    void Attack()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Fireball_Cooltime >= ShootingGameManager.Instance.Fireball_time)
        {
            Vector3 curPos = transform.position;
            curPos.x += 80;
            curPos.y -= 10;
            Instantiate(Fireball, curPos, transform.rotation);
            Fireball_Cooltime = 0.0f;
        }
        Fireball_Cooltime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "Item":
                ShootingGameManager.Instance.Player_Money += ShootingGameManager.Instance.Getting_Money;
                break;
            case "Enemy":
                GetDamage(25);
                break;
            case "Obstacle":
                print(collision.gameObject.name);
                if (collision.gameObject.name == "DeathBall(Clone)")
                { 
                    print("데스볼에 맞음 !!!!!!!!!!!!!!!!!!");
                    GetDamage(30);
                }
                else
                    GetDamage(15);                

                Destroy(collision.gameObject);
                break;
        }        
    }

    private void GetDamage(int _Damage)
    {
        DamageSound.GetComponent<AudioSource>().Play();
        ShootingGameManager.Instance.Player_HP -= _Damage;
        print(ShootingGameManager.Instance.Player_HP);
        HPBar.fillAmount = (float)(ShootingGameManager.Instance.Player_HP / 100.0f);
        StartCoroutine(Flick());
        if (ShootingGameManager.Instance.Player_HP <= 0)
        { 
            if(ShootingGameManager.Instance.Player_Life == true)
            {
                ShootingGameManager.Instance.Player_Life = false;
                ShootingGameManager.Instance.Player_HP = 100;
            }
            else
                ShootingGameManager.Instance.ChangeScene("2D_Score");
        }
    }

    public IEnumerator Flick()
    {
        int count = 0;

        while (count < 3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            count++;
        }
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print("col : 적과 부딪혔어 !");
    //}
}
