using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(BoxCollider2D))]
public class BoxColliderReadOut : Editor 
{
	public override void OnInspectorGUI()
	{
		BoxCollider2D myTarget = (BoxCollider2D)target;
		BoxCollider2D col = myTarget.GetComponent<BoxCollider2D>();
		
		
		DrawDefaultInspector ();
		
		EditorGUILayout.TextField(
			"BoxData",
			"new BoxPos(" + 
			col.size.x.ToString() + "f, " + 
			col.size.y.ToString() + "f, " +
			col.center.x.ToString()  + "f, " +
			col.center.y.ToString() + "f);"
		);
	}
}
