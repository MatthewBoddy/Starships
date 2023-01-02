using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class CompraReal : MonoBehaviour, IStoreListener
{
    private static IStoreController m_StoreController;
    private static IExtensionProvider m_ExtensionProvider;

    public static string naveMillennium = "navemillennium";

    void Start()
    {
        if(Restore.naveMillennium)
        {
            BuyMillennium();
        }

        if(m_StoreController == null)
        {
            InitializePurchasing();
        }
    }

    private bool IsInitialized()
    {
        return m_StoreController != null && m_ExtensionProvider != null;
    }

    private void InitializePurchasing()
    {
        if(IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(naveMillennium, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void CompraProduto(string productID)
    {
        if(IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productID);

            if(product != null && product.availableToPurchase)
            {
                m_StoreController.InitiatePurchase(product);
            } else
            {
                Debug.Log("Falha na transação!");
            }
        } else
        {
            Debug.Log("Falha Initialized");
        }
    }

    void Update()
    {
        
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extension)
    {
        Debug.Log("Ok");

        m_StoreController = controller;
        m_ExtensionProvider = extension;
    }

    public void OnInitializeFailed(InitializationFailureReason erro)
    {
        Debug.Log("Falha: "+ erro);
    }

    public void OnPurchaseFailed(Product produto, PurchaseFailureReason erroRazao)
    {
        Debug.Log("Compra não realizada");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if(String.Equals(args.purchasedProduct.definition.id, naveMillennium, StringComparison.Ordinal))
        {
            BuyMillennium();
        } else
        {
            Debug.Log("Falha no processo");
        }

        return PurchaseProcessingResult.Complete;
    }

    void BuyMillennium()
    {
        CarregaScore.instance.SalvaNaves(100);
            btnNaves.inst.CompraMille();
    }
}
