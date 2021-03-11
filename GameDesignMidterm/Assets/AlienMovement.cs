using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
	public Rigidbody2D rb;
	public SpriteRenderer sr;
	
	public float speed = 8;

	float moveX;
	float moveY;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate ()
 	{
 	    
 	    sr = GetComponent<SpriteRenderer>();
 		
 	//comment out if we want continuous movement
	    moveX = 0;
	    moveY = 0;

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
	     if(Input.GetKey(KeyCode.K)) {
	     	speed = speed + 1;
	     }
	     if(Input.GetKey(KeyCode.J)) {
	     	speed = speed - 1;
	     }

	     bool isIdle = moveX == 0 && moveY == 0;
	     
	     Vector3 moveDir = new Vector3(moveX, moveY).normalized;

	     Vector3 targetPosition = transform.position + moveDir * speed * Time.deltaTime;
	     RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, moveDir, speed*Time.deltaTime); //tells us if we are going to hit anything
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
}
