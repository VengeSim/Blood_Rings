using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;

using BloodRings;
using Debug = BloodRings.Debug;
using Input = BloodRings.Input;


namespace BloodRings{
//***************************************************************************************************************************
	public enum BH_STATUS{
		BH_READY,
		BH_SUCCESS,
		BH_FAILURE, 
		BH_RUNNING
	};
//***************************************************************************************************************************
	public class Behaviour{
	
		public BH_STATUS status;
		public CharacterController2D cController;
		public string debug;
		
		public Behaviour(){
			this.status = BH_STATUS.BH_READY;
			this.debug = "";
			
		}
		public Behaviour(CharacterController2D cController): this(){
			this.cController = cController;
		}
		public Behaviour(CharacterController2D cController, string debug): this(cController){
			this.debug = debug;
		}
		public BH_STATUS Tick()
		{	
			
			if (this.status != BH_STATUS.BH_RUNNING){
				this.OnInitialize();
			}
			this.Log();
			BH_STATUS status = this.Update();
			this.Log(status);

			if (status != BH_STATUS.BH_RUNNING){
				this.OnTerminate(status);
			}
			return this.status;
		}
		protected virtual BH_STATUS Update(){return BH_STATUS.BH_SUCCESS;}
		protected virtual void OnInitialize(){this.status = BH_STATUS.BH_RUNNING;}
		protected virtual void OnTerminate(BH_STATUS status){this.status = status;}
		
		protected void Log(){
			if(String.IsNullOrEmpty(this.debug)){
				Debug.Log(this.ToString() + "_PreUpdate");
			}else{
				Debug.Log(this.debug + "_PreUpdate");
			}
		}
		protected void Log(BH_STATUS status){
			if(String.IsNullOrEmpty(this.debug)){
				Debug.Log(this.ToString() + "_" + status.ToString());
			}else{
				Debug.Log(this.debug + "_" + status.ToString());	
			}
		}
	}
	//***************************************************************************************************************************
	public class Composite : Behaviour{
		
		protected List<Behaviour> children;
		public Composite(): base(){}
		public Composite(CharacterController2D cController): base(cController){
			this.children = new List<Behaviour>();
		}
		public Composite(CharacterController2D cController, string debug): this(cController){
			this.debug = debug;
		}
		public virtual void AddChild(Behaviour nChild){
			this.children.Add(nChild);
			nChild.cController = this.cController;
		}
	}
	//***************************************************************************************************************************
	public class Sequence : Composite{
		
		public Sequence():base(){}
		public Sequence(CharacterController2D cController):base(cController){}
		public Sequence(CharacterController2D cController, string debug):base(cController, debug){}
		protected override BH_STATUS Update (){
		
			for (int i = 0; i < this.children.Count; i++) {
				BH_STATUS cStatus = this.children[i].Tick();
				if (cStatus != BH_STATUS.BH_SUCCESS){return cStatus;}
				
			}
			return BH_STATUS.BH_SUCCESS;
				
		} 
		public override void AddChild(Behaviour nChild){
			base.AddChild(nChild);
		}
	}
	//***************************************************************************************************************************
	public class Selector : Composite{
	
		public Selector():base(){}
		public Selector(CharacterController2D cController):base(cController){}
		public Selector(CharacterController2D cController, string debug):base(cController, debug){}
		protected override BH_STATUS Update(){
			for (int i = 0; i < this.children.Count; i++) {
				Behaviour cChild = this.children[i];
				BH_STATUS cStatus = cChild.Tick();
				if (cStatus != BH_STATUS.BH_FAILURE){
					return cChild.status;
				}
			}
			return BH_STATUS.BH_FAILURE;	
		}
		public override void AddChild(Behaviour nChild){
			base.AddChild(nChild);
		}
	}
	//***************************************************************************************************************************
	public class Condition : Behaviour{
		protected bool b;
		public Condition(){}
		public Condition(bool b){this.b = b;}
		protected override BH_STATUS Update (){
			if (this.b){
				return BH_STATUS.BH_SUCCESS;
			}else{
				return BH_STATUS.BH_FAILURE;
			}
			
		}
	}

	//***************************************************************************************************************************
	public class Action : Behaviour{
		public Action(){}
		protected override BH_STATUS Update (){
			return BH_STATUS.BH_SUCCESS;
		}
	}
}











