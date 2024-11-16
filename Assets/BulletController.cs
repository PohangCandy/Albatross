using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "Enemy")
        {
            Destroy(gameObject, 0.2f );
            Destroy(coll.gameObject, 0.2f );
        }
        
    }
    private void Update()
    {
        Destroy(gameObject, 5f );
    }

    public void shootBullet(Vector3 vecBullet)
    {
        Rigidbody rigBody = GetComponent<Rigidbody>();
        rigBody.AddForce(vecBullet);
    }
}
