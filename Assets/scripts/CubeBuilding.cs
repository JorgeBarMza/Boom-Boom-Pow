using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class CubeBuilding : MonoBehaviour {

	float sp = -.01f;
	public GameController Controller;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Transform> ().position += new Vector3 (0, sp, 0);
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="bullet"){
			Controller.addPoints (10*(Controller.winningLine-transform.position.y/Controller.winningLine));
			if (GameObject.FindGameObjectsWithTag ("cube").Length == 1) {
				SceneManager.LoadScene (0);
			}
			GetComponent<AudioSource> ().Play ();
			Destroy(other.gameObject);
			GetComponent<SpriteRenderer>().enabled = false;
			Destroy (GetComponent<Collider2D> ());
			//Destroy (this.gameObect);
		}
	}
 }
