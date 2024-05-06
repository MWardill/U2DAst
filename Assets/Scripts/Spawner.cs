using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float spawnRate = 5.0f;
	public float spawnAmount = 3.0f;
	public float spawnDistance = 5.0f;

	public float quadSize = 10.0f;
	
	public Asteroid asteroidPrefab;

	private void Start()
	{
		InvokeRepeating(nameof(Spawn), 0, this.spawnRate);
	}

	private void Spawn()
	{
		for(int i = 0; i < spawnAmount; i++)
		{
			//Pick a random point around our spawner, then push it out to the spawn distance
			Vector3 spawnPoint = 
				Random.insideUnitCircle.normalized * this.spawnDistance;
			
			Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, new Quaternion(0, 0, 0, 0));
			
			Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
			Vector3 direction = (Utils.GetRandomPoint(this.quadSize) - asteroid.transform.position).normalized;
			asteroid.Init(direction, rotation);
		}		
	}
}
