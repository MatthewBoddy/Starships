using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyConfig : MonoBehaviour
{
    public GameObject joyFundo, joyFrente;    
    private float tamanhoJoy;
    
    void Start()
    {
        if(ZPlayerPrefs.HasKey("tamanhoJoy"))
        {
            tamanhoJoy = ZPlayerPrefs.GetFloat("tamanhoJoy");
        } else
        {
            tamanhoJoy = 1.0f;
            ZPlayerPrefs.SetFloat("tamanhoJoy", tamanhoJoy);
        }
        joyFundo.transform.localScale = new Vector3(tamanhoJoy, tamanhoJoy);
    }

    void Update()
    {
        
    }
    
    public void EscolheTamanhoJoy(float valor)
    {
        tamanhoJoy = valor;

        joyFundo.transform.localScale = new Vector3(tamanhoJoy, tamanhoJoy);
        
        ZPlayerPrefs.SetFloat("tamanhoJoy", tamanhoJoy);
    }
}
