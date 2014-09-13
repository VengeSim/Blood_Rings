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



public enum State{
	Neutral,
	Crouch,
	InAir
}

public enum BlockState{
	False,
	True
}
public enum StunState{
	False,
	True,
	Block
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
public enum HitState{
	False,
	High,
	Low
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


