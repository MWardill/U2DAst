using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites; 

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;

    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;

    // Start is called before the first frame update
    void Start()
    {        
		this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.rigidbody = GetComponent<Rigidbody2D>();        
        this.transform.localScale *= Random.Range(minSize, maxSize); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
