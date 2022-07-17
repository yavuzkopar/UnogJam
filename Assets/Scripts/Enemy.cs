using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;
    public GameObject Enemy6;
    public GameObject Target;
    Animator animator;
    PlayerActions playerActions;
    private void Start()
    {
        playerActions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerActions>();
        RandomSpawner();
        int enemy1ID = 1;
        int enemy2ID = 2;
        int enemy3ID = 3;
        int enemy4ID = 4;
        int enemy5ID = 5;
        int enemy6ID = 6;
        
        //Transform enemyTransform = GetComponent<Player>();
    }

    public void RandomSpawner()
    {
        int randomIDGenerator= Random.Range(1,7);
        if (randomIDGenerator == 1)
        {
            GameObject _Enemy = Instantiate(Enemy1);
            _Enemy.SetActive(true);
            _Enemy.transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z + 18);
            playerActions.dusman = _Enemy;
        }
        else if (randomIDGenerator == 2)
        {
            GameObject _Enemy = Instantiate(Enemy2);
            _Enemy.SetActive(true);
            _Enemy.transform.position = new Vector3(Target.transform.position.x-2, Target.transform.position.y, Target.transform.position.z + 19);
            playerActions.dusman = _Enemy;
        }
        else if (randomIDGenerator == 3)
        {
            GameObject _Enemy = Instantiate(Enemy3);
            _Enemy.SetActive(true);
            _Enemy.transform.position = new Vector3(Target.transform.position.x-2, Target.transform.position.y, Target.transform.position.z + 19);
            playerActions.dusman = _Enemy;
        }
        else if (randomIDGenerator == 4)
        {
            GameObject _Enemy = Instantiate(Enemy4);
            _Enemy.SetActive(true);
            _Enemy.transform.position = new Vector3(Target.transform.position.x-2, Target.transform.position.y, Target.transform.position.z + 19);
            playerActions.dusman = _Enemy;
        }
        else if (randomIDGenerator == 5)
        {
            GameObject _Enemy = Instantiate(Enemy5);
            _Enemy.SetActive(true);
            _Enemy.transform.position = new Vector3(Target.transform.position.x-2, Target.transform.position.y, Target.transform.position.z + 19);
            playerActions.dusman = _Enemy;
        }
        else if (randomIDGenerator == 6)
        {
            GameObject _Enemy = Instantiate(Enemy6);
            _Enemy.SetActive(true);
            _Enemy.transform.position = new Vector3(Target.transform.position.x-2, Target.transform.position.y, Target.transform.position.z + 19);
            playerActions.dusman = _Enemy;
        }
    }

}
