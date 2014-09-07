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


public class CollisionFlag : MonoBehaviour {
	
	protected ObjectController objectController;
	protected BoxCollider2D boxCol;
	public bool flag = false;
	
	public ObjectController ObjectController {get {return objectController;}}
	public BoxCollider2D BoxCollider2D {get {return boxCol;}}
	public bool Flag {get {return flag;}}
	
	void OnTriggerEnter2D(Collider2D other) {
		this.flag = true;
	}
	
	void OnTriggerExit2D(Collider2D other) {
		this.flag = false;
	}
	
	void OnTriggerStay2D(Collider2D other) {
		this.flag = true;
	}
	
	void Awake () {
		
		this.boxCol = this.GetComponent<BoxCollider2D>();
		this.objectController = this.gameObject.transform.root.GetComponent<ObjectController>();
		
	}
	
	void Update () {

	}
	

}






