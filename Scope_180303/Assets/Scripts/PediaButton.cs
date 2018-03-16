using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PediaButton : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // Buttonクリック時、OnClickメソッドを呼び出す
        GetComponent<Button>().onClick.AddListener(OnClick);

    }
	
	// Update is called once per frame


        void OnClick()
        {
            // 「GameScene」シーンに遷移する
            SceneManager.LoadScene("Encyclopedia");
        }

}
