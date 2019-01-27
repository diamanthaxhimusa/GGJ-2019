using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRightSpawner : MonoBehaviour {

public GameObject rightObstacle;
	private float timeBtwSpawn;
	public float startTimeBtwSpawn;
	public float decreaseTime;
	public float minTime = 0.65f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(timeBtwSpawn<=0)
		{

			Instantiate(rightObstacle, transform.position, Quaternion.identity);
			timeBtwSpawn = startTimeBtwSpawn;
			if(startTimeBtwSpawn > minTime)
			{
				startTimeBtwSpawn -= decreaseTime;
			}	
		}
		else {
			timeBtwSpawn -=Time.deltaTime;
		}
	}
}
