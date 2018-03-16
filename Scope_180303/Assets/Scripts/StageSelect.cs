using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelect : simdata
{

    // Use this for initialization
    void Start ()
    {
        EndCanvas = GameObject.Find("EndCanvas").GetComponent<CanvasGroup>();
        EndCanvas.alpha = 0;

        //1223追記
        Rank = GameObject.Find("Rank").GetComponent<Text>();
        Power = GameObject.Find("Power").GetComponent<Text>();
        Technique = GameObject.Find("Technique").GetComponent<Text>();
        Speed = GameObject.Find("Speed").GetComponent<Text>();

        Debug.Log("Power" + currentPower);
        Debug.Log("Tech" + currentTechnique);
        Debug.Log("Speed" + currentSpeed);
    }

    void Result()
    {
        switch (stageResult)
        {
            case (1):
                totalPower = currentPower / st0Power * 100;
                totalTechnique = st0Technique / currentTechnique * 100;
                totalSpeed = st0Speed / currentSpeed * 100;

                if(totalPower >= 100)
                {
                    totalPower = 100;
                }
                if (totalTechnique >= 100)
                {
                    totalTechnique = 100;
                }
                if (totalSpeed >= 100)
                {
                    totalSpeed = 100;
                }

                totalRank = (totalPower + totalTechnique + totalSpeed) / 3;

                EndCanvas.alpha = 1;

                if (totalRank >= 0)
                {
                    Rank.text = "Rank = C";
                }
                if (totalRank >= 80)
                {
                    Rank.text = "Rank = S";
                }

                totalresultPower = (int)totalPower;
                totalresultTechnique = (int)totalTechnique;
                totalresultSpeed = (int)totalSpeed;


                Power.text = "Power = " + totalresultPower.ToString();
                Technique.text = "Technique = " + totalresultTechnique.ToString();
                Speed.text = "Speed = " + totalresultSpeed.ToString();



                /*GameObject.Find("Stage_Point").GetComponent<CircleCollider2D>();*/
                /*Destroy(GetComponent<CircleCollider2D>());*/

                //EndCanvas.SetActive(true);


                /*EndPanel = GameObject.Find("EndTitle").GetComponent<Image>();
                EndPanel.color = new Color(0, 0, 0, 0);

                EndTitle = GameObject.Find("enemyDamageText").GetComponent<CanvasRenderer>();
                enemyDamageTextA.SetAlpha(0f);*/

                break;

        }
    }

    // Update is called once per frame
    void OnMouseDown()
    {

        StageSelect.stage_1 = 1;
        SceneManager.LoadScene("St0");

    }

    void Update()
    {

        if (stageResult >= 1)
        {
            Result();

            if (Input.GetMouseButtonDown(0))
            {
                stageResult = 0;
                EndCanvas.alpha = 0;
            }
        }

    }

}
