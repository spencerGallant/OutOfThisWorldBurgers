using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialCowMovement : MonoBehaviour
{
	public Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		int dir = Random.Range(0, 2);
		if(dir == 0) rb.AddForce(new Vector2(Random.Range(300, 500), Random.Range(300, 500)));
		else rb.AddForce(new Vector2(Random.Range(-300, -500), Random.Range(-300, -500)));
	}
    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {

    }
}
