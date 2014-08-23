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
		
		protected int player;
		protected Input up;
		protected Input down;
		protected Input left;
		protected Input right;
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
		
		
		#endregion
		
		#region Constructors
		public InputMon(int player ){
			this.player = player;
		
			this.up = new Input(player, "Up");
			this.down = new Input(player, "Down");
			this.left = new Input(player, "Left");
			this.right = new Input(player, "Right");
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
		}
		#endregion
		
		public void Update(){
			int trueCount = 0;
			for (int i = 0; i < this.inputArray.GetLength(0); i++) {
			
				bool state = this.inputArray[i].update();
				
				if(state){trueCount++;}
			}
			if(trueCount == 0){
				this.noInput = true;
			}else{
				this.noInput = false;
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
		
	}
}






