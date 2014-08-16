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
	protected BoxPos hitBox1;
	protected BoxPos hitBox2;
	protected BoxPos hitBox3;
	protected BoxPos hurtBox1;
	protected BoxPos hurtBox2;
	protected BoxPos hurtBox3;

	public BoxData(){
		this.top = new BoxPos();
		this.bottom = new BoxPos();
		this.front = new BoxPos();
		this.back = new BoxPos();
		this.hitBox1 = new BoxPos();
		this.hitBox2 = new BoxPos();
		this.hitBox3 = new BoxPos();
		this.hurtBox1 = new BoxPos();
		this.hurtBox2 = new BoxPos();
		this.hurtBox3 = new BoxPos();
	}
	
	public BoxData(BoxPos[] boxes){
		this.top = boxes[0];
		this.bottom = boxes[1];
		this.front = boxes[2];
		this.back = boxes[3];
		this.hitBox1 = boxes[4];
		this.hitBox2 = boxes[5];
		this.hitBox3 = boxes[6];
		this.hurtBox1 = boxes[7];
		this.hurtBox2 = boxes[8];
		this.hurtBox3 = boxes[9];
	}
	
	public BoxPos Top {get {return top;}}
	public BoxPos Bottom {get {return bottom;}}
	public BoxPos Front {get {return front;}}
	public BoxPos Back {get {return back;}}
	public BoxPos Hitbox1 {get {return hitBox1;}}
	public BoxPos Hitbox2 {get {return hitBox2;}}
	public BoxPos Hitbox3 {get {return hitBox3;}}
	public BoxPos HurtBox1 {get {return hurtBox1;}}
	public BoxPos HurtBox2 {get {return hurtBox2;}}
	public BoxPos HurtBox3 {get {return hurtBox3;}}
	
	
	public void SetFlagBoxes(BoxPos box1, BoxPos box2, BoxPos box3, BoxPos box4){
		this.top = box1;
		this.bottom = box2;
		this.front = box3;
		this.back = box4;
	}
	public void SetHitBoxes(BoxPos box1, BoxPos box2, BoxPos box3){
		this.hitBox1 = box1;
		this.hitBox2 = box2;
		this.hitBox3 = box3;
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
	public static BoxData ATTACKSHEET_0;
	
	
	static Fighter1BoxData(){
		
		NEUTRAL = Neutral();
		CROUCH = Crouch();
		ATTACKSHEET_0 = AttackSheet_0();
		
	}

	public static BoxData Neutral(){
		BoxData nBoxData = new BoxData();
	
		BoxPos top = new BoxPos(0.51f, 0.06f, 0f, 1.58f);
		BoxPos bottom = new BoxPos(0.33f, 0.05f, 0f, 0.05f);
		BoxPos front = new BoxPos(0.05f, 1.25f, 0.32f, 0.79f);
		BoxPos back = new BoxPos(0.05f, 1.31f, -0.35f, 0.79f);
		nBoxData.SetFlagBoxes(top, bottom, front, back);
		
		BoxPos hitBox1 = new BoxPos(0.56f, 1.47f, -0.03f, 0.82f);
		BoxPos hitBox2 = new BoxPos(0f, 0f, 0f, 0f);
		BoxPos hitBox3 = new BoxPos(0f, 0f, 0f, 0f);
		nBoxData.SetHitBoxes(hitBox1, hitBox2, hitBox3);
		
		BoxPos hurtBox1 = new BoxPos(0f, 0f, 0f, 0f);
		BoxPos hurtBox2 = new BoxPos(0f, 0f, 0f, 0f);
		BoxPos hurtBox3 = new BoxPos(0f, 0f, 0f, 0f);
		nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);
		
		return nBoxData;
	}
	
	public static BoxData Crouch(){
		BoxData nBoxData = new BoxData();
		
		BoxPos top = new BoxPos(0.51f, 0.06f, 0f, 1.07f);
		BoxPos bottom = new BoxPos(0.33f, 0.05f, 0f, 0.05f);
		BoxPos front = new BoxPos(0.05f, 0.85f, 0.32f, 0.55f);
		BoxPos back = new BoxPos(0.05f, 0.83f, -0.35f, 0.55f);
		nBoxData.SetFlagBoxes(top, bottom, front, back);
		
		BoxPos hitBox1 = new BoxPos(0.56f, 0.96f, 0.03f, 0.54f);
		BoxPos hitBox2 = new BoxPos(0.21f, 0.27f, -0.24f, 0.21f);
		BoxPos hitBox3 = new BoxPos(0f, 0f, 0f, 0f);
		nBoxData.SetHitBoxes(hitBox1, hitBox2, hitBox3);
		
		BoxPos hurtBox1 = new BoxPos(0f, 0f, 0f, 0f);
		BoxPos hurtBox2 = new BoxPos(0f, 0f, 0f, 0f);
		BoxPos hurtBox3 = new BoxPos(0f, 0f, 0f, 0f);
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
		
		BoxPos hitBox1 = new BoxPos(0.56f, 1.5f, -0.03f, 0.8f);
		BoxPos hitBox2 = new BoxPos(0.6f, 0.15f, 0.39f, 1.23f);
		BoxPos hitBox3 = new BoxPos(0f, 0f, 0f, 0f);
		nBoxData.SetHitBoxes(hitBox1, hitBox2, hitBox3);
		
		BoxPos hurtBox1 = new BoxPos(0.21f, 0.16f, 0.6f, 1.25f);
		BoxPos hurtBox2 = new BoxPos(0f, 0f, 0f, 0f);
		BoxPos hurtBox3 = new BoxPos(0f, 0f, 0f, 0f);
		nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);
		
		return nBoxData;
	}
}



















