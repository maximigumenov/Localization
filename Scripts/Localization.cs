using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LocalizationSpace{
public static class Localization {
		private static List<LocalizationObject> listLocalizationObject = new List<LocalizationObject> ();
		private static LanguageDataObject languageObject;
		public static List<LocalizationSetting.SettingObject> localizationSetting = new List<LocalizationSetting.SettingObject>();

		static Localization(){
			LocalizationSetting.InitSetting ();
			InitLanguage (SetLanguage(LocalizationSetting.startId));
		}






		public class LanguageDataObject
		{
			private GameObject prefab;
			private LanguagePrefab languagePrefab;
			private LocalizationSetting.SettingObject settingObject;
			public LanguageDataObject(GameObject _prefab, LocalizationSetting.SettingObject _settingObject){
				prefab = _prefab;
				settingObject = _settingObject;
				languagePrefab = prefab.GetComponent<LanguagePrefab>();
				languagePrefab.InitLanguages();
			}

			public string GetText(string key){
				return languagePrefab.GetText (key);
			}

			public string GetNameLanguage(){
				return settingObject.GetName ();
			}

			public int GetIdLanguage(){
				return settingObject.GetID ();
			}

			public int GetTotalWord(){
				return languagePrefab.GetTotalWord ();
			}
		}

		public static int GetTotalWord(){
			return languageObject.GetTotalWord ();
		}

		public static void AddLocalizationSetting(LocalizationSetting.SettingObject _localizationSetting){
			localizationSetting.Add (_localizationSetting);
		}

		private static void InitLanguage(LocalizationSetting.SettingObject _settingObject){
			GameObject language = Resources.Load (_settingObject.GetPath()) as GameObject;
			languageObject = new LanguageDataObject (language, _settingObject);
		}

		public static void SelectLanguage(int _id){
			InitLanguage (SetLanguage (_id));
			UpdateLocalization ();
		}

		private static LocalizationSetting.SettingObject SetLanguage(int _id){
			for (int i = 0; i < localizationSetting.Count; i++) {
				if (localizationSetting[i].GetID() == _id) {
					return localizationSetting [i];
				}
			}
			return null;
		}

		public static void AddLocalizationObject(LocalizationObject _localizationObject){
			listLocalizationObject.Add (_localizationObject);
		}

		public static void RemoveLocalizationObject(LocalizationObject _localizationObject){
			listLocalizationObject.Remove (_localizationObject);
		}

		public static void UpdateLocalization(){
			for (int i = 0; i < listLocalizationObject.Count; i++) {
				listLocalizationObject [i].UpdateLocalization ();
			}

		}

		public static string GetText(string key){
			return languageObject.GetText (key);

		}

}

	public class LocalizationObject : MonoBehaviour {

		public virtual void UpdateLocalization(){
		}

		void OnDestroy(){
			Localization.RemoveLocalizationObject (GetComponent<LocalizationObject> ());
		}

	}

}
