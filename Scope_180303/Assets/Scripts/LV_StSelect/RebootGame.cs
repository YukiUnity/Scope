using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitScene : simdata {
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        //ゲームシステム用
        tutorialFlag = true;
        for (int i = 0; i < N_EVENTS; i++)
        {
            tutorialEventFlag[i] = false;
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

    }
}
