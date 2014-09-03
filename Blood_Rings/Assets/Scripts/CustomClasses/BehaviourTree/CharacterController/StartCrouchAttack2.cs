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
		
	public class  StartCrouchAttack2 : Action{
		public StartCrouchAttack2(){}
		protected override BH_STATUS Update (){
			
			this.cController.CrouchAttack2();
			
			return BH_STATUS.BH_SUCCESS;
		}
	}

}
