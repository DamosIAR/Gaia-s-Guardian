using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] fruit;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
     

    void Start()
    {
        StartCoroutine(fruitSpawn());
    }

    IEnumerator fruitSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(fruit[Random.Range(0, fruit.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 2f);
        }
    }
}
