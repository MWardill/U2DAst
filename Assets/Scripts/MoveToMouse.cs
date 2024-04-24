using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	private Rigidbody2D rigidBody;

    public float initialSpeed = 0.3f;
	public float maxSpeed = 8f;	
	public float acceleration = 0.5f;
	public float stopFactor = 0.1f;


	public float smoothTime = 0.3f;
	public float rotationSpeed = 270f;

	private Vector3 target;
	
	private float speed;

	private Vector3 startPosition;
	private float totalDistance;
	private float decelerationStartDistance;



	private void Awake()
	{
		target = transform.position;
		speed = initialSpeed;
		rigidBody = GetComponent<Rigidbody2D>();
	}


	private void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;
			//Debug.Log($"{target.x}, {target.y}");			

			startPosition = transform.position;
			totalDistance = Vector3.Distance(target, startPosition);
			decelerationStartDistance = totalDistance * stopFactor;
			

		}
		
		//Debug.Log($"{transform.position.x}, {transform.position.y}");
		if (transform.position != target)
		{
			MoveDirectly();
		}
		else
		{
			speed = initialSpeed;
		}		
	}

	private void MoveDirectly()
	{
		Debug.Log(speed);


		float distanceToTarget = Vector3.Distance(target, transform.position);

		if (distanceToTarget < 0.01f)
		{
			transform.position = target;
		}
		else
		{
			if (distanceToTarget <= decelerationStartDistance)
			{
				float decelerationFactor = distanceToTarget / decelerationStartDistance;
				transform.position = Vector3.MoveTowards(transform.position, target, speed * decelerationFactor * Time.deltaTime);
			}
			else
			{
				transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
				speed += acceleration * Time.deltaTime;
				speed = Mathf.Min(speed, maxSpeed);
			}
		}



		RotateInDirectionOfInput();
	}

	private void RotateInDirectionOfInput()
	{
		Vector3 direction = target - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion targetRotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

		if (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		}			
	}
}
