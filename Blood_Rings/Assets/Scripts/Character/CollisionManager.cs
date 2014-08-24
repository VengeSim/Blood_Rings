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
public class CollisionManager : MonoBehaviour {
	
	protected HitPacket hPacket;
	
	protected CharacterController2D cController;
	
	protected CollisionFlag hitboxHigh1;
	protected CollisionFlag hitboxHigh2;
	protected CollisionFlag hitboxHigh3;
	protected CollisionFlag hitboxLow1;
	protected CollisionFlag hitboxLow2;
	protected CollisionFlag hitboxLow3;
	protected CollisionFlag hurtbox1;
	protected CollisionFlag hurtbox2;
	protected CollisionFlag hurtbox3;
	
	public HitPacket HitPacket {get {return hPacket;}set { hPacket = value;}}
	
	void Awake () {
		this.cController = this.gameObject.GetComponent<CharacterController2D>();
	
		this.hitboxHigh1 = this.transform.Find("Boxes/High/HitBoxHigh1").GetComponent<CollisionFlag>();
		this.hitboxHigh2 = this.transform.Find("Boxes/High/HitBoxHigh2").GetComponent<CollisionFlag>();
		this.hitboxHigh3 = this.transform.Find("Boxes/High/HitBoxHigh3").GetComponent<CollisionFlag>();
		
		this.hitboxLow1 = this.transform.Find("Boxes/Low/HitBoxLow1").GetComponent<CollisionFlag>();
		this.hitboxLow2 = this.transform.Find("Boxes/Low/HitBoxLow2").GetComponent<CollisionFlag>();
		this.hitboxLow3 = this.transform.Find("Boxes/Low/HitBoxLow3").GetComponent<CollisionFlag>();
		
		this.hurtbox1 = this.transform.Find("Boxes/HurtBox1").GetComponent<CollisionFlag>();
		this.hurtbox2 = this.transform.Find("Boxes/HurtBox2").GetComponent<CollisionFlag>();
		this.hurtbox3 = this.transform.Find("Boxes/HurtBox3").GetComponent<CollisionFlag>();
	}
	
	void Update () {
		
		List<CollisionFlag> highList = this.ConsolidateListFirst(hitboxHigh1, hitboxHigh2, hitboxHigh3);
		List<CollisionFlag> lowList = this.ConsolidateListFirst(hitboxLow1, hitboxLow2, hitboxLow3);
		List<CollisionFlag> allList = this.ConsolidateListSecond(highList, lowList);
		

		
		
		
		this.cController.HandleHitPack(highList, lowList, allList);
		
		
//		int[] damageArray = new int[allList.Count];
//		int[] hitStunArray = new int[allList.Count];
//		int[] blockStunArray = new int[allList.Count];
//		float[] pushBackArray = new float[allList.Count];
//		
//		for (int i = 0; i < allList.Count; i++) {
//			HitPacket cPacket = allList[i].HitPacket;
//			
//			damageArray[i] = cPacket.Damage;
//			hitStunArray[i] = cPacket.HitStun;
//			blockStunArray[i] = cPacket.BlockStun;
//			pushBackArray[i] = cPacket.PushBack;
//			
//		}
//		
//		Array.Sort(damageArray);
//		Array.Sort(hitStunArray);
//		Array.Sort(blockStunArray);
//		Array.Sort(pushBackArray);
//		Array.Reverse(damageArray);
//		Array.Reverse(hitStunArray);
//		Array.Reverse(blockStunArray);
//		Array.Reverse(pushBackArray);	



		
	}
	
	public List<CollisionFlag> ConsolidateListFirst(CollisionFlag colFlag1, CollisionFlag colFlag2, CollisionFlag colFlag3){
		List<CollisionFlag> nList  = new List<CollisionFlag>();
		nList.AddRange(colFlag1.Others);
		nList.AddRange(colFlag2.Others);
		nList.AddRange(colFlag3.Others);
		for (int i = 0; i < nList.Count - 1; i++) {
			GameObject current = nList[i].gameObject.transform.root.gameObject;
			GameObject next = nList[i+1].gameObject.transform.root.gameObject;
			
			if(current == next){
				nList.Remove(nList[i+1]);
			}
		}
		return nList;
	}
	public List<CollisionFlag> ConsolidateListSecond(List<CollisionFlag> colList1, List<CollisionFlag> colList2){
		List<CollisionFlag> nList  = new List<CollisionFlag>();
		nList.AddRange(colList1);
		nList.AddRange(colList2);
		for (int i = 0; i < nList.Count - 1; i++) {
			GameObject current = nList[i].gameObject.transform.root.gameObject;
			GameObject next = nList[i+1].gameObject.transform.root.gameObject;
			
			if(current == next){
				nList.Remove(nList[i+1]);
			}
		}
		return nList;
	}
}








