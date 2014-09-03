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

public enum HitBoxType{
	High,
	Low
}


public class HitBox : CollisionFlag {
	
	public HitBoxType type;

	public HitBoxType Type {get {return type;}}
	public List<HurtBox> others;
	public List<HurtBox> HurtBoxes {get {return others;}}
	
	
	void Start () {
		
	}
	
	void Update () {
		for (int i = 0; i < others.Count; i++) {
			if(others[i].HitPacket.IsReset){
				this.others.Remove(others[i]);
			}
		}

		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		HurtBox hBox = other.GetComponent<HurtBox>();
		if(!hBox.HitPacket.IsReset){
			this.others.Add(hBox);
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
	
		this.others.Remove(other.GetComponent<HurtBox>());
	}
	
	void OnTriggerStay2D(Collider2D other) {
	
		this.others.Remove(other.GetComponent<HurtBox>());
	}
	
}
