using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StageSelect_1 : MonoBehaviour {

    StageSelect Base = new StageSelect();

    // Use this for initialization
    void Start () {

        // Buttonクリック時、OnClickメソッドを呼び出す
    

    }
	
	// Update is called once per frame


        void OnMouseDown()
        {

        StageSelect.stage_1 = 1;
        SceneManager.LoadScene("Test_Seaquence_3");

    }

}
