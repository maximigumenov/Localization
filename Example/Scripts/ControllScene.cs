using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllScene : MonoBehaviour 

	{
		public DataScene previousScene;
		public DataScene nextScene;
		public DataScene nowScene;

		[System.Serializable]
		public class DataScene{
			[SerializeField] string nameScene;

			public void SelectScene(){
				SceneManager.LoadScene (nameScene);
			}

			
		}
	}
