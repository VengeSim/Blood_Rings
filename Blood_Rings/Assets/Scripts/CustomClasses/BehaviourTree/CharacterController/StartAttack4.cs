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
		
	public class StartAttack4 : Action{
		public StartAttack4(){}
		protected override BH_STATUS Update (){
			
			this.cController.Attack4();
			
			return BH_STATUS.BH_SUCCESS;
		}
	}

}
