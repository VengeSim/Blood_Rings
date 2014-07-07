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

	public CharacterStats cStats;
	public Animator animator;
	
	private InputMon iMon;
	private CollisionFlag triggers_Bottom;
	private CollisionFlag triggers_Top;
	private CollisionFlag triggers_Front;
	private CollisionFlag triggers_Back;
	

	public bool walkRight;
	public bool walkLeft;
	public bool jump;

	
	public bool flag_Bottom;
	public bool flag_Top;
	public bool flag_Front;
	public bool flag_Back;
	public bool flag_facingRight;
	
	
	public Vector2 velocity;
	
	void Awake () {
		this.iMon = new InputMon();
		
		triggers_Bottom = this.transform.Find("Sprite/Triggers/Bottom").GetComponent<CollisionFlag>();
		triggers_Top = this.transform.Find("Sprite/Triggers/Top").GetComponent<CollisionFlag>();
		triggers_Front = this.transform.Find("Sprite/Triggers/Front").GetComponent<CollisionFlag>();
		triggers_Back = this.transform.Find("Sprite/Triggers/Back").GetComponent<CollisionFlag>();
		
		this.flag_facingRight = true;
		this.FaceRight();
	}
	
	void Update () {
		this.iMon.Update();
		this.UpdateFlags();
		
		
		this.walkRight = false;
		this.walkLeft = false;
		this.jump = false;
		
		velocity = rigidbody2D.velocity;
		
		if(iMon.Right.State && this.flag_Bottom){
			this.animator.Play("Walk");
			this.FaceRight();
			this.walkRight = true;
		}
		if(iMon.Left.State && this.flag_Bottom){
			this.animator.Play("Walk");
			this.FaceLeft();
			this.walkLeft = true;
		}
		if(iMon.Up.State && this.flag_Bottom){
			
			this.jump = true;
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

	}
	
	
	
	public void FaceRight(){
		if( transform.localScale.x < 0f ){
			transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			this.flag_facingRight = true;
		}
	}
	public void FaceLeft(){
		if( transform.localScale.x > 0f ){
			transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			this.flag_facingRight = false;
			
		}
	}
	
	public void UpdateFlags(){
	
		flag_Bottom = this.triggers_Bottom.Flag;
		flag_Top = this.triggers_Top.Flag;
		flag_Front = this.triggers_Front.Flag;
		flag_Back = this.triggers_Back.Flag;
		
	
	}
	

}
