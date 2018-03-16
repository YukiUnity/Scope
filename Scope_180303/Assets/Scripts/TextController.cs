using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextController : DataBase2
{
    DataBase2 Base = new DataBase2();

    public string[] scenarios;
    [SerializeField] Text uiText;

    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalForCharacterDisplay = 0.05f;

    private string currentText = string.Empty;
    private float timeUntilDisplay = 0;
    private float timeElapsed = 1;
    private int currentLine = 0;
    private int lastUpdateCharacter = -1;

    // 文字の表示が完了しているかどうか
    public bool IsCompleteDisplayText
    {
        get { return Time.time > timeElapsed + timeUntilDisplay; }
    }

    void Start()
    {
        SetNextLine();
    }

    void Update()
    {
        //181220追記
            // 文字の表示が完了してるならクリック時に次の行を表示する
            if (IsCompleteDisplayText)
            {
                if (currentLine < scenarios.Length && Input.GetMouseButtonDown(0))
                {
                    SetNextLine();
                }
            }
            else
            {
                // 完了してないなら文字をすべて表示する
                if (Input.GetMouseButtonDown(0))
                {
                    timeUntilDisplay = 0;
                }
            }

            int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
            if (displayCharacterCount != lastUpdateCharacter)
            {
                uiText.text = currentText.Substring(0, displayCharacterCount);
                lastUpdateCharacter = displayCharacterCount;
            }

        //180120追記
        if (currentLine >= 32)
        {
           tutorialEventFlag[0] = false;
        }

        if (currentLine < 15)
        {
            //DonnaSelect.transform.position = new Vector3(0.270f, 0.30f, 1.0f);
        }
        else
        {
           // DonnaSelect.transform.position = new Vector3(-270f, -35f, 0.0f);
        }
    }


    void SetNextLine()
    {
        currentText = scenarios[currentLine];
        timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
        timeElapsed = Time.time;
        currentLine++;
        lastUpdateCharacter = -1;
    }
}