using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearDirector : MonoBehaviour
{
    GameObject getScore;
    GameObject lasttime;
    // Start is called before the first frame update
    void Start()
    {
       // Screen.SetResolution(1920, 1080, true);
        getScore = GameObject.Find("GetScore");
        lasttime = GameObject.Find("LastTime");
    }

    // Update is called once per frame
    void Update()
    {
        getScore.GetComponent<Text>().text = "Score: " + PlayerPrefs.GetString("StringA");
        lasttime.GetComponent<Text>().text = PlayerPrefs.GetString("StringB");
    }
}
