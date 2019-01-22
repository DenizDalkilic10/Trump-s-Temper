using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieMovement : MonoBehaviour {
	Rigidbody2D rb2d;
	float jumpSpeed = 3300f;
	float jumpFrequency,shotFrequency;
    public float maxSpeed = 90f;
	float timeLastJump;
	float instantiated;
	public GameObject bullet;
	public bool fired = false;
	Vector2 bulletPos;
    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		timeLastJump = Time.time;
		instantiated = Time.time;
		jumpFrequency = Random.Range(3.0f,5.0f);
		shotFrequency = Random.Range (3.0f, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.hard && !GameController.ultraHard)
			jumpWhenWalk ();
		else if (GameController.hard && GameController.ultraHard)
			fireJumpWalk ();
		else
			walk ();
		Quaternion rot = transform.rotation;
		rot.z = 0;
		transform.rotation = rot;
       
    }
	void walk(){
		Vector3 pos = transform.position;
		pos.x += maxSpeed * Time.deltaTime;
		transform.position = pos;
		Destroy(gameObject, 8f);
	}
	void jumpWhenWalk(){
		walk ();
		if (Time.time - timeLastJump > jumpFrequency) {
			rb2d.AddForce (Vector2.up * jumpSpeed);
			timeLastJump = Time.time;
			jumpFrequency = Random.Range(3.0f,5.0f);
		}
	}
	void fireJumpWalk(){
		jumpWhenWalk ();
		bulletPos = transform.position;
		bulletPos.x = transform.position.x + 1;
		if (!fired && instantiated + shotFrequency < Time.time) {
			Instantiate (bullet, bulletPos, Quaternion.identity);
			fired = true;
		}
	}
}
