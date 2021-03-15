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

	public Vector2 originalPosition;
	public TextMeshProUGUI countText;
	public int count;

	public GameObject door1;
	public GameObject door2;
	public GameObject door3;
	public GameObject door4;
	public GameObject gameOver;
	public InitialCowMovement cows;
	public InitialCowMovement cows1;
	public InitialCowMovement cows2;
	public InitialCowMovement cows3;
	public InitialCowMovement cows4;
	public InitialCowMovement cows5;
	public InitialCowMovement cows6;
	public InitialCowMovement cows7;
	public InitialCowMovement cows8;
	public InitialCowMovement cows9;
	public InitialCowMovement cows10;
	public InitialCowMovement cows11;
	public InitialCowMovement cows12;
	public InitialCowMovement cows13;
	public InitialCowMovement cows14;
	public GameObject winScreen;
	
	public AudioSource music;
	public AudioSource losemusic;

	public AudioSource cowsfx;
	public AudioClip pickupsfx1;	
	public AudioClip pickupsfx2;	
	public AudioClip dropsfx1;	
	public AudioClip dropsfx2;

	public float speed = 8;
	public int final_count;

	float moveX;
	float moveY;


    // Start is called before the first frame update
    void Start()
    {
		gameOver.SetActive(false);
		door1.SetActive(true);
		movement = true;
		count = 0;
		originalPosition = transform.position;
		winScreen.SetActive(false);
		music.Play();
	}

    // Update is called once per frame
    void FixedUpdate ()
 	{
 	    
 	    sr = GetComponent<SpriteRenderer>();

		SetCountText();
		OpenDoor(count);
		WinScreen(count);
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}


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
		if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.R)) && 
		(gameOver.activeInHierarchy || winScreen.activeInHierarchy))
        {
			Restart();
        }


	}
	 void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Cows") && !gameOver.activeInHierarchy && !winScreen.activeInHierarchy)
		{
			Death();
		}

	}

	private void Death()
	{
		movement = false;
		if (sr.sprite == sprite2) // if the spriteRenderer sprite = sprite1 then change to sprite2
		{
			sr.sprite = sprite1;
		}
		music.Stop();
		losemusic.Play();
		gameOver.SetActive(true);
	}

	public void SpriteChange2()
    {
			sr.sprite = sprite2;
			if (Random.value > 0.5f) cowsfx.PlayOneShot(pickupsfx1); else cowsfx.PlayOneShot(pickupsfx2);
	}

	public void SpriteChange1()
	{
		if (sr.sprite == sprite2) // if the spriteRenderer sprite = sprite1 then change to sprite2
		{
			sr.sprite = sprite1;
			count++;
			if (Random.value > 0.5f) cowsfx.PlayOneShot(dropsfx1); else cowsfx.PlayOneShot(dropsfx2);


		}
	}
	private void Restart()
    {
    		rb = GetComponent<Rigidbody2D>();
		gameOver.SetActive(false);
		winScreen.SetActive(false);
		losemusic.Stop();
		music.Play();

		cows.Reset();
		cows1.Reset();
		cows2.Reset();
		cows3.Reset();
		cows4.Reset();
		cows5.Reset();
		cows6.Reset();
		cows7.Reset();
		cows8.Reset();
		cows9.Reset();
		cows10.Reset();
		cows11.Reset();
		cows12.Reset();
		cows13.Reset();
		cows14.Reset();
		transform.position = originalPosition;
		rb.velocity = new Vector2(0.0f, 0.0f);
		sr.sprite = sprite1;
		door1.SetActive(true);
		door2.SetActive(true);
		door3.SetActive(true);
		door4.SetActive(true);
		movement = true;
		count = 0;

}
	public void SetCountText()
    {
		countText.text = "Count: " + count.ToString();
	}

	public void OpenDoor(int count)
    {
		if (count == 1)
        {
			door1.SetActive(false);
        }
		if (count == 3)
        {
			door2.SetActive(false);
        }
		if(count == 6)
        {
			door3.SetActive(false);
        }
		if(count == 10)
        {
			door4.SetActive(false);
        }
    }

	private void WinScreen(int count)
    {
		if (count == final_count)
        {
        		music.Stop();
			
			losemusic.Play();
			winScreen.SetActive(true);

        }
    }
	
}
