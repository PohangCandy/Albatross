using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingUI : MonoBehaviour
{
    GameObject getScore;
    GameObject lasttime;
    private GUIStyle HappyEnding = new GUIStyle();
    private GUIStyle SadEnding = new GUIStyle();
    int OnMars = 0;

    private void Start()
    {
        getScore = GameObject.Find("GetScore");
        lasttime = GameObject.Find("LastTime");
        OnMars = 0;
    }
    private void Update()
    {
        getScore.GetComponent<Text>().text = "Score: " + PlayerPrefs.GetString("StringA");
        lasttime.GetComponent<Text>().text = PlayerPrefs.GetString("StringB");
        OnMars = PlayerPrefs.GetInt("intA");
    }

    void OnGUI()
    {
        if(OnMars == 1)
        {
            HappyEnding.fontSize = 150;
            HappyEnding.normal.textColor = Color.blue;
            GUI.Label(new Rect(Screen.width / 5, Screen.height / 16, 128, 32), "Congratulation!!", HappyEnding);
        }
        else
        {
            SadEnding.fontSize = 150;
            SadEnding.normal.textColor = Color.red;
            GUI.Label(new Rect(Screen.width / 3, Screen.height / 16, 128, 32), "GameOver!", SadEnding);
        }
    }
}
