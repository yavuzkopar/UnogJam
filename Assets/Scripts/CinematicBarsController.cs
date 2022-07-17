using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicBarsController : MonoBehaviour
{
    public static CinematicBarsController Instance { get; private set; }
    [SerializeField] private GameObject cinematicBarsContainerGO;
    [SerializeField] private Animator cinematicBarsAnimator;
    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    public void ShowBars()
    {
        cinematicBarsContainerGO.SetActive(true);
    }
    public void HideBars()
    {
        if (cinematicBarsContainerGO.activeSelf)
            StartCoroutine(HideBarsAndDisableGO());
    }
    private IEnumerator HideBarsAndDisableGO()
    {
        cinematicBarsAnimator.SetTrigger("HideBars");
        yield return new WaitForSeconds(0.5f);
        cinematicBarsContainerGO.SetActive(false);
    }
}
