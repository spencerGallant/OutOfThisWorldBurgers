using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlienMovement : MonoBehaviour
{
	public Rigidbody2D rb;
	public SpriteRenderer sr;
	public bool movement;
	public Sprite sprite1;
	public Sprite sprite2;
	public int count;

	public float speed = 8;

	float moveX;
	float moveY;

    // Start is called before the first frame update
    void Start()
    {
		movement = true;
		count = 0;
	}

    // Update is called once per frame
    void FixedUpdate ()
 	{
 	    
 	    sr = GetComponent<SpriteRenderer>();
	

 		
 	//comment out if we want continuous movement
	    moveX = 0;
	    moveY = 0;
		if(movement == true)
        {
			if (Input.GetKey(KeyCode.A))
			{
				moveX = -1f;
				sr.flipX = true;
			}
			if (Input.GetKey(KeyCode.D))
			{
				moveX = +1f;
				sr.flipX = false;
			}
			if (Input.GetKey(KeyCode.W))
			{
				moveY = +1f;
			}
			if (Input.GetKey(KeyCode.S))
			{
				moveY = -1f;
			}
			if (Input.GetKey(KeyCode.K))
			{
				speed = speed + 1;
			}
			if (Input.GetKey(KeyCode.J))
			{
				speed = speed - 1;
			}

			bool isIdle = moveX == 0 && moveY == 0;

			Vector3 moveDir = new Vector3(moveX, moveY).normalized;
			Vector3 targetPosition = transform.position + moveDir * speed * Time.deltaTime;
			RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, moveDir, speed * Time.deltaTime); //tells us if we are going to hit anything
			transform.position = targetPosition;
			// if(raycastHit.collider == null) {

			// }
			// else {
			// 	Vector3 testMoveDir = new Vector3 (moveDir.x, 0f).normalized;
			// 	targetPosition = transform.position + testMoveDir * speed * Time.deltaTime;
			// 	raycastHit = Physics2D.Raycast(transform.position, testMoveDir, speed*Time.deltaTime);
			// 	if(raycastHit.collider == null) transform.position = targetPosition;
			// 	else {
			// 		testMoveDir = new Vector3 (0f, moveDir.y).normalized;
			// 		targetPosition = transform.position + testMoveDir * speed * Time.deltaTime;
			// 		raycastHit = Physics2D.Raycast(transform.position, testMoveDir, speed*Time.deltaTime);
			// 		if(raycastHit.collider == null) transform.position = targetPosition;
			// 	}

			// }
		}
		if (Input.GetKey(KeyCode.Space))
        {
			movement = true;
        }


	}
	 void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Cows"))
		{
			Death();
		}

	}

	private void Death()
	{
		movement = false;	
	}

	public void SpriteChange2()
    {
			sr.sprite = sprite2;
	}

	public void SpriteChange1()
	{
		if (sr.sprite == sprite2) // if the spriteRenderer sprite = sprite1 then change to sprite2
		{
			sr.sprite = sprite1;
			count++;
		}
	}
}
