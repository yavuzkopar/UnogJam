using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody rb;
    public static Vector3 diceVelocity;
    public Transform playerPos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity;

    }
    public void ZarAt()
    {
        float dirX = Random.Range(0, 2000);
        float dirY = Random.Range(0, 2000);
        float dirZ = Random.Range(0, 2000);

        transform.position = new Vector3(playerPos.position.x, 6, playerPos.position.z+12);
        transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        rb.AddForce(Vector3.up * 2000);
        rb.AddTorque(dirX, dirY, dirZ);
    }
}
