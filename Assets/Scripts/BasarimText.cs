using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BasarimText : MonoBehaviour
{
    void OnEnable()
    {
        transform.DOScale(Vector3.one, 1);
    }
    private void OnDisable()
    {
        transform.localScale = Vector3.zero;
    }
}
