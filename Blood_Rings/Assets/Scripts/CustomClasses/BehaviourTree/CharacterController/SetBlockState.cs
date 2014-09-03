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
	
	public class SetBlockState : Action{
		protected BlockState state;
		public SetBlockState(BlockState state){
			this.state = state;
		}
		protected override BH_STATUS Update (){
			this.cController.BlockState = state;
			return BH_STATUS.BH_SUCCESS;
		}
	}

}
