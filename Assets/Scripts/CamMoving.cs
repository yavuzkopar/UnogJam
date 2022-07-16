using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoving : MonoBehaviour
{
    //Moving camera tool for the background of the opening scene
    public float frame = 0;
    [Space(10)]
    [Header("Camera 1 Settings")]
    [SerializeField] GameObject Cam1;
    [Range(0, 300)]
    [SerializeField] int MaxMovementFrame1;
    [SerializeField] float Cam1_VectorX;
    [SerializeField] float Cam1_VectorZ;
    [Space(10)]
    [Header("Camera 2 Settings")]
    [SerializeField] GameObject Cam2;
    [Range(0,600)]
    [SerializeField] int MaxMovementFrame2;
    [SerializeField] float Cam2_VectorX;
    [SerializeField] float Cam2_VectorZ;
    [Space(10)]
    [Header("Camera 3 Settings")]
    [SerializeField] GameObject Cam3;
    [Range(0,900)]
    [SerializeField] int MaxMovementFrame3;
    [SerializeField] float Cam3_VectorX;
    [SerializeField] float Cam3_VectorZ;
    [Space(10)]
    [Header("Camera 4 Settings")]
    [SerializeField] GameObject Cam4;
    [Range(0, 1200)]
    [SerializeField] int MaxMovementFrame4;
    [SerializeField] float Cam4_VectorX;
    [SerializeField] float Cam4_VectorZ;
    [Space(10)]
    [Header("Camera 5 Settings")]
    [SerializeField] GameObject Cam5;
    [Range(0, 1500)]
    [SerializeField] int MaxMovementFrame5;
    [SerializeField] float Cam5_VectorX;
    [SerializeField] float Cam5_VectorZ;
    [Space(20)]
    [Header("Camera Stating Positions")]
    [SerializeField] Transform transform1;
    [SerializeField] Transform transform2;
    [SerializeField] Transform transform3;
    [SerializeField] Transform transform4;
    [SerializeField] Transform transform5;

    void Start()
    {
        transform1.position = new Vector3(Cam1.GetComponent<Transform>().transform.position.x, Cam1.GetComponent<Transform>().transform.position.y, Cam1.GetComponent<Transform>().transform.position.z);
        transform2.position = new Vector3(Cam2.GetComponent<Transform>().transform.position.x, Cam2.GetComponent<Transform>().transform.position.y, Cam2.GetComponent<Transform>().transform.position.z);
        transform3.position = new Vector3(Cam3.GetComponent<Transform>().transform.position.x, Cam3.GetComponent<Transform>().transform.position.y, Cam3.GetComponent<Transform>().transform.position.z);
        transform4.position = new Vector3(Cam4.GetComponent<Transform>().transform.position.x, Cam4.GetComponent<Transform>().transform.position.y, Cam4.GetComponent<Transform>().transform.position.z);
        transform5.position = new Vector3(Cam5.GetComponent<Transform>().transform.position.x, Cam5.GetComponent<Transform>().transform.position.y, Cam5.GetComponent<Transform>().transform.position.z);


        Cam1.SetActive(true);
        Cam2.SetActive(false);
        Cam3.SetActive(false);
        Cam4.SetActive(false);
        Cam5.SetActive(false);
        
        
    }

    void FixedUpdate()
    {
        frame++;
        CamTimer();
    }

    void CamTimer()
    {
        if (frame >= 0 && frame <= MaxMovementFrame1)
        {
            Cam1.GetComponent<Transform>().position = Cam1.GetComponent<Transform>().position + new Vector3(Cam1_VectorX * -0.001f, 0, -0.001f * Cam1_VectorZ);
            if (frame == MaxMovementFrame1)
            {
                Cam1.transform.position = new Vector3 (transform1.transform.position.x, transform1.transform.position.y, transform1.transform.position.z);
                Cam1.SetActive(false);
                Cam2.SetActive(true);
                
            }
        }
        if (((frame >= MaxMovementFrame1) && (frame <= MaxMovementFrame2)))
        {
            Cam2.GetComponent<Transform>().position = Cam2.GetComponent<Transform>().position + new Vector3(Cam2_VectorX * -0.001f, 0, -0.001f * Cam2_VectorZ);
            if (frame == MaxMovementFrame2)
            {
                Cam2.transform.position = new Vector3(transform2.transform.position.x, transform2.transform.position.y, transform2.transform.position.z);
                Cam2.SetActive(false);
                Cam3.SetActive(true);
            }
        }
        if ((frame >= MaxMovementFrame2 && frame <= MaxMovementFrame3))
        {
            Cam3.GetComponent<Transform>().position = Cam3.GetComponent<Transform>().position + new Vector3(Cam3_VectorX * -0.001f, 0, -0.001f * Cam3_VectorZ);
            if (frame == MaxMovementFrame3)
            {
                Cam3.transform.position = new Vector3(transform3.transform.position.x, transform3.transform.position.y, transform3.transform.position.z);
                Cam3.SetActive(false);
                Cam4.SetActive(true);
            }
        }
        if ((frame >= MaxMovementFrame3 && frame <= MaxMovementFrame4))
        {
            Cam4.GetComponent<Transform>().position = Cam4.GetComponent<Transform>().position + new Vector3(Cam4_VectorX * -0.001f, 0, -0.001f * Cam4_VectorZ);
            if (frame == MaxMovementFrame4)
            {
                Cam4.transform.position = new Vector3(transform4.transform.position.x, transform4.transform.position.y, transform4.transform.position.z);
                Cam4.SetActive(false);
                Cam5.SetActive(true);
            }
        }
        
        if ((frame >= MaxMovementFrame4))
        {
            Cam5.GetComponent<Transform>().position = Cam5.GetComponent<Transform>().position + new Vector3(Cam5_VectorX * -0.001f, 0, -0.001f * Cam5_VectorZ);
            if (frame == MaxMovementFrame5)
            {
                Cam5.transform.position = new Vector3(transform5.transform.position.x, transform5.transform.position.y, transform5.transform.position.z);
                Cam5.SetActive(false);
                Cam1.SetActive(true);
                
                frame = 0;
            }
        }
    }
}


