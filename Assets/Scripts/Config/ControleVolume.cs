using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleVolume : MonoBehaviour
{
    public Slider sliderMusic, sliderSFX;
    public float volumeMusic, volumeSFX;
    [SerializeField] GameObject[] sfx;
    void Start()
    {
        if(ZPlayerPrefs.HasKey("volumeMusic"))
        {
            sliderMusic.value = ZPlayerPrefs.GetFloat("volumeMusic");
        } else
        {
            ZPlayerPrefs.SetFloat("volumeMusic", 0.4f);
        }

        if(ZPlayerPrefs.HasKey("volumeSFX"))
        {
            sliderSFX.value = ZPlayerPrefs.GetFloat("volumeSFX");
        } else
        {
            ZPlayerPrefs.SetFloat("volumeSFX", 0.8f);
        }
    }

    
    void Update()
    {
        
    }

    public void VolumeMusic(float volume)
    {
        volumeMusic = volume;
        GameObject[] music = GameObject.FindGameObjectsWithTag("Music");

        for(int i=0; i<music.Length; i++)
        {
            music[i].GetComponent<AudioSource>().volume = volumeMusic;
        }

        ZPlayerPrefs.SetFloat("volumeMusic", volumeMusic);
    }

    public void VolumeSFX(float volume)
    {
        volumeSFX = volume;

        for(int i=0; i<sfx.Length; i++)
        {
            sfx[i].GetComponent<AudioSource>().volume = volumeSFX;
        }

        ZPlayerPrefs.SetFloat("volumeSFX", volumeSFX);
    }
}
