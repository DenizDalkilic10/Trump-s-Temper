using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyZombie : MonoBehaviour {
	public GameObject blood;
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collision name = " + col.gameObject.name);
        if (col.gameObject.name == "Trump")
        {
            Destroy(col.gameObject);
			GameController.isAlive = false;
        }
		if (col.gameObject.name == "bullet(Clone)")
		{
			Instantiate (blood, transform.position, Quaternion.identity);
			GameController.killcount++;
			Destroy(col.gameObject);
			Destroy (gameObject);
		}
		if (col.gameObject.name == "powerBall(Clone)")
		{
			//Instantiate (blood, transform.position, transform.rotation);
			GameController.killcount++;
			Destroy (gameObject);
		}
    }

}
