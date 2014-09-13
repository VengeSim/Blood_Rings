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

public enum HitType{
	None,
	Low,
	High	
}
static class HitTypeExtensions {
	public static HitState ToHitState(this HitType hitType) {
		switch (hitType) {
		case HitType.None:   return HitState.False;
		case HitType.High:  return HitState.High;
		case HitType.Low: return HitState.Low;
		default:    throw new ArgumentOutOfRangeException("HitTypeExtensions");
		}
	}
}
public class HitPacketWrapper{
	protected ObjectController owner;
	protected HurtBox source;
	protected HitPacket hitPacket;
	protected HitType hitType;
	
	public ObjectController Owner{get{return this.owner;}}
	public HurtBox Source {get{return this.source;}}
	public HitPacket HitPacket{get{return this.hitPacket;}}
	public HitType HitType{get{return this.hitType;}}

	public HitPacketWrapper(){
		this.owner = null;
		this.source = null;
		this.hitPacket = new HitPacket();
		this.hitType = HitType.None;
	}
	
	public HitPacketWrapper(ObjectController owner, HurtBox source, HitPacket hPacket, HitType hType){
		this.owner = owner;
		this.source = source;
		this.hitPacket = hPacket;
		this.hitType = hType;
	}
	
}



