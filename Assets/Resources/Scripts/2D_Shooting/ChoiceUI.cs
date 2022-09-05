using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceUI : MonoBehaviour
{
    private List<int> RandomItem;
    public GameObject Item_Healing;
    public GameObject Item_DoubleMoney;
    public GameObject Item_PlayerSpeedUp;
    public GameObject Item_FireballSpeedUp;
    public GameObject Item_Fireball_Increase;
    public GameObject Item_PlayerLife_Increase;
    public GameObject Item_Fireball_Pierce;

    // Start is called before the first frame update

    enum Item_List
    {
        Healing = 0,
        DoubleMoney = 1,
        PlayerSpeedUp = 2,
        FireballSpeedUp = 3,
        Fireball_Increase = 4,
        PlayerLife_Increase = 5,
        Fireball_Pierce = 6
    }
    void Start()
    {
        RandomItem = new List<int>();
        ShootingGameManager.Instance.isTimeStop = true;
        Time.timeScale = 0.0f;

        int random_value = Random.Range(0, 6);
        int Pierce_Prob = Random.Range(0, 100);
        RandomItem.Add(random_value);

        for (int i=1 ; i<3 ; ++i)
        {
            while (RandomItem.Contains(random_value))
            {
                random_value = Random.Range(0, 6);
            }
            RandomItem.Add(random_value);            
        }

        if (Pierce_Prob < 10)
        {
            RandomItem.RemoveAt(2);
            RandomItem.Add((int)Item_List.Fireball_Pierce);
        }

        SetItem();

    }

    void SetItem()
    {
        Image BackGround = this.gameObject.GetComponentInChildren<Image>();
        for (int i=0 ; i<3 ; ++i)
        {
            Vector3 curPos = BackGround.transform.position;
            if (i == 0)
                curPos.x -= 180.0f;
            else if (i == 2)
                curPos.x += 180.0f;
            curPos.y += 94;

            //print(i + "¹øÂ° : " + curPos.x);

            switch(RandomItem[i])
            {
                case (int)Item_List.Healing:
                    Instantiate(Item_Healing, curPos, transform.rotation, this.gameObject.transform);
                    break;
                case (int)Item_List.DoubleMoney:
                    Instantiate(Item_DoubleMoney, curPos, transform.rotation, this.gameObject.transform);
                    break;
                case (int)Item_List.PlayerSpeedUp:
                    Instantiate(Item_PlayerSpeedUp, curPos, transform.rotation, this.gameObject.transform);
                    break;
                case (int)Item_List.FireballSpeedUp:
                    Instantiate(Item_FireballSpeedUp, curPos, transform.rotation, this.gameObject.transform);
                    break;
                case (int)Item_List.Fireball_Increase:
                    Instantiate(Item_Fireball_Increase, curPos, transform.rotation, this.gameObject.transform);
                    break;
                case (int)Item_List.PlayerLife_Increase:
                    Instantiate(Item_PlayerLife_Increase, curPos, transform.rotation, this.gameObject.transform);
                    break;
                case (int)Item_List.Fireball_Pierce:
                    Instantiate(Item_Fireball_Pierce, curPos, transform.rotation, this.gameObject.transform);
                    break;
            }
        }
    }

    void Back()
    {
        Time.timeScale = 1.0f;
        ShootingGameManager.Instance.isTimeStop = false;
        Destroy(this.gameObject);
    }

    void onClick_Healing()
    {
        if (ShootingGameManager.Instance.Player_HP >= 70)
            ShootingGameManager.Instance.Player_HP = 100;
        else
            ShootingGameManager.Instance.Player_HP += 30;

        ShootingGameManager.Instance.Player_Money -= 500;
        Back();
    }
    void onClick_DoubleMoney()
    {
        if(ShootingGameManager.Instance.Getting_Money == 100)
        {
            ShootingGameManager.Instance.Getting_Money = 200;
            ShootingGameManager.Instance.Player_Money -= 500;
        }        
        Back();
    }
    void onClick_PlayerSpeedUp()
    {
        ShootingGameManager.Instance.Player_SpeedRatio += 0.1f;
        ShootingGameManager.Instance.Player_Money -= 500;
        Back();
    }
    void onClick_FireballSpeedUp()
    {
        ShootingGameManager.Instance.Fireball_time *= 0.9f;
        ShootingGameManager.Instance.Player_Money -= 1000;
        Back();
    }
    void onClick_Fireball_Increase()
    {

    }
    void onClick_PlayerLife_Increase()
    {
        ShootingGameManager.Instance.Player_Life = true;
        ShootingGameManager.Instance.Player_Money -= 5000;
        Back();
    }
    void onClick_Fireball_Pierce()
    {
        ShootingGameManager.Instance.Fireball_Pierce = true;
        ShootingGameManager.Instance.Player_Money -= 5000;
        Back();
    }
}
