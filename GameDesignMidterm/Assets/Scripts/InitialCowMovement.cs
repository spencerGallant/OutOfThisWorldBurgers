using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InitialCowMovement : MonoBehaviour
{
	public Rigidbody2D rb;
	public SpriteRenderer sr;
	public AlienMovement alien;

	public int min_speed = 100;
	public int max_speed = 300;

	public Vector2 originalPosition; 

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		int dir = Random.Range(0, 2);
		if(dir == 0) rb.AddForce(new Vector2(Random.Range(min_speed, max_speed), Random.Range(min_speed, max_speed)));
		else rb.AddForce(new Vector2(Random.Range(-min_speed, -max_speed), Random.Range(-min_speed, -max_speed)));
		originalPosition = transform.position;
	}
	// Update is called once per frame
	void Update()
	{
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		if (rb.GetPointVelocity(new Vector2(0, 0)).x < 0) sr.flipX = false;
		else sr.flipX = true;

		//checks if the alien is in radius
		if ((alien.transform.position - this.transform.position).sqrMagnitude < 2 * 2)
		{
			if (Input.GetButtonDown("Fire1"))
            {
				alien.SpriteChange2();
				gameObject.SetActive(false);
			}
			/*
			//checks if the mouse is clicked
			if (Input.GetButtonDown("Fire1"))
			{
				//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				//RaycastHit hit;
				Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

				RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
				if (hit.collider != null)
				{
					alien.SpriteChange2();
					Destroy(gameObject);
				}
			}*/
		}
	}

    void FixedUpdate() {

    }

	public void Reset()
    {
		gameObject.SetActive(true);
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		transform.position = originalPosition;

	}
	
}
