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

public class HurtBox : CollisionFlag {

	protected HitPacket hPacket;
	public HitPacket HitPacket{get{return this.hPacket;} set{this.hPacket = value;}}
	
	void Start () {
		this.hPacket = new HitPacket();
		
	}
	
	void Update () {
	
	}
	
	public void ResetHitPacket(){
		this.hPacket.Reset();
	}
}
