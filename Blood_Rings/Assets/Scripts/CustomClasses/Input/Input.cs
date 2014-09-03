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
		
		protected int player;
		protected string name;
		protected string buttonName;
		protected bool state;
		protected int held;
		protected int heldSince;
		
		#region Properties
		public int Player {get {return this.player;}}
		public string Name {get {return this.name;}}
		public string ButtonName {get {return this.name;}}
		public bool State{get{return this.state;}}
		public int Held {get {return held;}}
		public int HeldSince {get {return heldSince;}}
		#endregion
		
		#region Constructors
		public Input(int player, string name){
			this.player = player;
			this.name = name;
			this.buttonName = player.ToString() + "_" + name;
			this.state = false;
			this.held = 0;
			this.heldSince = 0;
		}
		#endregion
		
		public virtual bool update(){
			if(UnityEngine.Input.GetButtonDown(this.buttonName)){
				this.state = true;
				this.heldSince = 0;
			}
			if(UnityEngine.Input.GetButton (this.buttonName)){
				this.held++;
			}else{
				this.heldSince++;
			}
			if(UnityEngine.Input.GetButtonUp(this.buttonName)){
				this.state = false;
				this.held = 0;
			}
			return this.state;
		}
		
		public bool AntiTurbo{
			get{
				if(this.held <= 1 && this.state){
					return true;
				}
				return false;
			}
		}
	}

}
