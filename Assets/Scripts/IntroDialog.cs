using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroDialog : MonoBehaviour
{

    public void Update()
    {
        if (GameObject.Find("DialogManager").GetComponent<Dialog>().Stop == false)
            {
            CinematicBarsController.Instance.HideBars();
        }
            

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CinematicBarsController.Instance.ShowBars();
           
        }
    }
   
      /*  if (Input.GetKeyDown(KeyCode.L))
       {
            CinematicBarsController.Instance.HideBars();
        
    }*/
}
