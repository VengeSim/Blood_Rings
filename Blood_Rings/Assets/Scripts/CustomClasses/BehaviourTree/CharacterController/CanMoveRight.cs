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
	
	public class CanMoveRight : Condition{
		public CanMoveRight(){}
		protected override BH_STATUS Update (){
			if (cController.CanMoveRight()){
				return BH_STATUS.BH_SUCCESS;
			}else{
				return BH_STATUS.BH_FAILURE;
			}
		}
	}
}
