using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataController : MonoBehaviour {

	[SerializeField] Text totalField;

	public void TotalWord(){
		if(totalField){
			totalField.text = LocalizationSpace.Localization.GetText ("main_leng") + 
				" " + LocalizationSpace.Localization.GetTotalWord ().ToString();
		} 
	}
}