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
		
		BoxCollider2D topCol = gObject.transform.parent.transform.Find("Flags/Top").GetComponent<BoxCollider2D>();
		BoxCollider2D bottomCol = gObject.transform.parent.transform.Find("Flags/Bottom").GetComponent<BoxCollider2D>();
		BoxCollider2D frontCol = gObject.transform.parent.transform.Find("Flags/Front").GetComponent<BoxCollider2D>();
		BoxCollider2D backCol = gObject.transform.parent.transform.Find("Flags/Back").GetComponent<BoxCollider2D>();
		
		BoxCollider2D hitboxHigh1Col = gObject.transform.Find("High/HitBoxHigh1").GetComponent<BoxCollider2D>();
		BoxCollider2D hitboxHigh2Col = gObject.transform.Find("High/HitBoxHigh2").GetComponent<BoxCollider2D>();
		BoxCollider2D hitboxHigh3Col = gObject.transform.Find("High/HitBoxHigh3").GetComponent<BoxCollider2D>();
		
		BoxCollider2D hitboxLow1Col = gObject.transform.Find("Low/HitBoxLow1").GetComponent<BoxCollider2D>();
		BoxCollider2D hitboxLow2Col = gObject.transform.Find("Low/HitBoxLow2").GetComponent<BoxCollider2D>();
		BoxCollider2D hitboxLow3Col = gObject.transform.Find("Low/HitBoxLow3").GetComponent<BoxCollider2D>();
		
		BoxCollider2D hurtbox1Col = gObject.transform.Find("HurtBox1").GetComponent<BoxCollider2D>();
		BoxCollider2D hurtbox2Col = gObject.transform.Find("HurtBox2").GetComponent<BoxCollider2D>();
		BoxCollider2D hurtbox3Col = gObject.transform.Find("HurtBox3").GetComponent<BoxCollider2D>();
		
		DrawDefaultInspector ();
		
		EditorGUILayout.TextArea(
			
			
			
			"BoxPos top = new BoxPos(" + topCol.size.x.ToString() + "f, " + topCol.size.y.ToString() + "f, " + topCol.center.x.ToString()  + "f, " + topCol.center.y.ToString() + "f);  \n" +
			"BoxPos bottom = new BoxPos(" + bottomCol.size.x.ToString() + "f, " + bottomCol.size.y.ToString() + "f, " + bottomCol.center.x.ToString()  + "f, " + bottomCol.center.y.ToString() + "f);  \n" +
			"BoxPos front = new BoxPos(" + frontCol.size.x.ToString() + "f, " + frontCol.size.y.ToString() + "f, " + frontCol.center.x.ToString()  + "f, " + frontCol.center.y.ToString() + "f);  \n" +
			"BoxPos back = new BoxPos(" + backCol.size.x.ToString() + "f, " + backCol.size.y.ToString() + "f, " + backCol.center.x.ToString()  + "f, " + backCol.center.y.ToString() + "f);  \n" +
			"nBoxData.SetFlagBoxes(top, bottom, front, back);\n\n" + 
			
			"BoxPos hitBoxHigh1 = new BoxPos(" + hitboxHigh1Col.size.x.ToString() + "f, " + hitboxHigh1Col.size.y.ToString() + "f, " + hitboxHigh1Col.center.x.ToString()  + "f, " + hitboxHigh1Col.center.y.ToString() + "f);  \n" +
			"BoxPos hitBoxHigh2 = new BoxPos(" + hitboxHigh2Col.size.x.ToString() + "f, " + hitboxHigh2Col.size.y.ToString() + "f, " + hitboxHigh2Col.center.x.ToString()  + "f, " + hitboxHigh2Col.center.y.ToString() + "f);  \n" +
			"BoxPos hitBoxHigh3 = new BoxPos(" + hitboxHigh3Col.size.x.ToString() + "f, " + hitboxHigh3Col.size.y.ToString() + "f, " + hitboxHigh3Col.center.x.ToString()  + "f, " + hitboxHigh3Col.center.y.ToString() + "f);  \n" +
			
			"BoxPos hitBoxLow1 = new BoxPos(" + hitboxLow1Col.size.x.ToString() + "f, " + hitboxLow1Col.size.y.ToString() + "f, " + hitboxLow1Col.center.x.ToString()  + "f, " + hitboxLow1Col.center.y.ToString() + "f);  \n" +
			"BoxPos hitBoxLow2 = new BoxPos(" + hitboxLow2Col.size.x.ToString() + "f, " + hitboxLow2Col.size.y.ToString() + "f, " + hitboxLow2Col.center.x.ToString()  + "f, " + hitboxLow2Col.center.y.ToString() + "f);  \n" +
			"BoxPos hitBoxLow3 = new BoxPos(" + hitboxLow3Col.size.x.ToString() + "f, " + hitboxLow3Col.size.y.ToString() + "f, " + hitboxLow3Col.center.x.ToString()  + "f, " + hitboxLow3Col.center.y.ToString() + "f);  \n" +
			"nBoxData.SetHitBoxes(hitBoxHigh1, hitBoxHigh2, hitBoxHigh3, hitBoxLow1, hitBoxLow2, hitBoxLow3);\n\n" + 
			
			"BoxPos hurtBox1 = new BoxPos(" + hurtbox1Col.size.x.ToString() + "f, " + hurtbox1Col.size.y.ToString() + "f, " + hurtbox1Col.center.x.ToString()  + "f, " + hurtbox1Col.center.y.ToString() + "f);  \n" +
			"BoxPos hurtBox2 = new BoxPos(" + hurtbox2Col.size.x.ToString() + "f, " + hurtbox2Col.size.y.ToString() + "f, " + hurtbox2Col.center.x.ToString()  + "f, " + hurtbox2Col.center.y.ToString() + "f);  \n" +
			"BoxPos hurtBox3 = new BoxPos(" + hurtbox3Col.size.x.ToString() + "f, " + hurtbox3Col.size.y.ToString() + "f, " + hurtbox3Col.center.x.ToString()  + "f, " + hurtbox3Col.center.y.ToString() + "f);  \n" +
			"nBoxData.SetHurtBoxes(hurtBox1, hurtBox2, hurtBox3);"
			
			
		);
	}
}
