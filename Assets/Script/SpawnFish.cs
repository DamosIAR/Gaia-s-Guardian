using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    [SerializeField] GameObject[] fish;
    [SerializeField] float secondFish = 0.5f;
    [SerializeField] float minRange;
    [SerializeField] float maxRange;
    //[SerializeField] float speed;


    void Start()
    {
        StartCoroutine(fishSpawn());
    }

    IEnumerator fishSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minRange, maxRange);
            var position = new Vector3(transform.position.x, wanted );
            GameObject gameObject = Instantiate(fish[Random.Range(0, fish.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondFish);
            Destroy(gameObject, 5f);
        }
    }
}
