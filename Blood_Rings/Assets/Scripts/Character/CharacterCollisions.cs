using UnityEngine;
using System.Collections;

public class CharacterCollisions : MonoBehaviour {

	public CharacterController2D cController;
	
	
	public CircleCollider2D mainCollider;
	public LayerMask groundLayers;
	
	public bool floorCollisionFlag = false;
	public bool roofCollisionFlag = false;
	public bool rightCollisionFlag = false;
	public bool leftCollisionFlag = false;
	
	public bool Flag_FloorCollision {get {return floorCollisionFlag;}}
	public bool Flag_RoofCollision {get {return roofCollisionFlag;}}
	public bool Flag_RightCollision {get {return rightCollisionFlag;}}
	public bool Flag_LeftCollision {get {return leftCollisionFlag;}}
	
	void Start () {
	
	}
	
	void Update () {
		this.FloorCollision();
		this.RoofCollision();
		this.RightCollision();
		this.LeftCollision();
	}
	
	
	private RaycastHit2D RayCastFromCenter(float offSetX, float offSetY, Vector2 dir, float length){
		Vector2 lengthV = new Vector2(dir.x * length, dir.y * length);
		UnityEngine.Debug.DrawLine(
										new Vector2(
											this.transform.position.x + offSetX, 
											this.transform.position.y + offSetY
										),							
										new Vector2(
											this.transform.position.x + offSetX + (dir.x * length), 
											this.transform.position.y + offSetY + (dir.y * length)
										)
									);
		
	
		return Physics2D.Raycast(
									new Vector2(
										this.transform.position.x + offSetX, 
										this.transform.position.y + offSetY
									), 	
									dir, 
									length, 
									this.groundLayers
								);
	}
	
	private bool FloorCollision(){
	
		RaycastHit2D hitC = this.RayCastFromCenter(0f, 0f, new Vector2(0,-1), 0.505f);
		RaycastHit2D hitL = this.RayCastFromCenter(-mainCollider.radius/2, 0f, new Vector2(0,-1), 0.505f);
		RaycastHit2D hitR = this.RayCastFromCenter(mainCollider.radius/2, 0f, new Vector2(0,-1), 0.505f);
		
		if (hitC || hitL || hitR) {
			this.floorCollisionFlag = true;
			return true;
		}
		this.floorCollisionFlag = false;
		return false;
	}
	
	private bool RoofCollision(){
		
		RaycastHit2D hitC = this.RayCastFromCenter(0f, 0f, new Vector2(0,1), 0.505f);
		RaycastHit2D hitL = this.RayCastFromCenter(-mainCollider.radius/2, 0f, new Vector2(0,1), 0.505f);
		RaycastHit2D hitR = this.RayCastFromCenter(mainCollider.radius/2, 0f, new Vector2(0,1), 0.505f);
		
		if (hitC || hitL || hitR) {
			this.roofCollisionFlag = true;
			return true;
		}
		this.roofCollisionFlag = false;
		return false;
	}
	
	private bool RightCollision(){
		
		RaycastHit2D hitC = this.RayCastFromCenter(0f, 0f, new Vector2(1,0), 0.505f);
		RaycastHit2D hitL = this.RayCastFromCenter(0, -mainCollider.radius/2, new Vector2(1,0), 0.505f);
		RaycastHit2D hitR = this.RayCastFromCenter(0, mainCollider.radius/2, new Vector2(1,0), 0.505f);
		
		if (hitC || hitL || hitR) {
			this.rightCollisionFlag = true;
			return true;
		}
		this.rightCollisionFlag = false;
		return false;
	}
	private bool LeftCollision(){
		
		RaycastHit2D hitC = this.RayCastFromCenter(0f, 0f, new Vector2(-1,0), 0.505f);
		RaycastHit2D hitL = this.RayCastFromCenter(0, -mainCollider.radius/2, new Vector2(-1,0), 0.505f);
		RaycastHit2D hitR = this.RayCastFromCenter(0, mainCollider.radius/2, new Vector2(-1,0), 0.505f);
		
		if (hitC || hitL || hitR) {
			this.leftCollisionFlag = true;
			return true;
		}
		this.leftCollisionFlag = false;
		return false;
	}
}
