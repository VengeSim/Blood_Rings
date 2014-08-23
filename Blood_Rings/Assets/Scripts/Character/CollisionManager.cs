using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour {
	
	protected CharacterController2D cController;
	
	protected CollisionFlag hitboxHigh1;
	protected CollisionFlag hitboxHigh2;
	protected CollisionFlag hitboxHigh3;
	protected CollisionFlag hitboxLow1;
	protected CollisionFlag hitboxLow2;
	protected CollisionFlag hitboxLow3;
	protected CollisionFlag hurtbox1;
	protected CollisionFlag hurtbox2;
	protected CollisionFlag hurtbox3;
	
	protected CollisionFlag[] array;
	
	void Awake () {
		this.cController = this.gameObject.GetComponent<CharacterController2D>();
	
		this.hitboxHigh1 = this.transform.Find("Boxes/High/HitBoxHigh1").GetComponent<CollisionFlag>();
		this.hitboxHigh2 = this.transform.Find("Boxes/High/HitBoxHigh2").GetComponent<CollisionFlag>();
		this.hitboxHigh3 = this.transform.Find("Boxes/High/HitBoxHigh3").GetComponent<CollisionFlag>();
		
		this.hitboxLow1 = this.transform.Find("Boxes/Low/HitBoxLow1").GetComponent<CollisionFlag>();
		this.hitboxLow2 = this.transform.Find("Boxes/Low/HitBoxLow2").GetComponent<CollisionFlag>();
		this.hitboxLow3 = this.transform.Find("Boxes/Low/HitBoxLow3").GetComponent<CollisionFlag>();
		
		this.hurtbox1 = this.transform.Find("Boxes/HurtBox1").GetComponent<CollisionFlag>();
		this.hurtbox2 = this.transform.Find("Boxes/HurtBox2").GetComponent<CollisionFlag>();
		this.hurtbox3 = this.transform.Find("Boxes/HurtBox3").GetComponent<CollisionFlag>();
	}
	
	void Update () {
		
		
		
	}
}








