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
using Input = BloodRings.Input.InputButton;


namespace BloodRings{
	
	namespace Input
		{
				public class InputButton
				{
			
						protected int player;
						protected Sprite sprite;
						protected string name;
						protected string buttonName;
						protected bool state;
						protected int held;
						protected int heldSince;
						protected bool antiTurbo;
			
						#region Properties
						public int Player { get { return this.player; } }
						public Sprite Sprite { get { return this.sprite; } }
						public string Name { get { return this.name; } }
						public string ButtonName { get { return this.buttonName; } }
						public bool State{ get { return this.state; } }
						public int Held { get { return held; } }
						public int HeldSince { get { return heldSince; } }
			
			
						#endregion
			
						#region Constructors
						public InputButton (int player, string name, Sprite sprite)
						{
								this.player = player;
								this.sprite = sprite;
								this.name = name;
								this.buttonName = player.ToString () + "_" + name;
								this.state = false;
								this.held = 0;
								this.heldSince = 0;
								this.antiTurbo = false;
						}
			
						public InputButton (InputButton input)
						{
								this.player = input.Player;
								this.name = input.Name;
								this.buttonName = input.ButtonName;
								this.state = input.State;
								this.held = input.Held;
								this.heldSince = input.HeldSince;
								this.antiTurbo = false;
				
						}
						#endregion
			
						public virtual bool Update ()
						{
		
								if (UnityEngine.Input.GetButtonDown (this.buttonName)) {
										OnPress ();
										return this.state;
								}
				
								if (UnityEngine.Input.GetButton (this.buttonName)) {
										OnHold ();
					
								} else {
										NoAction ();
					
								}
				
								if (UnityEngine.Input.GetButtonUp (this.buttonName)) {
										OnRelease ();
										return this.state;
					
								}
				
								return this.state;
						}
		
						public void OnPress ()
						{
								this.state = true;
								this.heldSince = 0;
								this.antiTurbo = true;
						}
		
						public void OnHold ()
						{
								this.antiTurbo = false;
								this.held++;
						}
		
						public void NoAction ()
						{
								this.heldSince++;
								this.antiTurbo = false;
				
						}
		
						public void OnRelease ()
						{
								this.antiTurbo = false;
								this.state = false;
								this.held = 0;
						}
			
						public virtual bool AntiTurbo {
								get {
										//	if(this.held <= 1 && this.state){
										//		return true;
										//	}
										return this.antiTurbo;
								}
						}
			
						public InputCopy GetCopy (int currentTick)
						{
								return new InputCopy (this, currentTick);
						}
				}
		}

	
	
	

}
