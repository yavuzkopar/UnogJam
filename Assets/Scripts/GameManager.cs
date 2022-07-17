using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

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
    public TextMeshProUGUI currentBonus;
    public TextMeshProUGUI DayCounter;
    public Image endingImage;
    float a = 0;

    private void Start()
    {
        kalanBonus = PlayerPrefs.GetInt("kalan");
        deadPanel.SetActive(false);
        DayCounter.text = SceneManager.GetActiveScene().buildIndex.ToString();
        if (SceneManager.GetActiveScene().buildIndex==2)
        {
            kalanBonus = 10;
        }
    }
    public bool isPlayerTurn = true;
    [SerializeField] GameObject canvas;
    private void Awake()
    {
        instance = this;
        isPlayerTurn = true;
    }
    private void Update()
    {
        currentBonus.text = kalanBonus.ToString();
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
        a += Time.deltaTime * 0.33f;
        endingImage.color = new Color(0, 0, 0, a);
        if (a>=1)
        {
            PlayerPrefs.SetInt("kalan", kalanBonus);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
        }

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

