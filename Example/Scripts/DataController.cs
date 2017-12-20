using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LocalizationSpace;

public class DataController : MonoBehaviour {

	[SerializeField] Text totalField;

	public void TotalWord(){
		if(totalField){
			totalField.text = Localization.GetText ("main_leng") + 
				" " + Localization.GetTotalWord ().ToString();
		} 
	}
}