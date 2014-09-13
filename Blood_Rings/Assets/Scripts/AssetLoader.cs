using UnityEngine;
using System.Collections;

public class AssetLoader : MonoBehaviour {


	public GUISkin GUI_SKIN;
	public Sprite[] SPRITES_INPUT_ICONS;
	public Sprite[] SPRITES_FIGHTER_1;
	
	public Texture ICON_UP;
	public Texture ICON_DOWN;
	public Texture ICON_LEFT;
	public Texture ICON_RIGHT;
	public Texture ICON_UPLEFT;
	public Texture ICON_UPRIGHT;
	public Texture ICON_DOWNLEFT;
	public Texture ICON_DOWNRIGHT;
	public Texture ICON_1;
	public Texture ICON_2;
	public Texture ICON_3;
	public Texture ICON_4;
	public Texture ICON_BLOCK;
	public Texture ICON_TURN;
	
	void Awake(){
		BloodRingsAssets.SPRITES_INPUT_ICONS = this.SPRITES_INPUT_ICONS;
		BloodRingsAssets.SPRITES_FIGHTER_1 = this.SPRITES_FIGHTER_1;
		
		BloodRingsAssets.ICON_UP = this.ICON_UP;
		BloodRingsAssets.ICON_DOWN = this.ICON_DOWN;
		BloodRingsAssets.ICON_LEFT = this.ICON_LEFT;
		BloodRingsAssets.ICON_RIGHT = this.ICON_RIGHT;
		BloodRingsAssets.ICON_UPLEFT = this.ICON_UPLEFT;
		BloodRingsAssets.ICON_UPRIGHT = this.ICON_UPRIGHT;
		BloodRingsAssets.ICON_DOWNLEFT = this.ICON_DOWNLEFT;
		BloodRingsAssets.ICON_DOWNRIGHT = this.ICON_DOWNRIGHT;
		BloodRingsAssets.ICON_1 = this.ICON_1;
		BloodRingsAssets.ICON_2 = this.ICON_2;
		BloodRingsAssets.ICON_3 = this.ICON_3;
		BloodRingsAssets.ICON_4 = this.ICON_4;
		BloodRingsAssets.ICON_BLOCK = this.ICON_BLOCK;
		BloodRingsAssets.ICON_TURN = this.ICON_TURN;

		
		
		
	}
	
	
}
