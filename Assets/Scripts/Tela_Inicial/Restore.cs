using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Restore : MonoBehaviour
{
    public static bool naveMillennium;
    public void RestoreProduct(Product produto)
    {
        if(produto.definition.id == "navemillennium")
        {
            naveMillennium = true;
        }
    }
}
