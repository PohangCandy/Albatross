using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.player.transform.position.x + 15 >= this.transform.position.x || this.player.transform.position.x - 15 <= gameObject.transform.position.x)
        {
            Rigidbody rd = gameObject.GetComponent<Rigidbody>();
            rd.isKinematic = false;
        }
        if (this.player.transform.position.x + 15 <= gameObject.transform.position.x || this.player.transform.position.x - 15 >= gameObject.transform.position.x)
        {
            Rigidbody rd = gameObject.GetComponent<Rigidbody>();
            rd.isKinematic = true;
            if (gameObject.transform.position.y <= 15)
            {
                this.transform.Translate(new Vector3(0.0f, 3.0f * Time.deltaTime), 0.0f);
            }

        }
    }
}
