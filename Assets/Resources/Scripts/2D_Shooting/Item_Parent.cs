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

    private void FixedUpdate()
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
        this.gameObject.GetComponent<Button>().interactable = false; 
    }
    void onClick_DoubleMoney()
    {
        if (ShootingGameManager.Instance.Getting_Money == 100)
        {
            ShootingGameManager.Instance.Getting_Money = 200;
            ShootingGameManager.Instance.Player_Money -= (uint)Price;
        }
        this.gameObject.GetComponent<Button>().interactable = false;
    }
    void onClick_PlayerSpeedUp()
    {
        ShootingGameManager.Instance.Player_SpeedRatio += 0.1f;
        print("���� �ӵ� : " + (ShootingGameManager.Instance.Player_SpeedRatio - 0.1f).ToString() + "/ ���� �ӵ� : " + ShootingGameManager.Instance.Player_SpeedRatio);
        ShootingGameManager.Instance.Player_Money -= (uint)Price;
        this.gameObject.GetComponent<Button>().interactable = false;
    }
    void onClick_FireballSpeedUp()
    {
        ShootingGameManager.Instance.Fireball_time *= 0.8f;
        print("���� ��Ž : " + (ShootingGameManager.Instance.Fireball_time / 0.8f).ToString() + "/ ���� ��Ž : " + ShootingGameManager.Instance.Fireball_time);
        ShootingGameManager.Instance.Player_Money -= (uint)Price;
        this.gameObject.GetComponent<Button>().interactable = false;
    }
    void onClick_Fireball_Increase()
    {
    }
    void onClick_PlayerLife_Increase()
    {
        ShootingGameManager.Instance.Player_Life = true;
        ShootingGameManager.Instance.Player_Money -= (uint)Price;
        this.gameObject.GetComponent<Button>().interactable = false;
    }
    void onClick_Fireball_Pierce()
    {
        ShootingGameManager.Instance.Fireball_Pierce = true;
        ShootingGameManager.Instance.Player_Money -= (uint)Price;
        this.gameObject.GetComponent<Button>().interactable = false;
    }

    void onClick_SelfHeal()
    {
        ShootingGameManager.Instance.selfHeal += 0.0005;
        ShootingGameManager.Instance.Player_Money -= (uint)Price;
        this.gameObject.GetComponent<Button>().interactable = false;
    }

    void onClick_FireballBigger()
    {
        ShootingGameManager.Instance.Fireball_size += 0.05f;
        ShootingGameManager.Instance.Player_Money -= (uint)Price;
        this.gameObject.GetComponent<Button>().interactable = false;
    }
}
