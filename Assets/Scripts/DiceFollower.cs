using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceFollower : MonoBehaviour
{
    [SerializeField] Transform dice;
    void LateUpdate()
    {
        transform.position = dice.position;
    }
}
