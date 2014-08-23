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

public class DummyController2D: MonoBehaviour {
	
	public CharacterStats cStats;
	public Animator animator;
	
	private CollisionFlag flags_Bottom;
	private CollisionFlag flags_Top;
	private CollisionFlag flags_Front;
	private CollisionFlag flags_Back;
		
	public bool walkRight;
	public bool walkLeft;
	public bool jump;
	public bool crouch;
	public bool neutral;
	
	public bool bottom;
	public bool top;
	public bool front;
	public bool back;
	
	public bool facingRight;
	public Vector2 velocity;

	
	
	protected BoxCollider2D topCol;
	protected BoxCollider2D bottomCol;
	protected BoxCollider2D frontCol;
	protected BoxCollider2D backCol;
	protected BoxCollider2D hitboxHigh1Col;
	protected BoxCollider2D hitboxHigh2Col;
	protected BoxCollider2D hitboxHigh3Col;
	protected BoxCollider2D hitboxLow1Col;
	protected BoxCollider2D hitboxLow2Col;
	protected BoxCollider2D hitboxLow3Col;
	protected BoxCollider2D hurtbox1Col;
	protected BoxCollider2D hurtbox2Col;
	protected BoxCollider2D hurtbox3Col;
	
	protected SpriteRenderer mainRenderer;
	protected SpriteRenderer startRenderer;
		
	void Awake () {
		this.flags_Top = this.transform.Find("Flags/Top").GetComponent<CollisionFlag>();
		this.flags_Bottom = this.transform.Find("Flags/Bottom").GetComponent<CollisionFlag>();
		this.flags_Front = this.transform.Find("Flags/Front").GetComponent<CollisionFlag>();
		this.flags_Back = this.transform.Find("Flags/Back").GetComponent<CollisionFlag>();
		
		this.topCol = this.transform.Find("Flags/Top").GetComponent<BoxCollider2D>();
		this.bottomCol = this.transform.Find("Flags/Bottom").GetComponent<BoxCollider2D>();
		this.frontCol = this.transform.Find("Flags/Front").GetComponent<BoxCollider2D>();
		this.backCol = this.transform.Find("Flags/Back").GetComponent<BoxCollider2D>();
		
		this.hitboxHigh1Col = this.transform.Find("Boxes/High/HitBoxHigh1").GetComponent<BoxCollider2D>();
		this.hitboxHigh2Col = this.transform.Find("Boxes/High/HitBoxHigh2").GetComponent<BoxCollider2D>();
		this.hitboxHigh3Col = this.transform.Find("Boxes/High/HitBoxHigh3").GetComponent<BoxCollider2D>();
		
		this.hitboxLow1Col = this.transform.Find("Boxes/Low/HitBoxLow1").GetComponent<BoxCollider2D>();
		this.hitboxLow2Col = this.transform.Find("Boxes/Low/HitBoxLow2").GetComponent<BoxCollider2D>();
		this.hitboxLow3Col = this.transform.Find("Boxes/Low/HitBoxLow3").GetComponent<BoxCollider2D>();
		
		this.hurtbox1Col = this.transform.Find("Boxes/HurtBox1").GetComponent<BoxCollider2D>();
		this.hurtbox2Col = this.transform.Find("Boxes/HurtBox2").GetComponent<BoxCollider2D>();
		this.hurtbox3Col = this.transform.Find("Boxes/HurtBox3").GetComponent<BoxCollider2D>();
		
		this.mainRenderer = this.transform.Find("Sprite").GetComponent<SpriteRenderer>();
		this.startRenderer = this.transform.Find("StartupSprite").GetComponent<SpriteRenderer>();
		
		if(this.facingRight){
			this.FaceRight();
		}else{
			this.FaceLeft();
		}
	}
	
	void Update () {
		this.UpdateFlags();
		this.animator.SetBool("NotOnGround", !this.bottom);
		this.animator.SetFloat("VelocityY", this.rigidbody2D.velocity.y);
		this.SetBoxData(DummyBoxData.NEUTRAL);
		
		velocity = rigidbody2D.velocity;
		
	}
	
	void FixedUpdate(){
		
		if(this.walkRight){
			if(this.facingRight){
				this.rigidbody2D.velocity = new Vector2(cStats.walkForwardSpeed, this.rigidbody2D.velocity.y);
			}else{
				this.rigidbody2D.velocity = new Vector2(cStats.walkBackwardSpeed, this.rigidbody2D.velocity.y);
				
			}
		}
		if(this.walkLeft){
			if(!this.facingRight){
				this.rigidbody2D.velocity = new Vector2(-cStats.walkForwardSpeed, this.rigidbody2D.velocity.y);
			}else{
				this.rigidbody2D.velocity = new Vector2(-cStats.walkBackwardSpeed, this.rigidbody2D.velocity.y);
				
			}
		}
		if(this.jump){
			this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x, cStats.jumpHeight);
			
		}
		if(this.neutral){
			this.rigidbody2D.velocity = new Vector2(0, this.rigidbody2D.velocity.y);
			
		}
	}
	
	
	
	public void FaceRight(){
		if( transform.localScale.x < 0f ){
			transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			this.facingRight = true;
		}
	}
	public void FaceLeft(){
		if( transform.localScale.x > 0f ){
			transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			this.facingRight = false;
			
		}
	}
	public void Turn(){
		if(facingRight){
			this.FaceLeft();
		}else{
			this.FaceRight();
		}
	}
	
	public void UpdateFlags(){
		
		bottom = this.flags_Bottom.Bool;
		top = this.flags_Top.Bool;
		front = this.flags_Front.Bool;
		back = this.flags_Back.Bool;
		
		
	}
	
	public void SetBoxData(BoxData bData){
		//Sizes
		topCol.size = bData.Top.Size;
		bottomCol.size = bData.Bottom.Size;
		frontCol.size = bData.Front.Size;
		backCol.size = bData.Back.Size;
		
		hitboxHigh1Col.size = bData.HitboxHigh1.Size;
		hitboxHigh2Col.size = bData.HitboxHigh2.Size;
		hitboxHigh3Col.size = bData.HitboxHigh3.Size;
		
		hitboxLow1Col.size = bData.HitboxLow1.Size;
		hitboxLow2Col.size = bData.HitboxLow2.Size;
		hitboxLow3Col.size = bData.HitboxLow3.Size;
		
		
		hurtbox1Col.size = bData.HurtBox1.Size;
		hurtbox2Col.size = bData.HurtBox2.Size;
		hurtbox3Col.size = bData.HurtBox3.Size;
		
		
		//Centers
		topCol.center = bData.Top.Center;		
		bottomCol.center = bData.Bottom.Center;
		frontCol.center = bData.Front.Center;
		backCol.center = bData.Back.Center;
		
		hitboxHigh1Col.center = bData.HitboxHigh1.Center;
		hitboxHigh2Col.center = bData.HitboxHigh2.Center;
		hitboxHigh3Col.center = bData.HitboxHigh3.Center;
		
		hitboxLow1Col.center = bData.HitboxLow1.Center;
		hitboxLow2Col.center = bData.HitboxLow2.Center;
		hitboxLow3Col.center = bData.HitboxLow3.Center;
		
		hurtbox1Col.center = bData.HurtBox1.Center;
		hurtbox2Col.center = bData.HurtBox2.Center;
		hurtbox3Col.center = bData.HurtBox3.Center;
	}
}
