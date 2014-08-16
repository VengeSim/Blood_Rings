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



public class LevelProperties : MonoBehaviour {

	public bool GLOBAL_DEBUG_LOGS;
	public bool GLOBAL_SHOW_BOXES;

	void Start () {
		BloodRings.Global.SHOW_BOXES = GLOBAL_SHOW_BOXES;
		BloodRings.Debug.DEBUG_MODE = GLOBAL_DEBUG_LOGS;
	}
	
	void Update () {
	
	}
}
