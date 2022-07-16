using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject ExitPanel;
    public GameObject CreditsPannel;
    public GameObject CreditsExit;
    public void startButton()
    {
        SceneManager.LoadScene(1);
    }
    public void CreditsButton()
    {
        CreditsPannel.SetActive(true);
        CreditsExit.SetActive(true);
        Debug.Log("Credits");
    }
    public void CreditsExitButton()
    {
        CreditsPannel.SetActive(false);
        CreditsExit.SetActive(false);
    }
    public void ExitButton()
    {
        ExitPanel.SetActive(true);
    }
    public void ExitCancel()
    {
        ExitPanel.SetActive(false);
    }
    public void ExitConfirm()
    {

        Application.Quit();
        Debug.Log("Quit");

    }
}
