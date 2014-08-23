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
using Debug = BloodRings.Debug;
using Input = BloodRings.Input;



public enum State{
	Neutral,
	Crouch,
	InAir
}

public enum BlockState{
	False,
	True
}

public enum WalkState{
	False,
	Right,
	Left
}

public enum JumpState{
	False,
	True,
	InAir
}

public enum AttackState{
	Ready,
	StartUp,
	Active,
	Recovery
}
public enum AttackEXState{
	None,
	Invincible,
	Armored
}
public enum AttackSPState{
	None,
	Cancelable
}


