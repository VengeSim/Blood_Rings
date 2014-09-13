/*
	Blood Ring
	Copyright © 2014 jgumbo@live.com
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;

using BloodRings;
using BloodRings.Input;
using Debug = BloodRings.Debug;
using Input = BloodRings.Input.InputButton;

namespace BloodRings{
	
	namespace Input{
	
				public class InputList
				{
		
						protected List<InputCopy[]> list;
						protected int maxSize;
			
						public List<InputCopy[]> List {
								get {
										return new List<InputCopy[]> (this.list);				
								}
				
						}
						public List<InputCopy[]> ListReversed {
								get {
										List<InputCopy[]> nList = new List<InputCopy[]> (this.list);
										nList.Reverse ();
										return nList;		
								}
				
						}
			
						public InputList ()
						{
								this.maxSize = 10;
								this.list = new List<InputCopy[]> (this.maxSize);
				
						}
			
						public void Add (InputCopy[] inputArray)
						{
								if (this.list.Count < this.maxSize) {
										this.list.Add (inputArray);
								} else {
										this.list.RemoveAt (0);
										this.list.Add (inputArray);
								}
						}
		
						public void Add (InputCopy input)
						{
								if (this.list.Count < this.maxSize) {
										this.list.Add (new InputCopy[]{input});
								} else {
										this.list.RemoveAt (0);
										this.list.Add (new InputCopy[]{input});
					
								}
						}
				}
		}

}
