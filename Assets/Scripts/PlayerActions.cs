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
