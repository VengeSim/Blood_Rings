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
public class CollisionController : MonoBehaviour {
	
	
	protected ObjectController cController;
	
	protected HitBox hitboxHigh1;
	protected HitBox hitboxHigh2;
	protected HitBox hitboxHigh3;
	protected HitBox hitboxLow1;
	protected HitBox hitboxLow2;
	protected HitBox hitboxLow3;
	protected HurtBox hurtbox1;
	protected HurtBox hurtbox2;
	protected HurtBox hurtbox3;
	protected CollisionFlag physicalBox;
	
	protected List<HitPacketWrapper> collisionList;

	public List<HitPacketWrapper> CollisionList {get {return collisionList;}}	
	
		
	void Awake () {
		this.cController = this.gameObject.GetComponent<CharacterController2D>();
	
		this.hitboxHigh1 = this.transform.Find("Boxes/HitBoxHigh1").GetComponent<HitBox>();
		this.hitboxHigh2 = this.transform.Find("Boxes/HitBoxHigh2").GetComponent<HitBox>();
		this.hitboxHigh3 = this.transform.Find("Boxes/HitBoxHigh3").GetComponent<HitBox>();
		
		this.hitboxLow1 = this.transform.Find("Boxes/HitBoxLow1").GetComponent<HitBox>();
		this.hitboxLow2 = this.transform.Find("Boxes/HitBoxLow2").GetComponent<HitBox>();
		this.hitboxLow3 = this.transform.Find("Boxes/HitBoxLow3").GetComponent<HitBox>();
		
		this.hurtbox1 = this.transform.Find("Boxes/HurtBox1").GetComponent<HurtBox>();
		this.hurtbox2 = this.transform.Find("Boxes/HurtBox2").GetComponent<HurtBox>();
		this.hurtbox3 = this.transform.Find("Boxes/HurtBox3").GetComponent<HurtBox>();
		
		this.physicalBox = this.transform.Find("Boxes/PhysicalBox").GetComponent<CollisionFlag>();
		
		this.collisionList = new List<HitPacketWrapper>();
	}
	
	void Update () {
	
		//Create combined HurtBox Lists
		List<HurtBox> completeHighHurtBoxList = new List<HurtBox>();
		completeHighHurtBoxList.AddRange(this.hitboxHigh1.HurtBoxes);
		completeHighHurtBoxList.AddRange(this.hitboxHigh2.HurtBoxes);
		completeHighHurtBoxList.AddRange(this.hitboxHigh3.HurtBoxes);
		
		List<HurtBox> completeLowHurtBoxList = new List<HurtBox>();
		completeLowHurtBoxList.AddRange(this.hitboxLow1.HurtBoxes);
		completeLowHurtBoxList.AddRange(this.hitboxLow2.HurtBoxes);
		completeLowHurtBoxList.AddRange(this.hitboxLow3.HurtBoxes);
		
		
		//Create HitPacketWrapper Lists
		List<HitPacketWrapper> highWrapperList = new List<HitPacketWrapper>();
		for (int i = 0; i < completeHighHurtBoxList.Count; i++) {
			highWrapperList.Add(new HitPacketWrapper(
				completeHighHurtBoxList[i].ObjectController, 
				completeHighHurtBoxList[i],
				completeHighHurtBoxList[i].HitPacket, 
				HitType.High)
			);
		}
		
		List<HitPacketWrapper> lowWrapperList = new List<HitPacketWrapper>();
		for (int i = 0; i < completeLowHurtBoxList.Count; i++) {
			lowWrapperList.Add(new HitPacketWrapper(
				completeLowHurtBoxList[i].ObjectController, 
				completeLowHurtBoxList[i],
				completeLowHurtBoxList[i].HitPacket, 
				HitType.Low)
			);
		}
		
		//Combine HitPacketWrapper Lists
		List<HitPacketWrapper> completeWrapperList = new List<HitPacketWrapper>();
		completeWrapperList.AddRange(highWrapperList);
		completeWrapperList.AddRange(lowWrapperList);
		
		
		//Remove Duplicate Packets  //TODO Add/Workout priority to either high or low
		//I think High Has Priority because it was added to wrapper list first and
		//RemoveDuplicate checks the first and secont then removes the second.
		List<HitPacketWrapper> nList = this.RemoveDuplicates(completeWrapperList);
		
		this.cController.HandleHitPackets(nList);
		
	}
	

	
	public List<HitPacketWrapper> RemoveDuplicates(List<HitPacketWrapper> wrapperList){

		for (int i = 0; i < wrapperList.Count - 1; i++) {
			ObjectController current = wrapperList[i].Owner;
			ObjectController next = wrapperList[i+1].Owner;
			
			if(current.gameObject == next.gameObject){
				//UnityEngine.Debug.Log("RemoveDuplicates");
				wrapperList.RemoveAt(i);
			}
		}
		return wrapperList;
	}

	
	public void SetHitBoxHighData(BoxData bData){
		hitboxHigh1.BoxCollider2D.size = bData.HitboxHigh1.Size;
		hitboxHigh2.BoxCollider2D.size = bData.HitboxHigh2.Size;
		hitboxHigh3.BoxCollider2D.size = bData.HitboxHigh3.Size;
		hitboxHigh1.BoxCollider2D.center = bData.HitboxHigh1.Center;
		hitboxHigh2.BoxCollider2D.center = bData.HitboxHigh2.Center;
		hitboxHigh3.BoxCollider2D.center = bData.HitboxHigh3.Center;
	}
	public void SetHitBoxLowData(BoxData bData){
		hitboxLow1.BoxCollider2D.size = bData.HitboxLow1.Size;
		hitboxLow2.BoxCollider2D.size = bData.HitboxLow2.Size;
		hitboxLow3.BoxCollider2D.size = bData.HitboxLow3.Size;
		hitboxLow1.BoxCollider2D.center = bData.HitboxLow1.Center;
		hitboxLow2.BoxCollider2D.center = bData.HitboxLow2.Center;
		hitboxLow3.BoxCollider2D.center = bData.HitboxLow3.Center;
	}
	public void SetHurtBoxData(BoxData bData){
		hurtbox1.BoxCollider2D.size = bData.HurtBox1.Size;
		hurtbox2.BoxCollider2D.size = bData.HurtBox2.Size;
		hurtbox3.BoxCollider2D.size = bData.HurtBox3.Size;
		hurtbox1.BoxCollider2D.center = bData.HurtBox1.Center;
		hurtbox2.BoxCollider2D.center = bData.HurtBox2.Center;
		hurtbox3.BoxCollider2D.center = bData.HurtBox3.Center;
	}
	public void SetPhysicalBoxData(BoxData bData){
		
		physicalBox.BoxCollider2D.size = bData.Physical.Size;
		physicalBox.BoxCollider2D.center = bData.Physical.Center;
		
	}
}








