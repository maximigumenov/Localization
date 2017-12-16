using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public static class ControllCreateAsset
{
	
	public static void CreateAsset<T> (string pathJson, string pathSave, string fieldName, string nameAsset) where T : ScriptableObject
	{
		T asset = ScriptableObject.CreateInstance<T> ();
		string path = "Assets/" + pathSave;
		if (File.Exists (Application.dataPath + "/" + pathSave + "/" + nameAsset + ".asset")) {
			AssetDatabase.DeleteAsset (path + "/" + nameAsset + ".asset");
		}
		string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (path + "/" + nameAsset + ".asset");
		string json = File.ReadAllText(pathJson);
		FromJsonOverwriteArr (json, fieldName, asset);
		AssetDatabase.CreateAsset (asset, assetPathAndName);
		AssetDatabase.SaveAssets ();
		AssetDatabase.Refresh();
	}

	public static void FromJsonOverwriteArr(string json_array, string fieldName, object obj)
	{
		json_array = WrapArray(json_array, fieldName);
		JsonUtility.FromJsonOverwrite(json_array, obj);
	}

	private static string WrapArray(string json_array, string fieldName)
	{
		return "{\"" + fieldName + "\":" + json_array + "}";
	}
}