using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour {
	
	public BoxCollider2D box1;
	public BoxCollider2D box2;
	public BoxCollider2D box3;
	
	
	public bool flag = false;
	
	public bool Flag {get {return flag;}}
	
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
	
	public void SetPositions(Rect rect1, Rect rect2, Rect rect3){
	
		this.box1.size = rect1.size;
		this.box1.center = rect1.center;
		
		this.box2.size = rect2.size;
		this.box2.center = rect2.center;
		
		this.box3.size = rect3.size;
		this.box3.center = rect3.center;
	}
	
	public void ResetPositions(){
		
		this.box1.size = Vector2.zero;
		this.box1.center = Vector2.zero;
		
		this.box2.size = Vector2.zero;
		this.box2.center = Vector2.zero;
		
		this.box3.size = Vector2.zero;
		this.box3.center = Vector2.zero;
	}
}
