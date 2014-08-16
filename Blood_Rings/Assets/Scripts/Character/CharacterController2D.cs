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
	private CollisionFlag flags_Bottom;
	private CollisionFlag flags_Top;
	private CollisionFlag flags_Front;
	private CollisionFlag flags_Back;
	
	public Sprite[] sprites;

	public bool walkRight;
	public bool walkLeft;
	public bool jump;
	public bool crouch;
	public bool block;
	public bool neutral;
	public bool bottom;
	public bool top;
	public bool front;
	public bool back;
	public bool attackIsPlaying;
	public bool facingRight;
	public Vector2 velocity;
	
	
	protected BoxCollider2D topCol;
	protected BoxCollider2D bottomCol;
	protected BoxCollider2D frontCol;
	protected BoxCollider2D backCol;
	protected BoxCollider2D hitbox1Col;
	protected BoxCollider2D hitbox2Col;
	protected BoxCollider2D hitbox3Col;
	protected BoxCollider2D hurtbox1Col;
	protected BoxCollider2D hurtbox2Col;
	protected BoxCollider2D hurtbox3Col;
	
	protected SpriteRenderer mainRenderer;
	protected SpriteRenderer startRenderer;
	
	protected TickController tickController;
	
	void Awake () {
		this.iMon = new InputMon();
		this.flags_Top = this.transform.Find("Flags/Top").GetComponent<CollisionFlag>();
		this.flags_Bottom = this.transform.Find("Flags/Bottom").GetComponent<CollisionFlag>();
		this.flags_Front = this.transform.Find("Flags/Front").GetComponent<CollisionFlag>();
		this.flags_Back = this.transform.Find("Flags/Back").GetComponent<CollisionFlag>();
		
		this.topCol = this.transform.Find("Flags/Top").GetComponent<BoxCollider2D>();
		this.bottomCol = this.transform.Find("Flags/Bottom").GetComponent<BoxCollider2D>();
		this.frontCol = this.transform.Find("Flags/Front").GetComponent<BoxCollider2D>();
		this.backCol = this.transform.Find("Flags/Back").GetComponent<BoxCollider2D>();
		
		this.hitbox1Col = this.transform.Find("Boxes/HitBox1").GetComponent<BoxCollider2D>();
		this.hitbox2Col = this.transform.Find("Boxes/HitBox2").GetComponent<BoxCollider2D>();
		this.hitbox3Col = this.transform.Find("Boxes/HitBox3").GetComponent<BoxCollider2D>();
		
		this.hurtbox1Col = this.transform.Find("Boxes/HurtBox1").GetComponent<BoxCollider2D>();
		this.hurtbox2Col = this.transform.Find("Boxes/HurtBox2").GetComponent<BoxCollider2D>();
		this.hurtbox3Col = this.transform.Find("Boxes/HurtBox3").GetComponent<BoxCollider2D>();
		
		this.mainRenderer = this.transform.Find("Sprite").GetComponent<SpriteRenderer>();
		this.startRenderer = this.transform.Find("StartupSprite").GetComponent<SpriteRenderer>();
		
		this.tickController = gameObject.GetComponentInParent<TickController>();
		
		this.facingRight = true;
		this.FaceRight();
	}
	
	void Update () {
		this.iMon.Update();
		this.UpdateFlags();
		this.animator.SetBool("NotOnGround", !this.bottom);
		this.animator.SetFloat("VelocityY", this.rigidbody2D.velocity.y);
		
		
		this.walkRight = false;
		this.walkLeft = false;
		this.jump = false;
		this.crouch = false;
		this.block = false;
		this.neutral = false;
		
		velocity = rigidbody2D.velocity;
		
		if(!this.attackIsPlaying){
			
			//Block
			if(iMon.Block.State && this.flags_Bottom.Bool){
				this.animator.SetBool("Block", true);
				this.animator.SetBool("Walk", false);
				this.animator.SetBool("Crouch", false);
				
				this.block = true;
			}
			
			//Crouch
			if(this.iMon.Down.State && this.flags_Bottom.Bool){
				if(!this.block){
					this.animator.SetBool("Block", false);
				}
				this.animator.SetBool("Crouch", true);
				this.animator.SetBool("Walk", false);
				this.SetBoxData(Fighter1BoxData.CROUCH);
				this.crouch = true;
			}
			
			//test
			if(this.iMon.Button1.State && this.flags_Bottom.Bool && !this.block){
	
				this.animator.enabled = false;
				this.StartAttack(this.cStats.a1);
				
			}
			
			//Right
			if(this.flags_Bottom.Bool && !this.crouch && !this.block){
			
				//Right
				if(iMon.Right.State){
					this.animator.SetBool("Walk", true);
					this.animator.SetBool("Crouch", false);
					this.animator.SetBool("Block", false);
					this.SetBoxData(Fighter1BoxData.NEUTRAL);
					
					this.walkRight = true;
	
				}
				
				//Left
				if(iMon.Left.State){
					this.animator.SetBool("Walk", true);
					this.animator.SetBool("Crouch", false);
					this.animator.SetBool("Block", false);
					this.SetBoxData(Fighter1BoxData.NEUTRAL);
					
					this.walkLeft = true;
				}
			}
			
			//Jump
			if(iMon.Up.State && this.flags_Bottom.Bool && !this.block){
				this.animator.SetBool("Crouch", false);
				this.animator.SetBool("Block", false);
				this.animator.SetBool("Walk", false);
				this.SetBoxData(Fighter1BoxData.NEUTRAL);
				
				this.jump = true;
			}
			
			//Neutral
			if(this.flags_Bottom.Bool && !this.walkLeft && !this.walkRight && !this.jump && !this.crouch && !this.block){			
				this.animator.SetBool("Walk", false);
				this.animator.SetBool("Crouch", false);
				this.animator.SetBool("Block", false);
				this.animator.Play("Neutral");
				this.SetBoxData(Fighter1BoxData.NEUTRAL);
				
				this.neutral = true;
				
			}
			
			//Turn
			if(this.iMon.Turn.Held <= 1 && this.iMon.Turn.State){
				this.Turn();
			}
		}	

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
		
		hitbox1Col.size = bData.Hitbox1.Size;
		hitbox2Col.size = bData.Hitbox2.Size;
		hitbox3Col.size = bData.Hitbox3.Size;
		
		hurtbox1Col.size = bData.HurtBox1.Size;
		hurtbox2Col.size = bData.HurtBox2.Size;
		hurtbox3Col.size = bData.HurtBox3.Size;
		
		
		//Centers
		topCol.center = bData.Top.Center;		
		bottomCol.center = bData.Bottom.Center;
		frontCol.center = bData.Front.Center;
		backCol.center = bData.Back.Center;
		
		hitbox1Col.center = bData.Hitbox1.Center;
		hitbox2Col.center = bData.Hitbox2.Center;
		hitbox3Col.center = bData.Hitbox3.Center;
		
		hurtbox1Col.center = bData.HurtBox1.Center;
		hurtbox2Col.center = bData.HurtBox2.Center;
		hurtbox3Col.center = bData.HurtBox3.Center;
	}
	
	public void StartAttack(Attack attack){
		int startTick = this.tickController.Tick;
		
		this.attackIsPlaying = true;
		this.animator.enabled = false;
		
		this.startRenderer.sprite = attack.Sprite;
		StartCoroutine(AttackRoutine(startTick, attack));
		
	}
	
	IEnumerator AttackRoutine(int startTick, Attack attack){
		while(true){
		
			int currentTick = tickController.Tick;
			int elapsedTicks = currentTick - startTick;
			int startup = attack.Startup;
			int active = attack.Startup + attack.Active;
			int recovery = attack.Startup + attack.Active + attack.Recovery;
			Debug.Log("[Tick_Elapsed" + elapsedTicks + "]");
			
			
			if(elapsedTicks <= attack.Startup){
				
			}
			if(elapsedTicks > startup && elapsedTicks <= active){
				this.startRenderer.sprite = null;
				this.mainRenderer.sprite = attack.Sprite;
				this.SetBoxData(attack.BoxData);
			}
			if(elapsedTicks > active && elapsedTicks <= recovery){
				//Disable hurtboxes
			}
			if(elapsedTicks > recovery){
				this.attackIsPlaying = false;
				this.animator.enabled = true;
				
				break;
			}
			yield return 0;
		}
	}
}
