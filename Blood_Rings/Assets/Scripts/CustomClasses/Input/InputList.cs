/*
	Blood Ring
	Copyright © 2014 jgumbo@live.com
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

using BloodRings;
using Debug = BloodRings.Debug;
using Input = BloodRings.Input;

namespace BloodRings{
	
	public class InputList{
	
		protected List<InputClone[]> list;
		protected int maxSize;
		
		public List<InputClone[]> List{
			get{
				return new List<InputClone[]>(this.list);				
			}
			
		}
		public List<InputClone[]> ListReversed{
			get{
				List<InputClone[]> nList = new List<InputClone[]>(this.list);
				nList.Reverse();
				return nList;		
			}
			
		}
		
		public InputList(){
			this.maxSize = 10;
			this.list = new List<InputClone[]>(this.maxSize);
			
		}
		
		public void Add(InputClone[] inputArray){
			if(this.list.Count < this.maxSize){
				this.list.Add(inputArray);
			}else{
				this.list.RemoveAt(0);
				this.list.Add(inputArray);
			}
		}

		public void Add(InputClone input){
			if(this.list.Count < this.maxSize){
				this.list.Add(new InputClone[]{input});
			}else{
				this.list.RemoveAt(0);
				this.list.Add(new InputClone[]{input});
				
			}
		}
	}

}
