using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites; 

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;

    public float minSpeed = 0.5f;
    public float maxSpeed = 0.5f;

    private float speed = 1.0f;
    

    private Vector3 _target;
    private bool _pushed = false;
    private Quaternion _rotation;

	// Start is called before the first frame update
	void Start()
    {        
		this._spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        this._rigidbody = GetComponent<Rigidbody2D>();        
        this.transform.localScale *= Random.Range(minSize, maxSize);
        this.speed = Random.Range(minSpeed, maxSpeed);

		this._spriteRenderer.transform.rotation = this._rotation;
	}

	public void Init(Vector3 target, Quaternion rotation)
	{
        this._target = target;
        this._rotation = rotation;                
	}

	// Update is called once per frame
	void Update()
    {
        
    }

	private void FixedUpdate()
	{
		if(!this._pushed && this._target != null)
        {
            //this.transform.position = Vector3.MoveTowards(this.transform.position,
            //    this._target,
            //    speed);

            this._rigidbody.AddForce(this._target * speed);

            this._pushed = false;
        }
	}
}
