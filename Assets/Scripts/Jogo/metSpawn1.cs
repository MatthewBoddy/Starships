using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metSpawn1 : MonoBehaviour
{
    [SerializeField]
    private float TimeMet, TimeNave, TimeAlien;//"time" diminui pelo GAMEMANAGER  //, spawnRadius = 0.2f;
    private bool controladora;
    public GameObject[] enemies, Spawners;

    private int nivelEscolhido;

    public static metSpawn1 inst;
    void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }
    }
    void Start()
    {
        nivelEscolhido = ScoreManager.instance.RetornaNivelEscolhido();
    }

    void Update()
    {
        if(!GAMEMANAGER.inst.pause)
        {
            if(controladora == false)
            {
                StartCoroutine(SpawnEnemy());

                if(nivelEscolhido == 1)
                StartCoroutine(SpawnNave());  

                if(nivelEscolhido == 2)
                {
                    StartCoroutine(SpawnNave());               
                    StartCoroutine(SpawnAlien()); 
                }
            } 
        }
        else
        {
            StopAllCoroutines();
            controladora=false;
        }

        if(GAMEMANAGER.inst.pts_partida > 110)
        {
            TimeMet = 1.2f;

            if(nivelEscolhido == 1)
                TimeNave = 2.2f;

            if(nivelEscolhido == 2)
            {
                TimeNave = 2.2f;
                TimeAlien = 3.2f;
            }
                
        } else if(GAMEMANAGER.inst.pts_partida > 80)
        {
            TimeMet = 1.5f;

            if(nivelEscolhido == 1)
                TimeNave = 2.5f;

            if(nivelEscolhido == 2)
            {
                TimeNave = 2.5f;
                TimeAlien = 3.5f;
            }

        } else if(GAMEMANAGER.inst.pts_partida > 40)
        {
            TimeMet = 1.8f;

            if(nivelEscolhido == 1)
                TimeNave = 2.8f;

            if(nivelEscolhido == 2)
            {
                TimeNave = 2.8f;
                TimeAlien = 3.8f;
            }

        }
    }

    IEnumerator SpawnEnemy()
    {
        int rand = Random.Range(0, Spawners.Length);

        controladora = true;
        Vector2 spawnPos = Spawners[rand].transform.position;//FindWithTag("Spawnner").transform.position;
        spawnPos += Random.insideUnitCircle.normalized;// * spawnRadius;

        Instantiate(enemies[0], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(TimeMet);

        StartCoroutine(SpawnEnemy()); 
    }

    IEnumerator SpawnNave()
    {
        int rand = Random.Range(0, Spawners.Length);

        controladora = true;
        Vector2 spawnPos = Spawners[rand].transform.position;
        spawnPos += Random.insideUnitCircle.normalized;

        Instantiate(enemies[1], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(TimeNave);

        StartCoroutine(SpawnNave()); 
    }

    IEnumerator SpawnAlien()
    {
        int rand = Random.Range(0, Spawners.Length);

        controladora = true;
        Vector2 spawnPos = Spawners[rand].transform.position;
        spawnPos += Random.insideUnitCircle.normalized;

        Instantiate(enemies[2], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(TimeAlien);

        StartCoroutine(SpawnAlien()); 
    }
}
