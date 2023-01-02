using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text moedasUI;
    public Text bestPtsUI;
    public Text txtQtdNuke;
    public Text txtQtdShield;
    public Text txtQtdDouble;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += Carrega;
    }

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        moedasUI = GameObject.Find("MoedasUI").GetComponent<Text>();
        
        txtQtdNuke = GameObject.Find("qtd_Nuke").GetComponent<Text>();
        txtQtdShield = GameObject.Find("qtd_Shield").GetComponent<Text>();
        txtQtdDouble = GameObject.Find("qtd_Double").GetComponent<Text>();
    }

    public void UpdateUI()
    {
        moedasUI.text = ScoreManager.instance.moedas.ToString();

        txtQtdNuke.text = ScoreManager.instance.qtdNuke.ToString();
        txtQtdShield.text = ScoreManager.instance.qtdShield.ToString();
        txtQtdDouble.text = ScoreManager.instance.qtdDoubleTap.ToString();
    }
}
