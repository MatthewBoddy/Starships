using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mata_Objetos : MonoBehaviour
{
    [SerializeField] private float tempo;
    void Start()
    {
        Destroy(gameObject, tempo);
    }
}
