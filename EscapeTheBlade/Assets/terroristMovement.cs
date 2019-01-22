using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terroristMovement : MonoBehaviour {
	Rigidbody2D rb2d;
	public float maxSpeed = 110f;
	Vector2 bulletPos;
	float jumpSpeed = 3300f;
	float jumpFrequency;
	float timeLastJump;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
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
}
