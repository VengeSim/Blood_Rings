using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public CharacterController2D fighter1;
	public CharacterController2D fighter2;
	
	void Start () {
		fighter1 = GameObject.Find("Fighter1").GetComponent<CharacterController2D>();
		fighter2 = GameObject.Find("Fighter2").GetComponent<CharacterController2D>();
		
		fighter2.Turn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		GUILayout.Label("");
		GUILayout.Label("Player 1 : Health : " + fighter1.Health.ToString());
		GUILayout.Label("Player 1 : Stun : " + fighter1.StunTicks.ToString());
		
		GUILayout.Label("Player 2 : Health : " + fighter2.Health.ToString());
		GUILayout.Label("Player 2 : Stun : " + fighter2.StunTicks.ToString());
		
	}
}
