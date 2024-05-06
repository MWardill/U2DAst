using Assets.Scripts.Enemies;
using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : BaseMono, IEnemy
{
	public Sprite[] sprites;

	private SpriteRenderer _spriteRenderer;
	private Rigidbody2D _rigidbody;
	
	public float minSize = 0.5f;
	public float maxSize = 1.5f;

	public float minSpeed = 0.5f;
	public float maxSpeed = 0.5f;
	private float _size;

	public float test = 1.0f;

	private float _speed = 1.0f;


	private Vector3 _target;
	private Quaternion _rotation;

	public Asteroid childPrefab;
	private Asteroid[] children;

	private bool _isPushed = false;
	

	// Start is called before the first frame update
	void Start()
	{
						
	}

	public void Init(Vector3 target, Quaternion rotation, float? size = null, float? speed = null)
	{
		this._size = size ?? Random.Range(minSize, maxSize);
		this.transform.localScale *= this._size;

		this._speed = speed ?? Random.Range(minSpeed, maxSpeed);

		this._spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		this._rigidbody = GetComponent<Rigidbody2D>();		

		this._target = target;
		this._rotation = rotation;
		
		this._spriteRenderer.transform.rotation = this._rotation;
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void FixedUpdate()
	{
		if (!this._isPushed)
		{
			this.Log($"Asteroid velocity: {this._rigidbody.velocity}");
			this._rigidbody.AddForce(this._target * this._speed);

			this._isPushed = true;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//Debug.Log("Entered something");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log("Entered something trigger asteroid");
	}

	public void Destroy()
	{
		Debug.Log("Destroyed");				
		int rand = (int)Random.Range(2, 5.0f);
		children = new Asteroid[rand];

		for(int i = 0; i < rand; i++)
		{			
			Asteroid asteroid = Instantiate(this.childPrefab, this.transform.position, new Quaternion(0, 0, 0, 0));
			children[i] = asteroid;
			Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
			Vector3 direction = (Utils.GetRandomPoint(10.0f)).normalized;			
			asteroid.Init(direction, rotation, this._size / 2, this._speed);
		}

		Destroy(this.gameObject);
	}
}
