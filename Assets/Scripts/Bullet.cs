using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 500.0f;
    public float range = 5.0f;
    
    private SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
    void Awake()
    {        
		this._spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}

	public void Update()
	{
		Debug.DrawRay(transform.position, transform.up * 5f, Color.red);
	}

	public void Shoot(float startVelocity)
    {        
        this._spriteRenderer.transform.rotation = this.transform.rotation;
		StartCoroutine(Move(this.transform.up, startVelocity));
		Destroy(this.gameObject, this.range);
    }

	private IEnumerator Move(Vector2 direction, float startVelocity)
	{
		while (true)
		{
			transform.Translate(direction.normalized * (speed + startVelocity) * Time.deltaTime, Space.World);
			yield return null;
		}
	}



}
