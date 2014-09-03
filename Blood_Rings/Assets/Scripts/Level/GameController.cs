using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public bool GLOBAL_DEBUG_LOGS;
	public bool GLOBAL_SHOW_BOXES;

	public CharacterController2D fighter1;
	public CharacterController2D fighter2;
	public Camera mainCamera;
	public float cameraDepth = -10;
		
	void Awake () {
		fighter1 = GameObject.Find("Fighter1").GetComponent<CharacterController2D>();
		fighter2 = GameObject.Find("Fighter2").GetComponent<CharacterController2D>();
		mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		
		fighter2.controller = 2;
		fighter2.Turn();
	}
	
	// Update is called once per frame
	void Update () {
		BloodRings.Global.SHOW_BOXES = GLOBAL_SHOW_BOXES;
		BloodRings.Debug.DEBUG_MODE = GLOBAL_DEBUG_LOGS;
	
		this.CameraControl();
	
	}
	
	void OnGUI(){
		GUILayout.Label("");
		GUILayout.Label("Player 1 : Health : " + fighter1.Health.ToString());
		GUILayout.Label("Player 1 : Stun : " + fighter1.StunTicks.ToString());
		
		GUILayout.Label("Player 2 : Health : " + fighter2.Health.ToString());
		GUILayout.Label("Player 2 : Stun : " + fighter2.StunTicks.ToString());
		
	}
	
	public void CameraControl(){
		
		this.mainCamera.gameObject.transform.position = new Vector3(fighter1.transform.position.x, fighter1.transform.position.y + 1, this.cameraDepth);
	
	}
}
