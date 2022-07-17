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
    public GameObject endGameCanvas;

    private void Start()
    {
        healthSlider.maxValue = health;
        endGameCanvas.SetActive(false);
    }
    private void Update()
    {
        healthSlider.value = health;
        if (health <= 0 )
        {
            animator.SetBool("die",true);
            if (gameObject.CompareTag("finalBoss"))
            {
                endGameCanvas.SetActive(true);
                return;
            }
            if (gameObject.tag != "Player")
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
    int a;
    public void getDamage(float amount)
    {
        health -= amount;
        
    }
    public void final()
    {
        endGameCanvas.SetActive(true);
    }
}
