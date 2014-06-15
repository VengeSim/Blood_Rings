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

public class TickController : MonoBehaviour {
	
	public int tick = 0;
	
	public delegate void EventHandler();
	//public event EventHandler Ontick;
	//public Fighter fighter1;
	//public Fighter fighter2;
	

	
	void Start (){		
		//this.Ontick += new EventHandler(fighter1.TickUpdate);

		StartCoroutine("TickTimer");
	}
	
	void Update (){

	}
	
	void OnGUI(){

	}
	
	
	IEnumerator TickTimer(){
		while(true){
			this.tick += 1;
			Debug.Log("[Tick_" + this.tick + "]");
			//Ontick.Invoke();
			
			//yield return new WaitForSeconds(0.5f);
			yield return new WaitForSeconds(0.06f);
		}
	}
	
	public int Tick{
		get{return this.tick;}
	}
}