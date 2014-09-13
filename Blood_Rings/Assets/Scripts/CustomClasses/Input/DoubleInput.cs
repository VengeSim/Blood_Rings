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
				public class DoubleInput : InputButton
				{
			
						protected InputButton input1;
						protected InputButton input2;
						protected string buttonName2;
			
						public string ButtonName2 { get { return this.buttonName2; } }
			
						public DoubleInput (InputButton input1, InputButton input2, Sprite sprite): base(input1)
						{
								this.sprite = sprite;
								this.input1 = input1;
								this.input2 = input2;
				
								this.name = this.input1.Name + input2.Name;
								this.buttonName2 = player.ToString () + "_" + input2.Name;
				
						}
			
						public override bool Update ()
						{
								if (
										(this.input1.AntiTurbo && this.input2.State) ||
										(this.input1.State && this.input2.AntiTurbo) ||
										(this.input1.AntiTurbo && this.input2.AntiTurbo)
								) {
										this.OnPress ();
								}
								if (this.input1.State && this.input2.State) {
										this.OnHold ();	
								} else {
										if (this.input1.HeldSince == 0 && this.input2.HeldSince == 0) {
												this.OnRelease ();
										} else {	
												this.NoAction ();
										}
								}
								if (!this.input1.State && this.input2.State && this.input1.HeldSince == 1) {
										this.input2.OnRelease ();
										this.input2.OnPress ();
					
										this.OnRelease ();
								}
				
								if (this.input1.State && !this.input2.State && this.input2.HeldSince == 1) {	
										this.input1.OnRelease ();
										this.input1.OnPress ();
					
										this.OnRelease ();
								}
				
								return this.state;
						}
						public override bool AntiTurbo {
								get {
										if (
												(this.input1.AntiTurbo && this.input2.State) ||
												(this.input1.State && this.input2.AntiTurbo) ||
												(this.input1.AntiTurbo && this.input2.AntiTurbo)
										) {
												return true;
										}
										return false;
								}
						}
		
				}
		}

}
