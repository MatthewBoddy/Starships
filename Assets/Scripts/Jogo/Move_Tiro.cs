using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Tiro : MonoBehaviour
{
    private float Tiro_Speed = 10;

    public float Tiro_Vel
    {
        get{return Tiro_Speed;}
        set{Tiro_Vel = value;}
    }

    private Transform ld, le, lc, lb;

    void Start() //Captura o objeto pela TAG
    {
        ld = GameObject.FindWithTag ("lmtD").GetComponent<Transform>();
        le = GameObject.FindWithTag ("lmtE").GetComponent<Transform>();
        lc = GameObject.FindWithTag ("lmtC").GetComponent<Transform>();
        lb = GameObject.FindWithTag ("lmtB").GetComponent<Transform>();
    }

    void Move() //Move a munição pelo cenário
    {
        transform.Translate(new Vector3(Tiro_Speed * Time.deltaTime, 0, 0));
    }
    void Update()
    {
        Move();

        if(transform.position.x > ld.position.x || transform.position.x < le.position.x)
        {
            Destroy(gameObject);
        }

        if(transform.position.y > lc.position.y || transform.position.y < lb.position.y)
        {
            Destroy(gameObject);
        }
    }
}
