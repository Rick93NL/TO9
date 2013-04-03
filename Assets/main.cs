using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {
	//private GameObject myCamera;
	
	// Use this for initialization
	void Start () {
		//myCamera = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Time.deltaTime*5, 0, 0);
	}
}
