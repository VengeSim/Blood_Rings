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
		
	public class SetState : Action{
		protected State state;
		public SetState(State state){
			this.state = state;
		}
		protected override BH_STATUS Update (){
			this.cController.State = state;
			return BH_STATUS.BH_SUCCESS;
		}
	}

}
