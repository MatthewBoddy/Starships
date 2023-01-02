using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Acao_Botoes : MonoBehaviour
{
    public static Acao_Botoes inst;
    void Awake()
    {
        if(inst == null)
        {
            inst = this;
        } 
    }

    public GameObject objTelaNaves;
    public Image imgNaveAtual, imgNivelAtual;
    public Text moedasUI, bestPts;
    public Sprite img_HudFacil, img_HudMedio, img_HudDificil, naveInicial, naveSpeedy, naveMG, naveRay, naveMille;
    public Dropdown escolheNivel;

        //BOTÕES UI
    [SerializeField] private GameObject btnJogarUI;
    [SerializeField] private GameObject btnNavesUI;
    [SerializeField] private GameObject btnNivelUI;
    [SerializeField] private GameObject btnConfigUI;
    [SerializeField] private GameObject btnSairUI;
    
    void Start()
    {
        int aux = CarregaScore.instance.RetornaNaveEscolhida();
        if(aux == 0)
        {
            imgNaveAtual.sprite = naveInicial;
        } else if(aux == 1)
        {
            imgNaveAtual.sprite = naveSpeedy;
        } else if(aux == 2)
        {
            imgNaveAtual.sprite = naveMG;
        } else if(aux == 3)
        {
            imgNaveAtual.sprite = naveRay;
        } else if(aux == 100)
        {
            imgNaveAtual.sprite = naveMille;
        }
        
        escolheNivel.value = CarregaScore.instance.RetornaNivelEscolhido();

        AppodealCodBanner.inst.ShowBannerBottom();
    }

    void Update()
    {
        AttDinheiro();
        UpdateNiveis();
    }

    public void Aperta_btn_Naves()
    {
        DesativaFundo();
        
        objTelaNaves.SetActive(true);
    }

    public void AttDinheiro()
    {
        moedasUI.text = CarregaScore.instance.moedas.ToString();
    }

    public void UpdateNiveis()
    {
        if(escolheNivel.value == 0)
        {
            imgNivelAtual.sprite = img_HudFacil;
            bestPts.text = CarregaScore.instance.best_pts_0.ToString();
            CarregaScore.instance.SalvaNivelEscolhido(0);

        } else if(escolheNivel.value == 1)
        {
            imgNivelAtual.sprite = img_HudMedio;
            bestPts.text = CarregaScore.instance.best_pts_1.ToString();
            CarregaScore.instance.SalvaNivelEscolhido(1);

        } else
        {
            imgNivelAtual.sprite = img_HudDificil;
            bestPts.text = CarregaScore.instance.best_pts_2.ToString();
            CarregaScore.instance.SalvaNivelEscolhido(2);

        }
    }

    void DesativaFundo()
    {
        imgNivelAtual.enabled = false;
        imgNaveAtual.enabled = false;
        bestPts.enabled = false;

        btnJogarUI.SetActive(false);
        btnNavesUI.SetActive(false);
        btnNivelUI.SetActive(false);
        btnConfigUI.SetActive(false);
        btnSairUI.SetActive(false);
    }

    public void AtivaFundo()
    {
        imgNivelAtual.enabled = true;
        imgNaveAtual.enabled = true;
        bestPts.enabled = true;

        btnJogarUI.SetActive(true);
        btnNavesUI.SetActive(true);
        btnNivelUI.SetActive(true);
        btnConfigUI.SetActive(true);
        btnSairUI.SetActive(true);
    }
    
}
