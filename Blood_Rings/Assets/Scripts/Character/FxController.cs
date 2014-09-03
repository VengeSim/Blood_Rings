using UnityEngine;
using System.Collections;

public class FxController : MonoBehaviour {

	protected CharacterController2D characterController;

	public GameObject bloodSplatter;
	
	void Awake () {
		this.characterController = this.GetComponent<CharacterController2D>();
		
	}
	
	void Update () {

			
	}
	
	public void OnHit(HitPacketWrapper wrapper){
		float boxSize = wrapper.Source.BoxCollider2D.size.x /2;
		bool isRight = this.characterController.IsOnRightSide(wrapper.Source.gameObject.transform.position);
		if(isRight){			
					boxSize = boxSize * -1;
		}
		Vector3 hitPoint = new Vector3(wrapper.Source.gameObject.transform.TransformPoint(wrapper.Source.BoxCollider2D.center).x, wrapper.Source.gameObject.transform.TransformPoint(wrapper.Source.BoxCollider2D.center).y, -2);
		GameObject prefab = Instantiate (bloodSplatter, hitPoint, Quaternion.identity) as GameObject;
		
		if(isRight){			
			prefab.transform.localScale = new Vector3( -prefab.transform.localScale.x, prefab.transform.localScale.y, prefab.transform.localScale.z );
		}
	}
}
