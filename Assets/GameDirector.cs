using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    GameObject player;
    float time = 180.0f;
    int point = 0;
    public int PlayerHp = 1;
    public AudioClip coinSE;
    public AudioClip DestroySE;
    AudioSource aud;


    void Start()
    {
        //Screen.SetResolution(1920, 1080, true);
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.player = GameObject.Find("Player");
    }

    void Update()
    {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<Text>().text = ("Last Time ") + this.time.ToString("F1");
        this.pointText.GetComponent<Text>().text = ("Point ") + this.point.ToString();
        if(this.time < 0)
        {
            PlayerHp = 0;
        }
        if (PlayerHp == 0)
        {
            this.GoEnd();
        }
    }
    public void GoEnd()
    {
        if(this.PlayerHp == 0)
        {
            PlayerPrefs.SetInt("intA", 0);
        }
        else
        {
            PlayerPrefs.SetInt("intA", 1);
        }
        PlayerPrefs.SetString("StringA", this.pointText.GetComponent<Text>().text);
        PlayerPrefs.SetString("StringB", this.timerText.GetComponent<Text>().text);
        SceneManager.LoadScene("ClearScene");
    }
    public void GetCoin()
    {
        this.point += 100;
    }
    public void GetAttack()
    {
        if(this.player.GetComponent<PlayerController>().equipitem != 0)
        {
            this.player.GetComponent<PlayerController>().equipitem = 0;
        }
        else
        {
            this.PlayerHp = 0;
            Destroy(this.player);
        }

    }
}


