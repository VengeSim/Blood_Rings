using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {
	
	public int lifeInFrames;
	protected int fCount;
	void Start () {
		this.fCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(this.fCount >= this.lifeInFrames){
			Destroy(this.gameObject);
		}	
		fCount++;
	}
}
