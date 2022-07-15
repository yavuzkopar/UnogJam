using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnBaseSystem : MonoBehaviour
{
    public Animator playerAnimator;
    public Animator enemyAnimator;
    public Button attackButton;
    public bool enemyIsLive = true;
    public int playerHp = 100;
    public int enemyHp = 20;
    public int damage;


    public static bool isPlayerTurn;
    public void OnAttack()

    {
        attackButton.gameObject.SetActive(false);
        StartCoroutine(StartPlayerTurn());
    }
    IEnumerator StartPlayerTurn()
    {
        /*


        Zar kodlar� yaz�lacak.

         /

        damage = Random.Range(1,6)7;
        enemyHp = enemyHp - damage;
        playerAnimator.SetTrigger("attack");
        yield return new WaitForSeconds(2);
        /*

        d��man �ld� m� onun kontrol� yap�lacak if ile ve e�er �lmediyse

         /
        if (enemyHp>0)
        {
            StartCoroutine(StartEnemyTurn());
        }
        else
        {
            enemyAnimator.SetTrigger("dead");
            //rakip �ld� sonraki g�ne ge�eriz
        }

    }
    IEnumerator StartEnemyTurn()
    {
        yield return new WaitForSeconds(2);
        /
         Zar Kodlar�
        /


        damage = Random.Range(1, 6) 4;
        playerHp = playerHp - damage;

        enemyAnimator.SetTrigger("attack");
        yield return new WaitForSeconds(2);
        /*
         Karakterimiz �ld� m� onun kontrol� yap�lacak if ile ve e�er �lmediyse 

         */

        if (playerHp > 0)
        {
            yield return new WaitForSeconds(2);
            attackButton.gameObject.SetActive(true);
        }
        else
        {
            playerAnimator.SetTrigger("dead");
            //game over ekran�
        }

    }
}
