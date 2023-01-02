using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double_Controll : MonoBehaviour
{
    public static Double_Controll inst;
    
    void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }
    }

    public float TempRest_Double;
    
    public bool DoubleHabilitado;

    void Start()
    {
        TempRest_Double = 10;
    }

    void Update()
    {
        if(DoubleHabilitado && !GAMEMANAGER.inst.pause)
        {
            TempRest_Double -= Time.deltaTime;
        }
        if(TempRest_Double < 0)
        {
            DoubleHabilitado = false;
            TempRest_Double = 10;
        }
    }
}
