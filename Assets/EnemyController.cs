using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f; // 적의 이동 속도
    public float retreatDistance = 20.0f; 

    private Transform target;

    
    void Start()
    {
     target = GameObject.Find("Player").GetComponent<Transform>();
    }

    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        // 플레이어가 가까이 오면
        if (distance < retreatDistance)
        {
            // 플레이어 방향으로 이동
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        // 플레이어가 멀리 떨어졌을 때
        else if (distance > retreatDistance)
        {
            // 가만히 있음
            transform.position = this.transform.position;
        }
    }
}
