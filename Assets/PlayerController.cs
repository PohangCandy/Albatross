using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigid;
    public float jumpforce = 1050.0f;
    public float jetPackjumpforce = 80.0f;
    public float walkforce = 35.0f;
    public float maxWalkSpeed = 15.0f;
    public float carwalkforce = 60.0f;
    public float carWalkSpeed = 30.0f;
    public int equipitem;
    public float timer = 60f;
    public int Hp = 1;
    GameObject director;
    public int Canjump;
    GameObject movingCube;
    public AudioClip coinSE;
    public AudioClip DestroySE;
    AudioSource aud;

    

    void Start()
    {
        this.rigid = GetComponent<Rigidbody>();
        this.director = GameObject.Find("GameDirector");
        this.movingCube = GameObject.Find("MovingCube");
    }

    
    void Update()
    {
        switch (equipitem) //아이템에 따라 플레이어 조작감 초기화,변경
        {
            case 1: //자동차
                this.walkforce = this.carwalkforce;  
                this.maxWalkSpeed = this.carWalkSpeed;
                this.jumpforce = 1050.0f;
                this.timer = 60f;
                break;

            case 2: //제트팩
                this.walkforce = 35.0f;
                this.maxWalkSpeed = 15.0f;
                this.jumpforce = this.jetPackjumpforce ;
                if (this.rigid.velocity.y == 0 || Canjump == 1)
                { this.timer = 60f * Time.deltaTime * 50; }

                //if (Input.GetKey(KeyCode.W) && this.timer > 0 && this.equipitem == 2 )
                //{
                //    this.rigid.AddForce(transform.up * this.jumpforce );
                //    this.timer -= 1.0f;
                //}
                break;

            case 3: //총
                this.walkforce = 35.0f;
                this.maxWalkSpeed = 15.0f;
                this.jumpforce = 1050.0f;
                this.timer = 60f;
                break;

            default: //맨 손
                for (int i = 0; i < 3; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                this.walkforce = 35.0f;
                this.maxWalkSpeed = 15.0f;
                this.jumpforce = 1050.0f;
                this.timer = 60f;
                break;
        }


        float speedx = Mathf.Abs(this.rigid.velocity.x);
        
        if (Input.GetKeyDown(KeyCode.W) && (this.rigid.velocity.y == 0 || Canjump == 1) && this.equipitem != 2)//일반점프
        {
            this.rigid.AddForce(transform.up * this.jumpforce * Time.deltaTime * 50);
            Canjump = 0;
        }
        if (Input.GetKey(KeyCode.W) && this.timer > 0 && this.equipitem == 2)
        {
            if (this.transform.position.y > 17f)
            {
                this.jumpforce = 1 / (Time.deltaTime * 50);
            }
            this.rigid.AddForce(transform.up * this.jumpforce * Time.deltaTime * 50);
            this.timer -= 1.0f * Time.deltaTime * 50;
            Canjump = 0;
        }

        int key = 0;
        if (Input.GetKey(KeyCode.D)) key = 1;
        if (Input.GetKey(KeyCode.A)) key = -1;



        if (speedx < this.maxWalkSpeed)
        {

            this.rigid.AddForce(transform.right * key * this.walkforce * Time.deltaTime * 60);

        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        if(transform.position.y < -15)
        {
            this.director.GetComponent<GameDirector>().PlayerHp = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Debug.Log(other.gameObject.name);
            for (int i = 0;i<3;i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                this.equipitem = 0;
            }
            if (other.gameObject.name == "Key")
            {
      
                transform.GetChild(0).gameObject.SetActive(true);
                this.equipitem = 1;
            }
            if (other.gameObject.name == "JetPack")
            {

                transform.GetChild(1).gameObject.SetActive(true);
                this.equipitem = 2;
            }
            if (other.gameObject.name == "Block")
            {

                transform.GetChild(2).gameObject.SetActive(true);
                this.equipitem = 3;
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Coin")
        {
            this.director.GetComponent<GameDirector>().GetCoin();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Finish")
        {
            this.director.GetComponent<GameDirector>().GoEnd();
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            this.director.GetComponent<GameDirector>().GetAttack();
            this.aud.PlayOneShot(this.DestroySE);
        }
        if (other.gameObject.tag == "Ground")
        {
            Canjump = 1;
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject == this.movingCube)
        {
            float follw = movingCube.GetComponent<MovigCubeControoler>().movement;
            this.gameObject.transform.Translate(follw * 1.2f, 0, 0);
        }
    }


}
