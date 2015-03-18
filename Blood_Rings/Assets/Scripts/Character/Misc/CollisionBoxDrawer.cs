using UnityEngine;
using System.Collections;

public class CollisionBoxDrawer : MonoBehaviour {

	public Material mat;
	
	protected BoxCollider2D bCol;
	protected LineRenderer lineRenderer;
	void Start() {
		
		this.bCol = this.GetComponent<BoxCollider2D>();
		
		this.lineRenderer = gameObject.AddComponent<LineRenderer>();
		this.lineRenderer.useWorldSpace = false;
		
		this.lineRenderer.material = this.mat;
		
		this.lineRenderer.SetWidth(0.05F, 0.05F);
		this.lineRenderer.SetVertexCount(5);
		
		
	}
	
	void Update () {
	
		if(BloodRings.Global.SHOW_BOXES){
		
			float sizeX = bCol.size.x;
			float sizeY = bCol.size.y;
			float centerX = bCol.offset.x;
			float centerY = bCol.offset.y;
			
			if(sizeX > 0.0001f){
				if(!this.lineRenderer.enabled){
					this.lineRenderer.enabled = true;
				}
				this.lineRenderer.SetPosition(0, new Vector2(centerX - sizeX/2, centerY + sizeY/2));
				this.lineRenderer.SetPosition(1, new Vector2(centerX + sizeX/2, centerY + sizeY/2));
				this.lineRenderer.SetPosition(2, new Vector2(centerX + sizeX/2, centerY - sizeY/2));
				this.lineRenderer.SetPosition(3, new Vector2(centerX - sizeX/2, centerY - sizeY/2));
				this.lineRenderer.SetPosition(4, new Vector2(centerX - sizeX/2, centerY + sizeY/2));
			}else{
				this.lineRenderer.enabled = false;
			}
		}else{
			this.lineRenderer.enabled = false;
		}
	}
}
