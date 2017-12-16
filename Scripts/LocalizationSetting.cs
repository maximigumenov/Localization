using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LocalizationSpace{
	public static class LocalizationSetting {
		public static int startId = 0;


		public static void InitSetting(){
			new SettingObject (0, "EN", "Languages/EN");
			new SettingObject (1, "RU", "Languages/RU");
		}






		public class SettingObject{
			private int id;
			private string nameLanguage;
			private string pathToPrefab;

			public SettingObject(int _id, string _nameLanguage, string _pathToPrefab){
				id = _id;
				nameLanguage = _nameLanguage;
				pathToPrefab = _pathToPrefab;
				Localization.AddLocalizationSetting(this);
			}

			public int GetID(){
				return id;
			}

			public string GetPath(){
				return pathToPrefab;
			}

			public string GetName(){
				return nameLanguage;
			}
		}
	}
}
