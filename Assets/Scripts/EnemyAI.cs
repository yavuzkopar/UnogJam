using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Transform player;
    Vector3 ilkpos;
    bool ileri;
    public bool kac;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ilkpos = transform.position;
        ileri = true;
        kac = false;
    }

    // Update is called once per frame
    float a = 0;
   
    void Update()
    {
        if (GameManager.Instance.isPlayerTurn) return;
        Vector3 hedef = player.position + Vector3.forward * 5;
        if(kac)
        {
            transform.position += Vector3.forward * 5 * Time.deltaTime;
            if (transform.position.z >= 50)
                GameManager.Instance.BasariliGun();
            return;
        }
            
        if (ileri)
        {
            transform.position = Vector3.MoveTowards(transform.position, hedef, 15f * Time.deltaTime);
            if (transform.position == hedef)
            {
                if(a == 0)
                {
                    GetComponentInChildren<Animator>().SetTrigger("attack");
                    player.GetComponent<PlayerHealth>().getDamage(20);
                    
                }
                    
                a += Time.deltaTime;
                if(a >= 1)
                    ileri = false;

            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, ilkpos, 15f * Time.deltaTime);
            if (transform.position == ilkpos)
            {
             //   GetComponentInChildren<Animator>().SetTrigger("attack");
                ileri = true;
                GameManager.Instance.UIkapat(true);
                GameManager.Instance.isPlayerTurn = true;
               
                a = 0;
            }
        }

    }
    void Aa()
    {
        ileri = false;
    }
}
