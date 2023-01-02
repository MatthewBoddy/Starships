using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NavesCompradas : MonoBehaviour
{
    public GameObject naveSpeedy;
    public GameObject naveMG;
    public GameObject naveRay;
    public GameObject naveMille;


    void Update()
    {
         if(CarregaScore.instance.RetornaNaves(1) == 1)
        {
            naveSpeedy.SetActive(true);
        }   
        
        if(CarregaScore.instance.RetornaNaves(2) == 1)
        {
            naveMG.SetActive(true);
        }  

        if(CarregaScore.instance.RetornaNaves(3) == 1)
        {
            naveRay.SetActive(true);
        }

        if(CarregaScore.instance.RetornaNaves(100) == 1)
        {
            naveMille.SetActive(true);
        }
    }

    public void setInicial()
    {
        Acao_Botoes.inst.imgNaveAtual.sprite = Acao_Botoes.inst.naveInicial;
        CarregaScore.instance.SalvaNaveEscolhida(0);
        btnNaves.inst.ApertaSair();
    }
    public void setSpeedy()
    {
        Acao_Botoes.inst.imgNaveAtual.sprite = Acao_Botoes.inst.naveSpeedy;
        CarregaScore.instance.SalvaNaveEscolhida(1);
        btnNaves.inst.ApertaSair();
    }

    public void setMG()
    {
        Acao_Botoes.inst.imgNaveAtual.sprite = Acao_Botoes.inst.naveMG;
        CarregaScore.instance.SalvaNaveEscolhida(2);
        btnNaves.inst.ApertaSair();
    }

    public void setRay()
    {
        Acao_Botoes.inst.imgNaveAtual.sprite = Acao_Botoes.inst.naveRay;
        CarregaScore.instance.SalvaNaveEscolhida(3);
        btnNaves.inst.ApertaSair();
    }

    public void setMille()
    {
        Acao_Botoes.inst.imgNaveAtual.sprite = Acao_Botoes.inst.naveMille;
        CarregaScore.instance.SalvaNaveEscolhida(100);
        btnNaves.inst.ApertaSair();
    }
}
