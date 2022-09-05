using UnityEngine;
using UnityEngine.UI;

public class Item_Parent : MonoBehaviour
{
    [SerializeField]
    private int Price = 0;

    private void Start()
    {
        if (ShootingGameManager.Instance.Player_Money < (uint)Price)
            this.gameObject.GetComponent<Button>().interactable = false;
    }

    void Back()
    {
        Time.timeScale = 1.0f;
        ShootingGameManager.Instance.isTimeStop = false;

        GameObject Parent = this.gameObject.transform.parent.gameObject;
        Destroy(Parent);
    }

    void onClick_Healing()
    {
                
        if (ShootingGameManager.Instance.Player_HP >= 70)
            ShootingGameManager.Instance.Player_HP = 100;
        else
            ShootingGameManager.Instance.Player_HP += 30;
        ShootingGameManager.Instance.HPBar.fillAmount = (float)(ShootingGameManager.Instance.Player_HP / 100.0f);
        ShootingGameManager.Instance.Player_Money -= (uint)Price;
        Back();
    }
    void onClick_DoubleMoney()
    {
        if (ShootingGameManager.Instance.Getting_Money == 100)
        {
            ShootingGameManager.Instance.Getting_Money = 200;
            ShootingGameManager.Instance.Player_Money -= 1500;
        }
        Back();
    }
    void onClick_PlayerSpeedUp()
    {
        ShootingGameManager.Instance.Player_SpeedRatio += 0.1f;
        print("ÀÌÀü ¼Óµµ : " + (ShootingGameManager.Instance.Player_SpeedRatio - 0.1f).ToString() + "/ ÇöÀç ¼Óµµ : " + ShootingGameManager.Instance.Player_SpeedRatio);
        ShootingGameManager.Instance.Player_Money -= 1000;
        Back();
    }
    void onClick_FireballSpeedUp()
    {
        ShootingGameManager.Instance.Fireball_time *= 0.8f;
        print("ÀÌÀü ÄðÅ½ : " + (ShootingGameManager.Instance.Fireball_time / 0.8f).ToString() + "/ ÇöÀç ÄðÅ½ : " + ShootingGameManager.Instance.Fireball_time);
        ShootingGameManager.Instance.Player_Money -= 2000;
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

    void onClick_SelfHeal()
    {
        ShootingGameManager.Instance.selfHeal += 0.002;
        Back();
    }
}
