using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody rb;
    public static Vector3 diceVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            float dirX = Random.Range(0, 2000);
            float dirY = Random.Range(0, 2000);
            float dirZ = Random.Range(0, 2000);

            transform.position = new Vector3(20,6,35);
            transform.rotation = Quaternion.Euler(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360));
            rb.AddForce(Vector3.up * 2000);
            rb.AddTorque(dirX, dirY, dirZ);
        }
    }
}
