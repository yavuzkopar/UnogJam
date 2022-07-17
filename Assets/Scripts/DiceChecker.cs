using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceChecker : MonoBehaviour
{
    public int deger;
    Vector3 veloc;
    static int a = 0;
    PlayerActions playerActions;

    private void Start()
    {
        playerActions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerActions>();
    }
    void FixedUpdate()
    {
        veloc = Dice.diceVelocity;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (veloc == Vector3.zero)
            {
                a++;
                if (a ==1)
                {
                    GameManager.Instance.zarSonucu = deger + GameManager.Instance.zarBonusu;
                    GameManager.Instance.zarText.text = GameManager.Instance.zarSonucu.ToString();
                    GameManager.Instance.kalanBonus -= GameManager.Instance.zarBonusu;
                    GameManager.Instance.zarBonusu = 0;
                    GameManager.Instance.bonusText.text = GameManager.Instance.zarBonusu.ToString();
                    Invoke("Bitir", 2);
                }
               
            }
        }
    } 
    void Bitir()
    {
        transform.parent.gameObject.SetActive(false);
        a = 0;
    }
}
