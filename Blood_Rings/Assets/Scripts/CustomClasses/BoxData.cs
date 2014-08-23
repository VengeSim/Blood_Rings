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



public class BoxPos{
	protected float sizeX;
	protected float sizeY;
	protected float centerX;
	protected float centerY;
	
	public BoxPos(){
		this.sizeX = 0f;
		this.sizeY = 0f;
		this.centerX = 0f;
		this.centerY = 0f;
	}
	
	public BoxPos(float sX, float sY, float cX, float cY){
		this.sizeX = sX;
		this.sizeY = sY;
		this.centerX = cX;
		this.centerY = cY;
	}
	
	public Vector2 Size{
		get{return new Vector2(sizeX, sizeY);}
	}
	public Vector2 Center{
		get{return new Vector2(centerX, centerY);}
	}
}


public class BoxData{
	
	protected BoxPos top;
	protected BoxPos bottom;
	protected BoxPos front;
	protected BoxPos back;
	protected BoxPos hitBoxHigh1;
	protected BoxPos hitBoxHigh2;
	protected BoxPos hitBoxHigh3;
	protected BoxPos hitBoxLow1;
	protected BoxPos hitBoxLow2;
	protected BoxPos hitBoxLow3;
	protected BoxPos hurtBox1;
	protected BoxPos hurtBox2;
	protected BoxPos hurtBox3;

	public BoxData(){
		this.top = new BoxPos();
		this.bottom = new BoxPos();
		this.front = new BoxPos();
		this.back = new BoxPos();
		this.hitBoxHigh1 = new BoxPos();
		this.hitBoxHigh2 = new BoxPos();
		this.hitBoxHigh3 = new BoxPos();
		this.hitBoxLow1 = new BoxPos();
		this.hitBoxLow2 = new BoxPos();
		this.hitBoxLow3 = new BoxPos();
		this.hurtBox1 = new BoxPos();
		this.hurtBox2 = new BoxPos();
		this.hurtBox3 = new BoxPos();
	}
	
	public BoxData(BoxPos[] boxes){
		this.top = boxes[0];
		this.bottom = boxes[1];
		this.front = boxes[2];
		this.back = boxes[3];
		this.hitBoxHigh1 = boxes[4];
		this.hitBoxHigh2 = boxes[5];
		this.hitBoxHigh3 = boxes[6];
		this.hitBoxLow1 = boxes[7];
		this.hitBoxLow2 = boxes[8];
		this.hitBoxLow3 = boxes[9];
		this.hurtBox1 = boxes[10];
		this.hurtBox2 = boxes[11];
		this.hurtBox3 = boxes[12];
	}
	
	public BoxPos Top {get {return top;}}
	public BoxPos Bottom {get {return bottom;}}
	public BoxPos Front {get {return front;}}
	public BoxPos Back {get {return back;}}
	public BoxPos HitboxHigh1 {get {return hitBoxHigh1;}}
	public BoxPos HitboxHigh2 {get {return hitBoxHigh2;}}
	public BoxPos HitboxHigh3 {get {return hitBoxHigh3;}}
	public BoxPos HitboxLow1 {get {return hitBoxLow1;}}
	public BoxPos HitboxLow2 {get {return hitBoxLow2;}}
	public BoxPos HitboxLow3 {get {return hitBoxLow3;}}
	public BoxPos HurtBox1 {get {return hurtBox1;}}
	public BoxPos HurtBox2 {get {return hurtBox2;}}
	public BoxPos HurtBox3 {get {return hurtBox3;}}
	
	
	public void SetFlagBoxes(BoxPos box1, BoxPos box2, BoxPos box3, BoxPos box4){
		this.top = box1;
		this.bottom = box2;
		this.front = box3;
		this.back = box4;
	}
	public void SetHitBoxes(BoxPos box1, BoxPos box2, BoxPos box3, BoxPos box4, BoxPos box5, BoxPos box6){
		this.hitBoxHigh1 = box1;
		this.hitBoxHigh2 = box2;
		this.hitBoxHigh3 = box3;
		this.hitBoxLow1 = box4;
		this.hitBoxLow2 = box5;
		this.hitBoxLow3 = box6;
	}
	public void SetHurtBoxes(BoxPos box1, BoxPos box2, BoxPos box3){
		this.hurtBox1 = box1;
		this.hurtBox2 = box2;
		this.hurtBox3 = box3;
	}
}

public static class Fighter1BoxData{

	public static BoxData NEUTRAL;
	public static BoxData CROUCH;
	public static BoxData JUMP;
	
	public static BoxData ATTACKSHEET_0;
	public static BoxData ATTACKSHEET_1;
	public static BoxData ATTACKSHEET_2;
	public static BoxData ATTACKSHEET_3;
	public static BoxData ATTACKSHEET_4;
	public static BoxData ATTACKSHEET_5;
	public static BoxData ATTACKSHEET_6;
	public static BoxData ATTACKSHEET_7;
	
	
	
	
	static Fighter1BoxData(){
		
		NEUTRAL = Neutral();
		CROUCH = Crouch();
		JUMP = Jump();
		ATTACKSHEET_0 = AttackSheet_0();
		ATTACKSHEET_1 = AttackSheet_1();
		ATTACKSHEET_2 = AttackSheet_2();
		ATTACKSHEET_3 = AttackSheet_3();
		ATTACKSHEET_4 = AttackSheet_4();
		ATTACKSHEET_5 = AttackSheet_5();
		ATTACKSHEET_6 = AttackSheet_6();
		ATTACKSHEET_7 = AttackSheet_7();
		
		
	}

	public static BoxData Neutral(){
		BoxData nBoxData = new BoxData();
	
		BoxPos top = new BoxPos(0.51f, 0.06f, 0f, 1.58f);  
		BoxPos bottom = new BoxPos(0.33f, 0.05f, 0f, 0.05f);  
		BoxPos front = new BoxPos(0.05f, 1.25f, 0.32f, 0.79f);  
		BoxPos back = new BoxPos(0.05f, 1.31f, -0.35f, 0.79f);  
		nBoxData.SetFlagBoxes(top, bottom, front, back);
		
		BoxPos hitBoxHigh1 = new BoxPos(0.53f, 0.66f, -0.03f, 1.23f);  
		BoxPos hitBoxHigh2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxHigh3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxLow1 = new BoxPos(0.45f, 0.86f, -0.05f, 0.49f);  
		BoxPos hitBoxLow2 = new BoxPos(0.22f, 0.4f, 0.25f, 0.21f);  
		BoxPos hitBoxLow3 = new BoxPos(0.12f, 0.51f, -0.29f, 0.32f);  
		nBoxData.SetHitBoxes(hitBoxHigh1, hitBoxHigh2, hitBoxHigh3, hitBoxLow1, hitBoxLow2, hitBoxLow3);
		
		BoxPos hurtBox1 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hurtBox2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hurtBox3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);
		
		return nBoxData;
	}
	
	public static BoxData Crouch(){
		BoxData nBoxData = new BoxData();
		
		BoxPos top = new BoxPos(0.51f, 0.06f, 0f, 1.58f);  
		BoxPos bottom = new BoxPos(0.33f, 0.05f, 0f, 0.05f);  
		BoxPos front = new BoxPos(0.05f, 1.25f, 0.32f, 0.79f);  
		BoxPos back = new BoxPos(0.05f, 1.31f, -0.35f, 0.79f);  
		nBoxData.SetFlagBoxes(top, bottom, front, back);
		
		BoxPos hitBoxHigh1 = new BoxPos(0.38f, 0.12f, 0f, 0.99f);  
		BoxPos hitBoxHigh2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxHigh3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxLow1 = new BoxPos(0.63f, 0.86f, 0.01f, 0.49f);  
		BoxPos hitBoxLow2 = new BoxPos(0.22f, 0.4f, 0.25f, 0.82f);  
		BoxPos hitBoxLow3 = new BoxPos(0.12f, 0.51f, -0.29f, 0.32f);  
		nBoxData.SetHitBoxes(hitBoxHigh1, hitBoxHigh2, hitBoxHigh3, hitBoxLow1, hitBoxLow2, hitBoxLow3);
		
		BoxPos hurtBox1 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hurtBox2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hurtBox3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);
		
		return nBoxData;
	}
	
	public static BoxData Jump(){
		BoxData nBoxData = new BoxData();
		
		BoxPos top = new BoxPos(0.51f, 0.06f, 0f, 1.58f);  
		BoxPos bottom = new BoxPos(0.33f, 0.05f, 0f, 0.05f);  
		BoxPos front = new BoxPos(0.05f, 1.25f, 0.32f, 0.79f);  
		BoxPos back = new BoxPos(0.05f, 1.31f, -0.35f, 0.79f);  
		nBoxData.SetFlagBoxes(top, bottom, front, back);
		
		BoxPos hitBoxHigh1 = new BoxPos(0.53f, 0.66f, -0.03f, 1.23f);  
		BoxPos hitBoxHigh2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxHigh3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxLow1 = new BoxPos(0.45f, 0.86f, -0.05f, 0.49f);  
		BoxPos hitBoxLow2 = new BoxPos(0f, 0f, 0f, 0f);  
		BoxPos hitBoxLow3 = new BoxPos(0f, 0f, 0f, 0f);  
		nBoxData.SetHitBoxes(hitBoxHigh1, hitBoxHigh2, hitBoxHigh3, hitBoxLow1, hitBoxLow2, hitBoxLow3);
		
		BoxPos hurtBox1 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hurtBox2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hurtBox3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);
		
		return nBoxData;
	}
	
	public static BoxData AttackSheet_0(){
		BoxData nBoxData = new BoxData();
		
		BoxPos top = new BoxPos(0.51f, 0.06f, 0f, 1.58f);  
		BoxPos bottom = new BoxPos(0.33f, 0.05f, 0f, 0.05f);  
		BoxPos front = new BoxPos(0.05f, 1.25f, 0.32f, 0.79f);  
		BoxPos back = new BoxPos(0.05f, 1.31f, -0.35f, 0.79f);  
		nBoxData.SetFlagBoxes(top, bottom, front, back);
		
		BoxPos hitBoxHigh1 = new BoxPos(0.44f, 0.64f, -0.03f, 1.23f);  
		BoxPos hitBoxHigh2 = new BoxPos(0.6f, 0.18f, 0.41f, 1.24f);  
		BoxPos hitBoxHigh3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxLow1 = new BoxPos(0.42f, 0.86f, -0.08f, 0.49f);  
		BoxPos hitBoxLow2 = new BoxPos(0.22f, 0.46f, 0.16f, 0.33f);  
		BoxPos hitBoxLow3 = new BoxPos(0.13f, 0.63f, -0.29f, 0.38f);  
		nBoxData.SetHitBoxes(hitBoxHigh1, hitBoxHigh2, hitBoxHigh3, hitBoxLow1, hitBoxLow2, hitBoxLow3);
		
		BoxPos hurtBox1 = new BoxPos(0.25f, 0.16f, 0.57f, 1.24f);  
		BoxPos hurtBox2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hurtBox3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);
		
		return nBoxData;
	}
	
	public static BoxData AttackSheet_1(){
		BoxData nBoxData = new BoxData();
		
		BoxPos top = new BoxPos(0.51f, 0.06f, 0f, 1.58f);  
		BoxPos bottom = new BoxPos(0.33f, 0.05f, 0f, 0.05f);  
		BoxPos front = new BoxPos(0.05f, 1.25f, 0.32f, 0.79f);  
		BoxPos back = new BoxPos(0.05f, 1.31f, -0.35f, 0.79f);  
		nBoxData.SetFlagBoxes(top, bottom, front, back);
		
		BoxPos hitBoxHigh1 = new BoxPos(0.29f, 0.7f, 0.18f, 1.26f);  
		BoxPos hitBoxHigh2 = new BoxPos(0.36f, 0.15f, 0.5f, 1.27f);  
		BoxPos hitBoxHigh3 = new BoxPos(0.27f, 0.48f, -0.03f, 1.17f);  
		BoxPos hitBoxLow1 = new BoxPos(0.33f, 0.65f, 0.22f, 0.34f);  
		BoxPos hitBoxLow2 = new BoxPos(0.19f, 0.37f, -0.26f, 0.21f);  
		BoxPos hitBoxLow3 = new BoxPos(0.46f, 0.45f, 0.04f, 0.68f);  
		nBoxData.SetHitBoxes(hitBoxHigh1, hitBoxHigh2, hitBoxHigh3, hitBoxLow1, hitBoxLow2, hitBoxLow3);
		
		BoxPos hurtBox1 = new BoxPos(0.28f, 0.16f, 0.7f, 1.27f);  
		BoxPos hurtBox2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hurtBox3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);
		
		return nBoxData;
	}
	public static BoxData AttackSheet_2(){
		BoxData nBoxData = new BoxData();
		
		BoxPos top = new BoxPos(1.29f, 0.06f, 0f, 1.58f);  
		BoxPos bottom = new BoxPos(0.21f, 0.06f, -0.06f, 0.05f);  
		BoxPos front = new BoxPos(0.06f, 0.27f, 0.63f, 1.46f);  
		BoxPos back = new BoxPos(0.06f, 0.53f, -0.57f, 1.27f);  
		nBoxData.SetFlagBoxes(top, bottom, front, back);
		
		BoxPos hitBoxHigh1 = new BoxPos(0.42f, 0.7f, -0.45f, 1.23f);  
		BoxPos hitBoxHigh2 = new BoxPos(0.32f, 0.24f, 0.47f, 1.45f);  
		BoxPos hitBoxHigh3 = new BoxPos(0.51f, 0.48f, 0.03f, 1.16f);  
		BoxPos hitBoxLow1 = new BoxPos(0.24f, 1.01f, -0.09f, 0.46f);  
		BoxPos hitBoxLow2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxLow3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		nBoxData.SetHitBoxes(hitBoxHigh1, hitBoxHigh2, hitBoxHigh3, hitBoxLow1, hitBoxLow2, hitBoxLow3);
		
		BoxPos hurtBox1 = new BoxPos(0.28f, 0.16f, 0.52f, 1.51f);  
		BoxPos hurtBox2 = new BoxPos(0.27f, 0.28f, 0.33f, 1.36f);  
		BoxPos hurtBox3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);
		
		return nBoxData;
	}
	public static BoxData AttackSheet_3(){
		BoxData nBoxData = new BoxData();
		
		BoxPos top = new BoxPos(0.37f, 0.06f, 0f, 1.58f);  
		BoxPos bottom = new BoxPos(0.21f, 0.06f, -0.12f, 0.05f);  
		BoxPos front = new BoxPos(0.1f, 0.27f, 0.52f, 0.55f);  
		BoxPos back = new BoxPos(0.06f, 1.28f, -0.23f, 0.73f);  
		nBoxData.SetFlagBoxes(top, bottom, front, back);
		
		BoxPos hitBoxHigh1 = new BoxPos(0.57f, 0.7f, -0.06f, 1.23f);  
		BoxPos hitBoxHigh2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxHigh3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxLow1 = new BoxPos(0.24f, 0.76f, -0.09f, 0.37f);  
		BoxPos hitBoxLow2 = new BoxPos(0.28f, 0.28f, 0.41f, 0.54f);  
		BoxPos hitBoxLow3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		nBoxData.SetHitBoxes(hitBoxHigh1, hitBoxHigh2, hitBoxHigh3, hitBoxLow1, hitBoxLow2, hitBoxLow3);
		
		BoxPos hurtBox1 = new BoxPos(0.21f, 0.22f, 0.52f, 0.53f);  
		BoxPos hurtBox2 = new BoxPos(0.25f, 0.21f, 0.33f, 0.7f);  
		BoxPos hurtBox3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);
		
		return nBoxData;
	}
	public static BoxData AttackSheet_4(){
		BoxData nBoxData = new BoxData();
		
		BoxPos top = new BoxPos(0.88f, 0.06f, 0.29f, 0.93f);  
		BoxPos bottom = new BoxPos(0.57f, 0.05f, 0f, 0.05f);  
		BoxPos front = new BoxPos(0.06f, 0.22f, 0.76f, 0.79f);  
		BoxPos back = new BoxPos(0.05f, 0.76f, -0.26f, 0.52f);  
		nBoxData.SetFlagBoxes(top, bottom, front, back);
		
		BoxPos hitBoxHigh1 = new BoxPos(0.47f, 0.12f, 0.06f, 0.98f);  
		BoxPos hitBoxHigh2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxHigh3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxLow1 = new BoxPos(0.57f, 0.86f, 0.08f, 0.49f);  
		BoxPos hitBoxLow2 = new BoxPos(0.22f, 0.13f, 0.66f, 0.75f);  
		BoxPos hitBoxLow3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		nBoxData.SetHitBoxes(hitBoxHigh1, hitBoxHigh2, hitBoxHigh3, hitBoxLow1, hitBoxLow2, hitBoxLow3);
		
		BoxPos hurtBox1 = new BoxPos(0.12f, 0.12f, 0.71f, 0.76f);  
		BoxPos hurtBox2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hurtBox3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);
		
		return nBoxData;
	}
	public static BoxData AttackSheet_5(){
		BoxData nBoxData = new BoxData();
		
		BoxPos top = new BoxPos(0.57f, 0.07f, 0.2f, 0.94f);  
		BoxPos bottom = new BoxPos(0.57f, 0.05f, -0.02f, 0.05f);  
		BoxPos front = new BoxPos(0.06f, 0.16f, 0.69f, 0.81f);  
		BoxPos back = new BoxPos(0.08f, 0.74f, -0.16f, 0.55f);  
		nBoxData.SetFlagBoxes(top, bottom, front, back);
		
		BoxPos hitBoxHigh1 = new BoxPos(0.49f, 0.12f, 0.06f, 0.96f);  
		BoxPos hitBoxHigh2 = new BoxPos(0.19f, 0.12f, 0.61f, 0.82f);  
		BoxPos hitBoxHigh3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxLow1 = new BoxPos(0.64f, 0.47f, 0.05f, 0.27f);  
		BoxPos hitBoxLow2 = new BoxPos(0.4f, 0.57f, 0.02f, 0.67f);  
		BoxPos hitBoxLow3 = new BoxPos(0.38f, 0.19f, -0.14f, 0.19f);  
		nBoxData.SetHitBoxes(hitBoxHigh1, hitBoxHigh2, hitBoxHigh3, hitBoxLow1, hitBoxLow2, hitBoxLow3);
		
		BoxPos hurtBox1 = new BoxPos(0.42f, 0.13f, 0.53f, 0.81f);  
		BoxPos hurtBox2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hurtBox3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);
		
		return nBoxData;
	}
	public static BoxData AttackSheet_6(){
		BoxData nBoxData = new BoxData();
		
		BoxPos top = new BoxPos(0.23f, 0.06f, 0.08f, 1.09f);  
		BoxPos bottom = new BoxPos(1.24f, 0.05f, 0.28f, 0.05f);  
		BoxPos front = new BoxPos(0.06f, 0.16f, 0.85f, 0.23f);  
		BoxPos back = new BoxPos(0.05f, 0.92f, -0.25f, 0.58f);  
		nBoxData.SetFlagBoxes(top, bottom, front, back);
		
		BoxPos hitBoxHigh1 = new BoxPos(0.32f, 0.51f, 0.03f, 0.83f);  
		BoxPos hitBoxHigh2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxHigh3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxLow1 = new BoxPos(1.19f, 0.21f, 0.27f, 0.14f);  
		BoxPos hitBoxLow2 = new BoxPos(0.58f, 0.36f, 0.02f, 0.43f);  
		BoxPos hitBoxLow3 = new BoxPos(0.33f, 0.28f, 0.33f, 0.28f);  
		nBoxData.SetHitBoxes(hitBoxHigh1, hitBoxHigh2, hitBoxHigh3, hitBoxLow1, hitBoxLow2, hitBoxLow3);
		
		BoxPos hurtBox1 = new BoxPos(0.39f, 0.16f, 0.68f, 0.14f);  
		BoxPos hurtBox2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hurtBox3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);
		
		return nBoxData;
	}
	public static BoxData AttackSheet_7(){
		BoxData nBoxData = new BoxData();
		
		BoxPos top = new BoxPos(0.23f, 0.09f, 0.11f, 0.94f);  
		BoxPos bottom = new BoxPos(1.24f, 0.05f, 0.28f, 0.05f);  
		BoxPos front = new BoxPos(0.06f, 0.16f, 0.94f, 0.23f);  
		BoxPos back = new BoxPos(0.08f, 0.62f, -0.16f, 0.49f);  
		nBoxData.SetFlagBoxes(top, bottom, front, back);
		
		BoxPos hitBoxHigh1 = new BoxPos(0.32f, 0.39f, 0.09f, 0.77f);  
		BoxPos hitBoxHigh2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxHigh3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hitBoxLow1 = new BoxPos(1.19f, 0.21f, 0.27f, 0.14f);  
		BoxPos hitBoxLow2 = new BoxPos(0.58f, 0.57f, 0.02f, 0.58f);  
		BoxPos hitBoxLow3 = new BoxPos(0.33f, 0.28f, -0.23f, 0.28f);  
		nBoxData.SetHitBoxes(hitBoxHigh1, hitBoxHigh2, hitBoxHigh3, hitBoxLow1, hitBoxLow2, hitBoxLow3);
		
		BoxPos hurtBox1 = new BoxPos(0.21f, 0.16f, 0.83f, 0.14f);  
		BoxPos hurtBox2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hurtBox3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);
		
		return nBoxData;
	}
}



public static class DummyBoxData{
	
	public static BoxData NEUTRAL;

	
	static DummyBoxData(){
		
		NEUTRAL = Neutral();

	}
	
	public static BoxData Neutral(){
		BoxData nBoxData = new BoxData();
		
		BoxPos top = new BoxPos(0.17f, 0.06f, 0.03f, 1.58f);  
		BoxPos bottom = new BoxPos(0.84f, 0.05f, 0f, 0.05f);  
		BoxPos front = new BoxPos(0.06f, 1.25f, 0.23f, 0.79f);  
		BoxPos back = new BoxPos(0.05f, 1.31f, -0.29f, 0.79f);  
		nBoxData.SetFlagBoxes(top, bottom, front, back);
		
		BoxPos hitBoxHigh1 = new BoxPos(0.24f, 0.69f, 0.02f, 1.2f);  
		BoxPos hitBoxHigh2 = new BoxPos(0.24f, 0.56f, -0.17f, 1.09f);  
		BoxPos hitBoxHigh3 = new BoxPos(0.21f, 0.39f, 0.23f, 0.95f);  
		BoxPos hitBoxLow1 = new BoxPos(0.22f, 0.68f, 0.25f, 0.33f);  
		BoxPos hitBoxLow2 = new BoxPos(0.22f, 0.74f, -0.27f, 0.43f);  
		BoxPos hitBoxLow3 = new BoxPos(0.19f, 0.29f, -0.02f, 0.64f);  
		nBoxData.SetHitBoxes(hitBoxHigh1, hitBoxHigh2, hitBoxHigh3, hitBoxLow1, hitBoxLow2, hitBoxLow3);
		
		BoxPos hurtBox1 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hurtBox2 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		BoxPos hurtBox3 = new BoxPos(0.0001f, 0.0001f, 0f, 0f);  
		nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);
		
		return nBoxData;
	}

}













