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
using Action = BloodRings.Action;

namespace BloodRings{
	
	public class CheckWalkState : Condition{
		protected WalkState state;
		public CheckWalkState(WalkState state){
			this.state = state;
			
		}
		protected override BH_STATUS Update (){
			if (cController.WalkState == this.state){
				return BH_STATUS.BH_SUCCESS;
			}else{
				return BH_STATUS.BH_FAILURE;
			}
		}
	}
	
}
