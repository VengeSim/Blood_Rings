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
	
	public class StartCrouchAttack4 : Action{
		public StartCrouchAttack4(){}
		protected override BH_STATUS Update (){
			
			this.cController.CrouchAttack4();
			
			return BH_STATUS.BH_SUCCESS;
		}
	}
}



