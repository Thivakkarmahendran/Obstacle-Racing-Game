using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainScipt : MonoBehaviour
{

    public GameObject boulderPrefab;
    public static bool spawnBoulder;

    // Start is called before the first frame update
    void Start()
    {
        spawnBoulder = true;
        StartCoroutine(SpawnBoulder());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnBoulder() {
        while(spawnBoulder) {
            Instantiate(boulderPrefab, new Vector3(Random.Range(760f, 780f), 200f,  Random.Range(200f, 750f)), Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }


}
