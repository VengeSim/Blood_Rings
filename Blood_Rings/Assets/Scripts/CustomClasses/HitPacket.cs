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

public enum AttackType{
	Normal,
	Projectile,
	Weapon

}

public class HitPacket{
	protected bool isReset;
	protected int damage;
	protected int hitStun;
	protected int blockStun;
	protected float pushBack;
	
	protected AttackType attackType;
	
	public bool IsReset{get{return this.isReset;}}
	public int Damage{get{return this.damage;}}
	public int HitStun{get{return this.hitStun;}}
	public int BlockStun{get{return this.blockStun;}}
	public float PushBack{get{return this.pushBack;}}

	public AttackType AttackType {get {return attackType;}}	
	
	public HitPacket(){
		this.isReset = false;
		this.damage = 0;
		this.hitStun = 0;
		this.blockStun = 0;
		this.pushBack = 0f;
		
	}
	public HitPacket(int damage, int hitStun, int blockStun, float pushBack){
		this.isReset = false;
		this.damage = damage;
		this.hitStun = hitStun;
		this.blockStun = blockStun;
		this.pushBack = pushBack;
		this.attackType = AttackType.Normal;
	}
	public HitPacket(int damage, int hitStun, int blockStun, float pushBack, AttackType attackType){
		this.isReset = false;
		this.damage = damage;
		this.hitStun = hitStun;
		this.blockStun = blockStun;
		this.pushBack = pushBack;
		this.attackType = attackType;
	}
	public void Reset(){
		this.isReset = true;
		this.damage = 0;
		this.hitStun = 0;
		this.blockStun = 0;
		this.pushBack = 0;
	}
}
