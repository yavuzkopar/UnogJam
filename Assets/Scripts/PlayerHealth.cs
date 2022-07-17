using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    float maxHealth = 100;
    public Slider healthSlider;
    public Animator animator;
    private void Update()
    {
        healthSlider.value = health;
    }
    int a;
    public void getDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            animator.SetTrigger("die");
            if(gameObject.tag != "Player")
            {
                GetComponent<EnemyAI>().enabled = false;
                GameManager.Instance.BasariliGun();
            }
            else
            {
                GameManager.Instance.Fail();
            }
      
        }
    }
}
