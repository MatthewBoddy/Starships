using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class btnNaves : MonoBehaviour
{
    public static btnNaves inst;
     void Awake()
    {
        if(inst == null)
        {
            inst = this;
        } 
    }
    //LOJA
    [SerializeField] private int precoSpeedy;
    [SerializeField] private int precoMG;
    [SerializeField] private int precoRay;

    //PAINEIS
    [SerializeField] private GameObject goNaves;
    [SerializeField] private GameObject goNavesPlus;
    [SerializeField] private GameObject goHangar;

    //ÁUDIO
    [SerializeField]
    private AudioSource aud_Compra;

    void Start()
    {

    }

    public void AbreNaves()
    {
        if(!goNaves.gameObject.activeSelf)
        {
            goHangar.gameObject.SetActive(false);
            goNavesPlus.gameObject.SetActive(false);
            goNaves.gameObject.SetActive(true);
        }
    }

    public void AbreNavesPlus()
    {
        if(!goNavesPlus.gameObject.activeSelf)
        {
            goHangar.gameObject.SetActive(false);
            goNaves.gameObject.SetActive(false);
            goNavesPlus.gameObject.SetActive(true);
        }
    }

    public void AbreHangar()
    {
        if(!goHangar.gameObject.activeSelf)
        {
            goNaves.gameObject.SetActive(false);
            goNavesPlus.gameObject.SetActive(false);
            goHangar.gameObject.SetActive(true);
        }
    }

    public void ApertaSair()
    {
        Acao_Botoes.inst.AtivaFundo();

        Acao_Botoes.inst.objTelaNaves.SetActive(false);
    }

    public void CompraSpeedy()
    {
        if(CarregaScore.instance.moedas >= precoSpeedy && CarregaScore.instance.RetornaNaves(1) != 1)
        {
            CarregaScore.instance.SalvaNaves(1);
            CarregaScore.instance.PerdeMoedas(precoSpeedy);

            Instantiate(aud_Compra, transform.position, Quaternion.identity);
        }
    }

    public void CompraMG()
    {
        if(CarregaScore.instance.moedas >= precoMG && CarregaScore.instance.RetornaNaves(2) != 1)
        {
            CarregaScore.instance.SalvaNaves(2);
            CarregaScore.instance.PerdeMoedas(precoMG);

            Instantiate(aud_Compra, transform.position, Quaternion.identity);
        }
        
    }

    public void CompraRay()
    {
        if(CarregaScore.instance.moedas >= precoMG && CarregaScore.instance.RetornaNaves(3) != 1)
        {
            CarregaScore.instance.SalvaNaves(3);
            CarregaScore.instance.PerdeMoedas(precoRay);

            Instantiate(aud_Compra, transform.position, Quaternion.identity);
        }
    }

    public void CompraMille()
    {
        //CarregaScore.instance.SalvaNaves(100);
        Instantiate(aud_Compra, transform.position, Quaternion.identity);
    }
}

