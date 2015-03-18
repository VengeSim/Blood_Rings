/*
	Blood Ring
	Copyright © 2014 jgumbo@live.com
*/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;




[CanEditMultipleObjects]
[CustomEditor(typeof(BoxOutput))]
public class BoxDataReadOut : Editor 
{
	public override void OnInspectorGUI()
	{
		BoxOutput myTarget = (BoxOutput)target;
		GameObject gObject = myTarget.gameObject;
		
		BoxCollider2D physicalCol = gObject.transform.Find("PhysicalBox").GetComponent<BoxCollider2D>();
		
		BoxCollider2D hitboxHigh1Col = gObject.transform.Find("HitBoxHigh1").GetComponent<BoxCollider2D>();
		BoxCollider2D hitboxHigh2Col = gObject.transform.Find("HitBoxHigh2").GetComponent<BoxCollider2D>();
		BoxCollider2D hitboxHigh3Col = gObject.transform.Find("HitBoxHigh3").GetComponent<BoxCollider2D>();
		
		BoxCollider2D hitboxLow1Col = gObject.transform.Find("HitBoxLow1").GetComponent<BoxCollider2D>();
		BoxCollider2D hitboxLow2Col = gObject.transform.Find("HitBoxLow2").GetComponent<BoxCollider2D>();
		BoxCollider2D hitboxLow3Col = gObject.transform.Find("HitBoxLow3").GetComponent<BoxCollider2D>();
		
		BoxCollider2D hurtbox1Col = gObject.transform.Find("HurtBox1").GetComponent<BoxCollider2D>();
		BoxCollider2D hurtbox2Col = gObject.transform.Find("HurtBox2").GetComponent<BoxCollider2D>();
		BoxCollider2D hurtbox3Col = gObject.transform.Find("HurtBox3").GetComponent<BoxCollider2D>();
		
		DrawDefaultInspector ();
		
		EditorGUILayout.TextArea(
			
			
			
			"BoxPos physical = new BoxPos(" + physicalCol.size.x.ToString() + "f, " + physicalCol.size.y.ToString() + "f, " + physicalCol.offset.x.ToString()  + "f, " + physicalCol.offset.y.ToString() + "f);  \n" +
			"nBoxData.SetPhysicalBoxes(physical);\n\n" + 
			
			"BoxPos hitBoxHigh1 = new BoxPos(" + hitboxHigh1Col.size.x.ToString() + "f, " + hitboxHigh1Col.size.y.ToString() + "f, " + hitboxHigh1Col.offset.x.ToString()  + "f, " + hitboxHigh1Col.offset.y.ToString() + "f);  \n" +
			"BoxPos hitBoxHigh2 = new BoxPos(" + hitboxHigh2Col.size.x.ToString() + "f, " + hitboxHigh2Col.size.y.ToString() + "f, " + hitboxHigh2Col.offset.x.ToString()  + "f, " + hitboxHigh2Col.offset.y.ToString() + "f);  \n" +
			"BoxPos hitBoxHigh3 = new BoxPos(" + hitboxHigh3Col.size.x.ToString() + "f, " + hitboxHigh3Col.size.y.ToString() + "f, " + hitboxHigh3Col.offset.x.ToString()  + "f, " + hitboxHigh3Col.offset.y.ToString() + "f);  \n" +
			
			"BoxPos hitBoxLow1 = new BoxPos(" + hitboxLow1Col.size.x.ToString() + "f, " + hitboxLow1Col.size.y.ToString() + "f, " + hitboxLow1Col.offset.x.ToString()  + "f, " + hitboxLow1Col.offset.y.ToString() + "f);  \n" +
			"BoxPos hitBoxLow2 = new BoxPos(" + hitboxLow2Col.size.x.ToString() + "f, " + hitboxLow2Col.size.y.ToString() + "f, " + hitboxLow2Col.offset.x.ToString()  + "f, " + hitboxLow2Col.offset.y.ToString() + "f);  \n" +
			"BoxPos hitBoxLow3 = new BoxPos(" + hitboxLow3Col.size.x.ToString() + "f, " + hitboxLow3Col.size.y.ToString() + "f, " + hitboxLow3Col.offset.x.ToString()  + "f, " + hitboxLow3Col.offset.y.ToString() + "f);  \n" +
			"nBoxData.SetHitBoxes(hitBoxHigh1, hitBoxHigh2, hitBoxHigh3, hitBoxLow1, hitBoxLow2, hitBoxLow3);\n\n" + 
			
			"BoxPos hurtBox1 = new BoxPos(" + hurtbox1Col.size.x.ToString() + "f, " + hurtbox1Col.size.y.ToString() + "f, " + hurtbox1Col.offset.x.ToString()  + "f, " + hurtbox1Col.offset.y.ToString() + "f);  \n" +
			"BoxPos hurtBox2 = new BoxPos(" + hurtbox2Col.size.x.ToString() + "f, " + hurtbox2Col.size.y.ToString() + "f, " + hurtbox2Col.offset.x.ToString()  + "f, " + hurtbox2Col.offset.y.ToString() + "f);  \n" +
			"BoxPos hurtBox3 = new BoxPos(" + hurtbox3Col.size.x.ToString() + "f, " + hurtbox3Col.size.y.ToString() + "f, " + hurtbox3Col.offset.x.ToString()  + "f, " + hurtbox3Col.offset.y.ToString() + "f);  \n" +
			"nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);"
			
			
		);
	}
}
