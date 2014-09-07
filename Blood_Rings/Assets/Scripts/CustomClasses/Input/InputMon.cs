/*
	Blood Ring
	Copyright © 2014 jgumbo@live.com
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

using BloodRings;
using Debug = BloodRings.Debug;
using Input = BloodRings.Input;


namespace BloodRings{

	public class InputMon{
		
		protected CharacterController2D cController;
		protected int player;
		protected Input up;
		protected Input down;
		protected Input left;
		protected Input right;
		protected Input upLeft;
		protected Input upRight;
		protected Input downLeft;
		protected Input downRight;
		protected Input b1;
		protected Input b2;
		protected Input b3;
		protected Input b4;
		protected Input turn;
		protected Input block;
		protected Input select;
		protected Input start;
		
		protected Input[] inputArray;
		
		protected bool noInput;
		protected int noInputSince;
		
		protected InputList directionList;
		protected InputList buttonList;
		
		#region Properties
		
		public int Player {get {return player;}}
		public Input Up {get {return up;}}
		public Input Down {get {return down;}}
		public Input Left {get {return left;}}
		public Input Right {get {return right;}}
		public Input Button1 {get {return b1;}}
		public Input Button2 {get {return b2;}}
		public Input Button3 {get {return b3;}}
		public Input Button4 {get {return b4;}}
		public Input Turn {get {return turn;}}
		public Input Block {get {return block;}}
		public Input Select {get {return select;}}
		public Input Start {get {return start;}}

		public bool NoInput {get {return noInput;}}		
		public int NoInputSince {get {return noInputSince;}}
		
		public InputList DirectionList {get {return this.directionList;}}
		public InputList ButtonList {get {return this.buttonList;}}
		
		#endregion
		
		#region Constructors
		public InputMon(CharacterController2D cController ){
			this.cController = cController;
			this.player = cController.PlayerNo;
			this.up = new Input(player, "Up");
			this.down = new Input(player, "Down");
			this.left = new Input(player, "Left");
			this.right = new Input(player, "Right");
			this.downLeft = new InputDouble(this.down, this.left);
			this.downRight = new InputDouble(this.down, this.right);
			this.upLeft = new InputDouble(this.up, this.left);
			this.upRight = new InputDouble(this.up, this.right);
	
			this.b1 = new Input(player, "1");
			this.b2 = new Input(player, "2");
			this.b3 = new Input(player, "3");
			this.b4 = new Input(player, "4");
			this.turn = new Input(player, "Turn");
			this.block = new Input(player, "Block");
			this.select = new Input(player, "Select");
			this.start = new Input(player, "Start");
			
			this.inputArray = new Input[]{
 
							this.up, 
							this.down, 
							this.left, 
							this.right,
							this.downLeft,
							this.downRight,
							this.upLeft,
							this.upRight,
							this.b1, 
							this.b2, 
							this.b3, 
							this.b4, 
							this.turn, 
							this.block, 
							this.select, 
							this.start
						};
						
			this.noInput = false;
			this.noInputSince = 0;
			
			this.directionList = new InputList();
			this.buttonList = new InputList();
		}
		#endregion
		
		public void Update(){
			int trueCount = 0;
			for (int i = 0; i < this.inputArray.GetLength(0); i++) {
			
				bool state = this.inputArray[i].Update();
				
				if(state){trueCount++;}
			}
			if(trueCount == 0){
				this.noInput = true;
				this.noInputSince ++;
			}else{
				
				this.UpdateButtonInputList();
				this.UpdateDirectionalInputList();
			
				this.noInput = false;
				this.noInputSince = 0;
			}
		}
		
		private void UpdateDirectionalInputList(){

			if(this.downLeft.AntiTurbo){
				directionList.Add(this.downLeft.GetClone(this.cController.TickController.Tick));
				return;
			}
			if(this.downRight.AntiTurbo){
				directionList.Add(this.downRight.GetClone(this.cController.TickController.Tick));
				return;
			}
			if(this.upLeft.AntiTurbo){
				directionList.Add(this.upLeft.GetClone(this.cController.TickController.Tick));
				return;
			}
			if(this.upRight.AntiTurbo){
				directionList.Add(this.upRight.GetClone(this.cController.TickController.Tick));
				return;
			}
			if(this.down.AntiTurbo){
				directionList.Add(this.down.GetClone(this.cController.TickController.Tick));
				return;
			}
			if(this.up.AntiTurbo){
				directionList.Add(this.up.GetClone(this.cController.TickController.Tick));
				return;
			}
			if(this.left.AntiTurbo){
				directionList.Add(this.left.GetClone(this.cController.TickController.Tick));
				return;
			}
			if(this.right.AntiTurbo){
				directionList.Add(this.right.GetClone(this.cController.TickController.Tick));
				return;
			}
		}
		private void UpdateButtonInputList(){
		
			List<InputClone> tempList= new List<InputClone>();
			
			if(this.b1.AntiTurbo){
				tempList.Add(this.b1.GetClone(this.cController.TickController.Tick));
			}
			if(this.b2.AntiTurbo){
				tempList.Add(this.b2.GetClone(this.cController.TickController.Tick));
			}
			if(this.b3.AntiTurbo){
				tempList.Add(this.b3.GetClone(this.cController.TickController.Tick));
			}
			if(this.b4.AntiTurbo){
				tempList.Add(this.b4.GetClone(this.cController.TickController.Tick));
			}
			if(this.block.AntiTurbo){
				tempList.Add(this.block.GetClone(this.cController.TickController.Tick));
			}
			if(this.turn.AntiTurbo){
				tempList.Add(this.turn.GetClone(this.cController.TickController.Tick));
			}
			
			if(tempList.Count > 0){
				InputClone[] tempArray = tempList.ToArray();
				buttonList.Add(tempArray);
			}

		}
		public Input FindInput(String name){
		
			for (int i = 0; i < this.inputArray.GetLength(0); i++) {
				if(this.inputArray[i].Name == name){
					return this.inputArray[i];
				}
			}
			return null;
			
		}
		
		public bool CheckSequenceDirectional(String[] sequence){
		
			if(this.directionList.List.Count < sequence.GetLength(0)){
				return false;
			}
			Array.Reverse(sequence);
			int maxTickGap = 10;
			int matches = 0;
			List<InputClone[]> reversedDirectionList = this.directionList.ListReversed;
			
			for (int i = 0; i < sequence.GetLength(0); i++) {
			
				InputClone[] cInputArray = reversedDirectionList[i];
				
				for (int j = 0; j < cInputArray.GetLength(0); j++) {
				
					if(cInputArray[j].Name == sequence[i]){
						
						//check if the first input in the sequence has just been pressed
						//else use maxHeldSince
						if(i == 0){
							if(reversedDirectionList[i][j].ClonedTick == this.cController.TickController.Tick - 1){
								matches++;
								break;
							}

						}else{
							int tickGap = reversedDirectionList[i-1][0].ClonedTick - reversedDirectionList[i][0].ClonedTick;
							if(tickGap < maxTickGap){
								matches++;
								break;
							
							}
						}
					}	
				}
				
				if(matches <= i){
					return false;
				}
				
			}
			
			if(matches == sequence.GetLength(0)){
				return true;
			}
			
			return false;
		}
		
		public static void DrawListDebug(InputList list){
		
			List<InputClone[]> tempList= list.ListReversed;
			
			GUILayout.BeginVertical("box");
			
			for (int i = 0; i < tempList.Count; i++) {
				GUILayout.BeginHorizontal("box");
				
				for (int j = 0; j < tempList[i].GetLength(0); j++) {

					GUILayout.Label("'" + tempList[i][j].Name + "_" + tempList[i][j].ClonedTick + "'");

				}	
				GUILayout.EndHorizontal();
				
			}
			GUILayout.EndVertical();
			
		}
	}
}






