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
using BloodRings.Input;
using Debug = BloodRings.Debug;
using InputButton = BloodRings.Input.InputButton;


namespace BloodRings{

	public class InputMon{
		
		protected CharacterController2D cController;
		protected int player;
		protected InputButton up;
		protected InputButton down;
		protected InputButton left;
		protected InputButton right;
		protected InputButton upLeft;
		protected InputButton upRight;
		protected InputButton downLeft;
		protected InputButton downRight;
		protected InputButton b1;
		protected InputButton b2;
		protected InputButton b3;
		protected InputButton b4;
		protected InputButton turn;
		protected InputButton block;
		protected InputButton select;
		protected InputButton start;
		
		protected InputButton[] inputArray;
		
		protected bool noInput;
		protected int noInputSince;
		
		protected InputList inputList;
		
		#region Properties
		
		public int Player {get {return player;}}
		public InputButton Up {get {return up;}}
		public InputButton Down {get {return down;}}
		public InputButton Left {get {return left;}}
		public InputButton Right {get {return right;}}
		public InputButton Button1 {get {return b1;}}
		public InputButton Button2 {get {return b2;}}
		public InputButton Button3 {get {return b3;}}
		public InputButton Button4 {get {return b4;}}
		public InputButton Turn {get {return turn;}}
		public InputButton Block {get {return block;}}
		public InputButton Select {get {return select;}}
		public InputButton Start {get {return start;}}

		public bool NoInput {get {return noInput;}}		
		public int NoInputSince {get {return noInputSince;}}
		
		public InputList InputList {get {return this.inputList;}}
		
		#endregion
		
		#region Constructors
		public InputMon(CharacterController2D cController ){
			this.cController = cController;
			this.player = cController.PlayerNo;
			this.up = new InputButton(player, "Up", BloodRingsAssets.SPRITES_INPUT_ICONS[0]);
			this.down = new InputButton(player, "Down", BloodRingsAssets.SPRITES_INPUT_ICONS[1]);
			this.left = new InputButton(player, "Left", BloodRingsAssets.SPRITES_INPUT_ICONS[2]);
			this.right = new InputButton(player, "Right", BloodRingsAssets.SPRITES_INPUT_ICONS[3]);
			this.downLeft = new DoubleInput(this.down, this.left, BloodRingsAssets.SPRITES_INPUT_ICONS[4]);
			this.downRight = new DoubleInput(this.down, this.right, BloodRingsAssets.SPRITES_INPUT_ICONS[5]);
			this.upLeft = new DoubleInput(this.up, this.left, BloodRingsAssets.SPRITES_INPUT_ICONS[6]);
			this.upRight = new DoubleInput(this.up, this.right, BloodRingsAssets.SPRITES_INPUT_ICONS[7]);
	
			this.b1 = new InputButton(player, "1", BloodRingsAssets.SPRITES_INPUT_ICONS[8]);
			this.b2 = new InputButton(player, "2", BloodRingsAssets.SPRITES_INPUT_ICONS[9]);
			this.b3 = new InputButton(player, "3", BloodRingsAssets.SPRITES_INPUT_ICONS[10]);
			this.b4 = new InputButton(player, "4", BloodRingsAssets.SPRITES_INPUT_ICONS[11]);
			this.turn = new InputButton(player, "Turn", BloodRingsAssets.SPRITES_INPUT_ICONS[12]);
			this.block = new InputButton(player, "Block", BloodRingsAssets.SPRITES_INPUT_ICONS[13]);
			this.select = new InputButton(player, "Select", BloodRingsAssets.SPRITES_INPUT_ICONS[0]);
			this.start = new InputButton(player, "Start", BloodRingsAssets.SPRITES_INPUT_ICONS[0]);
			
			this.inputArray = new InputButton[]{
 
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
			
			this.inputList = new InputList();
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
				
				this.UpdateInputList();
			
				this.noInput = false;
				this.noInputSince = 0;
			}
		}
		
		private void UpdateInputList(){
			List<InputCopy> tempList = new List<InputCopy>();
			
			List<InputCopy> directionList = this.UpdateDirectionalInputList();
			List<InputCopy> buttonList = this.UpdateButtonInputList();
			
//			if(directionList.Count == 0 && buttonList.Count > 0){
//				directionList = this.UpdateDirectionalInputListSecondary();
//			}
			
			tempList.AddRange(directionList);
			tempList.AddRange(buttonList);
			
			if(tempList.Count > 0){
				InputCopy[] tempArray = tempList.ToArray();
				inputList.Add(tempArray);
			}
		}
		
		private List<InputCopy> UpdateDirectionalInputList(){
			List<InputCopy> tempList = new List<InputCopy>();
			
			if(this.downLeft.AntiTurbo){
				tempList.Add(this.downLeft.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			if(this.downRight.AntiTurbo){
				tempList.Add(this.downRight.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			if(this.upLeft.AntiTurbo){
				tempList.Add(this.upLeft.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			if(this.upRight.AntiTurbo){
				tempList.Add(this.upRight.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			if(this.down.AntiTurbo){
				tempList.Add(this.down.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			if(this.up.AntiTurbo){
				tempList.Add(this.up.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			if(this.left.AntiTurbo){
				tempList.Add(this.left.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			if(this.right.AntiTurbo){
				tempList.Add(this.right.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			
			return tempList;
		}
		private List<InputCopy> UpdateDirectionalInputListSecondary(){
			List<InputCopy> tempList = new List<InputCopy>();
			
			if(this.downLeft.State){
				tempList.Add(this.downLeft.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			if(this.downRight.State){
				tempList.Add(this.downRight.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			if(this.upLeft.State){
				tempList.Add(this.upLeft.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			if(this.upRight.State){
				tempList.Add(this.upRight.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			if(this.down.State){
				tempList.Add(this.down.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			if(this.up.State){
				tempList.Add(this.up.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			if(this.left.State){
				tempList.Add(this.left.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			if(this.right.State){
				tempList.Add(this.right.GetCopy(this.cController.TickController.Tick));
				return tempList;
			}
			
			return tempList;
		}
		private List<InputCopy> UpdateButtonInputList(){
			List<InputCopy> tempList = new List<InputCopy>();
			
			if(this.b1.AntiTurbo){
				tempList.Add(this.b1.GetCopy(this.cController.TickController.Tick));
			}
			if(this.b2.AntiTurbo){
				tempList.Add(this.b2.GetCopy(this.cController.TickController.Tick));
			}
			if(this.b3.AntiTurbo){
				tempList.Add(this.b3.GetCopy(this.cController.TickController.Tick));
			}
			if(this.b4.AntiTurbo){
				tempList.Add(this.b4.GetCopy(this.cController.TickController.Tick));
			}
			if(this.block.AntiTurbo){
				tempList.Add(this.block.GetCopy(this.cController.TickController.Tick));
			}
			if(this.turn.AntiTurbo){
				tempList.Add(this.turn.GetCopy(this.cController.TickController.Tick));
			}
			
			return tempList;

		}
		public InputButton FindInput(String name){
		
			for (int i = 0; i < this.inputArray.GetLength(0); i++) {
				if(this.inputArray[i].Name == name){
					return this.inputArray[i];
				}
			}
			return null;
			
		}
		
		public bool CheckSequence(String[] sequence){
		
			if(this.inputList.List.Count < sequence.GetLength(0)){
				return false;
			}
			Array.Reverse(sequence);
			int maxTickGap = 10;
			int matches = 0;
			List<InputCopy[]> reversedDirectionList = this.inputList.ListReversed;
			
			for (int i = 0; i < sequence.GetLength(0); i++) {
			
				InputCopy[] cInputArray = reversedDirectionList[i];
				
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
		
			List<InputCopy[]> tempList= list.ListReversed;
			
			GUILayout.BeginVertical("box");
			
			for (int i = 0; i < tempList.Count; i++) {
				GUILayout.BeginHorizontal("box");
				
				for (int j = 0; j < tempList[i].GetLength(0); j++) {

					GUILayout.Label("'" + tempList[i][j].Name + "_" + tempList[i][j].ClonedTick + "'");
					//GUILayout.Label(tempList[i][j].Sprite);
					
				}	
				GUILayout.EndHorizontal();
				
			}
			GUILayout.EndVertical();
			
		}
		
//		public bool CheckInputSequence(Input sequence){
//		
//		}
	}
}






