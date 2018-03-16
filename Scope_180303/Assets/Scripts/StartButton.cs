using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : simdata {

	// Use this for initialization
	void Start () {

        // Buttonクリック時、OnClickメソッドを呼び出す
        GetComponent<Button>().onClick.AddListener(OnClick);

    }
	
	// Update is called once per frame


        void OnClick()
        {
        //180120
        //ゲームシステム用
        tutorialFlag = true;
        for (int i = 0; i < N_EVENTS; i++)
        {
            tutorialEventFlag[i] = true;
        }

        st1Flag = false;
        for (int i = 0; i < N_EVENTS; i++)
        {
            st1EventFlag[i] = false;
        }

        st1EventFlagAA = false;
        st1EventFlagBB = false;
        st1EventFlagCC = false;

        St2Flag = false;


        // 「GameScene」シーンに遷移する
        SceneManager.LoadScene("StageSelect");
        }

}
