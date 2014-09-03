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
		
	public class StartAttack3 : Action{
		public StartAttack3(){}
		protected override BH_STATUS Update (){
			
			this.cController.Attack3();
			
			return BH_STATUS.BH_SUCCESS;
		}
	}

}
