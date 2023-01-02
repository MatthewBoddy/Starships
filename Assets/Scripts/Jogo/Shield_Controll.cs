using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Controll : MonoBehaviour
{
    public static Shield_Controll inst;
    void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }
    }
    public GameObject Shield;
    public float TempRest_Shield;

    void Start()
    {
        TempRest_Shield = 10;
    }

    void Update()
    {
        if(Shield.activeSelf == true && !GAMEMANAGER.inst.pause)
        {
            TempRest_Shield -= Time.deltaTime;
        }
        if(TempRest_Shield < 0)
        {
            Shield.SetActive(false);
            TempRest_Shield = 10;
        }
    }

}
