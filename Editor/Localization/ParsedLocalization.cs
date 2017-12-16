using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ParsedLocalization  {


	[MenuItem("Tools/ParsedLocalization")]
	public static void CreateAsset ()
	{
		DataLocalization ();
	}

	static void DataLocalization(){
		ControllCreateAsset.CreateAsset<LocalizationSpace.Language> ("Assets/Lang/RU.json","LocalizationFiles", "langData", "RU");
		ControllCreateAsset.CreateAsset<LocalizationSpace.Language> ("Assets/Lang/EN.json","LocalizationFiles", "langData", "EN");
	}


}

