using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerActions : MonoBehaviour
{
    Animator animator;
    [SerializeField] Dice dice;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] CinemachineVirtualCamera followCamera;
    public Actions action;
    public GameObject dusman;
    bool kac;

    [SerializeField] Transform basariText, failText;
    void Start()
    {
        animator = GetComponent<Animator>();
        kac = false;
    }
    private void Update()
    {
        if (kac)
        {
            transform.position -= Vector3.forward * 5 * Time.deltaTime;
            followCamera.Follow = null;
            if (transform.position.z < 12)
                GameManager.Instance.BasariliGun();
        }
            
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
         yield return new WaitForSeconds(4);
         virtualCamera.Priority = 9;
        if (GameManager.Instance.zarSonucu >= 3)
        {
            basariText.gameObject.SetActive(true);
        }
        else
        {
            failText.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(2f);
         animator.SetTrigger("attack");
        basariText.gameObject.SetActive(false);
        failText.gameObject.SetActive(false);
        Debug.Log("attack");
        yield return new WaitForSeconds(1);
        if (GameManager.Instance.zarSonucu >= 3)
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
        yield return new WaitForSeconds(4);
        virtualCamera.Priority = 9;
        if (GameManager.Instance.zarSonucu >= 5)
        {
            basariText.gameObject.SetActive(true);
        }
        else
        {
            failText.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(2);
        animator.SetTrigger("spellCast");
        basariText.gameObject.SetActive(false);
        failText.gameObject.SetActive(false);
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
        yield return new WaitForSeconds(4);
        virtualCamera.Priority = 9;
        if (GameManager.Instance.zarSonucu >= 9)
        {
            basariText.gameObject.SetActive(true);
        }
        else
        {
            failText.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(2);
        animator.SetTrigger("talk");
        basariText.gameObject.SetActive(false);
        failText.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        if (GameManager.Instance.zarSonucu >= 9)
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
        yield return new WaitForSeconds(4);
        virtualCamera.Priority = 9;
        if (GameManager.Instance.zarSonucu >= 8)
        {
            basariText.gameObject.SetActive(true);
        }
        else
        {
            failText.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(2);
        basariText.gameObject.SetActive(false);
        failText.gameObject.SetActive(false);
        if (GameManager.Instance.zarSonucu >= 8)
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
