using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    float maxHealth = 100;
    public Slider healthSlider;
    private void Update()
    {
        healthSlider.value = health;
        if (Input.GetKeyDown(KeyCode.H))
        {
            getDamage(20);
        }
        if (health >= 100)
        {
            health = 100;
        }
    }
    public void getDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Debug.Log("öldün");
        }
    }
}
