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
	
	namespace Input{
				public class InputCopy : InputButton
				{
						protected int clonedTick;
						public int ClonedTick{ get { return this.clonedTick; } }
						public InputCopy (InputButton input, int currentTick): base(input)
						{
			
								this.clonedTick = currentTick;
						}
			
						public override bool Update ()
						{
								return this.state;
						}
				}
		}

}
