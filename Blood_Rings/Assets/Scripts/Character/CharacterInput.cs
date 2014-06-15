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

public class CharacterInput : MonoBehaviour {

	public bool right;
	public bool left;
	public bool up;
	
	protected InputMon iMon;
	private CharacterMovement cMovement;
	
	void Awake () {
		this.iMon = new InputMon();
		this.cMovement = this.GetComponent<CharacterMovement>();
	}
	
	void Update () {
		this.iMon.Update();
		
		this.right = false;
		this.left = false;
		this.up = false;
		
		if(iMon.Right.State == true){

			
			
			right = true;
		}
		if(iMon.Left.State == true){

			
			left = true;
		}
		if(iMon.Up.State == true){
			
			up = true;
		}
		if(!up && !right && !left){			
			
			
		}
	}
}
