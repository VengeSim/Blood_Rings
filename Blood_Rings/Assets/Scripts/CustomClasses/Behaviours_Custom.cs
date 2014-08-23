﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;

using BloodRings;
using Debug = BloodRings.Debug;
using Input = BloodRings.Input;
using Action = BloodRings.Action;


namespace BloodRings{

	public static class SetBehaviours{
		public static Behaviour fighter1;
		
		public static Behaviour Fighter1(CharacterController2D cController){
			Condition returnFalse = new Condition(false);
			Condition returnTrue = new Condition(true);

			CheckInput checkUp = new CheckInput("Up");
			CheckInput checkDown = new CheckInput("Down");
			CheckInput checkTurn = new CheckAntiTurbo("Turn");
			CheckInput checkBlock = new CheckInput("Block");
			CheckInput checkRight = new CheckInput("Right");
			CheckInput checkLeft = new CheckInput("Left");
			CheckInput checkButton1 = new CheckAntiTurbo("1");
			CheckInput checkButton2 = new CheckAntiTurbo("2");
			CheckInput checkButton3 = new CheckAntiTurbo("3");
			CheckInput checkButton4 = new CheckAntiTurbo("4");
			
			CheckState checkStateNeutral = new CheckState(State.Neutral);
			CheckState checkStateCrouch = new CheckState(State.Crouch);
			CheckState checkStateInAir = new CheckState(State.InAir);
			
			
			SetState setNeutralState = new SetState(State.Neutral);
			SetState setCrouchState = new SetState(State.Crouch);
			
			SetBlockState setBlockStateTrue = new SetBlockState(BlockState.True);
			SetBlockState setBlockStateFalse = new SetBlockState(BlockState.False);
			
			SetWalkState setWalkStateFalse = new SetWalkState(WalkState.False);
			SetWalkState setWalkStateRight = new SetWalkState(WalkState.Right);
			SetWalkState setWalkStateLeft = new SetWalkState(WalkState.Left);
			
			SetJumpState setJumpStateFalse = new SetJumpState(JumpState.False);
			SetJumpState setJumpStateTrue = new SetJumpState(JumpState.True);
			
			CheckJumpState checkJumpStateFalse = new CheckJumpState(JumpState.False);
			CheckJumpState checkJumpStateTrue = new CheckJumpState(JumpState.True);
			CheckJumpState checkJumpStateInAir = new CheckJumpState(JumpState.InAir);
			
			CheckJumpOnGroundCoolDown checkJumpOnGroundCoolDown = new CheckJumpOnGroundCoolDown();

			CheckAttackState checkAttackStateReady = new CheckAttackState(AttackState.Ready);
			CheckAttackState checkAttackStateStartUp = new CheckAttackState(AttackState.StartUp);
			CheckAttackState checkAttackStateActive = new CheckAttackState(AttackState.Active);
			CheckAttackState checkAttackStateRecovery = new CheckAttackState(AttackState.Recovery);
			
			StartAttack1 startAttack1 = new StartAttack1();
			StartAttack2 startAttack2 = new StartAttack2();
			StartAttack3 startAttack3 = new StartAttack3();
			StartAttack4 startAttack4 = new StartAttack4();
			
			
			SetBoxData setNeutralBoxData = new SetBoxData(Fighter1BoxData.NEUTRAL);
			SetBoxData setCrouchBoxData = new SetBoxData(Fighter1BoxData.CROUCH);
			
			IsGrounded isGrounded = new IsGrounded();
			Turn doTurn = new Turn();
			
//********************************************************************************************

			Sequence walkLeft = new Sequence(cController, "WalkLeft");
			walkLeft.AddChild(setWalkStateLeft);
			walkLeft.AddChild(setNeutralBoxData);
			
			Sequence walkRight = new Sequence(cController, "WalkRight");
			walkRight.AddChild(setWalkStateRight);
			walkRight.AddChild(setNeutralBoxData);

			Sequence block = new Sequence(cController, "Block");
			block.AddChild(setBlockStateTrue);
			block.AddChild(setNeutralBoxData);
			

			Sequence crouch = new Sequence(cController, "Crouch");
			crouch.AddChild(setCrouchState);
			crouch.AddChild(setCrouchBoxData);
			
			Sequence jump = new Sequence(cController, "Jump");
			jump.AddChild(setJumpStateTrue);
			jump.AddChild(setNeutralBoxData);
			

			
//********************************************************************************************
			
			Selector Movement = new Selector(cController, "MoveMent");
			
			Sequence Attack1 = new Sequence(cController, "Attack1");
			Attack1.AddChild(checkButton1);
			Attack1.AddChild(startAttack1);
			Sequence Attack2 = new Sequence(cController, "Attack2");
			Attack2.AddChild(checkButton2);
			Attack2.AddChild(startAttack2);
			Sequence Attack3 = new Sequence(cController, "Attack3");
			Attack3.AddChild(checkButton3);
			Attack3.AddChild(startAttack3);
			Sequence Attack4 = new Sequence(cController, "Attack4");
			Attack4.AddChild(checkButton4);
			Attack4.AddChild(startAttack4);
			
//********************************************************************************************
			
			
			Sequence ResetStates = new Sequence(cController, "ResetStates");
			ResetStates.AddChild(setWalkStateFalse);
			ResetStates.AddChild(setBlockStateFalse);
			ResetStates.AddChild(setNeutralState);
			ResetStates.AddChild(returnFalse);
			
			Sequence Turn = new Sequence(cController, "Prioity 0");
			Turn.AddChild(checkTurn);
			Turn.AddChild(doTurn);
			
			Sequence BlockAndCrouch = new Sequence(cController, "BlockAndCrouch");
			BlockAndCrouch.AddChild(checkJumpStateFalse);
			BlockAndCrouch.AddChild(checkBlock);
			BlockAndCrouch.AddChild(checkDown);
			BlockAndCrouch.AddChild(block);
			BlockAndCrouch.AddChild(crouch);
			
			Sequence Block = new Sequence(cController, "Block");
			Block.AddChild(isGrounded);
			Block.AddChild(checkBlock);
			Block.AddChild(block);
	
			Sequence Crouch = new Sequence(cController, "Crouch");
			Crouch.AddChild(isGrounded);
			Crouch.AddChild(checkDown);
			Crouch.AddChild(crouch);
	
			Sequence Jump = new Sequence(cController, "Jump");
			Jump.AddChild(isGrounded);
			Jump.AddChild(checkUp);
			Jump.AddChild(checkJumpOnGroundCoolDown);
			Jump.AddChild(jump);
			Jump.AddChild(setNeutralBoxData);
			
	
			Sequence WalkRight = new Sequence(cController, "WalkRight");
			WalkRight.AddChild(isGrounded);
			WalkRight.AddChild(checkRight);
			WalkRight.AddChild(walkRight);
			WalkRight.AddChild(setNeutralBoxData);
			
	
			Sequence WalkLeft = new Sequence(cController, "WalkLeft");
			WalkLeft.AddChild(isGrounded);
			WalkLeft.AddChild(checkLeft);
			WalkLeft.AddChild(walkLeft);
			WalkLeft.AddChild(setNeutralBoxData);
			
			
			Sequence Neutral = new Sequence(cController, "Prioity 6");
			Neutral.AddChild(isGrounded);
			Neutral.AddChild(setNeutralState);
			Neutral.AddChild(setNeutralBoxData);
			
//*****************************************************************************
			
			Selector Attacks = new Selector(cController, "Attacks");
			Attacks.AddChild(checkJumpStateInAir);
			Attacks.AddChild(Attack1);
			Attacks.AddChild(Attack2);
			Attacks.AddChild(Attack3);
			Attacks.AddChild(Attack4);
			
//*****************************************************************************			
			
			Selector startNode = new Selector(cController, "StartNode");

			
			startNode.AddChild(ResetStates);
			
			startNode.AddChild(checkAttackStateStartUp);
			startNode.AddChild(checkAttackStateActive);
			startNode.AddChild(checkAttackStateRecovery);
			
			startNode.AddChild(Turn);
			startNode.AddChild(BlockAndCrouch);
			startNode.AddChild(Block);
			
			startNode.AddChild(Attacks);
			

			startNode.AddChild(Crouch);
			startNode.AddChild(Jump);
			startNode.AddChild(WalkRight);
			startNode.AddChild(WalkLeft);
			
			startNode.AddChild(Neutral);
			
			
			return startNode;
		}
	}




	public class CheckState : Condition{
		protected State state;
		public CheckState(State state){
			this.state = state;
			
		}
		protected override BH_STATUS Update (){
			if (cController.State == this.state){
				return BH_STATUS.BH_SUCCESS;
			}else{
				return BH_STATUS.BH_FAILURE;
			}
		}
	}
	public class CheckBlockState : Condition{
		protected BlockState state;
		public CheckBlockState(BlockState state){
			this.state = state;
			
		}
		protected override BH_STATUS Update (){
			if (cController.BlockState == this.state){
				return BH_STATUS.BH_SUCCESS;
			}else{
				return BH_STATUS.BH_FAILURE;
			}
		}
	}
	public class CheckWalkState : Condition{
		protected WalkState state;
		public CheckWalkState(WalkState state){
			this.state = state;
			
		}
		protected override BH_STATUS Update (){
			if (cController.WalkState == this.state){
				return BH_STATUS.BH_SUCCESS;
			}else{
				return BH_STATUS.BH_FAILURE;
			}
		}
	}
	public class CheckJumpState : Condition{
		protected JumpState state;
		public CheckJumpState(JumpState state){
			this.state = state;
			
		}
		protected override BH_STATUS Update (){
			if (cController.JumpState == this.state){
				return BH_STATUS.BH_SUCCESS;
			}else{
				return BH_STATUS.BH_FAILURE;
			}
		}
	}
	public class CheckInput : Condition{
		protected string name;
		
		public CheckInput(string name){
			this.name = name;
		}
		protected override BH_STATUS Update (){
			if (cController.iMon.FindInput(name).State){
				return BH_STATUS.BH_SUCCESS;
			}else{
				return BH_STATUS.BH_FAILURE;
			}
		}
	}
	
	public class CheckAntiTurbo : CheckInput{
		public CheckAntiTurbo(string name): base(name){}
		
		protected override BH_STATUS Update (){
			if (cController.iMon.FindInput(name).AntiTurbo){
				return BH_STATUS.BH_SUCCESS;
			}else{
				return BH_STATUS.BH_FAILURE;
			}
		}
	}
	
	public class IsGrounded : Condition{
		public IsGrounded(){}
		protected override BH_STATUS Update (){
			if (cController.isGrounded){
				return BH_STATUS.BH_SUCCESS;
			}else{
				return BH_STATUS.BH_FAILURE;
			}
		}
	}
	public class CheckJumpOnGroundCoolDown : Condition{
		public CheckJumpOnGroundCoolDown(){}
		protected override BH_STATUS Update (){
			if (cController.onGroundFrameCount >= cController.cStats.jumpGroundCoolDown){
				return BH_STATUS.BH_SUCCESS;
			}else{
				return BH_STATUS.BH_FAILURE;
			}
		}
	}
	public class CheckAttackState : Condition{
		protected AttackState state;
		public CheckAttackState(AttackState state){
			this.state = state;
			
		}
		protected override BH_STATUS Update (){
			if (cController.AttackState == this.state){
				return BH_STATUS.BH_SUCCESS;
			}else{
				return BH_STATUS.BH_FAILURE;
			}
		}
	}
	//**********************************************************************************
	
	
	
	public class SetState : Action{
		protected State state;
		public SetState(State state){
			this.state = state;
		}
		protected override BH_STATUS Update (){
			this.cController.State = state;
			return BH_STATUS.BH_SUCCESS;
		}
	}
	
	public class SetBlockState : Action{
		protected BlockState state;
		public SetBlockState(BlockState state){
			this.state = state;
		}
		protected override BH_STATUS Update (){
			this.cController.BlockState = state;
			return BH_STATUS.BH_SUCCESS;
		}
	}
	public class SetWalkState : Action{
		protected WalkState state;
		public SetWalkState(WalkState state){
			this.state = state;
		}
		protected override BH_STATUS Update (){
			this.cController.WalkState = state;
			return BH_STATUS.BH_SUCCESS;
		}
	}
	
	public class SetJumpState : Action{
		protected JumpState state;
		public SetJumpState(JumpState state){
			this.state = state;
		}
		protected override BH_STATUS Update (){
			this.cController.JumpState = state;
			return BH_STATUS.BH_SUCCESS;
		}
	}
	
	public class PlayAnimation : Action{
		protected string animation;
		public PlayAnimation(string animation){
			this.animation = animation;
		}
		protected override BH_STATUS Update (){
			this.cController.Animator.Play(animation);
			return BH_STATUS.BH_SUCCESS;
		}
	}
	
	public class SetBoxData : Action{
		protected BoxData bData;
		public SetBoxData(BoxData bData){
			this.bData = bData;
		}
		protected override BH_STATUS Update (){
			this.cController.SetBoxData(this.bData);
			return BH_STATUS.BH_SUCCESS;
		}
	}
	
	public class Turn : Action{
		public Turn(){}
		protected override BH_STATUS Update (){
			this.cController.Turn();
			return BH_STATUS.BH_SUCCESS;
		}
	}
	
	public class StartAttack1 : Action{
		public StartAttack1(){}
		protected override BH_STATUS Update (){
	
			this.cController.Attack1();

			return BH_STATUS.BH_SUCCESS;
		}
	} 
	public class  StartAttack2 : Action{
		public StartAttack2(){}
		protected override BH_STATUS Update (){
			
			this.cController.Attack2();
			
			return BH_STATUS.BH_SUCCESS;
		}
	}
	public class StartAttack3 : Action{
		public StartAttack3(){}
		protected override BH_STATUS Update (){
			
			this.cController.Attack3();
			
			return BH_STATUS.BH_SUCCESS;
		}
	}
	public class StartAttack4 : Action{
		public StartAttack4(){}
		protected override BH_STATUS Update (){
			
			this.cController.Attack4();
			
			return BH_STATUS.BH_SUCCESS;
		}
	}
}



