using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaPlayer : MonoBehaviour
{
    public static BarraVidaPlayer inst;

    void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }
    }

    public int quantMaxCor = 6;
    public int inicioQuantCor;
    public Image[] containers;

    public int vidaAtual;
    public int maxVida;

    void Start()
    {
        CalculaValoresVida();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Dano(1);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            MaisVidas();
            ScoreManager.instance.ColetaMoedas(10000);
        }
    }

    void QuantidadeVidas()
    {
        for(int i=0; i < quantMaxCor; i++)
        {
            if(vidaAtual <= i)
            {
                containers[i].enabled = false;
            } else
            {
                containers[i].enabled = true;
            }
        }
    }

    public void Dano(int d)
    {
        if(vidaAtual > 0 && d <= vidaAtual)
        {
            vidaAtual -= d;
            Camera_Segue.inst.CamShake(0.8f, 0.3f);
        } else
        {
            GAMEMANAGER.inst.gameover = true;
            gameObject.SetActive(false);
        }
        QuantidadeVidas();
    }

    public void MaisVidas()
    {
        if(vidaAtual < quantMaxCor)
        {
            vidaAtual++;
        }
        QuantidadeVidas();
    }

    void CalculaValoresVida()
    {
        if(ScoreManager.instance.RetornaNaveEscolhida() == 0)
            inicioQuantCor = 3;
        else if (ScoreManager.instance.RetornaNaveEscolhida() == 1)
            inicioQuantCor = 4;
        else if (ScoreManager.instance.RetornaNaveEscolhida() == 2)
            inicioQuantCor = 5;
        else if (ScoreManager.instance.RetornaNaveEscolhida() == 3 || ScoreManager.instance.RetornaNaveEscolhida() == 100)
            inicioQuantCor = 6;

        vidaAtual = inicioQuantCor;
        maxVida = quantMaxCor;

        QuantidadeVidas();
    }
}
