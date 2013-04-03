using UnityEngine;
using System.Collections;


public class leftBoneBoxSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		BoxCollider b = collider as BoxCollider;
		
		if(b != null)	{
	    	b.size = new Vector3(1f, 0.4f, 1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
