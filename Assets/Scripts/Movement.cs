using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform target;
    public float speed = 5;
    public bool animation = false;
    public Animator animator;
    public GameObject Panel;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("walk", true);
        animation = true;
        Panel.SetActive(false);
    }
    int a = 0;
    void Update()
    {
        if (animation==true)
        {
        
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        if (transform.position == target.position)
        {
            animator.SetBool("walk", false);
            animation= false;
            
               
        }
     /*   if(GameManager.Instance.isPlayerTurn)
            Panel.SetActive(true);
        else
        {
            Panel.SetActive(false);
        }*/
    }
}