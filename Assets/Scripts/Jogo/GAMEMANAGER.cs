using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class GAMEMANAGER : MonoBehaviour
{
    public static GAMEMANAGER inst;
     void Awake()
    {
        if(inst == null)
        {
            inst = this;
            //DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
    //VARIÁVEIS DE CONTROLE
    public bool gameover;
    public bool pause;
    public int habRewardedVid;
    [SerializeField] private int GameLevel;

    //PAINEIS
    [SerializeField] private Image introducao;
    [SerializeField] private RectTransform goGameOver;
    private GameObject goPause;
    private GameObject goMainCanvas;

    //BOTÕES
    public GameObject btnRewardedVideo;
    private Button btn_denovo;
    private Button btn_pause;
    public Sprite imgPlay;
    public Sprite imgPause;
    
    
    //PONTUAÇÃO
    [SerializeField] private Text Pontuacao;
    [SerializeField] private Text PtsFinais;
    [SerializeField] private Text BestPts;
    public int pts_partida;

    //CONTAINERS
    public GameObject container1, container2;

    //MÚSICAS
    public AudioClip[] clips;
    public AudioSource musicBG;

    void PegaDados()
    {
        container2 = GameObject.FindWithTag("uicena");

        //UI
        goPause = container2.transform.GetChild(0).GetChild(1).gameObject;
        btn_denovo = container2.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Button>();
        btn_pause = container2.transform.GetChild(0).GetChild(2).GetComponent<Button>();
        goMainCanvas = container2.transform.GetChild(1).gameObject;

        //event
        btn_denovo.onClick.AddListener(JogarNovamente);
        btn_pause.onClick.AddListener(AbrePause);
    }

    void Start()
    {
        ScoreManager.instance.GameStartScoreM();
        GameLevel = ScoreManager.instance.RetornaNivelEscolhido();

        PegaDados();

        PausaJogo();  
        AbrePause();

        UpdateMusic();  
        
        AtivaIntroducao();
    }

    void Update()
    {
        ScoreManager.instance.UpdateScore();
        UIManager.instance.UpdateUI();
        
        AtualizaPontos();

        if(gameover)
        {
            FimDeJogo();
        }
    }

    void FimDeJogo()
    {
        musicBG.Pause();
        pause = true; //para as rotinas e os Follow dos inimigos
        btn_pause.enabled = false;

        PtsFinais.text = pts_partida.ToString(); // tranfere a pontuação final para o TextUI

        SalvaBestPts();

        AppodealCodBanner.inst.ShowBanner(); // chama a propaganda

        goGameOver.gameObject.SetActive(true); // ativa o painel de Game Over
        goGameOver.DOScale(new Vector3(1f, 1f, 1f), 2); // animação do Game Over

        gameover=false; // variável controladora para não ficar repetindo

        if(habRewardedVid < 2)
            btnRewardedVideo.SetActive(true);
        else
            btnRewardedVideo.SetActive(false);
    }

    void JogarNovamente()
    {
        goGameOver.DOPause();
        Reinicia();
        SceneManager.LoadScene(1);
    }

    void Reinicia()
    {
        gameover = false;
        GameLevel = ScoreManager.instance.RetornaNivelEscolhido();
        goGameOver.gameObject.SetActive(false);
    }

    void UpdateMusic()
    {
        if(GameLevel == 0)
        {
            if(ScoreManager.instance.RetornaNaveEscolhida() == 100)
            {
                if(!musicBG.isPlaying)
                {
                    musicBG.clip = clips[3];
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

        } else if (GameLevel == 1)
        {
            if(ScoreManager.instance.RetornaNaveEscolhida() == 100)
            {
                if(!musicBG.isPlaying)
                {
                    musicBG.clip = clips[4];
                    musicBG.Play();
                }
            } else
            {
                if(!musicBG.isPlaying)
                {
                    musicBG.clip = clips[1];
                    musicBG.Play();
                }
            }
        } else if (GameLevel == 2)
        {
            if(ScoreManager.instance.RetornaNaveEscolhida() == 100)
            {
                if(!musicBG.isPlaying)
                {
                    musicBG.clip = clips[4];
                    musicBG.Play();
                }
            } else
            {
                if(!musicBG.isPlaying)
                {
                    musicBG.clip = clips[2];
                    musicBG.Play();
                }
            }
        }
    }

    void AtualizaPontos()
    {
        Pontuacao.text = pts_partida.ToString();
    }

    void AbrePause()
    {
        if(!goPause.gameObject.activeSelf)
        {
            PausaJogo();
            goPause.gameObject.SetActive(true);
            AppodealCodBanner.inst.ShowBannerBottom();
        }
        else
        {
            DesPausaJogo();
            goPause.gameObject.SetActive(false);
            AppodealCodBanner.inst.HideBannerBottom();
        }
    }

    void PausaJogo()
    {
        pause=true;
        btn_pause.image.sprite = imgPlay;
        musicBG.Pause();
    }

    void DesPausaJogo()
    {
        btn_pause.image.sprite = imgPause;
        pause=false;
        musicBG.UnPause();
    }

    void SalvaBestPts()
    {
        if(GameLevel == 0)
        {
            BestPts.text = ScoreManager.instance.best_pts_0.ToString(); // tranfere a melhor pontuação daquele nível para o TextUI
            
            if(pts_partida > ScoreManager.instance.best_pts_0)
                ScoreManager.instance.SalvaPtsEasy(pts_partida); // Salva a melhor pontuação

        } else if(GameLevel == 1)
        {
            BestPts.text = ScoreManager.instance.best_pts_1.ToString();

            if(pts_partida > ScoreManager.instance.best_pts_1)
                ScoreManager.instance.SalvaPtsMed(pts_partida);

        } else if(GameLevel == 2)
        {
            BestPts.text = ScoreManager.instance.best_pts_2.ToString();

            if(pts_partida > ScoreManager.instance.best_pts_2)
                ScoreManager.instance.SalvaPtsHard(pts_partida);
        }
    }

    public void SalvaPtsAtualJogo()
    {
        if(GameLevel == 0)
        {
            if(pts_partida > ScoreManager.instance.best_pts_0)
                {ScoreManager.instance.SalvaPtsEasy(pts_partida);
                Debug.Log("Salvo facil");
                } // Salva a melhor pontuação

        } else if(GameLevel == 1)
        {
            if(pts_partida > ScoreManager.instance.best_pts_1)
            {
                ScoreManager.instance.SalvaPtsMed(pts_partida);
                Debug.Log("Salvo medio");
            }

        } else if(GameLevel == 2)
        {
            if(pts_partida > ScoreManager.instance.best_pts_2)
            {
                ScoreManager.instance.SalvaPtsHard(pts_partida);
                Debug.Log("Salvo dificil");
            }
        }
    }

    public void ClickRewardedVideo()
    {
        AppodealCodBanner.inst.ShowRewarded();
    }

    public void RecompensaAd()
    {
        habRewardedVid++;
        goGameOver.gameObject.SetActive(false);
        BarraVidaPlayer.inst.MaisVidas();
        BarraVidaPlayer.inst.gameObject.SetActive(true);
        btn_pause.enabled = true;

        Player_Controll.inst.DestroyAllEnemies();
        Player_Controll.inst.Naves.transform.position = new Vector3(0f, 0f, 0f);

        AbrePause();
    }
    void AtivaIntroducao()
    {
        introducao.gameObject.SetActive(true);
    }
}

