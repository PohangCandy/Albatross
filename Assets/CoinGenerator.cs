using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject coinPrefab;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.transform.position = new Vector3(12 + i * 5, 3, 0);
        }
    }
}
