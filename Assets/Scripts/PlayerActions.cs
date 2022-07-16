using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerActions : MonoBehaviour
{
    Animator animator;
    [SerializeField] Dice dice;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    public Actions action;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    #region AttackAAction
    public void Attack()
    {
        GameManager.Instance.UIkapat(false);
        action = Actions.Attack;
        StartCoroutine(AttackRoutine());
    }
    IEnumerator AttackRoutine()
    {
       
         dice.ZarAt();
         virtualCamera.Priority = 11;
         yield return new WaitForSeconds(3);
         virtualCamera.Priority = 9;
         yield return new WaitForSeconds(2f);
         animator.SetTrigger("attack");
         Debug.Log("attack");
        yield return new WaitForSeconds(1);
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
        yield return new WaitForSeconds(1);
        GameManager.Instance.isPlayerTurn = false;

    }
    #endregion
    public IEnumerator SpellCast()
    {
        dice.ZarAt();
        virtualCamera.Priority = 11;
        yield return new WaitForSeconds(3);
        virtualCamera.Priority = 9;
        yield return new WaitForSeconds(2);
        animator.SetTrigger("spellCast");
        yield return new WaitForSeconds(1);
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
        yield return new WaitForSeconds(1);
        GameManager.Instance.isPlayerTurn = false;

    }
    public void Spell()
    {
        GameManager.Instance.UIkapat(false);
        action = Actions.Spellcast;
        StartCoroutine(SpellCast());
    }


}
public enum Actions
{
    None,
    Attack,
    Spellcast,
    Talk,
    Run
}
