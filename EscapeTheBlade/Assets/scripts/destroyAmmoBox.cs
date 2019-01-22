using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAmmoBox : MonoBehaviour {
	//GameController control = new GameController();
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Trump")
		{
			GameController.ammo += 7;
			Destroy(gameObject);
		}
	}
}
