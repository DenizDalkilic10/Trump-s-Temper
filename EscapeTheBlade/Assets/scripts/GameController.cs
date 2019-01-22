using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	Vector2 dollarPos,zombiePos,specialCharPos,ammoPos,terroristPos;
	float timeLastDrop,timeLastZombie,timeLastAmmo,timeLastSpec,timeLastterrorist; // drop = dolar instantiation
    float dollarFrequency = 0.90f;
	float zombieFrequency = 4.5f;
	float terroristFrequency = 3.0f;
	float ammoFrequency = 13.0f;
	float specFrequency = 1.0f;
	float survivalTime = 0;
	float timer = 0.0f;
	public int specialCost = 5;
	bool formed = false;
	public static bool isAlive = true;
	public static bool hard = false;
	public static bool ultraHard = false;
	public static int points = 0;
	public static int killcount = 0;
	public static int ammo = 30;
	public static float seconds;
	float levelUptTime = 40.0F;
	public Text count,kill,bullets,startText,survive;
    public GameObject dollar,zombie,specialChar,ammoBox,terrorist,gamePanel;
	public float timeLeft = 3.0f;



	// Use this for initialization
    void Start () {
	
		hard = false;
		ultraHard = false;
		gamePanel.SetActive (true);
		
	}


	void Update()
	{
		seconds += Time.deltaTime;

        if (Time.time - timeLastDrop > dollarFrequency)
            formDollar();
		if (Time.time - timeLastZombie > zombieFrequency)
			formZombie();
		if (Time.time - timeLastterrorist > terroristFrequency)
			formTerrorist();
		if (Time.time - timeLastAmmo > ammoFrequency)
			formAmmoBox();
		if (Time.time - timeLastSpec > specFrequency)
			formed = false;

		updateText ();
		survivalTime = Time.time;

		if (survivalTime > levelUptTime)
			hard = true;
		if (survivalTime > 2*levelUptTime)
			ultraHard = true;

		//add form special char here
		if (Input.touchCount > 0)
		if (Input.GetTouch (0).position.x > Screen.width / 2 && Input.GetTouch (0).position.y > Screen.height / 2 && !formed) {
				formSpecialChar (); //special cost is increased
		}	

		if (!isAlive)
			gamePanel.SetActive (false);

    }
    void formDollar()
    {
        
        dollarPos.y = 145;
        dollarPos.x = Random.Range(-235.0f,240.0f);
        Instantiate(dollar, dollarPos, Quaternion.identity);
        timeLastDrop = Time.time;
    }
	void formZombie()
	{

		zombiePos.y = -86;
		zombiePos.x = Random.Range(-470.0f,-440.0f);
		Instantiate(zombie, zombiePos, Quaternion.identity);
		timeLastZombie = Time.time;
	}
	void formTerrorist()
	{

		terroristPos.y = -98;
		terroristPos.x = Random.Range(-470.0f,-440.0f);
		Instantiate(terrorist, terroristPos, Quaternion.identity);
		timeLastterrorist = Time.time;
	}
	public void formSpecialChar()
	{
		
		specialCharPos.y = -95.0f;
		specialCharPos.x = 215.0f;
		Instantiate(specialChar, specialCharPos, Quaternion.identity);
		points -= specialCost;
		//specialCost++;
		timeLastSpec = Time.time;
		formed = true;
	}
	void formAmmoBox()
	{

		ammoPos.y = 145;
		ammoPos.x = Random.Range(-235.0f,240.0f);
		Instantiate(ammoBox, ammoPos, Quaternion.identity);
		timeLastAmmo = Time.time;
	}
	void updateText(){
		count.text = "Money: "+ points;
		kill.text = "Kill: " + killcount;
		//kill.text = "Kill: " + Input.acceleration.x;
		bullets.text = "Ammo: " + ammo;
		survive.text = "Time: " + (seconds).ToString("0");
	}
}

