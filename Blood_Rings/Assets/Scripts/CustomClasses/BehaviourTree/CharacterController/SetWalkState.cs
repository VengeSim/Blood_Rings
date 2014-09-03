using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;

using BloodRings;
using Debug = BloodRings.Debug;
using Input = BloodRings.Input;
using Action = BloodRings.Action;

namespace BloodRings{
		
	public class SetWalkState : Action{
		protected WalkState state;
		public SetWalkState(WalkState state){
			this.state = state;
		}
		protected override BH_STATUS Update (){
			this.cController.WalkState = state;
			return BH_STATUS.BH_SUCCESS;
		}
	}

}
