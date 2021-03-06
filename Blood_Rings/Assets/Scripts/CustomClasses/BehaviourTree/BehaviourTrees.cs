using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;

using BloodRings;
using Debug = BloodRings.Debug;
using Input = BloodRings.Input;
using Action = BloodRings.Action;

#pragma warning disable 0219

namespace BloodRings{
	
	public static class BehaviourTrees{
		
		public static Behaviour ControllerInput(CharacterController2D cController){
			
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
			
			CheckStunState checkStunStateFalse = new CheckStunState(StunState.False);
			CheckStunState checkStunStateTrue = new CheckStunState(StunState.True);
			CheckStunState checkStunStateBlock = new CheckStunState(StunState.Block);
			
			
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
			
			CheckHitState checkHitStateFalse = new CheckHitState(HitState.False);
			CheckHitState checkHitStateHigh = new CheckHitState(HitState.High);
			CheckHitState checkHitStateLow = new CheckHitState(HitState.Low);
			
			
			StartAttack1 startAttack1 = new StartAttack1();
			StartAttack2 startAttack2 = new StartAttack2();
			StartAttack3 startAttack3 = new StartAttack3();
			StartAttack4 startAttack4 = new StartAttack4();
			
			StartCrouchAttack1 startCrouchAttack1 = new StartCrouchAttack1();
			StartCrouchAttack2 startCrouchAttack2 = new StartCrouchAttack2();
			StartCrouchAttack3 startCrouchAttack3 = new StartCrouchAttack3();
			StartCrouchAttack4 startCrouchAttack4 = new StartCrouchAttack4();
			
			SetBoxData setNeutralBoxData = new SetBoxData(BoxData.FIGHTER_1.NEUTRAL);
			SetBoxData setCrouchBoxData = new SetBoxData(BoxData.FIGHTER_1.CROUCH);
			
			GroundFlag groundFlag = new GroundFlag();
			FrontFlag frontFlag = new FrontFlag();
			BackFlag backFlag = new BackFlag();
			
			CanMoveLeft canMoveLeft = new CanMoveLeft();
			CanMoveRight canMoveRight = new CanMoveRight();
			
			Turn doTurn = new Turn();
			
			//********************************************************************************************
			
			Sequence walkLeft = new Sequence(cController, "WalkLeft");
			walkLeft.AddChild(canMoveLeft);
			walkLeft.AddChild(setWalkStateLeft);
			walkLeft.AddChild(setNeutralBoxData);
			
			Sequence walkRight = new Sequence(cController, "WalkRight");
			walkRight.AddChild(canMoveRight);
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
			
			
			
			//**********ATTACKS**********************************************************************************
			
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
			
			Sequence crouchAttack1 = new Sequence(cController, "CrouchAttack1");
			crouchAttack1.AddChild(checkDown);
			crouchAttack1.AddChild(checkButton1);
			crouchAttack1.AddChild(startCrouchAttack1);
			Sequence crouchAttack2 = new Sequence(cController, "CrouchAttack2");
			crouchAttack2.AddChild(checkDown);
			crouchAttack2.AddChild(checkButton2);
			crouchAttack2.AddChild(startCrouchAttack2);
			Sequence crouchAttack3 = new Sequence(cController, "CrouchAttack3");
			crouchAttack3.AddChild(checkDown);
			crouchAttack3.AddChild(checkButton3);
			crouchAttack3.AddChild(startCrouchAttack3);
			Sequence crouchAttack4 = new Sequence(cController, "CrouchAttack4");
			crouchAttack4.AddChild(checkDown);
			crouchAttack4.AddChild(checkButton4);
			crouchAttack4.AddChild(startCrouchAttack4);
			
			Selector CrouchAttacks = new Selector(cController, "CrouchAttacks");
			CrouchAttacks.AddChild(checkJumpStateInAir);
			CrouchAttacks.AddChild(crouchAttack1);
			CrouchAttacks.AddChild(crouchAttack2);
			CrouchAttacks.AddChild(crouchAttack3);
			CrouchAttacks.AddChild(crouchAttack4);
			
			Selector NeutralAttacks = new Selector(cController, "Attacks");
			NeutralAttacks.AddChild(checkJumpStateInAir);
			NeutralAttacks.AddChild(Attack1);
			NeutralAttacks.AddChild(Attack2);
			NeutralAttacks.AddChild(Attack3);
			NeutralAttacks.AddChild(Attack4);
			
			//********************************************************************************************
			
			
			Sequence ResetStates_P1 = new Sequence(cController, "ResetStates");
			ResetStates_P1.AddChild(setWalkStateFalse);
			ResetStates_P1.AddChild(returnFalse);
			
			Sequence ResetStates_P2 = new Sequence(cController, "ResetStates");
			ResetStates_P2.AddChild(setNeutralState);
			ResetStates_P2.AddChild(setBlockStateFalse);
			ResetStates_P2.AddChild(returnFalse);
			
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
			Block.AddChild(groundFlag);
			Block.AddChild(checkBlock);
			Block.AddChild(block);
			
			Sequence Crouch = new Sequence(cController, "Crouch");
			Crouch.AddChild(groundFlag);
			Crouch.AddChild(checkDown);
			Crouch.AddChild(crouch);
			
			Sequence Jump = new Sequence(cController, "Jump");
			Jump.AddChild(groundFlag);
			Jump.AddChild(checkUp);
			Jump.AddChild(checkJumpOnGroundCoolDown);
			Jump.AddChild(jump);
			Jump.AddChild(setNeutralBoxData);
			
			Sequence WalkRight = new Sequence(cController, "WalkRight");
			WalkRight.AddChild(groundFlag);
			WalkRight.AddChild(checkRight);
			WalkRight.AddChild(walkRight);
			WalkRight.AddChild(setNeutralBoxData);
			
			Sequence WalkLeft = new Sequence(cController, "WalkLeft");
			WalkLeft.AddChild(groundFlag);
			WalkLeft.AddChild(checkLeft);
			WalkLeft.AddChild(walkLeft);
			WalkLeft.AddChild(setNeutralBoxData);
			
			Sequence Neutral = new Sequence(cController, "Prioity 6");
			Neutral.AddChild(groundFlag);
			Neutral.AddChild(setNeutralState);
			Neutral.AddChild(setNeutralBoxData);
			//*****************************************************************************			
			
			Selector startNode = new Selector(cController, "StartNode");
			
			startNode.AddChild(checkAttackStateStartUp);
			startNode.AddChild(checkAttackStateActive);
			startNode.AddChild(checkAttackStateRecovery);
			
			startNode.AddChild(ResetStates_P1);
			
			startNode.AddChild(checkStunStateTrue);
			
			startNode.AddChild(ResetStates_P2);
			
			startNode.AddChild(Turn);
			startNode.AddChild(BlockAndCrouch);
			startNode.AddChild(Block);
			
			startNode.AddChild(CrouchAttacks);
			startNode.AddChild(NeutralAttacks);
			
			startNode.AddChild(Crouch);
			startNode.AddChild(Jump);
			startNode.AddChild(WalkRight);
			startNode.AddChild(WalkLeft);
			
			startNode.AddChild(Neutral);
			
			return startNode;
		}
	}
}
