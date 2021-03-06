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

public class TickController : MonoBehaviour {
	
	public float timeBetweenTicks = 0.06f;
	public int tick = 0;
	
	void Start (){		

		StartCoroutine(TickTimer());
	}
	
	void Update (){

	}
	
	void OnGUI(){
	
	}
	
	
	IEnumerator TickTimer(){
		while(true){
			this.tick += 1;
			Debug.Log("[Tick_" + this.tick + "]");
			
			yield return new WaitForSeconds(timeBetweenTicks);
		}
	}
	
	public int Tick{
		get{return this.tick;}
	}
}