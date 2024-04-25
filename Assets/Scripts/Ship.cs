using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Ship : MonoBehaviour
{        
    private Rigidbody2D rb;    
    private Transform origin;

    private bool moving = false;
    private float turnDirection = 0f;

	public float thrustSpeed = 1.0f;
	public float turnSpeed = 1.0f;
	

	public Bullet bullet;

	public float rateOfFire = 0.2f;
	private float _nextFireTime = 0f;
	private float _fireTime = 0f;
    
	// Start is called before the first frame update
	void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();        
		origin = transform.Find("RotationOrigin"); 
	}

    // Update is called once per frame
    void Update()
    {
		Debug.DrawRay(transform.position, transform.up * 5f, Color.green);

		_fireTime += Time.deltaTime;

		Vector2 offset = new Vector2(origin.position.x, origin.position.y);

		if (Input.GetKey(KeyCode.W))
        {
            this.moving = true;
		}
		else
		{
			this.moving = false;
		}


		if (Input.GetKey(KeyCode.A))
        {
			this.turnDirection = 1.0f;			
        }
		else 
		if (Input.GetKey(KeyCode.D))
		{
			this.turnDirection = -1.0f;			
		}
		else
		{
			this.turnDirection = 0;
		}

		if(Input.GetKey(KeyCode.Space) && _fireTime > this._nextFireTime)
		{
			this._nextFireTime = _fireTime + (1f * rateOfFire);
			Shoot();
		}
	}

	private void FixedUpdate()
	{

		Debug.Log($"Ship speed: {Vector2.Dot(rb.velocity, transform.up)}");

		if(moving)
		{			
			rb.AddForce(this.transform.up * thrustSpeed);
		}

		if(turnDirection != 0)
		{
			rb.AddTorque(turnDirection * turnSpeed);
		}
	}

	private void Shoot()
	{
		//Spawn a bullet and set it's location and position to ours
		var shipSpeed = Vector2.Dot(rb.velocity, transform.up);
		Bullet bullet = Instantiate(this.bullet, this.origin.transform.position, this.origin.transform.rotation);
		bullet.Shoot(shipSpeed);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log($"Ship collided with {collision.gameObject.tag}");

		if (collision.gameObject.tag == "Boundary")
		{
			Vector3 newPosition;

			var boundary = collision.gameObject.GetComponent("Boundary") as Boundary;
			if (boundary.TopBottom) 
			{
				newPosition = new Vector3(
					this.transform.position.x,
					-this.transform.position.y,
					this.transform.position.z
					);
			} 
			else
			{
				newPosition = new Vector3(
					-this.transform.position.x,
					this.transform.position.y,
					this.transform.position.z
					);
			}

			this.transform.position = newPosition;
			
		}

	}






}
