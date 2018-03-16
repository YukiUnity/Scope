using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RebootGame : simdata {
    void Start()
    {
        // Buttonクリック時、OnClickメソッドを呼び出す
        GameObject.Find("StartAsFirst").GetComponent<Button>().onClick.AddListener(OnClick);
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            tutorialEventFlag[0] = true;
        }
    }

void OnClick()
    {
        //ゲームシステム用
        tutorialFlag = true;
        for (int i = 0; i < N_EVENTS; i++)
        {
            tutorialEventFlag[i] = false;
        }

        tutorialEventFlag[0] = true;

        st1Flag = false;
        for (int i = 0; i < N_EVENTS; i++)
        {
            st1EventFlag[i] = false;
        }

        st1EventFlagAA = false;
        st1EventFlagBB = false;
        st1EventFlagCC = false;

        St2Flag = false;

    }
}
