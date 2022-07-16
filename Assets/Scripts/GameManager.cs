using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public int zarSonucu;
    public int zarBonusu;
    public int kalanBonus = 10;
    public TextMeshProUGUI zarText;
    public TextMeshProUGUI bonusText;
    private void Awake()
    {
        instance = this;
    }
    public void BonusEkle(int i)
    {
        
        zarBonusu += i;
        zarBonusu = Mathf.Clamp(zarBonusu, -(10 - kalanBonus), kalanBonus);
        bonusText.text = zarBonusu.ToString();
    }
    
}
