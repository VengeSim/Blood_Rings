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


public class CharacterStats : MonoBehaviour {
	
	public Sprite[] sprites;
	
	public float walkForwardSpeed;
	public float walkBackwardSpeed;
	public float jumpHeight;
	
	public Attack a1;
	public Attack a2;
	public Attack a3;
	public Attack a4;
	
	//public startup renderer colour
	void Start () {
		
		this.a1 = new Attack(sprites[0], Fighter1BoxData.ATTACKSHEET_0,new int[]{4,4,4});
	}
	
	void Update () {
	
	}
}
