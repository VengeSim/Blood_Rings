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

public class CharacterController2D : ObjectController {
	public int playerNo = 1;
	
	
	public InputMon iMon;
	public BloodRings.Behaviour inputBehaviour;
	
	protected GameController gameController;
	protected PhysicsController physicsController;
	protected CollisionController collisionController;
	protected FxController fxController;
	protected SpriteRenderer mainRenderer;
	protected SpriteRenderer startRenderer;
	protected TickController tickController;
	protected CharacterStats characterStats;
	public Animator animator;
	
	private CollisionFlag flags_Bottom;
	protected BoxCollider2D bottomCol;
	protected BoxCollider2D physicalCol;
	protected BoxCollider2D hitboxHigh1Col;
	protected BoxCollider2D hitboxHigh2Col;
	protected BoxCollider2D hitboxHigh3Col;
	protected BoxCollider2D hitboxLow1Col;
	protected BoxCollider2D hitboxLow2Col;
	protected BoxCollider2D hitboxLow3Col;
	protected BoxCollider2D hurtbox1Col;
	protected BoxCollider2D hurtbox2Col;
	protected BoxCollider2D hurtbox3Col;
	
	protected HitPacket hPacket;
	
	public int health;
	public int stunTicks;
	
	public int inAirFrameCount;
	public int onGroundFrameCount;
	
	public State state;
	public BlockState blockState;
	public WalkState walkState;
	public JumpState jumpState;
	public HitState hitState;
	public StunState stunState;
	public AttackState attackState;
	public AttackEXState attackEXState;
	public AttackSPState attackSPState;
			
	#region Properties
	public GameController GameController{
		get{
			return this.gameController;
		}
	}
	public TickController TickController{
		get{
			return this.tickController;
		}
	}
	public PhysicsController PhysicsController{
		get{
			return this.physicsController;
		}
	}
	public FxController FxController{
		get{
			return this.fxController;
		}
	}
	public Animator Animator{
		get{
			return this.animator;
		}
	}
	public InputMon InputMon{
		get{
			return this.iMon;
		}
	}
	public CharacterStats Stats{
		get{
			return this.characterStats;
		}
	}
	public int PlayerNo{
		get{
			return this.playerNo;
		}
	}
	public HitPacket HitPacket{
		get{
			return this.hPacket;
		}
		set{
			this.hPacket = value;
		}
	}
	
	public int Health{
		get{
			return this.health;
		}
		set{
			this.health = value;
		}
	}
	public int StunTicks{
		get{
			return this.stunTicks;
		}
	}
	public bool GroundFlag{
		get{
			return this.physicsController.GroundFlag;
		}
	}
	public bool FrontFlag{
		get{
			return this.physicsController.FrontFlag;
		}
	}
	public bool BackFlag{
		get{
			return this.physicsController.BackFlag;
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
	public HitState HitState{
		get{
			return this.hitState;
		}
		set{
			this.hitState = value;
		}
	}
	public StunState StunState{
		get{
			return this.stunState;
		}
		set{
			this.stunState = value;
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

	#endregion
	
	void Start () {
		this.iMon = new InputMon(this);
		
		this.gameController = GameObject.Find("GameController").GetComponent<GameController>();
		this.tickController = this.gameController.GetComponent<TickController>();
		
		this.physicsController = this.GetComponent<PhysicsController>();
		this.collisionController = this.GetComponent<CollisionController>();
		this.characterStats = this.GetComponent<CharacterStats>();
		this.fxController = this.GetComponent<FxController>();
		
		this.mainRenderer = this.transform.Find("Sprite").GetComponent<SpriteRenderer>();
		this.startRenderer = this.transform.Find("StartupSprite").GetComponent<SpriteRenderer>();
		
		
		this.physicalCol = this.transform.Find("Boxes/PhysicalBox").GetComponent<BoxCollider2D>();
		
		this.hitboxHigh1Col = this.transform.Find("Boxes/HitBoxHigh1").GetComponent<BoxCollider2D>();
		this.hitboxHigh2Col = this.transform.Find("Boxes/HitBoxHigh2").GetComponent<BoxCollider2D>();
		this.hitboxHigh3Col = this.transform.Find("Boxes/HitBoxHigh3").GetComponent<BoxCollider2D>();
		this.hitboxLow1Col = this.transform.Find("Boxes/HitBoxLow1").GetComponent<BoxCollider2D>();
		this.hitboxLow2Col = this.transform.Find("Boxes/HitBoxLow2").GetComponent<BoxCollider2D>();
		this.hitboxLow3Col = this.transform.Find("Boxes/HitBoxLow3").GetComponent<BoxCollider2D>();
		this.hurtbox1Col = this.transform.Find("Boxes/HurtBox1").GetComponent<BoxCollider2D>();
		this.hurtbox2Col = this.transform.Find("Boxes/HurtBox2").GetComponent<BoxCollider2D>();
		this.hurtbox3Col = this.transform.Find("Boxes/HurtBox3").GetComponent<BoxCollider2D>();
		
		
		this.SetBoxData(BoxData.FIGHTER_1.NEUTRAL);
		
		this.inputBehaviour = BloodRings.BehaviourTrees.ControllerInput(this);
		
		this.health = characterStats.health;
		
	}
	
	void Update () {
	
		if(this.GroundFlag){
			this.onGroundFrameCount++;
			this.inAirFrameCount = 0;
			this.jumpState = JumpState.False;	
		}else{
			this.onGroundFrameCount = 0;
			this.inAirFrameCount++;
			this.jumpState = JumpState.InAir;	
			
		}
		
		this.StunCheck();
		
		this.iMon.Update();
		this.inputBehaviour.Tick();
		
		this.animator.SetInteger("State",(int)this.state);
		this.animator.SetInteger("BlockState",(int)this.blockState);
		this.animator.SetInteger("WalkState",(int)this.walkState);
		this.animator.SetInteger("JumpState",(int)this.jumpState);
		this.animator.SetFloat("Velocity_Y", this.GetComponent<Rigidbody2D>().velocity.y);
		this.animator.SetInteger("HitState",(int)this.hitState);
		this.animator.SetInteger("StunState",(int)this.stunState);
		
		if(this.health <= 0){
			this.animator.SetBool("KnockDown", true);
			this.SetBoxData(BoxData.FIGHTER_1.KNOCKDOWN);
		}
		
//		break timer		
//		if(this.tickController.Tick == 500){
//			
//		}
	}
	
	public bool CanMoveLeft(){
		if(this.FacingRight){
			if(this.BackFlag){
				return false;
			}
		}else{
			if(this.FrontFlag){
				return false;
			}
		}
		return true;
	}
	public bool CanMoveRight(){
		if(this.FacingRight){
			if(this.FrontFlag){
				return false;
			}
		}else{
			if(this.BackFlag){
				return false;
			}
		}
		return true;
	}

	public void SetBoxData(BoxData bData){
		this.collisionController.SetPhysicalBoxData(bData);
		this.collisionController.SetHitBoxHighData(bData);
		this.collisionController.SetHitBoxLowData(bData);
		this.collisionController.SetHurtBoxData(bData);
				
	}
	
	public void Attack1(){
		this.StartAttack(this.characterStats.attack1);
	}
	public void Attack2(){
		this.StartAttack(this.characterStats.attack2);
	}
	public void Attack3(){
		this.StartAttack(this.characterStats.attack3);
	}
	public void Attack4(){
		this.StartAttack(this.characterStats.attack4);
	}
	public void CrouchAttack1(){
		this.StartAttack(this.characterStats.attack5);
	}
	public void CrouchAttack2(){
		this.StartAttack(this.characterStats.attack6);
	}
	public void CrouchAttack3(){
		this.StartAttack(this.characterStats.attack7);
	}
	public void CrouchAttack4(){
		this.StartAttack(this.characterStats.attack8);
	}
	
	public void StartAttack(Attack attack){
		int startTick = this.tickController.Tick;
		
		this.animator.enabled = false;		
		this.startRenderer.sprite = attack.Sprite;
		
		this.state = attack.EndState;
		StartCoroutine(AttackRoutine(startTick, attack));
		
	}
	
	public void EndAttack(Attack attack){
		this.state = attack.EndState;
		this.attackState = AttackState.Ready;
		this.attackEXState = AttackEXState.None;
		this.attackSPState = AttackSPState.None;
		this.startRenderer.sprite = null;
		
		this.animator.enabled = true;
		
	}
	
	IEnumerator AttackRoutine(int startTick, Attack attack){
	
		int startCount = 0;
		int activeCount = 0;
		int recoveryCount = 0;
		while(true){
			
			if(this.HitState != HitState.False){
				this.EndAttack(attack);
				
				yield break;
			}
			
			
			int currentTick = tickController.Tick;
			int elapsedTicks = currentTick - startTick;
			int startup = attack.Startup;
			int active = attack.Startup + attack.Active;
			int recovery = attack.Startup + attack.Active + attack.Recovery;
			//Debug.Log("[Tick_Elapsed" + elapsedTicks + "]");
			
			
			if(elapsedTicks <= attack.Startup){
				startCount++;
				
				this.attackState = AttackState.StartUp;
				this.attackEXState = AttackEXState.None;
				this.attackSPState = AttackSPState.None;
				
			}
			if(elapsedTicks > startup && elapsedTicks <= active){
				activeCount++;
				
				if(activeCount == 1){
					this.SendHitPacket(attack.GetHitPacket());
				}
				
				this.startRenderer.sprite = null;
				this.mainRenderer.sprite = attack.Sprite;
				this.SetBoxData(attack.BoxData);
				
				this.attackState = AttackState.Active;
				this.attackEXState = AttackEXState.None;
				this.attackSPState = AttackSPState.None;
				
			}
			if(elapsedTicks > active && elapsedTicks <= recovery){
				recoveryCount++;
				
				if(recoveryCount == 1){
					this.ResetHitPackets();
				}
				
				BoxData nData = new BoxData(attack.BoxData);
				nData.SetHurtBoxes(new BoxPos(), new BoxPos(), new BoxPos());
				this.SetBoxData(nData);
				
				this.attackState = AttackState.Recovery;
				this.attackEXState = AttackEXState.None;
				this.attackSPState = AttackSPState.None;
				
			}
			if(elapsedTicks > recovery){
				this.EndAttack(attack);
				
				yield break;
			}
			yield return 0;
		}
	}
	
	public void StunCheck(){		
		if(this.stunTicks > 0){
			
			this.StunState = StunState.True;
			this.stunTicks--;
			
			
		}else{
			this.StunState = StunState.False;
			this.HitState = HitState.False;
		}
		
	}
	
	public override void SendHitPacket(HitPacket hPacket){
		HurtBox hurtbox1ColFlag = this.transform.Find("Boxes/HurtBox1").GetComponent<HurtBox>();
		HurtBox hurtbox2ColFlag = this.transform.Find("Boxes/HurtBox2").GetComponent<HurtBox>();
		HurtBox hurtbox3ColFlag = this.transform.Find("Boxes/HurtBox3").GetComponent<HurtBox>();
		
		hurtbox1ColFlag.HitPacket = hPacket;
		hurtbox2ColFlag.HitPacket = hPacket;
		hurtbox3ColFlag.HitPacket = hPacket;
		
	}
	public override void ResetHitPackets(){
		HurtBox hurtbox1ColFlag = this.transform.Find("Boxes/HurtBox1").GetComponent<HurtBox>();
		HurtBox hurtbox2ColFlag = this.transform.Find("Boxes/HurtBox2").GetComponent<HurtBox>();
		HurtBox hurtbox3ColFlag = this.transform.Find("Boxes/HurtBox3").GetComponent<HurtBox>();
		
		hurtbox1ColFlag.HitPacket.Reset();
		hurtbox2ColFlag.HitPacket.Reset();
		hurtbox3ColFlag.HitPacket.Reset();
		
	}
	
	public override void HandleHitPackets(List<HitPacketWrapper> wrapperList){
		for (int i = 0; i < wrapperList.Count; i++) {
			
			//ObjectController owner = wrapperList[i].Owner;
			//HitPacket hPacket = wrapperList[i].HitPacket;
			HitType hitType = wrapperList[i].HitType;
			
			if(hitType == HitType.Low){
				if(this.State == State.Neutral){
					if(this.blockState == BlockState.True){
						//Neutral Block low hit
						this.OnHit(wrapperList[i]);
					}
					if(this.blockState == BlockState.False){
						//Neutral low hit
						this.OnHit(wrapperList[i]);
					}
				}
				if(this.State == State.Crouch){
					if(this.blockState == BlockState.True){
						//crouch Block low hit
						this.OnBlock(wrapperList[i]);
						
					}
					if(this.blockState == BlockState.False){
						this.OnHit(wrapperList[i]);
					}
				}
			}
			if(hitType == HitType.High){
			
				if(this.State == State.Neutral){
					if(this.blockState == BlockState.True){
						//neutral Block high hit
						this.OnBlock(wrapperList[i]);
							
					}
					if(this.blockState == BlockState.False){
						//Neutral high hit
						this.OnHit(wrapperList[i]);
						
					}
				}
				if(this.State == State.Crouch){
					if(this.blockState == BlockState.True){
						//crouch Block high hit
						this.OnHit(wrapperList[i]);
							
					}
					if(this.blockState == BlockState.False){
						//crouch high hit
						this.OnHit(wrapperList[i]);
						
					}
				}
			}
		}
	}
	
	public void OnBlock(HitPacketWrapper wrapper){
		this.stunTicks += wrapper.HitPacket.BlockStun;
		this.ApplyPushBack(wrapper);
		
		wrapper.HitPacket.Reset();
	}
	
	public void OnHit(HitPacketWrapper wrapper){
		//UnityEngine.Debug.Log(this.tickController.Tick.ToString() + "_OnHit_" + wrapper.Owner.gameObject.name +"_"+ wrapper.Source.gameObject.name);
	
		this.HitState = wrapper.HitType.ToHitState();
		this.BlockState = BlockState.False;
		this.stunTicks += wrapper.HitPacket.HitStun;
		this.health -= wrapper.HitPacket.Damage;
		
		this.ApplyPushBack(wrapper);
		this.FxController.OnHit(wrapper);
		wrapper.HitPacket.Reset();
	}
	
	public bool IsBackAgainstWall(){
		return this.BackFlag;
	}
	
	
	public void ApplyPushBack(HitPacketWrapper wrapper){
	
		if(this.IsBackAgainstWall()){
		
			HitPacketWrapper returnWrapper = new HitPacketWrapper(
				this, null, new HitPacket(0, 0, 0, wrapper.HitPacket.PushBack), HitType.None
			);
			wrapper.Owner.ReturnEffects(returnWrapper);
		}else{
		
			bool onRight = this.IsOnRightSide(wrapper.Owner.transform.position);
			
			if(onRight){
				this.GetComponent<Rigidbody2D>().AddForce(new Vector2(wrapper.HitPacket.PushBack , 0), ForceMode2D.Impulse);
			}else{
				this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-wrapper.HitPacket.PushBack , 0), ForceMode2D.Impulse);
				
			}	
		}
	}
	
	public override void ReturnEffects(HitPacketWrapper wrapper){
	
		this.stunTicks += wrapper.HitPacket.HitStun;
		this.health -= wrapper.HitPacket.Damage;
		this.ApplyPushBack(wrapper);
		
		this.HitState = wrapper.HitType.ToHitState();
			
	}
}






