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
	
	public class CheckInput : Condition{
		protected string name;
		
		public CheckInput(string name){
			this.name = name;
		}
		protected override BH_STATUS Update (){
			if (cController.iMon.FindInput(name).State){
				return BH_STATUS.BH_SUCCESS;
			}else{
				return BH_STATUS.BH_FAILURE;
			}
		}
	}
}
