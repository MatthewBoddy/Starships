using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tela_Pause : MonoBehaviour
{
    public static Tela_Pause inst;
     void Awake()
    {
        if(inst == null)
        {
            inst = this;
        } 
    }
    //LOJA
    [SerializeField] private int precoNuke, precoShield, precoDouble;

    //CONTAINERS
    public GameObject container2;

    //PAINEIS
    private GameObject goHabilidade, goMissoes, goConfig, goSalvar;

    //ÁUDIO
    [SerializeField]
    private AudioSource aud_Compra;

    void PegaDados()
    {
        container2 = GameObject.FindWithTag("uicena");

        //UI
        goHabilidade = container2.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).gameObject;
        goMissoes = container2.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(3).gameObject;
        goSalvar = container2.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(5).gameObject;
        goConfig = container2.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(7).gameObject;  
    }
    void Start()
    {
        PegaDados();
    }

    public void AbreHabilidade()
    {
        if(!goHabilidade.gameObject.activeSelf)
        {
            goConfig.gameObject.SetActive(false);
            goMissoes.gameObject.SetActive(false);
            goHabilidade.gameObject.SetActive(true);
            goSalvar.gameObject.SetActive(false);
        }
    }

    public void AbreMissoes()
    {
        if(!goMissoes.gameObject.activeSelf)
        {
            goConfig.gameObject.SetActive(false);
            goMissoes.gameObject.SetActive(true);
            goHabilidade.gameObject.SetActive(false);
            goSalvar.gameObject.SetActive(false);
        }
    }

    public void AbreSalvar()
    {
        if(!goSalvar.gameObject.activeSelf)
        {
            goSalvar.gameObject.SetActive(true);
            goConfig.gameObject.SetActive(false);
            goMissoes.gameObject.SetActive(false);
            goHabilidade.gameObject.SetActive(false);
        }
    }

    public void AbreConfig()
    {
        if(!goConfig.gameObject.activeSelf)
        {
            goConfig.gameObject.SetActive(true);
            goMissoes.gameObject.SetActive(false);
            goHabilidade.gameObject.SetActive(false);
            goSalvar.gameObject.SetActive(false);
        }
    }

    public void CompraNuke()
    {
        if(ScoreManager.instance.moedas > precoNuke && ScoreManager.instance.qtdNuke < 2)
        {
            ScoreManager.instance.PerdeMoedas(precoNuke);
            ScoreManager.instance.GanhaHabilidade(0);
            
            Instantiate(aud_Compra, transform.position, Quaternion.identity);
        }
    }

    public void CompraShield()
    {
        if(ScoreManager.instance.moedas > precoShield && ScoreManager.instance.qtdShield < 3)
        {
            ScoreManager.instance.PerdeMoedas(precoShield);
            ScoreManager.instance.GanhaHabilidade(1);

            Instantiate(aud_Compra, transform.position, Quaternion.identity);
        }
    }

    public void CompraDouble()
    {
        if(ScoreManager.instance.moedas > precoDouble && ScoreManager.instance.qtdDoubleTap < 3)
        {
            ScoreManager.instance.PerdeMoedas(precoDouble);
            ScoreManager.instance.GanhaHabilidade(2);

            Instantiate(aud_Compra, transform.position, Quaternion.identity);
        }
    }
}
