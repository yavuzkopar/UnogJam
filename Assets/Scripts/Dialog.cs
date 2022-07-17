using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingspeed;
    public bool Stop = false;
    public GameObject continueButton;
    public GameObject DialogText;



    private void Update()
    {

        if (textDisplay.text == sentences[index] && Stop == true)
        {
        
            continueButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }
    }
    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index<sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            Stop = false;
           continueButton.SetActive(false);
            DialogText.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {          
            StartCoroutine(Type());
            Stop = true;

        }
    }
}
