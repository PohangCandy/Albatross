using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int bulletPower = 600;
    public int direction = 0;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D)) direction = 1;
        if (Input.GetKey(KeyCode.A)) direction = -1;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletObj = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody rd = bulletPrefab.GetComponent<Rigidbody>();
            rd.isKinematic = false;
            Vector3 vecBullet = new Vector3(bulletPower * direction, 0, 0);
            BulletController bulletControllerScr = bulletObj.GetComponent<BulletController>();
            bulletControllerScr.shootBullet(vecBullet);
        }
        
    }
}
