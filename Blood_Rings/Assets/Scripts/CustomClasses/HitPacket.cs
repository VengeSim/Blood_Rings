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


public class HitPacket{
	protected int damage;
	protected int hitStun;
	protected int blockStun;
	protected float pushBack;
	
	public int Damage{get{return this.damage;}}
	public int HitStun{get{return this.hitStun;}}
	public int BlockStun{get{return this.blockStun;}}
	public float PushBack{get{return this.pushBack;}}
	
	
	public HitPacket(){
		this.damage = 10;
		this.hitStun = 10;
		this.blockStun = 10;
		this.pushBack = 5f;
		
	}
	public HitPacket(int damage, int hitStun, int blockStun, float pushBack){
		this.damage = damage;
		this.hitStun = hitStun;
		this.blockStun = blockStun;
		this.pushBack = pushBack;
	}
	
	public void Reset(){
		this.damage = 0;
		this.hitStun = 0;
		this.blockStun = 0;
		this.pushBack = 0;
	}
}
