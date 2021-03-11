using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialCowMovement : MonoBehaviour
{
	public Rigidbody2D rb;
	public SpriteRenderer sr;

	public int min_speed = 100;
	public int max_speed = 300;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		int dir = Random.Range(0, 2);
		if(dir == 0) rb.AddForce(new Vector2(Random.Range(min_speed, max_speed), Random.Range(min_speed, max_speed)));
		else rb.AddForce(new Vector2(Random.Range(-min_speed, -max_speed), Random.Range(-min_speed, -max_speed)));
	}
    // Update is called once per frame
    void Update()
    {
    	rb = GetComponent<Rigidbody2D>();
    	sr = GetComponent<SpriteRenderer>();
    	if ( rb.GetPointVelocity( new Vector2( 0, 0 ) ).x < 0 ) sr.flipX = false;
    	else sr.flipX = true;
     }

    void FixedUpdate() {

    }
}
