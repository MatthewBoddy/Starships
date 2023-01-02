using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TurboControl : MonoBehaviour
{
    public Image img;
    public float tempRestTurbo = 3.0f, loadingTurbo = 10.0f, aux;
    public bool habTurbo;

    public static TurboControl inst;
    void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if(habTurbo && !GAMEMANAGER.inst.pause)
        {
            if(tempRestTurbo > 0)
            {
                tempRestTurbo -=Time.deltaTime;
                Player_Controll.inst.Player_Speed = 8.0f;
            } else 
            {
                tempRestTurbo = 3;
                loadingTurbo = 0;
                habTurbo = false;
                Player_Controll.inst.Player_Speed = aux;
            }

            img.fillAmount = tempRestTurbo/3;
        } else if(!GAMEMANAGER.inst.pause)
        {
            if(loadingTurbo < 10)
            {
                loadingTurbo +=Time.deltaTime;
                img.fillAmount = loadingTurbo/10;
            } else
            {
                loadingTurbo = 10;
            }
        }
    }

    public void ArmazenaVel(float vel)
    {
        aux = vel;
    }
}
