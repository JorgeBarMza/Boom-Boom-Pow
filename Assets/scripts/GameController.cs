using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public int cubesNum = 10;
	GameObject cube;
	public GameObject Fondo1;
	public GameObject Fondo2;
	public Text textoPuntos;
	public Text textoCubos;

	public float fondo1switch;
	public float fondo2punto;
	public float fondo2switch;
	public float fondo1punto;
	public float fondosp;


	public float carrilOffset;
	public float carrilWidth;
	public float winningLine;
	public float firstCubeY;
	public float cubeInterval;
	float points = 0;
	int cubes = 0;


	// Use this for initialization
	void Start () {
		cube = Resources.Load("prefabs/cube") as GameObject;
		spawn ();
	}
	
	// Update is called once per frame
	void Update () {
		fondoswitch (); 
	}
	public void addPoints(float pts){
		points+=pts;
		cubes += 1;
		textoPuntos.text = "Puntos: " + points;
		textoCubos.text = "Edificios Destruidos: " + cubes;
	}
	void spawn(){
		for (int i = 0; i < cubesNum; i++) {
			int r = Random.Range (0,2);
			GameObject Temp = Instantiate(cube);
			Temp.GetComponent<CubeBuilding>().Controller = this;
			SpriteRenderer sp = Temp.GetComponent<SpriteRenderer> ();
			float color = (i*.7f) / (float)cubesNum + .3f;
			Temp.GetComponent<AudioSource>().clip = Resources.Load ("sounds/Don't Cry ( Smooth Beat )-" + (i + 1)) as AudioClip;
			sp.color = new Color(color,0,0,1);
			Temp.GetComponent<Transform> ().position = new Vector3 (carrilOffset+r*carrilWidth,firstCubeY+ cubeInterval*i,0);

		}	
	}
	void fondoswitch(){
		Transform transform1 = Fondo1.GetComponent<Transform> ();
		Transform transform2 = Fondo2.GetComponent<Transform> ();
		if (transform1.position.y < fondo1switch) {
			transform1.position = new Vector3 (transform1.position.x, fondo1punto, 0);
		} else if (transform2.position.y < fondo2switch) {
			transform2.position = new Vector3 (transform2.position.x, fondo2punto, 0);
		}
		transform1.position += new Vector3(0,fondosp,0);
		transform2.position += new Vector3(0,fondosp,0);
	}	
}