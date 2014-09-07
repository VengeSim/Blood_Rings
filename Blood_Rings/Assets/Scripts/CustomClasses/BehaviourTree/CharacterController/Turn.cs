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
		
	public class Turn : Action{
		public Turn(){}
		protected override BH_STATUS Update (){
			this.cController.Turn();
			return BH_STATUS.BH_SUCCESS;
		}
	}

}
