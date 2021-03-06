﻿/*
	Blood Ring
	Copyright © 2014 jgumbo@live.com
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using BloodRings;


namespace BloodRings{
	
	public static class Global{
		public static bool SHOW_BOXES = false;
		
	}
	
	public static class Debug{
		

		
		public static bool DEBUG_MODE = true;
		
		public static string debugFilePath = Application.dataPath + "/Resources/Output/Log.txt";
		
		#region Constructor
		static Debug(){
		

			Debug.LogClear(debugFilePath);
			Debug.FileHeader(debugFilePath);

		}
		#endregion
		
		#region General Log Methods
		public static void FileHeader(string path){
				using (StreamWriter writer = new StreamWriter(path, true)){
					string date = DateTime.Now.ToString("dd/MM/yyyy");
					writer.WriteLine("[" + date + "] ##Clans Debug Log## ");
					
				}
		}
		public static void LogClear(string path){
			using (StreamWriter writer = new StreamWriter(path, false)){}
		}
		#endregion
		
		#region Log Methods
		public static void Log(string msg){
			if(Debug.DEBUG_MODE){
				using (StreamWriter writer = new StreamWriter(debugFilePath, true)){
	
					string time = DateTime.Now.ToString("HH:mm:ss:ff");
					writer.WriteLine("[" + time + "] " + msg);
	
				}
			}
		}
		#endregion
		
	}
	
	public static class Methods{
	
		#region ArrayToString Methods
		public static string ArrayToString(int[] array){
			string str = "[";			
			for (int i = 0; i < array.GetLength(0); i++) {
				str = str + array[i].ToString();
				if(i < array.GetLength(0) - 1){
					str = str + ",";
				}
			}
			str = str + "]";
			return str;
		}
	
		public static string ArrayToString(bool[] array){
			string str = "[";			
			for (int i = 0; i < array.GetLength(0); i++) {
				int b = array[i] ? 1 : 0;
				str = str + b.ToString();
			}
			str = str + "]";
			return str;
		}
		#endregion
		
	}
	
}