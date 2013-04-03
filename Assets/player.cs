using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	float speed;
	bool isGrounded = false;
	
	void OnCollisionEnter(Collision collision) {
		
		print("collision");
		
        foreach (ContactPoint contact in collision.contacts) {
            Debug.DrawRay(contact.point, contact.normal, Color.red);
			if(contact.point.y < gameObject.transform.position.y){
				isGrounded = true;
				if (collision.relativeVelocity.magnitude > 2){
            		audio.Play();
				}
			} else {
				Debug.Log("collision with non floor");	
			}
        }
    }
	
	 void OnCollisionExit(Collision collisionInfo) {
        print("exit");
		isGrounded = false;
    }
	
	// Use this for initialization
	void Start () {
		speed = 10;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		
	}
	
	
	// Update is called once per frame
	void Update () {
			
		if(Input.GetKey(KeyCode.RightArrow)){
			rigidbody.AddForce(new Vector3(1, 0, 0)*speed);
		}
		if(Input.GetKey (KeyCode.LeftArrow)){
			rigidbody.AddForce(new Vector3(-1, 0, 0)*speed);
		}
		if(Input.GetKey(KeyCode.UpArrow) && isGrounded){
			rigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
		}
	}
}
