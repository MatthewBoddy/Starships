using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine;

public class Player_Controll : MonoBehaviour
{
    static public Player_Controll inst;
    void Awake()
    {
        if(inst == null)
            inst = this;
    }

    //CONTROLE DO PLAYER
    public int Nave_Player;// 00 - Nave Inicial ## 03 - Última nave
    public float Player_Speed, Plyr_Rotat_Speed;
    public GameObject Naves;
    public Sprite sprtNaveIni;
    public Sprite sprtSpeedy;
    public Sprite sprtMG;
    public Sprite sprtRay;
    public Sprite sprtMille;

    //CONTROLE DOS INIMIGOS
    public GameObject[] Meteors, EnemyNave, EnemyAlien;
    public GameObject[] animExplosao;

    //CONTROLE DO TIRO
    public GameObject[] OndeSaiTiro;
    public GameObject[] Tiro;
    private float TempRest_Tiro;

    //CONTROLE DAS HABILIDADES
    public GameObject Shield;

    //CONTROLE DE ÁUDIO
    //public AudioClip[] clips;
    public AudioSource[] aud_Fire;
    public AudioSource aud_Shield;
    public AudioSource aud_Nuke;
    
    [SerializeField] private AudioSource aud_Double;
    [SerializeField] private AudioSource aud_Turbo;

    //CONSTANTS DE MOVIMENTO
    private struct PlayerInputConstants
    {
        public const string Horizontal = "Horizontal";
        public const string Vertical = "Vertical";
        public const string Nuke = "Nuke";
        public const string Shield = "Shield";
        public const string DoubleTap = "DoubleTap";
        public const string Turbo = "Turbo";
        public const string Fire = "Fire";
    }

    public void GetMovementInput()
    {
        //Input teclado
        float horizontalInput = Input.GetAxisRaw(PlayerInputConstants.Horizontal);
        float verticalInput = Input.GetAxisRaw(PlayerInputConstants.Vertical);
        //se o input do teclado for 0, tentamos o do celular
        if(Mathf.Approximately(horizontalInput, 0.0f))
        {
            horizontalInput = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Horizontal);
        }

        if(Mathf.Approximately(verticalInput, 0.0f))
        {
            verticalInput = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Vertical);
        }

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0.0f);
        transform.position = transform.position + movement * Player_Speed * Time.deltaTime;
        
        if(movement != Vector3.zero)
        {
            Quaternion paraRotacao = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, paraRotacao, Plyr_Rotat_Speed * Time.deltaTime);
        }
    }

    public void IsFireButtonDown()
    {
        
        bool IsKeyboardButtonDown = Input.GetKeyDown(KeyCode.Space);
        bool IsMobileButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.Fire);
        if(IsKeyboardButtonDown || IsMobileButtonDown)
        {
            if(HabilitaDisparo())
            {
                if(Nave_Player == 100)
                {
                    Instantiate(aud_Fire[1], transform.position, Quaternion.identity);
            
                    Instantiate(Tiro[1], new Vector3(OndeSaiTiro[0].transform.position.x, OndeSaiTiro[0].transform.position.y, 
                    OndeSaiTiro[0].transform.position.z), OndeSaiTiro[0].transform.rotation);

                    Instantiate(Tiro[1], new Vector3(OndeSaiTiro[1].transform.position.x, OndeSaiTiro[1].transform.position.y, 
                    OndeSaiTiro[1].transform.position.z), OndeSaiTiro[1].transform.rotation);

                } else if (Nave_Player == 1)
                { 
                    Instantiate(aud_Fire[2], transform.position, Quaternion.identity);
            
                    Instantiate(Tiro[0], new Vector3(OndeSaiTiro[0].transform.position.x, OndeSaiTiro[0].transform.position.y, 
                    OndeSaiTiro[0].transform.position.z), OndeSaiTiro[0].transform.rotation);

                } else if(Nave_Player == 2 || Nave_Player == 3)
                {
                    Instantiate(aud_Fire[3], transform.position, Quaternion.identity);
            
                    Instantiate(Tiro[0], new Vector3(OndeSaiTiro[0].transform.position.x, OndeSaiTiro[0].transform.position.y, 
                    OndeSaiTiro[0].transform.position.z), OndeSaiTiro[0].transform.rotation);

                } else if(Nave_Player == 0)
                {
                    Instantiate(aud_Fire[0], transform.position, Quaternion.identity);
            
                    Instantiate(Tiro[0], new Vector3(OndeSaiTiro[0].transform.position.x, OndeSaiTiro[0].transform.position.y, 
                    OndeSaiTiro[0].transform.position.z), OndeSaiTiro[0].transform.rotation);
                }
            }
        }
    }

    public void IsNukeButtonDown()
    {
        bool IsKeyboardButtonDown = Input.GetKeyDown(KeyCode.C);
        bool IsMobileButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.Nuke);
        if (IsKeyboardButtonDown || IsMobileButtonDown)
        {            
            HabilitaNuke();
        }
    }

    public void IsShieldButtonDown()
    {
        bool IsKeyboardButtonDown = Input.GetKeyDown(KeyCode.X);
        bool IsMobileButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.Shield);
        if (IsKeyboardButtonDown || IsMobileButtonDown)
        {
            HabilitaShield();
        }
    }

    public void IsDoubleTapButtonDown()
    {
        bool IsKeyboardButtonDown = Input.GetKeyDown(KeyCode.Z);
        bool IsMobileButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.DoubleTap);
        if (IsKeyboardButtonDown || IsMobileButtonDown)
        {
            HabilitaDouble();
        }
    }

    public void IsTurboButtonDown()
    {
        bool IsKeyboardButtonDown = Input.GetKeyDown(KeyCode.T);
        bool IsMobileButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.Turbo);
        if (IsKeyboardButtonDown || IsMobileButtonDown)
        {
            HabilitaTurbo();
        }
    }

    void Start()
    {
        int aux = ScoreManager.instance.RetornaNaveEscolhida();
        
        if(aux == 0)
        {
            AlteraNave(aux, 2.5f);

        } else if(aux == 1)
        {
            AlteraNave(aux, 3.5f);

        } else if(aux == 2)
        {
            AlteraNave(aux, 3f);

        } else if(aux == 3)
        {
            AlteraNave(aux, 3.9f);
        } else if(aux == 100)
        {
            AlteraNave(aux, 3.1f);
        }
        
    }

    void Update()
    {
        GetMovementInput();
        IsFireButtonDown();
        IsNukeButtonDown();
        IsShieldButtonDown();
        IsDoubleTapButtonDown();
        IsTurboButtonDown();

        TempRest_Tiro -= Time.deltaTime;
    }

    bool HabilitaDisparo() //repensar essa lógica
    {
        if(!Double_Controll.inst.DoubleHabilitado && Nave_Player != 100)
        {
            if(TempRest_Tiro <= 0 && Nave_Player == 0)
            {
                TempRest_Tiro = 0.5f;
                return true;
            } else if (TempRest_Tiro <= 0 && Nave_Player == 1)
            {
                TempRest_Tiro = 0.5f;
                return true;
            } else if(TempRest_Tiro <= 0 && Nave_Player == 2)
            {
                TempRest_Tiro = 0.3f;
                return true;
            } else if(TempRest_Tiro <= 0 && Nave_Player == 3)
            {
                TempRest_Tiro = 0.1f;
                return true;
            } else
                return false;
        } else
            return true;
        
    }

    void HabilitaNuke()
    {
        if(ScoreManager.instance.qtdNuke > 0)
        {
            ScoreManager.instance.PerdeHabilidade(0);

            Instantiate(aud_Nuke, transform.position, Quaternion.identity);
            
            DestroyAllEnemies();

            Camera_Segue.inst.CamShake(3.0f, 0.8f);
        }
    }

    void HabilitaShield()
    {
        if(ScoreManager.instance.qtdShield > 0)
        {
            ScoreManager.instance.PerdeHabilidade(1);

            Instantiate(aud_Shield, transform.position, Quaternion.identity);
            Shield.SetActive(true);
        }
    }

    void HabilitaDouble()
    {
        if(ScoreManager.instance.qtdDoubleTap > 0)
        {
            ScoreManager.instance.PerdeHabilidade(2);

            Instantiate(aud_Double, transform.position, Quaternion.identity);
            
            Double_Controll.inst.DoubleHabilitado = true;
        }
    }

    void HabilitaTurbo()
    {
        if(TurboControl.inst.habTurbo == false && TurboControl.inst.loadingTurbo == 10)
        {
            TurboControl.inst.ArmazenaVel(Player_Speed);

            Instantiate(aud_Turbo, transform.position, Quaternion.identity);

            TurboControl.inst.habTurbo = true;
        }
            
    }

    public void DestroyAllEnemies()    
    {
        Meteors = GameObject.FindGameObjectsWithTag ("Meteors");
        EnemyNave = GameObject.FindGameObjectsWithTag ("EnemyNave");
        EnemyAlien = GameObject.FindGameObjectsWithTag ("EnemyAlien");
     
        for(var i = 0 ; i < Meteors.Length ; i ++)
        {
            Destroy(Meteors[i]);
            Instantiate(animExplosao[0], new Vector2(Meteors[i].transform.position.x, Meteors[i].transform.position.y), Quaternion.identity);
        }

        for(var i = 0 ; i < EnemyNave.Length ; i ++)
        {
            Destroy(EnemyNave[i]);
            Instantiate(animExplosao[1], new Vector2(EnemyNave[i].transform.position.x, EnemyNave[i].transform.position.y), Quaternion.identity);
        }

        for(var i = 0 ; i < EnemyAlien.Length ; i ++)
        {
            Destroy(EnemyAlien[i]);
            Instantiate(animExplosao[1], new Vector2(EnemyAlien[i].transform.position.x, EnemyAlien[i].transform.position.y), Quaternion.identity);
        }
        
    }

    public void AlteraNave(int nave, float vel)
    {
        Nave_Player = nave;
        Player_Speed = vel;

        if(nave == 0) // nave inicial
        {
            Destroy(this.GetComponent<Collider2D>());
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprtNaveIni;
            this.gameObject.AddComponent<PolygonCollider2D>();

            Naves.transform.localScale = new Vector3(0.109f, 0.109f, 0f);
            Naves.transform.eulerAngles = Vector3.forward;

            OndeSaiTiro[0].transform.position = new Vector3(0.009202515f, -4f, 0f);

            Shield.transform.localScale = new Vector3(1.3f, 1.3f, 0f);
        }   
        else if (nave == 1) // nave speedy
        {
            Destroy(this.GetComponent<Collider2D>());
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprtSpeedy;
            this.gameObject.AddComponent<PolygonCollider2D>();

            Naves.transform.localScale = new Vector3(0.28f, 0.28f, 0f);
            Naves.transform.eulerAngles = Vector3.forward;

            OndeSaiTiro[0].transform.position = new Vector3(0.01292191f, -4f, 0f);

            Shield.transform.localScale = new Vector3(-0.43f, -0.43f, 0f);
        }
        else if (nave == 2) // nave MG
        {
            Destroy(this.GetComponent<Collider2D>());
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprtMG;
            this.gameObject.AddComponent<PolygonCollider2D>();

            Naves.transform.localScale = new Vector3(0.09f, 0.09f, 0f);
            Naves.transform.eulerAngles = Vector3.forward;

            OndeSaiTiro[0].transform.position = new Vector3(0.01292191f, -4f, 0f);

            Shield.transform.localScale = new Vector3(1.6f, 1.6f, 0f);
        }
        else if (nave == 3) // nave ray
        {
            Destroy(this.GetComponent<Collider2D>());
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprtRay;
            this.gameObject.AddComponent<PolygonCollider2D>();

            Naves.transform.localScale = new Vector3(0.10f, 0.1f, 0f);
            Naves.transform.eulerAngles = Vector3.forward;

            OndeSaiTiro[0].transform.position = new Vector3(0.01292191f, -4f, 0f);

            Shield.transform.localScale = new Vector3(1.9f, 1.9f, 0f);
        }
        else if (nave == 100) // nave Millennium
        {
            Destroy(this.GetComponent<Collider2D>());
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprtMille;
            this.gameObject.AddComponent<PolygonCollider2D>();

            Naves.transform.localScale = new Vector3(0.29f, 0.30f, 0f);
            Naves.transform.eulerAngles = Vector3.forward;

            OndeSaiTiro[0].transform.position = new Vector3(-0.15f, -4.05f, 0f);
            OndeSaiTiro[1].gameObject.SetActive(true);

            Shield.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
        }
    }
}
