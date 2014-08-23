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
	
	public Collider2D[] ignoreColliders;
	
	public bool flag = false;
	public bool Bool {get {return flag;}}
	public List<Collider2D> others;
	public List<Collider2D> Others {get {return others;}}
	
	
	void OnTriggerEnter2D(Collider2D other) {
		this.flag = true;
		this.others.Add(other);
	}
	
	void OnTriggerExit2D(Collider2D other) {
		this.flag = false;
		this.others.Remove(other);
	}
	
	void OnTriggerStay2D(Collider2D other) {
		this.flag = true;
		this.others.Remove(other);
	}
	
	void Start () {
		for (int i = 0; i < ignoreColliders.GetLength(0); i++) {	
			Physics2D.GetIgnoreCollision(this.collider2D, this.ignoreColliders[i]);
		}
	}
	
	void Update () {

	}
	
}






