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
	
	public class InputClone : Input{
		protected int clonedTick;
		public int ClonedTick{get{return this.clonedTick;}}
		public InputClone(Input input, int currentTick): base(input){
		
			this.clonedTick = currentTick;
		}
		
		public override bool Update(){
			return this.state;
		}
	}

}
