using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float spawnRate = 5.0f;
	public float spawnAmount = 3.0f;
	public float spawnDistance = 22.0f;

	public Asteroid asteroidPrefab;

	private void Start()
	{
		InvokeRepeating(nameof(Spawn), 0, this.spawnRate);
	}

	private void Spawn()
	{
		for(int i = 0; i < spawnAmount; i++)
		{
			Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;

			//Asteroid asteroid = Instantiate(this.asteroidPrefab, )
		}
		
	}
}
