using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class Player2D : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float maxSpeed = 250.0f;
    [SerializeField]
    private GameObject Fireball = null;
    [SerializeField]
    private Image HPBar;
    [SerializeField]
    private GameObject DamageSound = null;


    private float HP = 100.0f;


    private float Fireball_Cooltime = 1.0f;

    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {        
        Attack();
        ShootingGameManager.Instance.PlayTime += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Move_2D();
    }

    void Move_2D()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 position = rigidBody.transform.position;
        if ((position.x > -437.0f && x < 0)
            || position.x < 430.0f && x > 0)
            position.x += (x * maxSpeed * Time.deltaTime);

        if ((position.y < 93.0f && y > 0)
            || (position.y > -230.0f && y < 0))
            position.y += (y * maxSpeed * Time.deltaTime);

        //position = new Vector3(position.x + (x * maxSpeed * Time.deltaTime),
        //                        position.y + (y * maxSpeed * Time.deltaTime),
        //                        position.z);

        rigidBody.MovePosition(position);
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) && Fireball_Cooltime >= 1.0f)
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
                ShootingGameManager.Instance.Player_Money += 100;
                print("Á¡¼ö : " + ShootingGameManager.Instance.Player_Money);
                break;
            case "Enemy":
                HP -= 30.0f;
                HPBar.fillAmount = HP / 100.0f;
                StartCoroutine(Flick());
                DamageSound.GetComponent<AudioSource>().Play();
                if (HP <= 0.0f)
                    ShootingGameManager.Instance.ChangeScene("2D_Score");
                break;
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
    //    print("col : Àû°ú ºÎµúÇû¾î !");
    //}
}
