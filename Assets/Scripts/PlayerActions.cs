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
    public GameObject dusman;
    bool kac;
    void Start()
    {
        animator = GetComponent<Animator>();
        kac = false;
    }
    private void Update()
    {
        if (kac)
            transform.position -= Vector3.forward * 5 * Time.deltaTime;
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
            dusman.GetComponent<PlayerHealth>().getDamage(30);
            dusman.GetComponentInChildren<Animator>().SetTrigger("getHit");
            // basarili sonuc
        }
        else
        {
            // dusman dodge animasyon
         //   dusman.GetComponentInChildren<Animator>().SetTrigger("");
            //basarisiz
        }
        yield return new WaitForSeconds(1);
        GameManager.Instance.isPlayerTurn = false;

    }
    #endregion
    #region SpellAction
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
            dusman.GetComponent<PlayerHealth>().getDamage(50);
            dusman.GetComponentInChildren<Animator>().SetTrigger("getHit");
            // basarili sonuc
        }
        else
        {
            // dusman dodge animasyon
         //   dusman.GetComponentInChildren<Animator>().SetTrigger("");
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
    #endregion
    #region TalkAction
    IEnumerator TalkRoutine()
    {
        GameManager.Instance.UIkapat(false);
        dice.ZarAt();
        virtualCamera.Priority = 11;
        yield return new WaitForSeconds(3);
        virtualCamera.Priority = 9;
        yield return new WaitForSeconds(2);
        animator.SetTrigger("talk");
        yield return new WaitForSeconds(2);
        if (GameManager.Instance.zarSonucu >= 5)
        {
            // hasar verme
            dusman.GetComponent<EnemyAI>().kac = true;
            // basarili sonuc
        }
        else
        {
            // dusman dodge animasyon
        //    dusman.GetComponentInChildren<Animator>().SetTrigger("");
            //basarisiz
        }
        yield return new WaitForSeconds(1);
        GameManager.Instance.isPlayerTurn = false;
    }
    public void Talk()
    {
        StartCoroutine(TalkRoutine());
    }
    #endregion
    #region Run
    IEnumerator RunRoutine()
    {
        GameManager.Instance.UIkapat(false);
        dice.ZarAt();
        virtualCamera.Priority = 11;
        yield return new WaitForSeconds(3);
        virtualCamera.Priority = 9;
        yield return new WaitForSeconds(2);
        if (GameManager.Instance.zarSonucu >= 5)
        {
            // hasar verme
           // dusman.GetComponent<EnemyAI>().kac = true;
            kac = true;
            // basarili sonuc
        }
        else
        {
            // dusman dodge animasyon
          //  dusman.GetComponentInChildren<Animator>().SetTrigger("");
            //basarisiz
        }
        yield return new WaitForSeconds(1);
        GameManager.Instance.isPlayerTurn = false;
    }
    public void Run()
    {
        StartCoroutine(RunRoutine());
    }
    #endregion


}
public enum Actions
{
    None,
    Attack,
    Spellcast,
    Talk,
    Run
}
