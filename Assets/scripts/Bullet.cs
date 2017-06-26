using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	float sp = .03f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Transform> ().position += new Vector3 (0, sp, 0);
	}
	//Eliminate on visibility
	void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
