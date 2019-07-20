using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour {
    public ReferenceController rc;

    public GameObject[] spawners;
    public float spawnSpeed;

    float spawnTimer = 0f;
    float spawnDelay = 5f;

	// Use this for initialization
	void Start () {
        // spawn straight away
        spawnTimer = spawnDelay;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnTimer >= spawnDelay)
        {
            GameObject spawnObj = spawners[Random.Range(0, spawners.Length)];
            Formation formation = Instantiate(rc.formationPrefab, spawnObj.transform.position, Quaternion.identity);
            formation.SetSpeed(spawnSpeed);
            spawnTimer = 0;
        }
        else
        {
            spawnTimer += Time.deltaTime;
        }
	}
}
