using UnityEngine;
using System.Collections;

public class CollisionFlag : MonoBehaviour {

	public bool flag = false;
	
	public bool Bool {get {return flag;}}

	void OnTriggerEnter2D(Collider2D other) {
		this.flag = true;
	}
	
	void OnTriggerExit2D(Collider2D other) {
		this.flag = false;
	}
	void OnTriggerStay2D(Collider2D other) {
		this.flag = true;
	}
	void Start () {
	
	}
	
	void Update () {


	}
	
}






