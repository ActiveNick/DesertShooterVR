using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject EnemyTarget;
    public float SpawnInterval = 5;

    //private GameObject enemies[];

	// Use this for initialization
	void Start () {
		InvokeRepeating("CreateEnemy", 12f, SpawnInterval);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateEnemy()
    {
        Vector3 spawnpoint = new Vector3(-40, 0, -36);

        GameObject newEnemy = (GameObject)Instantiate(Enemy, spawnpoint, Quaternion.identity);
        newEnemy.GetComponent<EnemyMovement>().DesiredTarget = EnemyTarget;
    }
}
