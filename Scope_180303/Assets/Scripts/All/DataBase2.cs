using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataBase2 : simdata
{
    
    void Start()
    {
        //1216追記
        InitHPGage();

        for (int y = 0; y <= 10; y++)
        {
            for (int x = 0; x <= 10; x++)
            {
                randomCantake[y, x] = r.Next(3) ;
            }
        }

        for (int y = 0; y <= 10; y++)
        {
            for (int x = 0; x <= 10; x++)
            {
                if (initTerCount <= initTerSt1)
                {
                    switch (randomCantake[y, x])
                    {
                        case (0):
                            AreaTake[y, x] = 0;
                            break;
                        case (1):
                            AreaTake[y, x] = 3;
                            initTerCount++;
                            break;
                        case (2):
                            AreaTake[y, x] = 1;
                            initTerCount++;
                            break;
                    }
                }

                else
                {
                    AreaTake[y, x] = 0;
                }
            }
        }

        for (int y = 0; y <= 10; y++)
        {
            for (int x = 0; x <= 10; x++)
            {
                returnCanTake[1][y, x] = CanTake2[y, x];
            }
        }

    }

    void InitHPGage()
    {
        playerHPGage = GameObject.Find("playerHPGage").GetComponent<Image>();
        playerHPGage.fillAmount = 1;

        playerHPGageRed = GameObject.Find("playerHPGageRed").GetComponent<Image>();
        playerHPGageRed.fillAmount = 1;

        playerDamageText = GameObject.Find("playerDamageText").GetComponent<Text>();
        playerDamageText.text = playerDamageSave.ToString() + " Damage";

        playerDamageTextA = GameObject.Find("playerDamageText").GetComponent<CanvasRenderer>();
        playerDamageTextA.SetAlpha(0f);

        enemyHPGage = GameObject.Find("enemyHPGage").GetComponent<Image>();
        enemyHPGage.fillAmount = 1;

        enemyHPGageRed = GameObject.Find("enemyHPGageRed").GetComponent<Image>();
        enemyHPGageRed.fillAmount = 1;

        enemyDamageText = GameObject.Find("enemyDamageText").GetComponent<Text>();
        enemyDamageText.text = enemyDamageSave.ToString() + " Damage";

        enemyDamageTextA = GameObject.Find("enemyDamageText").GetComponent<CanvasRenderer>();
        enemyDamageTextA.SetAlpha(0f);



        /*EndCanvas = GameObject.Find("EndCanvas").GetComponent<CanvasGroup>();
        EndCanvas.alpha = 1; */
    }

    void endScene()
    {
        stageResult = 1;

        SceneManager.LoadScene("StageSelect");
    }

    /*--------------------------------ジャッジ用-----------------------------------------------*/
    void checkJudge()
    {

        //陣取り判定、Judgeリセット

        if (Judge == 1)
        {
            Debug.Log("Judge Start");

            //最小値、最大値を計算し、陣取り
            for (int y = 0; y < N_MAPS; y++)
            {
                for (int x = 0; x < N_MAPS; x++)
                {
                    //現y軸で、2の値を見つけた場合
                    if (CanTake2[y, x] == 2)
                    {
                        //現y軸で初めてのxを記録
                        if (mincount == 0)
                        {
                            min = x;
                            mincount = 1;

                        }

                        //最大値を記録
                        if (x >= max)
                        {
                            max = x;
                        }

                        //イレギュラーの最小値を記録
                        if (x <= min)
                        {
                            min = x;
                        }

                    }

                }

                //1216追記
                if (y % 2 == 0)
                {
                    //現y軸の面をひっくり返す
                    for (judgex = min + 1; judgex <= max; judgex++)
                    {
                        if (AreaTake[y, (int)judgex] == 0)
                        {
                            //1215変更
                            AreaTake[y, (int)judgex] = 2;
                            count++;
                            enemyDamage += 10;
                            /*

                            if (AreaTake[y, judgex] == 5)
                           {

                            Damage();

                        　　エリア側で自身が5の値でひっくり返ったのを確認した場合、Damageの値を入力する

                          　write("Damage = &n, Damage")

                            (HP - Damage;)

                            エリアから入力されていたダメージをリセット
                            Damage = 0;

                            }
                             */
                        }
                        //1223変更
                        if (AreaTake[y, (int)judgex] == 1)
                        {
                            AreaTake[y, (int)judgex] = 2;
                            count++;
                            enemyDamage += 20;
                            currentPower++;
                        }

                        if (AreaTake[y, (int)judgex] == 3)
                        {
                            //1215変更
                            AreaTake[y, (int)judgex] = 2;
                            count++;
                            playerDamage += 20;
                            currentTechnique += 20f;
                        }
                    }
                }
                //エッジもひっくり返す
                for (int judgex = min; judgex <= max; judgex++)
                {
                    if (CanTake2[y, judgex] == 1)
                    {
                        CanTake2[y, judgex] = 0;
                        count++;
                    }

                    //1215追記
                    if (CanTake2[y, judgex] == 2)
                    {
                        CanTake2[y, judgex] = 0;
                        count++;
                    }
                }

                //ジャッジ終了後値を初期化
                DataBase2.CurrentPoint.y = N_MAPS;
                DataBase2.CurrentPoint.x = N_MAPS;
                FirstPoint.y = N_MAPS;
                FirstPoint.x = N_MAPS;
                LastPoint.y = N_MAPS;
                LastPoint.x = N_MAPS;
                returnCount = 1;
               


                //現y軸の処理終了後、数値初期化
                max = 0;
                min = 0;
                mincount = 0;

            }

            //判定終了後 1 の場所を初期化
            for (int y = 0; y <= 10; y++)
            {
                for (int x = 0; x <= 10; x++)
                {
                    if (CanTake2[y, x] == 1)
                    {
                        CanTake2[y, x] = 0;
                    }


                }
            }

            count = 0;
            score = 0;
            Judge = 0;

            /*
            for (y = 0; y <= 10; y++)
            {
                for (x = 0; x <= 10; x++)
                {
                    //現y軸で、2の値を見つけた場合

                    if (CanTake2[y, x] == 2)
                    {
                        CanTake2[y, x] = 3;

                    }

                }
            }
            */


            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j < N_MAPS; j++)
                {
                    for (int k = 0; k < N_MAPS; k++)
                    {
                        returnCanTake[i][j, k] = 0;

                    }
                }
            }

            dealDamage();
        }
    }

    void dealDamage()
    {
        playerDamage5s = 0;
        enemyDamage5s = 0;
        //味方へのダメージ
        playerDamageSave = playerDamage;
        playerHP -= playerDamage;
        if (playerDamage > 0)
        {
            playerDamageAlpha = 1;
            playerDamageTextA.SetAlpha(playerDamageAlpha);
        }
        //敵へのダメージ
        enemyDamageSave = enemyDamage;
        enemyHP -= enemyDamage;
        if (enemyDamage > 0)
        {
            enemyDamageAlpha = 1;
            enemyDamageTextA.SetAlpha(enemyDamageAlpha);
        }
        //ダメージ値リセット
        playerDamage = 0;
        enemyDamage = 0;
        Debug.Log(enemyHP);
    }

    /*------------------------------------------------------------------------------------*/
    public static void clickPoint(int y, int x)
    {
        int ya = 0;
        int xa = 0;

        ya = y;
        xa = x;

        //クリックされた際、未取得なら自らを"2"に

        if (CanTake2[ya, xa] == 0)
        {


            //バックアップ保存
            for (y = 0; y <= 10; y++)
            {
                for (x = 0; x <= 10; x++)
                {
                    DefaultCanTake[y, x] = CanTake2[y, x];
                    
                    //1215追記
                    returnCanTake[returnCount][y, x] = CanTake2[y, x];
                }
            }

            CanTake2[ya, xa] = 2;

            //初期座標入力

            FirstPoint.y = ya;
            FirstPoint.x = xa;

            CurrentPoint.y = ya;
            CurrentPoint.x = xa;

            returnCanTakeB[returnCount][0] = (int)CurrentPoint.y;
            returnCanTakeB[returnCount][1] = (int)CurrentPoint.x;

            //クリックされた際、周囲の辺を"1"に

            for (y = ya - 1; y <= ya + 1; y++)
            {
                for (x = xa - 1; x < xa + 1; x++)
                {
                    if (CanTake2[y, x] == 0)
                    {
                        CanTake2[y, x] = 1;
                    }

                }
            }

            if (CanTake2[ya, xa + 1] == 0)
            {
                CanTake2[ya, xa + 1] = 1;
            }
        }

    }

    public static void enterPoint(int y, int x)
    {
        int ya = 0;
        int xa = 0;
        int y2 = 0;
        int x2 = 0;
        int resety = 0;
        int resetx = 0;

        ya = y;
        xa = x;

        int currentY = 0;
        int currentX = 0;

        /*----------------------------------------------"待った"判定-------------------------------------------------*/
        //1215追記　待ったの値を計算する

        Debug.Log(returnCount);

        //3次元→2次元はジャグ配列を使うと解決？http://bbs.wankuma.com/index.cgi?mode=al2&namber=75399&KLOG=127
        //1215　座標値専用
        returnY = returnCanTakeB[returnCount-1][0];
        returnX = returnCanTakeB[returnCount-1][1];

        //LastPointの時
        if (ya == returnY && xa == returnX)
        {
            //FirstPointの場合、全てリセット
            if (DataBase2.FirstPoint.y == ya && DataBase2.FirstPoint.x == xa)
            {
                for (y = 0; y <= 10; y++)
                {
                    for (x = 0; x <= 10; x++)
                    {
                        DataBase2.CanTake2[y, x] = DataBase2.DefaultCanTake[y, x];

                        DataBase2.CurrentPoint.y = N_MAPS;
                        DataBase2.CurrentPoint.x = N_MAPS;
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < N_MAPS; j++)
                            {
                                for ( int k = 0; k < N_MAPS; k++)
                                {
                                    //1215追記

                                    returnCanTake[i][j, k] = 0;
                                    

                                }
                            }
                        }

                        returnCount = 1;
                    }
                }
            }

            //FirstPointではない場合１つ前にもどる
            else
            {
                for (y = 0; y <= 10; y++)
                {
                    for (x = 0; x <= 10; x++)
                    {
                        //1215追記
                        CanTake2[y, x] = returnCanTake[returnCount - 1][y, x];


                        returnCanTake[returnCount][y, x] = 0;

                        DataBase2.CurrentPoint.y = ya;
                        DataBase2.CurrentPoint.x = xa;
                    }
                }

                returnCount -= 1;
                Debug.Log(returnCount);
            }


        }
        
        /*
        //LastPointの場合、待った実行
        if (DataBase2.LastPoint.y == ya && DataBase2.LastPoint.x == xa)
        {
            //FirstPointの場合、全てリセット
            if (DataBase2.FirstPoint.y == ya && DataBase2.FirstPoint.x == xa)
            {
                for (y = 0; y <= 10; y++)
                {
                    for (x = 0; x <= 10; x++)
                    {
                        DataBase2.CanTake2[y, x] = DataBase2.DefaultCanTake[y, x];

                        DataBase2.CurrentPoint.y = N_MAPS;
                        DataBase2.CurrentPoint.x = N_MAPS;
                    }
                }

            }
            
            //FirstPointではない場合１つ前にもどる
            else
            {
                for (y = 0; y <= 10; y++)
                {
                    for (x = 0; x <= 10; x++)
                    {

                        DataBase2.CanTake2[y, x] = DataBase2.SavedCanTake[y, x];

                        DataBase2.CurrentPoint.y = ya;
                        DataBase2.CurrentPoint.x = xa;

                    }
                }
            }
            
        }
        */

 /*-----------------------------”待った”以外------------------------------------*/

        else
        {
            if (DataBase2.CanTake2[ya, xa] == 2)
            {

                //ジャッジするか判定
                if (DataBase2.FirstPoint.y == ya && DataBase2.FirstPoint.x == xa)
                {

                    if (CurrentPoint.y == ya && CurrentPoint.x == xa)
                    {
                    }

                    else
                    { 
                        if (DataBase2.CanTake2[ya, xa + 1] == 1)
                        {
                            DataBase2.CanTake2[ya, xa] = 2;
                            DataBase2.CanTake2[ya, xa + 1] = 2;
                        }

                        else
                        {
                            for (y = ya - 1; y <= ya + 1; y++)
                            {
                                for (x = xa - 1; x <= xa; x++)
                                {
                                    if (y == ya && x == xa)
                                    { }

                                    else
                                    {

                                        if (DataBase2.CanTake2[y, x] == 1)
                                        {
                                            DataBase2.CanTake2[ya, xa] = 2;
                                            DataBase2.CanTake2[y, x] = 2;


                                        }

                                    }
                                }
                            }

                        }


                        //現在地入力

                        DataBase2.CurrentPoint.y = 0;
                        DataBase2.CurrentPoint.x = 0;

                        DataBase2.Judge = 1;
                        Debug.Log("Hello");
                    }

                }
            }



            // 点が１かつ、周りの辺のどれかが取得可能なら、点を２に
            // 該当辺を２に
            // 周囲の辺を1に

            if (DataBase2.CanTake2[ya, xa] == 1)
            {
                //1215追記
                returnCanTakeB[returnCount][0] = (int)CurrentPoint.y;
                returnCanTakeB[returnCount][1] = (int)CurrentPoint.x;

                //バックアップ保存
                for (y = 0; y <= 10; y++)
                {
                    for (x = 0; x <= 10; x++)
                    {
                        DataBase2.SavedCanTake[y, x] = DataBase2.CanTake2[y, x];
                        returnCanTake[returnCount][y, x] = CanTake2[y, x];
                    }

                }
                returnCount++;
                Debug.Log(returnCount);

                //右横が 1 なら点を 2 に
                if (DataBase2.CanTake2[ya, xa + 1] == 1)
                {
                    DataBase2.CanTake2[ya, xa] = 2;
                    DataBase2.CanTake2[ya, xa + 1] = 2;

                    //現在地
                    DataBase2.CurrentPoint.y = ya;
                    DataBase2.CurrentPoint.x = xa;
                }

                //周囲のどれかが 1 なら、点を 2 に
                else
                {

                    for (y = ya - 1; y <= ya + 1; y++)
                    {
                        for (x = xa - 1; x <= xa; x++)
                        {
                            if (y == ya && x == xa)
                            { }

                            else
                            {

                                if (DataBase2.CanTake2[y, x] == 1)
                                {
                                    DataBase2.CanTake2[ya, xa] = 2;
                                    DataBase2.CanTake2[y, x] = 2;

                                    //現在地
                                    DataBase2.CurrentPoint.y = ya;
                                    DataBase2.CurrentPoint.x = xa;

                                }

                            }
                        }
                    }

                }

                //1215追記　周りの辺を 1 に
                if (DataBase2.CanTake2[ya, xa + 1] == 0)
                {
                    DataBase2.CanTake2[ya, xa + 1] = 1;
                }

                for (y2 = ya - 1; y2 <= ya + 1; y2++)
                {
                    for (x2 = xa - 1; x2 <= xa; x2++)
                    {
                        if (DataBase2.CanTake2[y2, x2] == 0)
                        {
                            DataBase2.CanTake2[y2, x2] = 1;
                        }

                    }
                }

                //1215追記　3 の場合 1 に
                if (DataBase2.CanTake2[ya, xa + 1] == 3)
                {
                    DataBase2.CanTake2[ya, xa + 1] = 1;
                }

                for (y2 = ya - 1; y2 <= ya + 1; y2++)
                {
                    for (x2 = xa - 1; x2 <= xa; x2++)
                    {
                        if (DataBase2.CanTake2[y2, x2] == 3)
                        {
                            DataBase2.CanTake2[y2, x2] = 1;
                        }

                    }
                }

            }

            
            //1215追記　　2になっていたら
            if (CurrentPoint.y == ya && CurrentPoint.x == xa)
            {
            }
            else
            { 
                if (DataBase2.CanTake2[ya, xa] >= 2)
                {
                    //171215追記
                    returnCanTakeB[returnCount][0] = (int)CurrentPoint.y;
                    returnCanTakeB[returnCount][1] = (int)CurrentPoint.x;

                    //バックアップ保存
                    for (y = 0; y <= 10; y++)
                    {
                        for (x = 0; x <= 10; x++)
                        {
                            DataBase2.SavedCanTake[y, x] = DataBase2.CanTake2[y, x];
                            returnCanTake[returnCount][y, x] = CanTake2[y, x];
                        }

                    }
                    returnCount++;



                    //既に周りに 1 の辺があるか確認
                    if (DataBase2.CanTake2[ya, xa + 1] == 1)
                    {
                        takeCount = 1;
                        CanTake2[ya, xa + 1] = 2;
                        DataBase2.CanTake2[ya, xa] = 2;
                    }
                    else
                    {
                        for (int i = ya - 1; i <= ya + 1; i++)
                        {
                            for (int j = xa - 1; j <= xa; j++)
                            {
                                //自分の時はなにもしない
                                if (i == ya && j == xa)
                                {
                                }
                                //他のとき
                                else
                                {
                                    //他でみつけたとき
                                    if (DataBase2.CanTake2[y, x] == 1)
                                    {
                                        takeCount = 1;
                                        CanTake2[i, j] = 2;
                                        if (ya == i && ya == j)
                                        {
                                            DataBase2.CanTake2[i, j] = 2;
                                        }
                                        else
                                        {
                                            DataBase2.CanTake2[i, j] = 2;
                                        }
                                    }
                                }


                            }
                        }
                    }

                    // 1215 2 や 3 をとることはありえないのでこれは使わない 
                    // 1　があったとき自らを 1 に。周りも 1 に
                    if (takeCount == 1)
                    {

                        Debug.Log("takeCount");

                        //周囲の辺を1に

                        if (DataBase2.CanTake2[ya, xa + 1] >= 0)
                        {
                            DataBase2.CanTake2[ya, xa + 1] = 1;
                        }


                        for (y2 = ya - 1; y2 <= ya + 1; y2++)
                        {
                            for (x2 = xa - 1; x2 <= xa; x2++)
                            {
                                if (DataBase2.CanTake2[y2, x2] >= 0)
                                {
                                    if (ya == y2 && ya == xa)
                                    {
                                        DataBase2.CanTake2[y2, x2] = 2;
                                    }
                                    else
                                    {
                                        DataBase2.CanTake2[y2, x2] = 1;
                                    }
                                }

                            }
                        }

                        CurrentPoint.y = ya;
                        CurrentPoint.x = xa;

                        takeCount = 0;
                    }
                    

                    CurrentPoint.y = ya;
                    CurrentPoint.x = xa;
                }

            }
            
        }

    }

    public static void checkEdges(int y, int x)
    {

        int ya = 0;
        int xa = 0;
        int y2 = 0;
        int x2 = 0;
        int count = 0;

        int[] resetPoint = new int[5];

        ya = y;
        xa = x;


 /*---------------------------------------予測線リセット---------------------------------------------------*/

        //LastPointの時に 1 の辺を 0 にリセット

        //CurrentPointの場合はリセットしない
        if (DataBase2.CurrentPoint.y == ya && DataBase2.CurrentPoint.x == xa)
        {
        }

        else
        {
            //1215追記
            returnY = returnCanTakeB[returnCount-1][0];
            returnX = returnCanTakeB[returnCount-1][1];

            if (ya == returnY && xa == returnX)
            {
                //LastPointの時のみリセット
                if (count <= 0)
                {
                    //xa + 1 が1のときに、他の１をリセット
                    if (DataBase2.CanTake2[ya, xa + 1] == 1)
                    { 
                        DataBase2.CanTake2[y, x + 1] = 0;
                    }

                    //xa + 1、自分以外が2の時に、他の１をリセット
                    for (y = ya - 1; y <= ya + 1; y++)
                    {
                        for (x = xa - 1; x <= xa; x++)
                        {

                            //自分の時はなにもしない

                            if (y == ya && x == xa)
                            {

                            }

                            //他のとき
                            else
                            {

                                //他でみつけたとき
                                if (DataBase2.CanTake2[y, x] == 1)
                                {
                                    //xa + 1以外
                                    DataBase2.CanTake2[y, x] = 0;

                                    //countを削除

                                }
                            }
                        }
                    }
                }
            }
        }


        //171215追記　点のリセット
        int resetCount = 0;

        //1215追記
        returnY = returnCanTakeB[returnCount-1][0];
        returnX = returnCanTakeB[returnCount-1][1];

        //LastPointはリセットしない
        if (ya == returnY && xa == returnX)
        {

        }

        else
        {
            if (CanTake2[ya, xa + 1] == 1)
            {
                resetCount = 1;
            }

            else
            {
                for (y = ya - 1; y <= ya + 1; y++)
                {
                    for (x = xa - 1; x <= xa; x++)
                    {
                        //自分の時はなにもしない
                        if (y == ya && x == xa)
                        {

                        }
                        else
                        {
                            if (CanTake2[y, x] == 1)
                            {
                                resetCount = 1;
                            }
                        }


                    }

                }
            }

            //周りに2がある時も実行
            if (CanTake2[ya, xa + 1] == 2)
            {
                resetCount = 1;
            }

            else
            {
                for (y = ya - 1; y <= ya + 1; y++)
                {
                    for (x = xa - 1; x <= xa; x++)
                    {
                        //自分の時はなにもしない

                        if (y == ya && x == xa)
                        {

                        }
                        else
                        {
                            if (CanTake2[y, x] == 2)
                            {
                                resetCount = 1;
                            }
                        }
                    }
                }
            }


            if (resetCount == 0)
            {
                if (CanTake2[ya, xa] == 1)
                {
                    CanTake2[ya, xa] = 0;
                }
            }

            resetCount = 0;

        }

    }

    public static void takePoint(int y, int x)
    {

        int ya = 0;
        int xa = 0;
        int y2 = 0;
        int x2 = 0;

        ya = y;
        xa = x;
        
        if (DataBase2.CanTake2[ya, xa] == 1)
        {
            if(CurrentPoint.y == ya && CurrentPoint.x == x + 1)
            {
                if (CanTake2[ya,x - 1] == 0)
                {
                    DataBase2.CanTake2[ya, x - 1] = 1;
                }

                if (CanTake2[ya, x - 1] == 3)
                {
                    DataBase2.CanTake2[ya, x - 1] = 1;
                }
            }

            if (CurrentPoint.y == ya && CurrentPoint.x == x - 1)
            {
                if (DataBase2.CanTake2[ya, x + 1] == 0)
                {
                    DataBase2.CanTake2[ya, x + 1] = 1;
                }

                if (DataBase2.CanTake2[ya, x + 1] == 3)
                {
                    DataBase2.CanTake2[ya, x + 1] = 1;
                }
            }
            /*
            if (DataBase2.CanTake2[ya, x + 1] == 0)
            {
                DataBase2.CanTake2[ya, x + 1] = 1;
            }
            if (DataBase2.CanTake2[ya, x - 1] == 0)
            {
                DataBase2.CanTake2[ya, x - 1] = 1;
            }
            */
        }
        
    }

    public static void takeLeftPoint(int y, int x)
    {

        int ya = 0;
        int xa = 0;
        int y2 = 0;
        int x2 = 0;

        ya = y;
        xa = x;

        if (DataBase2.CanTake2[ya, xa] == 1)
        {
            if (CurrentPoint.y == ya - 1 && CurrentPoint.x == xa + 1)
            {
                if (DataBase2.CanTake2[ya + 1, xa] == 0)
                {
                    DataBase2.CanTake2[ya + 1, xa] = 1;
                }

                if (DataBase2.CanTake2[ya + 1, xa] == 3)
                {
                    DataBase2.CanTake2[ya + 1, xa] = 1;
                }
            }

            if (CurrentPoint.y == ya + 1 && CurrentPoint.x == xa)
            {
                if (DataBase2.CanTake2[ya - 1, xa + 1] == 0)
                {
                    DataBase2.CanTake2[ya - 1, xa + 1] = 1;
                }

                if (DataBase2.CanTake2[ya - 1, xa + 1] == 3)
                {
                    DataBase2.CanTake2[ya - 1, xa + 1] = 1;
                }
            }
        }
    }

    public static void takeRightPoint(int y, int x)
    {
        int ya = 0;
        int xa = 0;
        int y2 = 0;
        int x2 = 0;

        ya = y;
        xa = x;

        if (DataBase2.CanTake2[ya, xa] == 1)
        {
            if (CurrentPoint.y == ya - 1 && CurrentPoint.x == xa)
            {
                if (DataBase2.CanTake2[y + 1, xa + 1] == 0)
                {
                    DataBase2.CanTake2[y + 1, xa + 1] = 1;
                }

                if (DataBase2.CanTake2[y + 1, xa + 1] == 3)
                {
                    DataBase2.CanTake2[y + 1, xa + 1] = 1;
                }
            }

            if (CurrentPoint.y == ya + 1 && CurrentPoint.x == xa + 1)
            {
                if (DataBase2.CanTake2[y - 1, xa] == 0)
                {
                    DataBase2.CanTake2[y - 1, xa] = 1;
                }

                if (DataBase2.CanTake2[y - 1, xa] == 3)
                {
                    DataBase2.CanTake2[y - 1, xa] = 1;
                }
            }

        }
    }

    public static void resetPoint(int y, int x)
    {

        int ya = 0;
        int xa = 0;

        ya = y;
        xa = x;

      

        
    }

    //startPointの時にカウントダウン数も記録しておき、'R'を押すことで選択を全てリセット＋カウントダウンをその位置まで戻す


    /*------------------------------呼ばれてない-----------------------------------------*/

    // スプライトの取得
    // @param fileName ファイル名
    // @param spriteName スプライト名
    public Sprite GetSprite(string fileName, string spriteName)
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(fileName);
        return System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(spriteName));
    }

    /*---------------------------Sprite関連---------------------------*/

    public void changePointSprite(int y, int x)
    {
        MainSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        int ya = 0;
        int xa = 0;

        ya = y;
        xa = x;

        // SpriteRenderのspriteを設定済みの他のspriteに変更

        // 例) HoldSpriteに変更

        if (DataBase2.CanTake2[ya, xa] == 0)
        {
            Sprite0 = Resources.Load<Sprite>("PointBlack");

            MainSpriteRenderer.sprite = Sprite0;
        }

        if (DataBase2.CanTake2[ya, xa] == 1)
        {
            Sprite1 = Resources.Load<Sprite>("PointGreen");

            MainSpriteRenderer.sprite = Sprite1;
        }

        if (DataBase2.CanTake2[ya, xa] == 2)
        {
            Sprite2 = Resources.Load<Sprite>("PointBlue");
            MainSpriteRenderer.sprite = Sprite2;
        }

        if (DataBase2.CanTake2[ya, xa] == 3)
        {
            Sprite3 = Resources.Load<Sprite>("PointRed");
            MainSpriteRenderer.sprite = Sprite3;
        }

    }

    public void changeAreaUpSprite(int y, int x)
    {
        MainSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        int ya = 0;
        int xa = 0;

        ya = y;
        xa = x;


        // SpriteRenderのspriteを設定済みの他のspriteに変更

        // 例) HoldSpriteに変更

        if (DataBase2.AreaTake[ya, xa] == 0)
        {
            Sprite0 = Resources.Load<Sprite>("AreaUpBlack");

            MainSpriteRenderer.sprite = Sprite0;
        }


        if (DataBase2.AreaTake[ya, xa] == 2)
        {
            Sprite1 = Resources.Load<Sprite>("AreaUpBlue");

            MainSpriteRenderer.sprite = Sprite1;
        }

        if (DataBase2.AreaTake[ya, xa] == 3)
        {
            Sprite3 = Resources.Load<Sprite>("AreaUpRed");

            MainSpriteRenderer.sprite = Sprite3;
        }
    }

    public void changeAreaDownSprite(int y, int x)
    {
        MainSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        int ya = 0;
        int xa = 0;

        ya = y;
        xa = x;


        // SpriteRenderのspriteを設定済みの他のspriteに変更

        // 例) HoldSpriteに変更

        if (DataBase2.AreaTake[ya, xa] == 0)
        {
            Sprite0 = Resources.Load<Sprite>("AreaDownBlack");

            MainSpriteRenderer.sprite = Sprite0;
        }


        if (DataBase2.AreaTake[ya, xa] == 2)
        {
            Sprite1 = Resources.Load<Sprite>("AreaDownBlue");

            MainSpriteRenderer.sprite = Sprite1;
        }

        if (DataBase2.AreaTake[ya, xa] == 3)
        {
            Sprite3 = Resources.Load<Sprite>("AreaDownRed");

            MainSpriteRenderer.sprite = Sprite3;
        }
    }

    public void changeLeftSprite(int y, int x)
    {
        MainSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        int ya = 0;
        int xa = 0;

        ya = y;
        xa = x;

        // SpriteRenderのspriteを設定済みの他のspriteに変更

        // 例) HoldSpriteに変更

        if (DataBase2.CanTake2[ya, xa] == 0)
        {
            Sprite0 = Resources.Load<Sprite>("EdgeLeftBlack");

            MainSpriteRenderer.sprite = Sprite0;
        }

        if (DataBase2.CanTake2[ya, xa] == 1)
        {
            /*
            if (DataBase2.CanTake2[ya - 1, xa + 1] == 0)
            {
                DataBase2.CanTake2[ya - 1, xa + 1] = 1;
            }
            if (DataBase2.CanTake2[ya + 1, xa] == 0)
            {
                DataBase2.CanTake2[ya + 1, xa] = 1;
            }
            */
            Sprite1 = Resources.Load<Sprite>("EdgeLeftGreen");

            MainSpriteRenderer.sprite = Sprite1;
        }

        if (DataBase2.CanTake2[ya, xa] == 2)
        {
            Sprite2 = Resources.Load<Sprite>("EdgeLeftBlue");

            MainSpriteRenderer.sprite = Sprite2;
        }

        if (DataBase2.CanTake2[ya, xa] == 3)
        {
            Sprite3 = Resources.Load<Sprite>("EdgeLeftred");

            MainSpriteRenderer.sprite = Sprite3;
        }

    }

    public void changeRightSprite(int y, int x)
    {
        MainSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        int ya = 0;
        int xa = 0;

        ya = y;
        xa = x;

        if (DataBase2.CanTake2[ya, xa] == 0)
        {
            /*
            if (DataBase2.CanTake2[y - 1, xa] == 1)
            {
                DataBase2.CanTake2[y - 1, xa] = 0;
            }
            if (DataBase2.CanTake2[y + 1 , xa + 1] == 1)
            {
                DataBase2.CanTake2[y + 1, xa + 1] = 0;
            }

            if (DataBase2.CanTake2[y - 1, xa] == 4)
            {
                DataBase2.CanTake2[y - 1, xa] = 3;
            }
            if (DataBase2.CanTake2[y + 1, xa + 1] == 4)
            {
                DataBase2.CanTake2[y + 1, xa + 1] = 3;
            }
            */
            Sprite0 = Resources.Load<Sprite>("EdgeRightBlack");

            MainSpriteRenderer.sprite = Sprite0;
        }

        // 例) HoldSpriteに変更
        if (DataBase2.CanTake2[ya, xa] == 1)
        {
            /*
            if (DataBase2.CanTake2[y - 1, xa] == 0)
            {
                DataBase2.CanTake2[y - 1, xa] = 1;
            }
            if (DataBase2.CanTake2[y + 1, xa + 1] == 0)
            {
                DataBase2.CanTake2[y + 1, xa + 1] = 1;
            }
            */

            /*
            if (DataBase2.CanTake2[y - 1, xa] == 3)
            {
                DataBase2.CanTake2[y - 1, xa] = 4;
            }
            if (DataBase2.CanTake2[y + 1, xa + 1] == 3)
            {
                DataBase2.CanTake2[y + 1, xa + 1] = 4;
            }

            if (DataBase2.CanTake2[y - 1, xa] == 5)
            {
                DataBase2.CanTake2[y - 1, xa] = 0;
            }
            if (DataBase2.CanTake2[y + 1, xa + 1] == 5)
            {
                DataBase2.CanTake2[y + 1, xa + 1] = 0;
            }
            */
            Sprite1 = Resources.Load<Sprite>("EdgeRightGreen");

            MainSpriteRenderer.sprite = Sprite1;
        }

        if (DataBase2.CanTake2[ya, xa] == 2)
        {
            Sprite2 = Resources.Load<Sprite>("EdgeRightBlue");

            MainSpriteRenderer.sprite = Sprite2;
        }

        if (DataBase2.CanTake2[ya, xa] == 3)
        {
            Sprite3 = Resources.Load<Sprite>("EdgeRightRed");

            MainSpriteRenderer.sprite = Sprite3;
        }

    }

    public void changeUnderSprite(int y, int x)
    {



    MainSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        int ya = 0;
        int xa = 0;

        ya = y;
        xa = x;
        
        if (DataBase2.CanTake2[ya, xa] == 0)
        {
            /*
            if (DataBase2.CanTake2[ya, x + 1] == 1)
            {
                DataBase2.CanTake2[ya, x + 1] = 0;
            }
            if (DataBase2.CanTake2[ya, x - 1] == 1)
            {
                DataBase2.CanTake2[ya, x - 1] = 0;
            }

            if (DataBase2.CanTake2[ya, x + 1] == 4)
            {
                DataBase2.CanTake2[ya, x + 1] = 3;
            }
            if (DataBase2.CanTake2[ya, x - 1] == 4)
            {
                DataBase2.CanTake2[ya, x - 1] = 3;
            }

    */

            Sprite0 = Resources.Load<Sprite>("EdgeUnderBlack");

            MainSpriteRenderer.sprite = Sprite0;
        }

        if (DataBase2.CanTake2[ya, xa] == 1)
        {

            //9/8追加、エッジが３でもとれるように

            /*
            if (DataBase2.CanTake2[ya, x + 1] == 3)
            {
                DataBase2.CanTake2[ya, x + 1] = 4;
            }
            if (DataBase2.CanTake2[ya, x - 1] == 3)
            {
                DataBase2.CanTake2[ya, x - 1] = 4;
            }

            if (DataBase2.CanTake2[ya, x + 1] == 5)
            {
                DataBase2.CanTake2[ya, xa] = 0;
            }
            if (DataBase2.CanTake2[ya, x - 1] == 5)
            {
                DataBase2.CanTake2[ya, xa] = 0;
            }
            */

            Sprite1 = Resources.Load<Sprite>("EdgeUnderGreen");

            MainSpriteRenderer.sprite = Sprite1;
        }

        if (DataBase2.CanTake2[ya, xa] == 2)
        {
            Sprite2 = Resources.Load<Sprite>("EdgeUnderBlue");

            MainSpriteRenderer.sprite = Sprite2;
        }

        if (DataBase2.CanTake2[ya, xa] == 3)
        {
            Sprite3 = Resources.Load<Sprite>("EdgeUnderRed");

            MainSpriteRenderer.sprite = Sprite3;
        }

    }
  
    
    /*----------------------------------------------------------------*/

    void Update()
    {
        //1223追記
        currentSpeed += Time.deltaTime;

        //1216追記
        playerHPGage.fillAmount = (float)playerHP / (float)playerMaxHP;
        enemyHPGage.fillAmount = (float)enemyHP / (float)enemyMaxHP;

        playerDamageText.text = playerDamageSave.ToString() + " Damage";
        enemyDamageText.text = enemyDamageSave.ToString() + " Damage";

        if (playerDamageAlpha > 0)
        {
            playerDamage5s += Time.deltaTime;
            if (playerDamage5s >= 7f)
            {
                playerDamageAlpha -= 0.03f;
                playerDamageTextA.SetAlpha(playerDamageAlpha);
            }
        }

        if (enemyDamageAlpha > 0)
        {
            enemyDamage5s += Time.deltaTime;
            if (enemyDamage5s >= 7f)
            {
                enemyDamageAlpha -= 0.03f;
                enemyDamageTextA.SetAlpha(enemyDamageAlpha);
            }
        }

        if(enemyHP <= 0)
        {
            stageResult = 1;
            endScene();
        }


        if (Who == 3)
        {
            Who = 1;
        }

        if (Input.GetMouseButton(0))
        {
            //ボールをドラッグしはじめたとき
            OnDrag = 1;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //ボールをドラッグし終わったとき
            OnDrag = 0;
        }
        checkJudge();
        keybord();
    }

    void keybord ()
    {

        if (Input.GetKey(KeyCode.R))
        {

            for (y = 0; y <= 10; y++)
            {
                for (x = 0; x <= 10; x++)
                {

                    DataBase2.CanTake2[y, x] = DataBase2.DefaultCanTake[y, x];

                }
            }

        }

    }

}