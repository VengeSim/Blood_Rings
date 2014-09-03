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
	
	public class CheckAttackState : Condition{
		protected AttackState state;
		public CheckAttackState(AttackState state){
			this.state = state;
			
		}
		protected override BH_STATUS Update (){
			if (cController.AttackState == this.state){
				return BH_STATUS.BH_SUCCESS;
			}else{
				return BH_STATUS.BH_FAILURE;
			}
		}
	}
}
