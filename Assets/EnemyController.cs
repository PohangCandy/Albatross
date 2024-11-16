using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f; // ���� �̵� �ӵ�
    public float retreatDistance = 20.0f; 

    private Transform target;

    
    void Start()
    {
     target = GameObject.Find("Player").GetComponent<Transform>();
    }

    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        // �÷��̾ ������ ����
        if (distance < retreatDistance)
        {
            // �÷��̾� �������� �̵�
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        // �÷��̾ �ָ� �������� ��
        else if (distance > retreatDistance)
        {
            // ������ ����
            transform.position = this.transform.position;
        }
    }
}
