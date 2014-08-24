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

/*
	//TODO ADD Input class features held and heldsince
*/

public class CollisionFlag : MonoBehaviour {
	public CollisionManager cManager;
	public Collider2D[] ignoreColliders;
	
	public bool flag = false;
	public List<CollisionFlag> others;
	protected HitPacket hPacket;
	
	public bool Bool {get {return flag;}}
	public List<CollisionFlag> Others {get {return others;}}
	public HitPacket HitPacket{get{return this.hPacket;} set{this.hPacket = value;}}
	
	void OnTriggerEnter2D(Collider2D other) {
		this.flag = true;
		this.others.Add(other.GetComponent<CollisionFlag>());
	}
	
	void OnTriggerExit2D(Collider2D other) {
		this.flag = false;
		this.others.Remove(other.GetComponent<CollisionFlag>());
	}
	
	void OnTriggerStay2D(Collider2D other) {
		this.flag = true;
		this.others.Remove(other.GetComponent<CollisionFlag>());
	}
	
	void Start () {
		
		for (int i = 0; i < ignoreColliders.GetLength(0); i++) {	
			Physics2D.GetIgnoreCollision(this.collider2D, this.ignoreColliders[i]);
		}
	}
	
	void Update () {

	}
	
	public void ResetHitPacket(){
		this.hPacket.Reset();
	}
}






