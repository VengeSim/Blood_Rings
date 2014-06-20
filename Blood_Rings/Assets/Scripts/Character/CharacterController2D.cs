/*
	Blood Ring
	Copyright © 2014 jgumbo@live.com
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;

using BloodRings;
using Debug = BloodRings.Debug;
using Input = BloodRings.Input;

public class CharacterController2D: MonoBehaviour {

	public CharacterCollisions cCollisions;
	public CharacterStats cStats;
	public Animator animator;
	
	private InputMon iMon;
	

	public bool walkRight;
	public bool walkLeft;
	public bool jump;
	public bool floatRight;
	public bool floatLeft;
	
	public Vector2 velocity;
	
	void Awake () {
		this.iMon = new InputMon();
		
	}
	
	void Update () {
		this.iMon.Update();
		
		this.walkRight = false;
		this.walkLeft = false;
		this.jump = false;
		this.floatRight = false;
		this.floatLeft = false;
		
		velocity = rigidbody2D.velocity;
		
		if(cCollisions.Flag_FloorCollision && iMon.Right.State){
			this.animator.Play("Walk");
			this.FaceRight();
			this.walkRight = true;
		}
		if(cCollisions.Flag_FloorCollision && iMon.Left.State){
			this.animator.Play("Walk");
			this.FaceLeft();
			this.walkLeft = true;
		}
		if(cCollisions.Flag_FloorCollision  && iMon.Up.State){
			
			this.jump = true;
		}
		if(!cCollisions.Flag_FloorCollision && iMon.Right.State){
			this.FaceRight();
			this.floatRight = true;
		}
		if(!cCollisions.Flag_FloorCollision && iMon.Left.State){
			this.FaceLeft();
			this.floatLeft = true;
		}
		if(!jump && !walkRight && !walkLeft){			
			
			this.animator.Play("Idle");
			
		}
		
		
	}
	
	void FixedUpdate(){
		
		if(this.walkRight){
			this.rigidbody2D.velocity = new Vector2(cStats.walkSpeed, this.rigidbody2D.velocity.y);

		}
		if(this.walkLeft){
			this.rigidbody2D.velocity = new Vector2(-cStats.walkSpeed, this.rigidbody2D.velocity.y);
			
		}
		if(this.jump){
			this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x, cStats.jumpHeight);
			
		}
		if(this.floatRight){
			this.rigidbody2D.velocity = new Vector2(cStats.jumpFloat, this.rigidbody2D.velocity.y);
			
		}
		if(this.floatLeft){
			this.rigidbody2D.velocity = new Vector2(-cStats.jumpFloat, this.rigidbody2D.velocity.y);
			
		}
	}
	
	
	
	public void FaceRight(){
		if( transform.localScale.x < 0f ){
			transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
		}
	}
	public void FaceLeft(){
		if( transform.localScale.x > 0f ){
			transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
		}
	}
}
