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
	public int jumpGroundCoolDown;
	
	public Attack attack1;
	public Attack attack2;
	public Attack attack3;
	public Attack attack4;
	public Attack attack5;
	public Attack attack6;
	public Attack attack7;
	public Attack attack8;
	
	
	//public startup renderer colour
	void Start () {
		
		this.attack1 = new Attack(sprites[0], Fighter1BoxData.ATTACKSHEET_0,new int[]{2,2,3});
		this.attack2 = new Attack(sprites[1], Fighter1BoxData.ATTACKSHEET_1,new int[]{6,3,5});
		this.attack3 = new Attack(sprites[2], Fighter1BoxData.ATTACKSHEET_2,new int[]{9,3,17});
		this.attack4 = new Attack(sprites[3], Fighter1BoxData.ATTACKSHEET_3,new int[]{4,6,8});
		this.attack5 = new Attack(sprites[4], Fighter1BoxData.ATTACKSHEET_4,new int[]{4,4,4});
		this.attack6 = new Attack(sprites[5], Fighter1BoxData.ATTACKSHEET_5,new int[]{6,4,7});
		this.attack7 = new Attack(sprites[6], Fighter1BoxData.ATTACKSHEET_6,new int[]{12,6,5});
		this.attack8 = new Attack(sprites[7], Fighter1BoxData.ATTACKSHEET_7,new int[]{16,9,7});
		
	}
	
	void Update () {
	
	}
}
