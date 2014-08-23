﻿/*
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
	public int controller = 1;
	
	public InputMon iMon;
	private CollisionFlag flags_Bottom;
	private CollisionFlag flags_Top;
	private CollisionFlag flags_Front;
	private CollisionFlag flags_Back;
	
	public Sprite[] sprites;

	protected bool phys_WalkRight;
	protected bool phys_WalkLeft;
	protected bool phys_Jump;
	protected bool phys_Stop;
	protected bool facingRight;
	
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
	
	protected TickController tickController;
	
	protected Attack cAttack;
	
	public bool isGrounded;
	public int inAirFrameCount;
	public int onGroundFrameCount;
	public State state;
	public BlockState blockState;
	public WalkState walkState;
	public JumpState jumpState;
	public AttackState attackState;
	public AttackEXState attackEXState;
	public AttackSPState attackSPState;
	
	public BloodRings.Behaviour inputBehaviour;
	
	#region Properties
	public bool Flag_Bottom{
		get{
			return this.flags_Bottom.Bool;
		}
	}
	public bool Flag_Top{
		get{
			return this.flags_Top.Bool;
		}
	}
	public bool Flag_Front{
		get{
			return this.flags_Front.Bool;
		}
	}
	public bool Flag_Back{
		get{
			return this.flags_Back.Bool;
		}
	}
	public State State{
		get{
			return this.state;
		}
		set{
			this.state = value;
		}
	}
	public BlockState BlockState{
		get{
			return this.blockState;
		}
		set{
			this.blockState = value;
		}
	}	
	public WalkState WalkState{
		get{
			return this.walkState;
		}
		set{
			this.walkState = value;
		}
	}
	public JumpState JumpState{
		get{
			return this.jumpState;
		}
		set{
			this.jumpState = value;
		}
	}
	public AttackState AttackState{
		get{
			return this.attackState;
		}
		set{
			this.attackState = value;
		}
	}
	public Animator Animator{
		get{
			return this.animator;
		}
	}
	#endregion
	
	void Awake () {
		this.iMon = new InputMon(this.controller);
		this.tickController = gameObject.GetComponentInParent<TickController>();
		
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
		
		
		this.cAttack = null;
		this.facingRight = true;
		this.FaceRight();
		this.SetBoxData(Fighter1BoxData.NEUTRAL);
		
		this.inputBehaviour = BloodRings.SetBehaviours.Fighter1(this);
		
	}
	
	void Update () {
	
		if(this.Flag_Bottom){
			this.onGroundFrameCount++;
			this.inAirFrameCount = 0;
			this.isGrounded = true;	
			this.jumpState = JumpState.False;	
		}else{
			this.onGroundFrameCount = 0;
			this.inAirFrameCount++;
			this.isGrounded = false;
			this.jumpState = JumpState.InAir;	
			
		}
		
		this.iMon.Update();
		this.inputBehaviour.Tick();
		
		this.phys_Stop = false;
		
		this.animator.SetInteger("State",(int)this.state);
		this.animator.SetInteger("BlockState",(int)this.blockState);
		this.animator.SetInteger("WalkState",(int)this.walkState);
		this.animator.SetInteger("JumpState",(int)this.jumpState);
		this.animator.SetFloat("Velocity_Y", this.rigidbody2D.velocity.y);
		

	}
	

	
	public void Turn(){
		if(facingRight){
			this.FaceLeft();
		}else{
			this.FaceRight();
		}
	}
	#region Physics
	void FixedUpdate(){
		
		if(this.walkState == WalkState.Right){
			if(this.facingRight){
				this.rigidbody2D.velocity = new Vector2(cStats.walkForwardSpeed, this.rigidbody2D.velocity.y);
			}else{
				this.rigidbody2D.velocity = new Vector2(cStats.walkBackwardSpeed, this.rigidbody2D.velocity.y);
				
			}
		}
		if(this.walkState == WalkState.Left){
			if(!this.facingRight){
				this.rigidbody2D.velocity = new Vector2(-cStats.walkForwardSpeed, this.rigidbody2D.velocity.y);
			}else{
				this.rigidbody2D.velocity = new Vector2(-cStats.walkBackwardSpeed, this.rigidbody2D.velocity.y);
				
			}
		}
		if(this.jumpState == JumpState.True){
			this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x, cStats.jumpHeight);
			
		}
		if(this.phys_Stop){
			this.rigidbody2D.velocity = new Vector2(0, this.rigidbody2D.velocity.y);
			
		}
	}
	
	#endregion
	
	
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
	

	
	public void SetHitBoxHighData(BoxData bData){
		hitboxHigh1Col.size = bData.HitboxHigh1.Size;
		hitboxHigh2Col.size = bData.HitboxHigh2.Size;
		hitboxHigh3Col.size = bData.HitboxHigh3.Size;
		hitboxHigh1Col.center = bData.HitboxHigh1.Center;
		hitboxHigh2Col.center = bData.HitboxHigh2.Center;
		hitboxHigh3Col.center = bData.HitboxHigh3.Center;
	}
	public void SetHitBoxLowData(BoxData bData){
		hitboxLow1Col.size = bData.HitboxLow1.Size;
		hitboxLow2Col.size = bData.HitboxLow2.Size;
		hitboxLow3Col.size = bData.HitboxLow3.Size;
		hitboxLow1Col.center = bData.HitboxLow1.Center;
		hitboxLow2Col.center = bData.HitboxLow2.Center;
		hitboxLow3Col.center = bData.HitboxLow3.Center;
	}
	public void SetHurtBoxData(BoxData bData){
		hurtbox1Col.size = bData.HurtBox1.Size;
		hurtbox2Col.size = bData.HurtBox2.Size;
		hurtbox3Col.size = bData.HurtBox3.Size;
		hurtbox1Col.center = bData.HurtBox1.Center;
		hurtbox2Col.center = bData.HurtBox2.Center;
		hurtbox3Col.center = bData.HurtBox3.Center;
	}
	public void SetTriggerData(BoxData bData){
		topCol.size = bData.Top.Size;
		topCol.center = bData.Top.Center;		
		bottomCol.size = bData.Bottom.Size;
		bottomCol.center = bData.Bottom.Center;
		frontCol.size = bData.Front.Size;
		frontCol.center = bData.Front.Center;
		backCol.size = bData.Back.Size;
		backCol.center = bData.Back.Center;
	}
	public void SetBoxData(BoxData bData){
		this.SetTriggerData(bData);
		this.SetHitBoxHighData(bData);
		this.SetHitBoxLowData(bData);
		this.SetHurtBoxData(bData);
				
	}
	
	public void Attack1(){
		this.StartAttack(this.cStats.attack5);
	}
	public void Attack2(){
		this.StartAttack(this.cStats.attack6);
	}
	public void Attack3(){
		this.StartAttack(this.cStats.attack7);
	}
	public void Attack4(){
		this.StartAttack(this.cStats.attack8);
	}

	
	public void StartAttack(Attack attack){
		int startTick = this.tickController.Tick;
		
		this.cAttack = attack;
		this.animator.enabled = false;
		
		this.startRenderer.sprite = attack.Sprite;
		StartCoroutine(AttackRoutine(startTick, attack));
		
	}
	
	public void EndAttack(){
		this.attackState = AttackState.Ready;
		this.animator.enabled = true;
		this.attackEXState = AttackEXState.None;
		this.attackSPState = AttackSPState.None;
		
		
	}
	
	IEnumerator AttackRoutine(int startTick, Attack attack){
		while(true){
		
			int currentTick = tickController.Tick;
			int elapsedTicks = currentTick - startTick;
			int startup = attack.Startup;
			int active = attack.Startup + attack.Active;
			int recovery = attack.Startup + attack.Active + attack.Recovery;
			//Debug.Log("[Tick_Elapsed" + elapsedTicks + "]");
			
			
			if(elapsedTicks <= attack.Startup){
				this.attackState = AttackState.StartUp;
				this.attackEXState = AttackEXState.None;
				this.attackSPState = AttackSPState.None;
				
			}
			if(elapsedTicks > startup && elapsedTicks <= active){
				this.startRenderer.sprite = null;
				this.mainRenderer.sprite = attack.Sprite;
				this.SetBoxData(attack.BoxData);
				
				this.attackState = AttackState.Active;
				this.attackEXState = AttackEXState.None;
				this.attackSPState = AttackSPState.None;
				
			}
			if(elapsedTicks > active && elapsedTicks <= recovery){
				BoxData nData = new BoxData();
				nData.SetHurtBoxes(new BoxPos(), new BoxPos(), new BoxPos());
				this.SetHurtBoxData(nData);
				
				this.attackState = AttackState.Recovery;
				this.attackEXState = AttackEXState.None;
				this.attackSPState = AttackSPState.None;
				
			}
			if(elapsedTicks > recovery){
				this.EndAttack();
				
				yield break;
			}
			yield return 0;
		}
	}


}
