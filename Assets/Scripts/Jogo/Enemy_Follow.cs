using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow : MonoBehaviour
{
    public float speed;
    private Transform target;
    private Transform limite;
    public LayerMask layer;

    public GameObject AnimExplosao;

    //ÁUDIO
    [SerializeField]
    private AudioSource aud_Explosao;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    
    void Update()
    {
        if(!GAMEMANAGER.inst.pause)
            SeguePlayer();
    }

    void SeguePlayer()
    {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Bullet"))
        {
            Instantiate(aud_Explosao, transform.position, Quaternion.identity);
            Instantiate(AnimExplosao, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

            Destroy(gameObject);
            Destroy(col.gameObject);

            GAMEMANAGER.inst.pts_partida++;
            ScoreManager.instance.ColetaMoedas(1);

        } else if(col.gameObject.CompareTag("Player"))
        {
            Instantiate(aud_Explosao, transform.position, Quaternion.identity);
            Instantiate(AnimExplosao, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

            Destroy(gameObject);
            BarraVidaPlayer.inst.Dano(1);
            
        } else if(col.gameObject.CompareTag("Shield"))
        {
            Instantiate(aud_Explosao, transform.position, Quaternion.identity);
            Instantiate(AnimExplosao, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

            Destroy(gameObject);
        }

    }
}
