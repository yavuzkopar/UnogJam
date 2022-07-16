using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceChecker : MonoBehaviour
{
    public int deger;
    Vector3 veloc;
    static int a = 0;
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
