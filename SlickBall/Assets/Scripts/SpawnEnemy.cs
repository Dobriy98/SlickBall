using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject pref;
    public GameObject pref2;

    public GameObject prefCoin;
    private int count = 0;

    public float waitTime = 5;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            count++;
            if (count == 1)
            {
                List<float> randPos = new List<float>();
                randPos.Add(-3.8f);
                randPos.Add(1f);
                randPos.Add(6.2f);
                SpawnOne(pref, randPos);
            }
            if (count == 2)
            {
                List<float> randPos = new List<float>();
                randPos.Add(3f);
                randPos.Add(-1.2f);
                SpawnOne(pref2, randPos);
                count = 0;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SpawnOne(GameObject pref, List<float> arr)
    {
        float rand = arr[Random.Range(0, arr.Count)];
        if (rand == 1)
        {
            GameObject enemy = Instantiate(pref, gameObject.transform.position, Quaternion.identity);
            enemy.transform.localScale += new Vector3(0, 1.6f, 0);
            enemy.transform.position += new Vector3(0, rand, 0);
            Destroy(enemy, 50);
            SpawnCoin(rand, arr);
        }
        else
        {
            GameObject enemy = Instantiate(pref, gameObject.transform.position, Quaternion.identity);
            enemy.transform.position += new Vector3(0, rand, 0);
            Destroy(enemy, 50);
            SpawnCoin(rand, arr);
        }
    }

    void SpawnCoin(float rand, List<float> arr)
    {
        if (rand == 6.2f)
        {
            GameObject coin = Instantiate(prefCoin, gameObject.transform.position, Quaternion.identity);
            coin.transform.position += new Vector3(0, 1.2f, 0);
            Destroy(coin, 50);
        }
        else if (rand == -3.8f)
        {
            GameObject coin = Instantiate(prefCoin, gameObject.transform.position, Quaternion.identity);
            coin.transform.position += new Vector3(0, 1.2f, 0);
            Destroy(coin, 50);
        }
        else if (rand == 1f)
        {
            arr.Remove(rand);
            float random = arr[Random.Range(0, arr.Count)];
            if (random == -3.8f)
            {
                GameObject coin = Instantiate(prefCoin, gameObject.transform.position, Quaternion.identity);
                coin.transform.localScale += new Vector3(0, -1, 0);
                coin.transform.position += new Vector3(0, -4.25f, 0);
                Destroy(coin, 50);
            }
            else if (random == 6.2f)
            {
                GameObject coin = Instantiate(prefCoin, gameObject.transform.position, Quaternion.identity);
                coin.transform.localScale += new Vector3(0, -0.8f, 0);
                coin.transform.position += new Vector3(0, 6.4f, 0);
                Destroy(coin, 50);
            }
        }


        else if (rand == 3)
        {
            GameObject coin = Instantiate(prefCoin, gameObject.transform.position, Quaternion.identity);
            coin.transform.localScale += new Vector3(0, -1, 0);
            coin.transform.position += new Vector3(0, -4.5f, 0);
            Destroy(coin, 50);
        }
        else if (rand == -1.2f)
        {
            GameObject coin = Instantiate(prefCoin, gameObject.transform.position, Quaternion.identity);
            coin.transform.localScale += new Vector3(0, -0.8f, 0);
            coin.transform.position += new Vector3(0, 6.4f, 0);
            Destroy(coin, 50);
        }

    }
}
