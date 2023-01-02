using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Segue : MonoBehaviour
{
    public GameObject Player;
    public float cam_Vel;
    private bool segue_Player;

    public Vector3 ultima_Pos;
    public Vector3 vel_Atual;

    public static Camera_Segue inst;

    //limites
    [SerializeField] private Transform ld, le, lc, lb;


    private void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }
    }

    void Start()
    {
        segue_Player = true;
        ultima_Pos = Player.transform.position;    
    }

    void FixedUpdate()
    {
        if(segue_Player && Player!=null)
        { 
            Vector3 nova_CamPos = Vector3.SmoothDamp(transform.position, Player.transform.position, ref vel_Atual, cam_Vel);

            transform.position = new Vector3(nova_CamPos.x, nova_CamPos.y, transform.position.z);

            ultima_Pos = Player.transform.position;
        }
    }   

    public void CamShake(float intensidade, float tempo)
    {
        iTween.ShakePosition(gameObject, new Vector3(intensidade,00,0), tempo);
    }
}
