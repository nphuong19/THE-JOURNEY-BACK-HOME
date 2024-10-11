using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health;
    public float maxHealth=100;

    //100 mau = 1 fill amount

    public void LoseHealth(int value )
    {
        //khi het mau khong the lam gi
        if (health <= 0)
            return;
        // giam luong mau
        health -= value;
        // lam moi fillbar
        fillBar.fillAmount = health / 100;
        //neu luong mau <= 0 thi ng choi se chet
        if (health <= 0)
        {
            FindObjectOfType<player>().Die();
            
        }
    }

    public void GainHealth(int value)
    {
        // tang luong mau neu chua max
        if (health < maxHealth)
        {
            health += value;
            // dam bao mau k vuot qua luong mau max
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            // cap nhat thanh mau
            fillBar.fillAmount = health / 100f;
        }
    }
    private void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.R))
            LoseHealth(25);*/
    }
}
