using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float maxSpeed = 10f;
	float jumpSpeed = 3100f;
    float rotSpeed = 180f;
    float shotFrequency = 0.3f;
    float timeCount;
	bool grounded = true;
    public GameObject bullet;
	Rigidbody2D rb2d;
    //public GameObject dialogue;
    float timeLastShot, timeThisShot;
    Vector2 bulletPos, dialoguePos;
    Animator anim;
    //public float fireRate = 0.5f;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
        anim.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
		Quaternion rot = transform.rotation;
		rot.z = 0;
		transform.rotation = rot;
        Vector3 pos = transform.position;
        //pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;  // for pc controls
		if(Input.acceleration.x > 0.04 || Input.acceleration.x < -0.04)
			transform.Translate(Input.acceleration.x*maxSpeed, 0, 0);
        //pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;  // for pc controls
       	// transform.position = pos;
        //if (Input.GetKey(KeyCode.RightArrow))
		if(Input.acceleration.x > 0.04)
            anim.SetInteger("state", 2);
        //else if (Input.GetKey(KeyCode.LeftArrow))
		else if (Input.acceleration.x < -0.04)
            anim.SetInteger("state", 4);
        else
            anim.SetInteger("state", 0);
		if (Input.GetButton ("Jump")) { // change it to on display button for android
			if (Time.time - timeLastShot > shotFrequency && GameController.ammo > 0)
				fire ();
		}

		if(Input.touchCount > 0){
			// touch x position is bigger than half of the screen, moving right
			if (Input.GetTouch (0).position.x > Screen.width / 2) {
				if (Time.time - timeLastShot > shotFrequency && GameController.ammo > 0)
					fire ();
			}
			// touch x position is smaller than half of the screen, moving left
			else if (grounded && Input.GetTouch (0).position.x < Screen.width / 2) {
				rb2d.AddForce (Vector2.up * jumpSpeed);
				grounded = false;
			}
		}
		//if (Input.GetButtonDown ("Vertical")) // change it to on display button for android
			
			
    }
	void fire(){
		GameController.ammo--;
		bulletPos = transform.position;
		bulletPos.x = transform.position.x - 1;
		Instantiate (bullet, bulletPos, Quaternion.identity);
		timeLastShot = Time.time;

	}
	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log("collision name = " + col.gameObject.name);
		if (col.gameObject.name == "Ground")
		{
			grounded = true;
		}
	}
    
}