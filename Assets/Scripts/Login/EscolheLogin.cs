using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscolheLogin : MonoBehaviour
{
    public GameObject panEscolheLogin, panEntrar, panRegistrar;
    public void ClicaEntrar()
    {
        panEscolheLogin.SetActive(false);
        panEntrar.SetActive(true);
    }

    public void ClicaRegistrar()
    {
        panEscolheLogin.SetActive(false);
        panRegistrar.SetActive(true);
    }

    public void ClicaVoltar()
    {
        panEscolheLogin.SetActive(true);
        panRegistrar.SetActive(false);
        panEntrar.SetActive(false);
    }
}
