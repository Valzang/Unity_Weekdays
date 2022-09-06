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
    public GameObject Item_SelfHeal;
    public GameObject Item_Fireball_Pierce;
    public GameObject Item_FireballBigger;

    enum Item_List
    {
        Healing = 0,
        DoubleMoney = 1,
        PlayerSpeedUp = 2,
        FireballSpeedUp = 3,
        Fireball_Increase = 4,
        PlayerLife_Increase = 5,
        SelfHeal = 6,
        FireballBigger = 7,
        Fireball_Pierce = 8,
        End = 9
    }
    void Start()
    {
        RandomItem = new List<int>();
        ShootingGameManager.Instance.isTimeStop = true;
        Time.timeScale = 0.0f;

        int random_value = Random.Range(0, (int)Item_List.Fireball_Pierce);
        int Pierce_Prob = Random.Range(0, 100);
        RandomItem.Add(random_value);

        for (int i=1 ; i<3 ; ++i)
        {
            while (RandomItem.Contains(random_value))
            {
                random_value = Random.Range(0, (int)Item_List.Fireball_Pierce);
            }
            RandomItem.Add(random_value);            
        }

        if (Pierce_Prob < 10 && ShootingGameManager.Instance.Fireball_Pierce == false)
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
                case (int)Item_List.SelfHeal:
                    Instantiate(Item_SelfHeal, curPos, transform.rotation, this.gameObject.transform);
                    break;
                case (int)Item_List.Fireball_Pierce:
                    Instantiate(Item_Fireball_Pierce, curPos, transform.rotation, this.gameObject.transform);
                    break;
                case (int)Item_List.FireballBigger:
                    Instantiate(Item_FireballBigger, curPos, transform.rotation, this.gameObject.transform);
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
}
