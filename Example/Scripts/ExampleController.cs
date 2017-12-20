using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LocalizationSpace;

public class ExampleController : MonoBehaviour {
	[SerializeField] ControllScene controllScene;
	[SerializeField] ControllLanguage controllLanguage;
	[SerializeField] DataController dataController;



	void Awake(){
		controllLanguage.InitLanguages ();
	}

	void Start(){
		Localization.onTranslate += UpdateData;
		controllLanguage.UpdateLanguages ();
		OutputLang ();
		dataController.TotalWord ();
	}

	void OnDestroy(){
		Localization.onTranslate -= UpdateData;
	}

	void UpdateData(){
		dataController.TotalWord ();
		OutputLang ();
	}

	#region ControllScenes

	public void NextScene(){
		controllScene.nextScene.SelectScene ();
	}

	public void PreviousScene(){
		controllScene.previousScene.SelectScene ();
	}

	#endregion

	#region ControllLanguage

	public void NextLang(){
		controllLanguage.MoveForward ();
		controllLanguage.nextLang.SelectLang ();
	}

	public void PreviousLang(){
		controllLanguage.MoveBack ();
		controllLanguage.previousLang.SelectLang ();
	}

	public void OutputLang(){
		controllLanguage.previousLang.SetKey ();
		controllLanguage.nextLang.SetKey ();
		controllLanguage.nowLang.SetKey ();
	}

	#endregion


}
