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
using Input = BloodRings.InputClone;


public class Attack{

	protected Sprite sprite;
	protected BoxData bData;
	protected int[] frames;
	protected int damage;
	protected int hitStun;
	protected int blockStun;
	protected float pushBack;
	protected State endState;
	
	public Attack(Sprite sprite, BoxData bData, int[] frames){
		this.sprite = sprite;
		this.bData = bData;
		this.frames = frames;
	}
	public Attack(Sprite sprite, BoxData bData, int[] frames, HitPacket hPacket, State endState): this(sprite, bData, frames){
		this.damage = hPacket.Damage;
		this.hitStun = hPacket.HitStun;
		this.blockStun = hPacket.BlockStun;
		this.pushBack = hPacket.PushBack;
		this.endState = endState;
	}
	
	public Sprite Sprite {get {return sprite;}}
	public BoxData BoxData {get {return bData;}}
	public int[] Frames {get {return frames;}}
	public int Startup {get {return frames[0];}}
	public int Active {get {return frames[1];}}
	public int Recovery {get {return frames[2];}}
	public int Damage {get {return damage;}}
	public int HitStun {get {return hitStun;}}
	public int BlockStun {get {return blockStun;}}
	public float PushBack {get {return pushBack;}}
	public State EndState {get {return endState;}}
	
	public HitPacket GetHitPacket(){
		return new HitPacket(this.damage, this.hitStun, this.blockStun, this.pushBack);
	}
	
}
