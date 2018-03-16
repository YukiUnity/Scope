using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

    // Use this for initialization
    void OnMouseDown()
    {
        for (int y = 0; y <= 10; y++)
        {
            for (int x = 0; x <= 10; x++)
            {
                DataBase2.Judge = 0;
                DataBase2.CanTake2[y, x] = 0;
                DataBase2.AreaTake[y, x] = 0;

                DataBase2.FirstPoint = new Vector2(0, 0);
                DataBase2.CurrentPoint = new Vector2(0, 0);
                DataBase2.LastPoint = new Vector2(0, 0);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
