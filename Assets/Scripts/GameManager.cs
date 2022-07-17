using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public Image EndingCanvas;
    public int zarSonucu;
    public int zarBonusu;
    public int kalanBonus = 10;
    public TextMeshProUGUI zarText;
    public TextMeshProUGUI bonusText;
    public GameObject deadPanel;
    public bool isDead = false;

    private void Start()
    {
        deadPanel.SetActive(false);
    }
    public bool isPlayerTurn = true;
    [SerializeField] GameObject canvas;
    private void Awake()
    {
        instance = this;
        isPlayerTurn = true;
    }
    public void BonusEkle(int i)
    {

        zarBonusu += i;
        zarBonusu = Mathf.Clamp(zarBonusu, -(10 - kalanBonus), kalanBonus);
        bonusText.text = zarBonusu.ToString();
    }
    public void UIkapat(bool v)
    {
        canvas.SetActive(v);
    }
    public void BasariliGun()
    {
        
    }
    public void Fail()
    {
        deadPanel.SetActive(true);
        UIkapat(false);
    }
    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
}

