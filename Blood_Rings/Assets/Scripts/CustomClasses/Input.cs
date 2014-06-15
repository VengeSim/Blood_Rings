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

	public class Input{
		
		protected string name;
		protected bool state;
		protected int held;
		protected int heldSince;
		
		#region Properties
		public string Name {get {return this.name;}}
		public bool State{get{return this.state;}}
		public int Held {get {return held;}}
		public int HeldSince {get {return heldSince;}}
		#endregion
		
		#region Constructors
		public Input(string name){
			this.name = name;
			this.state = false;
			this.held = 0;
			this.heldSince = 0;
		}
		#endregion
		
		public virtual bool update(){
			if(UnityEngine.Input.GetButtonDown(this.name)){
				this.state = true;
				this.heldSince = 0;
			}
			if(UnityEngine.Input.GetButton (this.name)){
				this.held++;
			}else{
				this.heldSince++;
			}
			if(UnityEngine.Input.GetButtonUp(this.name)){
				this.state = false;
				this.held = 0;
			}
			return this.state;
		}
	}

}
