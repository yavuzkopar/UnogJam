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
                    switch (playerActions.action)
                    {
                        case Actions.None:
                            break;
                        case Actions.Attack:
                            if (GameManager.Instance.zarSonucu >= 2)
                            {
                                // hasar verme
                                // basarili sonuc
                            }
                            else
                            { 
                                // dusman dodge animasyon
                                //basarisiz
                            }
                            break;
                        case Actions.Spellcast:
                            if (GameManager.Instance.zarSonucu >= 5)
                            {
                                // hasar verme
                                // basarili sonuc
                            }
                            else
                            {
                                // dusman dodge animasyon
                                //basarisiz
                            }
                            break;
                        case Actions.Talk:
                            if (GameManager.Instance.zarSonucu >= 8)
                            {

                                // dusman kacar
                                // basarili sonuc
                            }
                            else
                            {
                                // dusman hasari artar
                                // dusman sýrasý
                                //basarisiz
                            }
                            break;
                        case Actions.Run:
                            if (GameManager.Instance.zarSonucu >= 2)
                            {
                                // geri dönüp ilerleme
                                // basarili sonuc
                            }
                            else
                            {
                                // dusman hasari artar
                                // dusman sýrasý
                                //basarisiz
                            }
                            break;
                        default:
                            break;
                    }
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
