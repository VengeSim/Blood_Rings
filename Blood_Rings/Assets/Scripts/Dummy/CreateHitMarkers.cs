﻿using UnityEngine;
using System.Collections;

public class CreateHitMarkers : MonoBehaviour {

	public GameObject hitMarker;

	protected CollisionFlag hitboxHigh1Col;
	protected CollisionFlag hitboxHigh2Col;
	protected CollisionFlag hitboxHigh3Col;
	protected CollisionFlag hitboxLow1Col;
	protected CollisionFlag hitboxLow2Col;
	protected CollisionFlag hitboxLow3Col;
	
	protected int count;

	
	
	void Start () {
		this.hitboxHigh1Col = this.transform.Find("Boxes/High/HitBoxHigh1").GetComponent<CollisionFlag>();
		this.hitboxHigh2Col = this.transform.Find("Boxes/High/HitBoxHigh2").GetComponent<CollisionFlag>();
		this.hitboxHigh3Col = this.transform.Find("Boxes/High/HitBoxHigh3").GetComponent<CollisionFlag>();
		
		this.hitboxLow1Col = this.transform.Find("Boxes/Low/HitBoxLow1").GetComponent<CollisionFlag>();
		this.hitboxLow2Col = this.transform.Find("Boxes/Low/HitBoxLow2").GetComponent<CollisionFlag>();
		this.hitboxLow3Col = this.transform.Find("Boxes/Low/HitBoxLow3").GetComponent<CollisionFlag>();
		
		this.count = 0;

	}
	
	void Update () {
	
		if (this.count < 1){
			if (this.hitboxHigh1Col.Bool) {
				Object prefab = Instantiate (hitMarker, this.hitboxHigh1Col.gameObject.transform.TransformPoint(this.hitboxHigh1Col.gameObject.GetComponent<BoxCollider2D>().center), this.hitboxHigh1Col.gameObject.transform.localRotation);
					this.count++;
					StartCoroutine (DestroyMon (prefab));
	
			}
			if (this.hitboxHigh2Col.Bool) {
				Object prefab = Instantiate (hitMarker, this.hitboxHigh1Col.gameObject.transform.TransformPoint(this.hitboxHigh2Col.gameObject.GetComponent<BoxCollider2D>().center), this.hitboxHigh2Col.gameObject.transform.localRotation);
					this.count++;
					StartCoroutine (DestroyMon (prefab));
			}
			if (this.hitboxHigh3Col.Bool) {
				Object prefab = Instantiate (hitMarker, this.hitboxHigh1Col.gameObject.transform.TransformPoint(this.hitboxHigh3Col.gameObject.GetComponent<BoxCollider2D>().center), this.hitboxHigh3Col.gameObject.transform.localRotation);
					this.count++;
					StartCoroutine (DestroyMon (prefab));
			}
			if (this.hitboxLow1Col.Bool) {
				Object prefab = Instantiate (hitMarker, this.hitboxHigh1Col.gameObject.transform.TransformPoint(this.hitboxLow1Col.gameObject.GetComponent<BoxCollider2D>().center), this.hitboxLow1Col.gameObject.transform.localRotation);
				this.count++;
				StartCoroutine (DestroyMon (prefab));
				
			}
			if (this.hitboxLow2Col.Bool) {
				Object prefab = Instantiate (hitMarker, this.hitboxHigh1Col.gameObject.transform.TransformPoint(this.hitboxLow2Col.gameObject.GetComponent<BoxCollider2D>().center), this.hitboxLow2Col.gameObject.transform.localRotation);
				this.count++;
				StartCoroutine (DestroyMon (prefab));
			}
			if (this.hitboxLow3Col.Bool) {
				Object prefab = Instantiate (hitMarker, this.hitboxHigh1Col.gameObject.transform.TransformPoint(this.hitboxLow3Col.gameObject.GetComponent<BoxCollider2D>().center), this.hitboxLow3Col.gameObject.transform.localRotation);
				this.count++;
				StartCoroutine (DestroyMon (prefab));
			}
		}
	}
	
	IEnumerator DestroyMon(Object prefab){
		while(true){
			if(prefab == null){
				this.count--;
				break;
			}
			
			yield return 0;
		}
	}
}
