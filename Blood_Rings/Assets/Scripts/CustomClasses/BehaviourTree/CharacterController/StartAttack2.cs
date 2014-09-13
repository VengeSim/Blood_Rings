/*
	Blood Ring
	Copyright © 2014 jgumbo@live.com
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;

using BloodRings;
using BloodRings.Input;
using Debug = BloodRings.Debug;
using Input = BloodRings.Input.InputButton;
using Action = BloodRings.Action;

namespace BloodRings{
		
	public class  StartAttack2 : Action{
		public StartAttack2(){}
		protected override BH_STATUS Update (){
			
			this.cController.Attack2();
			
			return BH_STATUS.BH_SUCCESS;
		}
	}

}
