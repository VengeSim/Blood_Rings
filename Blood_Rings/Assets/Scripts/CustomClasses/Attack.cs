using UnityEngine;
using System.Collections;

public class Attack{

	protected Sprite sprite;
	protected BoxData bData;
	protected int[] frames;
	
	public Attack(Sprite sprite, BoxData bData, int[] frames){
		this.sprite = sprite;
		this.bData = bData;
		this.frames = frames;
	}
	
	
	public Sprite Sprite {get {return sprite;}}
	public BoxData BoxData {get {return bData;}}
	public int[] Frames {get {return frames;}}
	public int Startup {get {return frames[0];}}
	public int Active {get {return frames[1];}}
	public int Recovery {get {return frames[2];}}
	
	
	
}
