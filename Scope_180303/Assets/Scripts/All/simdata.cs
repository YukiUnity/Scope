using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class simdata : MonoBehaviour {

    /*------------------------------------------------------------------*/
    //ゲームシステム用
    public const int N_EVENTS = 10;
    
    //チュートリアルイベント
    public static bool tutorialFlag = true;
    public static bool [] tutorialEventFlag = new bool [N_EVENTS];

    //ストーリーイベント
    public static bool st1Flag = false;
    public bool[] st1EventFlag = new bool[N_EVENTS];

    public bool st1EventFlagAA = false;
    public bool st1EventFlagBB = false;
    public bool st1EventFlagCC = false;


    public bool St2Flag = false;

    //180120イベント用
    
    //stSelect
    public CanvasGroup ActorCanvas;
    static public Transform DonnaSelect;
    static public Image FilomenaSlect;

    public CanvasGroup TextCanvas;

    public GameObject uiTextStSelect;

    //st0
    public CanvasGroup ActorCanvasSt0;
    public Image DonnaSt0;
    public Image FilomenaSt0;

    public CanvasGroup TextCanvasSt0;

    public GameObject uiTextSt0;

    /*------------------------------------------------------------------*/
    //1221 StageSelect リザルト用
    public static int stageResult = 0;

    public CanvasGroup EndCanvas;
    public Image EndPanel;
    public Text Rank;
    public Text Power;
    public Text Technique;
    public Text Speed;

    public CanvasRenderer EndTitle;

    //1222 リザルト計算用
    public float totalRank;
    public float totalPower;
    public float totalTechnique;
    public float totalSpeed;

    public int totalresultRank;
    public int totalresultPower;
    public int totalresultTechnique;
    public int totalresultSpeed;

    public static float currentPower;
    public static float currentTechnique;
    public static float currentSpeed;

    public float st0Power = 1;  //2クリティカル
    public float st0Technique = 20;  //20ダメージ
    public float st0Speed = 60; //5分

    public float st1Power = 1;  //2クリティカル
    public float st1Technique = 20;  //20ダメージ
    public float st1Speed = 300; //5分

    public static int stage_1 = 0;

    //1221追記
    public int rank = 0;
    public int power = 0;
    public int technique = 0;
    public int speed = 0;


    /*------------------------------------------------------------------*/
    //ゲームプレイ用変数群
    public System.Random r = new System.Random(100);


    public const int N_MAPS = 50;

    public SpriteRenderer MainSpriteRenderer;

    public Sprite Sprite0, Sprite1, Sprite2, Sprite3, Sprite4, Sprite5;

    /*静的変数で必要分宣言*/
    public static string ID;

    public int y = 0;
    public int x = 0;
    public int judgex = 0;

    public int max = 0;
    public int min = 0;

    public int mincount = 0;

    public static int[,] randomCantake = new int[N_MAPS, N_MAPS];
    public static int initTerCount = 0;
    public static int initTerSt1 = 500;

    public static int[,] CanTake2 = new int[N_MAPS, N_MAPS];
    public static int[,] AreaTake = new int[N_MAPS, N_MAPS];

    public static int[,] SavedCanTake = new int[N_MAPS, N_MAPS];
    public static int[,] DefaultCanTake = new int[N_MAPS, N_MAPS];

    //           待った用の配列                回数 / y軸 / x軸 = 当時の値を格納
    public static int returnX, returnY, returnCount = 1;
    public static int[][,] returnCanTake = new int[][,]
    {
       new int [N_MAPS,N_MAPS],
       new int [N_MAPS,N_MAPS],
       new int [N_MAPS,N_MAPS],
       new int [N_MAPS,N_MAPS],
       new int [N_MAPS,N_MAPS],
       new int [50,50],
       new int [50,50],
       new int [50,50],
       new int [50,50],
       new int [50,50],
       new int [50,50],
       new int [50,50],
       new int [50,50],
       new int [50,50],
    };
    public static int[][] returnCanTakeB = new int[][]
    {
       new int []{50,50},
       new int []{50,50},
       new int []{50,50},
       new int []{50,50},
       new int []{50,50},
       new int []{50,50},
       new int []{50,50},
       new int []{50,50},
       new int []{50,50},
       new int []{50,50},
       new int []{50,50},
       new int []{50,50},

    };

    public static int takeCount = 0;

    public static Vector2 FirstPoint = new Vector2(0, 0);
    public static Vector2 CurrentPoint = new Vector2(0, 0);
    public static Vector2 LastPoint = new Vector2(0, 0);

    public static int playerMaxHP = 100;
    public static int playerHP = 100;
    public static int enemyMaxHP = 100;
    public static int enemyHP = 100;
    public static int playerDamage = 0;
    public static int enemyDamage = 0;
    public static int playerDamageSave = 0;
    public static int enemyDamageSave = 0;

    public static float playerDamageAlpha = 0f;
    public static float enemyDamageAlpha = 0f;
    public static float playerDamage5s = 0f;
    public static float enemyDamage5s = 0f;

    public Image playerHPGage;
    public Image playerHPGageRed;
    public Image enemyHPGage;
    public Image enemyHPGageRed;

    public Text playerDamageText;
    public Text enemyDamageText;
    public CanvasRenderer playerDamageTextA;
    public CanvasRenderer enemyDamageTextA;


    /*同数値計算用*/
    public static int turnCount = 0;
    public int count = 0;
    public int score = 0;
    public int firstBall;


    public static int OnDrag = 0;

    public static bool RuleStart = true;
    public static int TurnCount = 0;
    public static int Who = 1;
    public static int RespondedType = 0;

    public static int Judge;

}
