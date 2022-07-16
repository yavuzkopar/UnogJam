using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerActions : MonoBehaviour
{
    Animator animator;
    [SerializeField] Dice dice;
    [SerializeField] CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    #region AttackAAction
    public void Attack()
    {
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


    }
    public void Spell()
    {
        StartCoroutine(SpellCast());
    }


}
