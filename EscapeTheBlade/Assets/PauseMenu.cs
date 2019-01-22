using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour{

	public static bool GameisPaused = false;
	public GameObject pauseMenu;
	public GameObject gameOverMenu;
    public GameObject canvas;
	public Text score;
    
	void Update(){
		if (!GameController.isAlive)
			gameOver ();
	}
	public void resume(){
		pauseMenu.SetActive (false);
		gameOverMenu.SetActive (false);
		Time.timeScale = 1f;
		GameisPaused = false;
		GameController.isAlive = true;
        canvas.SetActive(true);
    }
	public void pause(){
		pauseMenu.SetActive (true);
		Time.timeScale = 0f;
		GameisPaused = true;
        canvas.SetActive(false);
	}
	public void gameOver(){
		gameOverMenu.SetActive (true);
		score.text = "Score " + GameController.seconds.ToString("0");
		Time.timeScale = 0f;
		GameisPaused = true;
        canvas.SetActive(false);
    }
	public void restart(){
		SceneManager.LoadScene ("GameScreen");
		GameController.isAlive = true;
		Time.timeScale = 1f;
		GameController.ammo = 20;
		GameController.killcount = 0;
		GameController.points = 0;
		GameController.seconds = 0;
		GameController.ultraHard = false;
		GameController.hard = false;
        canvas.SetActive(true);
    }
	public void loadMenu(){
		SceneManager.LoadScene ("MainMenu");
		GameController.isAlive = true;
		Time.timeScale = 1f;
		GameController.ammo = 20;
		GameController.killcount = 0;
		GameController.points = 0;
		GameController.seconds = 0;
		GameController.ultraHard = false;
		GameController.hard = false;
        canvas.SetActive(true);
    }
	public void quit(){
		Application.Quit();
	}
}
