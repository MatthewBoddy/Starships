using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarregaScore : MonoBehaviour
{
    public static CarregaScore instance;
    public int moedas;
    public int best_pts_0, best_pts_1, best_pts_2; // '0' significa nível fácil
    
    // armazena Quantidades
    public int qtdNuke;
    public int qtdShield;
    public int qtdDoubleTap;

    // armazena Naves
    public int naveInicial;
    public int naveSpeedy;
    public int naveMG;
    public int naveRay;
    public int naveMille;

    // armazena escolha usuário
    public int naveEscolhida;
    public int nivelEscolhido;

    void Awake()
    {
        ZPlayerPrefs.Initialize("1196CX2000", "7311ChicoXavier");

        if(instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GameStartScoreM();
        //ResetScore();
    }

    void ResetScore()
    {
        ZPlayerPrefs.SetInt("bstPts0_Save", 0);
        ZPlayerPrefs.SetInt("bstPts1_Save", 0);
        ZPlayerPrefs.SetInt("bstPts2_Save", 0);
        ZPlayerPrefs.SetInt("hasSpeedy", 0);
        ZPlayerPrefs.SetInt("hasMG", 0);
        ZPlayerPrefs.SetInt("hasRay", 0);
        ZPlayerPrefs.SetInt("hasMille", 0);
        ZPlayerPrefs.SetInt("moedasSave", 50);
        ZPlayerPrefs.SetInt("naveEscolhida", 0);
        ZPlayerPrefs.SetInt("nivelEscolhido", 0);

        ScoreManager.instance.ResetScoreJogo();
        Missoes.inst.ResetMissoes();
    }

    public void GameStartScoreM() // estabelece os valores iniciais de moedas, valores e quantidades
    {
        // moedas
        if(ZPlayerPrefs.HasKey("moedasSave"))
        {
            moedas = ZPlayerPrefs.GetInt("moedasSave");
        } else
        {
            moedas = 50;
            ZPlayerPrefs.SetInt("moedasSave", moedas);
        }


        // pontuação
        if(ZPlayerPrefs.HasKey("bstPts0_Save"))
        {
            best_pts_0 = ZPlayerPrefs.GetInt("bstPts0_Save");
        } else
        {
            best_pts_0 = 0;
            ZPlayerPrefs.SetInt("bstPts0_Save", best_pts_0);
        }

        if(ZPlayerPrefs.HasKey("bstPts1_Save"))
        {
            best_pts_1 = ZPlayerPrefs.GetInt("bstPts1_Save");
        } else
        {
            best_pts_1 = 0;
            ZPlayerPrefs.SetInt("bstPts1_Save", best_pts_1);
        }

        if(ZPlayerPrefs.HasKey("bstPts2_Save"))
        {
            best_pts_2 = ZPlayerPrefs.GetInt("bstPts2_Save");
        } else
        {
            best_pts_2 = 0;
            ZPlayerPrefs.SetInt("bstPts2_Save", best_pts_2);
        }


        // hangar naves
        if(ZPlayerPrefs.HasKey("hasSpeedy")) // speedy
        {
            naveSpeedy = ZPlayerPrefs.GetInt("hasSpeedy");
        } else
        {
            naveSpeedy = 0;
            ZPlayerPrefs.SetInt("hasSpeedy", naveSpeedy);
        }

        if(ZPlayerPrefs.HasKey("hasMG")) // MG
        {
            naveMG = ZPlayerPrefs.GetInt("hasMG");
        } else
        {
            naveMG = 0;
            ZPlayerPrefs.SetInt("hasMG", naveMG);
        }

        if(ZPlayerPrefs.HasKey("hasRay")) // Ray
        {
            naveRay = ZPlayerPrefs.GetInt("hasRay");
        } else
        {
            naveRay = 0;
            ZPlayerPrefs.SetInt("hasRay", naveRay);
        }

        if(ZPlayerPrefs.HasKey("hasMille")) // Millennium
        {
            naveMille = ZPlayerPrefs.GetInt("hasMille");
        } else
        {
            naveMille = 0;
            ZPlayerPrefs.SetInt("hasMille", naveMille);
        }

        // escolha do usuário
        if(ZPlayerPrefs.HasKey("naveEscolhida"))
        {
            naveEscolhida = ZPlayerPrefs.GetInt("naveEscolhida");
        } else
        {
            naveEscolhida = 0;
            ZPlayerPrefs.SetInt("naveEscolhida", naveEscolhida);
        }

        if(ZPlayerPrefs.HasKey("nivelEscolhido"))
        {
            nivelEscolhido = ZPlayerPrefs.GetInt("nivelEscolhido");
        } else
        {
            nivelEscolhido = 0;
            ZPlayerPrefs.SetInt("nivelEscolhido", nivelEscolhido);
        }
    }

#region salva moedas 
    public void UpdateScore()
    {
        moedas = ZPlayerPrefs.GetInt("moedasSave");
    }
    public void ColetaMoedas(int coin)
    {
        moedas += coin;
        SalvaMoedas(moedas);
    }

    public void PerdeMoedas(int coin)
    {
        moedas -= coin;
        SalvaMoedas(moedas);
    }

    public void SalvaMoedas(int coin)
    {
        ZPlayerPrefs.SetInt("moedasSave", coin);
        Acao_Botoes.inst.AttDinheiro();
    }
#endregion

#region salva naves
    public void SalvaNaves(int nave)
    {
        if(nave == 1)
        {
            ZPlayerPrefs.SetInt("hasSpeedy", 1);
        } else if(nave == 2)
        {
            ZPlayerPrefs.SetInt("hasMG", 1);
        } else if(nave == 3)
        {
            ZPlayerPrefs.SetInt("hasRay", 1);
        } else if(nave == 100)
        {
            ZPlayerPrefs.SetInt("hasMille", 1);
        }
    }

    public int RetornaNaves(int nave)
    {
        if(nave == 1)
        {
            return ZPlayerPrefs.GetInt("hasSpeedy");

        } else if(nave == 2)
        {
            return ZPlayerPrefs.GetInt("hasMG");

        } else if(nave == 3)
        {
            return ZPlayerPrefs.GetInt("hasRay");
        } else if(nave == 100)
        {
            return ZPlayerPrefs.GetInt("hasMille");
        } else
        {
            return 0;
        }
    }
#endregion

#region salva escolhas usuário
    public void SalvaNaveEscolhida(int nave)
    {
        ZPlayerPrefs.SetInt("naveEscolhida", nave);
    }

    public int RetornaNaveEscolhida()
    {
        return ZPlayerPrefs.GetInt("naveEscolhida");
    }

    public void SalvaNivelEscolhido(int nivel)
    {
        ZPlayerPrefs.SetInt("nivelEscolhido", nivel);
    }

    public int RetornaNivelEscolhido()
    {
        return ZPlayerPrefs.GetInt("nivelEscolhido");
    }
#endregion

}

