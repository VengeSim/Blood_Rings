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
	
		protected Input up;
		protected Input down;
		protected Input left;
		protected Input right;
		protected Input b1;
		protected Input b2;
		protected Input b3;
		protected Input b4;
		protected Input combo;
		protected Input block;
		protected Input select;
		protected Input start;
		protected Input[] inputArray;
		
		protected bool noInput;
		
		#region Properties

		public Input Up {get {return up;}}
		public Input Down {get {return down;}}
		public Input Left {get {return left;}}
		public Input Right {get {return right;}}
		public Input Button1 {get {return b1;}}
		public Input Button2 {get {return b2;}}
		public Input Button3 {get {return b3;}}
		public Input Button4 {get {return b4;}}
		public Input Combo {get {return combo;}}
		public Input Block {get {return block;}}
		public Input Select {get {return select;}}
		public Input Start {get {return start;}}

		public bool NoInput {get {return noInput;}}		
		
		
		#endregion
		
		#region Constructors
		public InputMon(){
			this.up = new Input("1_Up");
			this.down = new Input("1_Down");
			this.left = new Input("1_Left");
			this.right = new Input("1_Right");
			this.b1 = new Input("1_1");
			this.b2 = new Input("1_2");
			this.b3 = new Input("1_3");
			this.b4 = new Input("1_4");
			this.combo = new Input("1_Combo");
			this.block = new Input("1_Block");
			this.select = new Input("1_Select");
			this.start = new Input("1_Start");
			
			this.inputArray = new Input[]{
							this.up, 
							this.down, 
							this.left, 
							this.right, 
							this.b1, 
							this.b2, 
							this.b3, 
							this.b4, 
							this.combo, 
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
		
		
	}
}





