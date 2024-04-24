using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyboardMovement : MonoBehaviour
{

        
    private Rigidbody2D rb;    
    private Transform origin;

    private bool moving = false;
    private float turnDirection = 0f;

	public float thrustSpeed = 1.0f;
	public float turnSpeed = 1.0f;
    
	// Start is called before the first frame update
	void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();        
		origin = transform.Find("RotationOrigin"); 
	}

    // Update is called once per frame
    void Update()
    {
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
			turnDirection = -1.0f;			
		}
		else
		{
			turnDirection = 0;
		}
	}

	private void FixedUpdate()
	{
		if(moving)
		{
			//currentSpeed += acceleration;
			//currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
			rb.AddForce(this.transform.up * thrustSpeed);
		}

		if(turnDirection != 0)
		{
			rb.AddTorque(turnDirection * turnSpeed);
		}
	}




}
