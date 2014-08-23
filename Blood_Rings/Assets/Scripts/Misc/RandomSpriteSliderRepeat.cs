using UnityEngine;
using System.Collections;

public class RandomSpriteSliderRepeat : MonoBehaviour {

	public float maxSpeed;
	public float minSpeed;
	public Sprite[] sprites;
	public JointLimitState2D limitDebug;
	
	protected SliderJoint2D sJoint;
	protected SpriteRenderer sRend;
	protected Sprite cSprite;
	protected JointMotor2D motorForward;
	protected JointMotor2D motorReverse;
	public bool startUp;
	
	void Start () {
		this.sJoint = this.GetComponent<SliderJoint2D>();
		this.sRend = this.GetComponent<SpriteRenderer>();
		
		this.cSprite = this.RandomSprite();
		this.sRend.sprite = cSprite;
		
		this.motorForward.maxMotorTorque = 100000f;
		this.motorReverse.maxMotorTorque = 100000f;
		this.motorReverse.motorSpeed = -500f;
		
		this.motorForward.motorSpeed = this.RandomSpeed();
		this.cSprite = this.RandomSprite();
		this.sRend.sprite = cSprite;
		this.sJoint.motor = motorForward;
		this.startUp = false;
	}
	
	void Update () {
	
		if(this.startUp && sJoint.limitState == JointLimitState2D.LowerLimit){
			this.motorForward.motorSpeed = this.RandomSpeed();
			this.cSprite = this.RandomSprite();
			this.sRend.sprite = cSprite;
			this.sJoint.useMotor = true;
			this.sJoint.motor = motorForward;
			
			foreach( Transform child in transform )
			{
				child.gameObject.SetActive(true);
			}
			
			this.startUp = false;
		}
	
		if(sJoint.limitState == JointLimitState2D.UpperLimit){
			this.sJoint.motor = motorReverse;
			this.sRend.sprite = null;
			
			foreach( Transform child in transform )
			{
				child.gameObject.SetActive(false);
			}
			this.startUp = true;
		}
	}
	
	public Sprite RandomSprite(){
		return sprites[UnityEngine.Random.Range(0, this.sprites.GetLength(0) - 1)];
	}
	
	public float RandomSpeed(){
		return UnityEngine.Random.Range(this.minSpeed, this.maxSpeed);
	}
}
