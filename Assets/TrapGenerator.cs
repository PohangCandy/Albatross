using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapGenerator : MonoBehaviour
{
    public GameObject trapPrefab;
    
    void Start()
    {
        for( int i = 0;i<10;i++)
        {
            GameObject trap = Instantiate(trapPrefab);
            trap.transform.position = new Vector3(10 + i*5, 13, 0);
        }
    }

   
}
