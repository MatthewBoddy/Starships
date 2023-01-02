using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missoes : MonoBehaviour
{
    //VARIAVEIS - FACIL
    public Image img_E50F, img_E100F, img_E150F, img_E200F, img_E300F, img_E400F; 
    private int E50F, E100F, E150F, E200F, E300F, E400F;

    //VARIAVEIS - MEDIO
    public Image img_E50M, img_E100M, img_E150M, img_E200M, img_E300M, img_E400M;
    private int E50M, E100M, E150M, E200M, E300M, E400M;

    //VARIAVEIS - DIFICIL
    public Image img_E50D, img_E100D, img_E150D, img_E200D, img_E300D, img_E400D;
    private int E50D, E100D, E150D, E200D, E300D, E400D;

    //AUDIO
    public AudioSource aud_Compra;

    public static Missoes inst;
     void Awake()
    {
        ZPlayerPrefs.Initialize("1196CX2000", "7311ChicoXavier");
        
        if(inst == null)
        {
            inst = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        CarregaMissoes();
    }

    void Update()
    {
        
    }

    public void VerificaMissoes()
    {
        int best_pts_0 = ZPlayerPrefs.GetInt("bstPts0_Save");
        int best_pts_1 = ZPlayerPrefs.GetInt("bstPts1_Save");
        int best_pts_2 = ZPlayerPrefs.GetInt("bstPts2_Save");

        VerificaMissaoFacil(best_pts_0);
        VerificaMissaoMedio(best_pts_1);
        VerificaMissaoDificil(best_pts_2);
    }

    void CarregaMissoes()
    {
        CarregaMissaoFacil();
        CarregaMissaoMedio();
        CarregaMissaoDificil();
    }

    public void ClicaMissao(Image img)
    {
        if(img.color == Color.green)
        {
            img.color = Color.blue;
            ZPlayerPrefs.SetInt(img.name, 1);

            //fácil
            if(img.name == "E50F")
                ScoreManager.instance.ColetaMoedas(25);

            if(img.name == "E100F")
                ScoreManager.instance.ColetaMoedas(50);

            if(img.name == "E150F")
                ScoreManager.instance.ColetaMoedas(80);

            if(img.name == "E200F")
                ScoreManager.instance.ColetaMoedas(100);

            if(img.name == "E300F")
                ScoreManager.instance.ColetaMoedas(200);

            if(img.name == "E400F")
                ScoreManager.instance.ColetaMoedas(300);

            //médio
            if(img.name == "E50M")
                ScoreManager.instance.ColetaMoedas(50);

            if(img.name == "E100M")
                ScoreManager.instance.ColetaMoedas(100);

            if(img.name == "E150M")
                ScoreManager.instance.ColetaMoedas(150);

            if(img.name == "E200M")
                ScoreManager.instance.ColetaMoedas(200);

            if(img.name == "E300M")
                ScoreManager.instance.ColetaMoedas(300);

            if(img.name == "E400M")
                ScoreManager.instance.ColetaMoedas(400);

            //difícil
            if(img.name == "E50D")
                ScoreManager.instance.ColetaMoedas(70);

            if(img.name == "E100D")
                ScoreManager.instance.ColetaMoedas(120);

            if(img.name == "E150D")
                ScoreManager.instance.ColetaMoedas(180);

            if(img.name == "E200D")
                ScoreManager.instance.ColetaMoedas(250);

            if(img.name == "E300D")
                ScoreManager.instance.ColetaMoedas(380);

            if(img.name == "E400D")
                ScoreManager.instance.ColetaMoedas(500);
                
            Instantiate(aud_Compra, transform.position, Quaternion.identity);
        }
    }

    void VerificaMissaoFacil(int best_pts_0)
    {
        if(ZPlayerPrefs.GetInt("E50F")==1)
        {
            img_E50F.color = Color.blue;
        } else if(best_pts_0 >= 50)
        {
            img_E50F.color = Color.green;
        }

        if(ZPlayerPrefs.GetInt("E100F")==1)
        {
            img_E100F.color = Color.blue;
        } else if(best_pts_0 >= 100)
        {
            img_E100F.color = Color.green;
        }

        if(ZPlayerPrefs.GetInt("E150F")==1)
        {
            img_E150F.color = Color.blue;
        } else if(best_pts_0 >= 150)
        {
            img_E150F.color = Color.green;
        }

        if(ZPlayerPrefs.GetInt("E200F")==1)
        {
            img_E200F.color = Color.blue;
        } else if(best_pts_0 >= 200)
        {
            img_E200F.color = Color.green;
        }

        if(ZPlayerPrefs.GetInt("E300F")==1)
        {
            img_E300F.color = Color.blue;
        } else if(best_pts_0 >= 300)
        {
            img_E300F.color = Color.green;
        }

        if(ZPlayerPrefs.GetInt("E400F")==1)
        {
            img_E400F.color = Color.blue;
        } else if(best_pts_0 >= 400)
        {
            img_E400F.color = Color.green;
        }
    }

    void VerificaMissaoMedio(int best_pts_1)
    {
        if(ZPlayerPrefs.GetInt("E50M")==1)
        {
            img_E50M.color = Color.blue;
        } else if(best_pts_1 >= 50)
        {
            img_E50M.color = Color.green;
        }

        if(ZPlayerPrefs.GetInt("E100M")==1)
        {
            img_E100M.color = Color.blue;
        } else if(best_pts_1 >= 100)
        {
            img_E100M.color = Color.green;
        }

        if(ZPlayerPrefs.GetInt("E150M")==1)
        {
            img_E150M.color = Color.blue;
        } else if(best_pts_1 >= 150)
        {
            img_E150M.color = Color.green;
        }

        if(ZPlayerPrefs.GetInt("E200M")==1)
        {
            img_E200M.color = Color.blue;
        } else if(best_pts_1 >= 200)
        {
            img_E200M.color = Color.green;
        }

        if(ZPlayerPrefs.GetInt("E300M")==1)
        {
            img_E300M.color = Color.blue;
        } else if(best_pts_1 >= 300)
        {
            img_E300M.color = Color.green;
        }

        if(ZPlayerPrefs.GetInt("E400M")==1)
        {
            img_E400M.color = Color.blue;
        } else if(best_pts_1 >= 400)
        {
            img_E400M.color = Color.green;
        }
    }

    void VerificaMissaoDificil(int best_pts_2)
    {
        if(ZPlayerPrefs.GetInt("E50D")==1)
        {
            img_E50D.color = Color.blue;
        } else if(best_pts_2 >= 50)
        {
            img_E50D.color = Color.green;
        }

        if(ZPlayerPrefs.GetInt("E100D")==1)
        {
            img_E100D.color = Color.blue;
        } else if(best_pts_2 >= 100)
        {
            img_E100D.color = Color.green;
        }

        if(ZPlayerPrefs.GetInt("E150D")==1)
        {
            img_E150D.color = Color.blue;
        } else if(best_pts_2 >= 150)
        {
            img_E150D.color = Color.green;
        }

        if(ZPlayerPrefs.GetInt("E200D")==1)
        {
            img_E200D.color = Color.blue;
        } else if(best_pts_2 >= 200)
        {
            img_E200D.color = Color.green;
        }

        if(ZPlayerPrefs.GetInt("E300D")==1)
        {
            img_E300D.color = Color.blue;
        } else if(best_pts_2 >= 300)
        {
            img_E300D.color = Color.green;
        }

        if(ZPlayerPrefs.GetInt("E400D")==1)
        {
            img_E400D.color = Color.blue;
        } else if(best_pts_2 >= 400)
        {
            img_E400D.color = Color.green;
        }
    }

    void CarregaMissaoFacil()
    {
        if(ZPlayerPrefs.HasKey("E50F"))
        {
            E50F = ZPlayerPrefs.GetInt("E50F");
        } else 
        {
            E50F = 0;
            ZPlayerPrefs.SetInt("E50F", 0);
        }

        if(ZPlayerPrefs.HasKey("E100F"))
        {
            E100F = ZPlayerPrefs.GetInt("E100F");
        } else 
        {
            E100F = 0;
            ZPlayerPrefs.SetInt("E100F", 0);
        }

        if(ZPlayerPrefs.HasKey("E150F"))
        {
            E150F = ZPlayerPrefs.GetInt("E150F");
        } else 
        {
            E150F = 0;
            ZPlayerPrefs.SetInt("E150F", 0);
        }

        if(ZPlayerPrefs.HasKey("E200F"))
        {
            E200F = ZPlayerPrefs.GetInt("E200F");
        } else 
        {
            E200F = 0;
            ZPlayerPrefs.SetInt("E200F", 0);
        }

        if(ZPlayerPrefs.HasKey("E300F"))
        {
            E300F = ZPlayerPrefs.GetInt("E300F");
        } else 
        {
            E300F = 0;
            ZPlayerPrefs.SetInt("E300F", 0);
        }

        if(ZPlayerPrefs.HasKey("E400F"))
        {
            E400F = ZPlayerPrefs.GetInt("E400F");
        } else 
        {
            E400F = 0;
            ZPlayerPrefs.SetInt("E400F", 0);
        }
    }

    void CarregaMissaoMedio()
    {
        if(ZPlayerPrefs.HasKey("E50M"))
        {
            E50M = ZPlayerPrefs.GetInt("E50M");
        } else 
        {
            E50M = 0;
            ZPlayerPrefs.SetInt("E50M", 0);
        }

        if(ZPlayerPrefs.HasKey("E100M"))
        {
            E100M = ZPlayerPrefs.GetInt("E100M");
        } else 
        {
            E100M = 0;
            ZPlayerPrefs.SetInt("E100M", 0);
        }

        if(ZPlayerPrefs.HasKey("E150M"))
        {
            E150M = ZPlayerPrefs.GetInt("E150M");
        } else 
        {
            E150M = 0;
            ZPlayerPrefs.SetInt("E150M", 0);
        }

        if(ZPlayerPrefs.HasKey("E200M"))
        {
            E200M = ZPlayerPrefs.GetInt("E200M");
        } else 
        {
            E200M = 0;
            ZPlayerPrefs.SetInt("E200M", 0);
        }

        if(ZPlayerPrefs.HasKey("E300M"))
        {
            E300M = ZPlayerPrefs.GetInt("E300M");
        } else 
        {
            E300M = 0;
            ZPlayerPrefs.SetInt("E300M", 0);
        }

        if(ZPlayerPrefs.HasKey("E400M"))
        {
            E400M = ZPlayerPrefs.GetInt("E400M");
        } else 
        {
            E400M = 0;
            ZPlayerPrefs.SetInt("E400M", 0);
        }
    }

    void CarregaMissaoDificil()
    {
        if(ZPlayerPrefs.HasKey("E50D"))
        {
            E50D = ZPlayerPrefs.GetInt("E50D");
        } else 
        {
            E50D = 0;
            ZPlayerPrefs.SetInt("E50D", 0);
        }

        if(ZPlayerPrefs.HasKey("E100D"))
        {
            E100D = ZPlayerPrefs.GetInt("E100D");
        } else 
        {
            E100D = 0;
            ZPlayerPrefs.SetInt("E100D", 0);
        }

        if(ZPlayerPrefs.HasKey("E150D"))
        {
            E150D = ZPlayerPrefs.GetInt("E150D");
        } else 
        {
            E150D = 0;
            ZPlayerPrefs.SetInt("E150D", 0);
        }

        if(ZPlayerPrefs.HasKey("E200D"))
        {
            E200D = ZPlayerPrefs.GetInt("E200D");
        } else 
        {
            E200D = 0;
            ZPlayerPrefs.SetInt("E200D", 0);
        }

        if(ZPlayerPrefs.HasKey("E300D"))
        {
            E300D = ZPlayerPrefs.GetInt("E300D");
        } else 
        {
            E300D = 0;
            ZPlayerPrefs.SetInt("E300D", 0);
        }

        if(ZPlayerPrefs.HasKey("E400D"))
        {
            E400D = ZPlayerPrefs.GetInt("E400D");
        } else 
        {
            E400D = 0;
            ZPlayerPrefs.SetInt("E400D", 0);
        }
    }

    void ResetaMissaoFacil()
    {
        ZPlayerPrefs.SetInt("E50F", 0);
        ZPlayerPrefs.SetInt("E100F", 0);
        ZPlayerPrefs.SetInt("E150F", 0);
        ZPlayerPrefs.SetInt("E200F", 0);
        ZPlayerPrefs.SetInt("E300F", 0);
        ZPlayerPrefs.SetInt("E400F", 0);
    }

    void ResetaMissaoMedio()
    {
        ZPlayerPrefs.SetInt("E50M", 0);
        ZPlayerPrefs.SetInt("E100M", 0);
        ZPlayerPrefs.SetInt("E150M", 0);
        ZPlayerPrefs.SetInt("E200M", 0);
        ZPlayerPrefs.SetInt("E300M", 0);
        ZPlayerPrefs.SetInt("E400M", 0);
    }

    void ResetMissaoDificil()
    {
        ZPlayerPrefs.SetInt("E50D", 0);
        ZPlayerPrefs.SetInt("E100D", 0);
        ZPlayerPrefs.SetInt("E150D", 0);
        ZPlayerPrefs.SetInt("E200D", 0);
        ZPlayerPrefs.SetInt("E300D", 0);
        ZPlayerPrefs.SetInt("E400D", 0);
    }

    public void ResetMissoes()
    {
        ResetaMissaoFacil();
        ResetaMissaoMedio();
        ResetMissaoDificil();
    }
}
