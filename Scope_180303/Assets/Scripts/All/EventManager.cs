using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : simdata
{
    // Use this for initialization
    void Start () {
        ActorCanvas.alpha = 0;
        TextCanvas.alpha = 0;
    }
	
    void uiOnStSelect()
    {
        ActorCanvas.alpha = 1;
        TextCanvas.alpha = 1;
        //ActorCanvas.alpha = 0;
        //TextCanvas.alpha = 0;
        uiTextStSelect.transform.Translate(0, 0, 0);
    }

    void uiOffStSelect()
    {
        //ActorCanvas.alpha = 1;
        //TextCanvas.alpha = 1;
        ActorCanvas.alpha = 0;
        TextCanvas.alpha = 0;
        uiTextStSelect.transform.TransformPoint(005f, -3.5f, 1.88f);
    }

    void uiOnSt0()
    {
        ActorCanvasSt0.alpha = 0;
        TextCanvasSt0.alpha = 0;
        uiTextSt0.transform.Translate(0, 0, 0);
    }

    void uiOffSt0()
    {
        ActorCanvasSt0.alpha = 1;
        TextCanvasSt0.alpha = 1;
        uiTextSt0.transform.Translate(005f, -3.5f, 1.88f);
    }

    // Update is called once per frame
    void Update ()
    {
        if(tutorialEventFlag[0])
        {
            uiOnStSelect();
        }
        else {
            uiOffStSelect();
        }

        if(tutorialEventFlag[1])
        {
            uiOnSt0();
        }
        else{
            uiOffSt0();
        }
    }
}
