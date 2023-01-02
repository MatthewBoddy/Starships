using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class Anim_Introducao : MonoBehaviour
{
    [SerializeField] private Image bg;
    [SerializeField] private Text txt;
    void Start()
    {
        txt.DOText("Sobreviva o máximo que puder...", 5, true, 0, null);
    }

    public void OnClick()
    {
        txt.DOPause();
        Destroy(gameObject);
        Destroy(bg);
    }
}
