using UnityEngine;
using System.Collections;
using BloodRings;

public class GameController : MonoBehaviour {

	public bool GLOBAL_DEBUG_LOGS;
	public bool GLOBAL_SHOW_BOXES;

	public CharacterController2D fighter1;
	public CharacterController2D fighter2;
	public Camera mainCamera;
	public float cameraDepth = -10;
	public bool sequence;
	
	protected TickController tController;
	protected AssetLoader assetLoader;
	
	public TickController TickController{
		get{
			return this.tController;
		}
	}
	public AssetLoader AssetLoader{
		get{
			return this.assetLoader;
		}
	}
	void Awake () {
		this.tController = this.GetComponent<TickController>();
		this.assetLoader = this.GetComponent<AssetLoader>();
		
		fighter1 = GameObject.Find("Fighter1").GetComponent<CharacterController2D>();
		fighter2 = GameObject.Find("Fighter2").GetComponent<CharacterController2D>();
		mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		
		fighter2.playerNo = 2;
		fighter2.Turn();
	}
	
	// Update is called once per frame
	void Update () {
		BloodRings.Global.SHOW_BOXES = GLOBAL_SHOW_BOXES;
		BloodRings.Debug.DEBUG_MODE = GLOBAL_DEBUG_LOGS;
	
		this.CameraControl();
	
		sequence = fighter1.InputMon.CheckSequenceDirectional(new string[]{"Down", "DownRight", "Right"});
		
		if(sequence){
			UnityEngine.Debug.Log("True" + "_" + this.TickController.tick);
			
		}
	}
	
	void OnGUI(){
	
		GUI.skin = AssetLoader.GUI_SKIN;
	
		//GUILayout.Label(this.tick.ToString());
		GUILayout.BeginHorizontal("box");
		GUILayout.BeginHorizontal("box");
		GUILayout.Label("Player 1 :");
		GUILayout.Label("Health :" + fighter1.Health.ToString());
		GUILayout.Label(": Stun : " + fighter1.StunTicks.ToString());
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal("box");
		GUILayout.Label("Player 2 :");
		GUILayout.Label("Health :" + fighter2.Health.ToString());
		GUILayout.Label(": Stun : " + fighter2.StunTicks.ToString());
		GUILayout.EndHorizontal();
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal("box");
		InputMon.DrawListDebug(fighter1.InputMon.DirectionList);
		InputMon.DrawListDebug(fighter1.InputMon.ButtonList);
		GUILayout.EndHorizontal();
		
	}
	
	public void CameraControl(){
		
		this.mainCamera.gameObject.transform.position = new Vector3(fighter1.transform.position.x, fighter1.transform.position.y + 1, this.cameraDepth);
	
	}
}
