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
		
	public class StartAttack1 : Action{
		public StartAttack1(){}
		protected override BH_STATUS Update (){
			
			this.cController.Attack1();
			
			return BH_STATUS.BH_SUCCESS;
		}
	} 

}
