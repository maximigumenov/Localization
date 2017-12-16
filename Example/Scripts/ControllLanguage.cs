using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllLanguage : MonoBehaviour 
	{
		[SerializeField] List<DataLanguage> languages;
		int numLang = 0;
		public DataButton previousLang;
		public DataButton nextLang;
		public DataButton nowLang;


		public delegate void MethodContainer();
		public event MethodContainer onCount;


		[System.Serializable]
		public class DataLanguage{
			[SerializeField] string keyLang;
			[SerializeField] int idLang;


			public int GetId(){
				return idLang;
			}

			public string GetKey(){
				return keyLang;
			}
		}

		[System.Serializable]
		public class DataButton{
			DataLanguage dataLanguage;

			[SerializeField] Text textButton;

			public void SelectLang(){
				LocalizationSpace.Localization.SelectLanguage (dataLanguage.GetId());
			}

			public void SetDataLanguage(DataLanguage _dataLanguage){
				dataLanguage = _dataLanguage;
			}

			public void SetKey(){
				textButton.text = LocalizationSpace.Localization.GetText (dataLanguage.GetKey());
			}
		}


		public void UpdateLanguages(){
			nowLang.SetDataLanguage (languages [0]);
			nextLang.SetDataLanguage (languages [1]);
			previousLang.SetDataLanguage (languages [1]);

		}

		public void MoveForward(){
			DataLanguage t_language = languages [languages.Count - 1];
			languages.Remove (t_language);
			languages.Insert (0, t_language);
			UpdateLanguages ();
		}

		public void MoveBack(){
			DataLanguage t_language = languages [0];
			languages.Remove (t_language);
			languages.Add (t_language);
			UpdateLanguages ();
		}

	}