using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tank : MonoBehaviour {


	public float ShootingInterval=.3f;
	public float Timer = .5f;
	public GameObject bullet;
	public GameController Controller;
	public Text gameOver;


//	public string position = "center";

	// Use this for initialization
	void Start () {
		gameOver.text = "";
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "cube") {
		    gameOver.text = "Game Over";
			Invoke ("quitApp", 1);
//			SceneManager.LoadScene (0);

		}
	}

	void quitApp(){
		Application.Quit();
	}

	public void moveLeft(){
		GetComponent<Transform> ().position = new Vector3 (Controller.carrilOffset,transform.position.y, 0);
		Timer+= Time.deltaTime;
//		if(position == "right"){
//			position = "center";	
//		}
//		else if(position == "center"){
//			position = "left";
//		}
	}
	public void moveRight(){
		GetComponent<Transform> ().position = new Vector3 (Controller.carrilOffset + Controller.carrilWidth * 2,transform.position.y, 0); 
		Timer+= Time.deltaTime;
//		if(position == "left"){
//			position = "center";	
//		}
//		else if(position == "center"){
//			position = "right";
//		}
	}
	public void moveCenter(){
		GetComponent<Transform> ().position = new Vector3 (Controller.carrilOffset + Controller.carrilWidth,transform.position.y, 0); 
		Timer+= Time.deltaTime;
//		position = "center";
	}
	public void shoot(){
		Instantiate (bullet, transform.position + new Vector3 (0, .1f, 0),transform.rotation);
		Timer = 0;
		Timer+= Time.deltaTime;
	}
		
}