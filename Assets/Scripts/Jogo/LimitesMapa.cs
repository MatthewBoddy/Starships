using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitesMapa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            int qtdVidaAtual = BarraVidaPlayer.inst.vidaAtual;
            qtdVidaAtual++;

            BarraVidaPlayer.inst.Dano(qtdVidaAtual);
        }
    }
}
