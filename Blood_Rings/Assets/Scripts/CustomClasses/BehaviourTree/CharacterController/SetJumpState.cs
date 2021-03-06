using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;

using BloodRings;
using Debug = BloodRings.Debug;
using Input = BloodRings.InputClone;
using Action = BloodRings.Action;

namespace BloodRings{
	
	
	public class SetJumpState : Action{
		protected JumpState state;
		public SetJumpState(JumpState state){
			this.state = state;
		}
		protected override BH_STATUS Update (){
			this.cController.JumpState = state;
			return BH_STATUS.BH_SUCCESS;
		}
	}
}
