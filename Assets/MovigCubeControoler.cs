using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovigCubeControoler : MonoBehaviour
{
    GameObject movingCube;
    float cubePos;
    int direction = 1;
    float speed = 5f;
    public float movement;
    
    void Start()
    {
        this.movingCube = GameObject.Find("MovingCube");
    }

    
    void Update()
    {
        this.cubePos = this.movingCube.transform.position.x;
        if (this.cubePos >= 126) // 큐브가 움직일 거리 설정
        {
            direction = -1;
        }
        if (this.cubePos <= 112)
        {
            direction = 1;
        }
        movement = direction * speed * Time.deltaTime;
        this.movingCube.transform.Translate(movement, 0, 0);
    }
}
