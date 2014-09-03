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
	
	public class CheckJumpOnGroundCoolDown : Condition{
		public CheckJumpOnGroundCoolDown(){}
		protected override BH_STATUS Update (){
			if (cController.onGroundFrameCount >= cController.Stats.jumpGroundCoolDown){
				return BH_STATUS.BH_SUCCESS;
			}else{
				return BH_STATUS.BH_FAILURE;
			}
		}
	}
}
