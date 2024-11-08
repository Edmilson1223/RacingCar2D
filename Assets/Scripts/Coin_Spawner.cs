using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Coin_Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoinSpawner());

    }

    // Update is called once per frame
    void Update()
    {

    }
    void CoinSpawn()
    {
        float rand = UnityEngine.Random.Range(-1.8f, 1.8f);
        Instantiate(coinPrefab, new Vector3(rand, transform.position.y, transform.position.z), Quaternion.identity);
    }
    IEnumerator CoinSpawner()
    {
        while (true)
        {
            int time = UnityEngine.Random.Range(10, 20);
            yield return new WaitForSeconds(2f);
            CoinSpawn();
        }
    }
}
