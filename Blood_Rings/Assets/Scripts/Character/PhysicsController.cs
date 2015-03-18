using UnityEngine;
using System.Collections;

public class PhysicsController : MonoBehaviour {
	
	public float colliderWidth = 0.06f;
	public float colliderLength = 0.80f;
	
	
	protected CollisionFlag frontFlag;
	protected CollisionFlag backFlag;
	protected CollisionFlag groundFlag;
	
	protected CharacterController2D cController;
	protected Rigidbody2D mainBody;
	protected CircleCollider2D mainCircle;
	
	public bool GroundFlag{
		get{
			return this.groundFlag.Flag;
		}
	}
	public bool FrontFlag{
		get{
			return this.frontFlag.Flag;
		}
	}	
	public bool BackFlag{
		get{
			return this.backFlag.Flag;
		}
	}
	void Awake () {
		this.frontFlag = this.transform.Find("FrontFlag").GetComponent<CollisionFlag>();
		this.backFlag = this.transform.Find("BackFlag").GetComponent<CollisionFlag>();
		this.groundFlag = this.transform.Find("GroundFlag").GetComponent<CollisionFlag>();
		
		this.cController = this.GetComponent<CharacterController2D>();
		this.mainBody = this.GetComponent<Rigidbody2D>();
		this.mainCircle = this.GetComponent<CircleCollider2D>();
		
		
	}
	
	
	void Start () {
		BoxCollider2D front = this.frontFlag.gameObject.GetComponent<BoxCollider2D>();
		BoxCollider2D back = this.backFlag.gameObject.GetComponent<BoxCollider2D>();
		BoxCollider2D bottom = this.groundFlag.gameObject.GetComponent<BoxCollider2D>();
		
		front.size = new Vector2( this.colliderWidth, this.mainCircle.radius * colliderLength);
		front.offset = new Vector2(this.mainCircle.offset.x + this.mainCircle.radius, this.mainCircle.offset.y);
		
		back.size = new Vector2( this.colliderWidth, this.mainCircle.radius * colliderLength);
		back.offset = new Vector2(this.mainCircle.offset.x - this.mainCircle.radius, this.mainCircle.offset.y);
		
		bottom.size = new Vector2(this.mainCircle.radius * colliderLength, this.colliderWidth);
		bottom.offset = new Vector2(this.mainCircle.offset.x, this.mainCircle.offset.y - this.mainCircle.radius);
		
	}
	
	void FixedUpdate() {
		if(this.cController.WalkState == WalkState.Right){
			if(this.cController.FacingRight){
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.cController.Stats.walkForwardSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
			}else{
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.cController.Stats.walkBackwardSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
				
			}
		}
		if(this.cController.WalkState == WalkState.Left){
			if(!this.cController.FacingRight){
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(-this.cController.Stats.walkForwardSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
			}else{
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(-this.cController.Stats.walkBackwardSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
				
			}
		}
		if(this.cController.JumpState == JumpState.True){
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, this.cController.Stats.jumpHeight);
			
		}

	}
}
