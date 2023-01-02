using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
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

    void Awake()
    {
        ZPlayerPrefs.Initialize("1196CX2000", "7311ChicoXavier");

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetScoreJogo()
    {
        ZPlayerPrefs.SetInt("qtdNukeSave", 1);
        ZPlayerPrefs.SetInt("qtdShieldSave", 1);
        ZPlayerPrefs.SetInt("qtdDoubleSave", 1);
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


        // qtd habilidades
        if(ZPlayerPrefs.HasKey("qtdNukeSave")) // nuke
        {
            qtdNuke = ZPlayerPrefs.GetInt("qtdNukeSave");
        } else
        {
            qtdNuke = 1;
            ZPlayerPrefs.SetInt("qtdNukeSave", qtdNuke);
        }

        if(ZPlayerPrefs.HasKey("qtdShieldSave")) // shield
        {
            qtdShield = ZPlayerPrefs.GetInt("qtdShieldSave");
        } else
        {
            qtdShield = 1;
            ZPlayerPrefs.SetInt("qtdShieldSave", qtdShield);
        }

        if(ZPlayerPrefs.HasKey("qtdDoubleSave")) // double
        {
            qtdDoubleTap = ZPlayerPrefs.GetInt("qtdDoubleSave");
        } else
        {
            qtdDoubleTap = 1;
            ZPlayerPrefs.SetInt("qtdDoubleSave", qtdDoubleTap);
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
    }
#endregion

#region salva habilidades // 0-Nuke // 1-Shield // 2-Double

    public void UpdateHabilidade()
    {
        qtdNuke = ZPlayerPrefs.GetInt("qtdNukeSave");
        qtdShield = ZPlayerPrefs.GetInt("qtdShieldSave");
        qtdDoubleTap = ZPlayerPrefs.GetInt("qtdDoubleSave");
    }

    public void GanhaHabilidade(int hab)
    {
        if(hab == 0)
        {
            qtdNuke ++;
            SalvaHabilidade(hab, qtdNuke);
        } 

        else if (hab == 1)
        {
            qtdShield ++;
            SalvaHabilidade(hab, qtdShield);
        } 

        else if(hab == 2)
        {
            qtdDoubleTap ++;
            SalvaHabilidade(hab, qtdDoubleTap);
        }
        
    }

    public void PerdeHabilidade(int hab)
    {
        if(hab == 0)
        {
            qtdNuke --;
            SalvaHabilidade(hab, qtdNuke);
        } 

        else if (hab == 1)
        {
            qtdShield --;
            SalvaHabilidade(hab, qtdShield);
        } 

        else if(hab == 2)
        {
            qtdDoubleTap --;
            SalvaHabilidade(hab, qtdDoubleTap);
        }
    }

    public void SalvaHabilidade(int hab, int qtd)
    {
        if(hab == 0)
        {
            ZPlayerPrefs.SetInt("qtdNukeSave", qtd);
        } 

        else if (hab == 1)
        {
            ZPlayerPrefs.SetInt("qtdShieldSave", qtd);
        } 

        else if(hab == 2)
        {
            ZPlayerPrefs.SetInt("qtdDoubleSave", qtd);
        }
        UpdateHabilidade();
    }
#endregion

#region retorna escolhas usuário

    public int RetornaNaveEscolhida()
    {
        return ZPlayerPrefs.GetInt("naveEscolhida");
    }

    public int RetornaNivelEscolhido()
    {
        return ZPlayerPrefs.GetInt("nivelEscolhido");
    }
#endregion

#region salva Best pontos
    public void SalvaPtsEasy(int pontos)
    {
        ZPlayerPrefs.SetInt("bstPts0_Save", pontos);
    }

    public void SalvaPtsMed(int pontos)
    {
        ZPlayerPrefs.SetInt("bstPts1_Save", pontos);
    }

    public void SalvaPtsHard(int pontos)
    {
        ZPlayerPrefs.SetInt("bstPts2_Save", pontos);
    }
#endregion

}
