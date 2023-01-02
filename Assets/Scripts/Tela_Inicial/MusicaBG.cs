using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaBG : MonoBehaviour
{
    //MÚSICAS
    public AudioClip[] clips;
    public AudioSource musicBG;

    void Start()
    {
        if(CarregaScore.instance.RetornaNaves(100) == 1)
            {
                if(!musicBG.isPlaying)
                {
                    musicBG.clip = clips[1];
                    musicBG.Play();
                }
            } else
            {
                if(!musicBG.isPlaying)
                {
                    musicBG.clip = clips[0];
                    musicBG.Play();
                }
            }
    }

    void Update()
    {
        
    }
}
