using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject bluebirdPrefab;
    public int hp = 15;
    float time = 0f;
    float delta;
    private Transform target;
    public float retreatDistance = 30.0f;
    public float speed = 3.0f;
    // 일정시간마다 파랑새 생성, 총알 15대 맞아야 죽음
    void Start()
    {
        this.delta = Time.deltaTime;
        
        target = GameObject.Find("Player").GetComponent<Transform>();
        
    }

    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        // 플레이어가 가까이 오면
        if (distance < retreatDistance)
        {
            time += delta;
            if (time > 4f)
            {
                GameObject bluebird = Instantiate(bluebirdPrefab);
                bluebird.transform.position = new Vector3(this.transform.position.x - 3, this.transform.position.y, this.transform.position.z);
                time = 0f;
            }
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (distance > retreatDistance)
        {
            transform.position = this.transform.position;
        }

    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "Bullet")
        {
            Destroy(coll.gameObject, 0.2f);
            hp -= 1;
            if (hp <= 0)
            {
                Destroy(gameObject, 0.2f);
            }
        }
    }
}
