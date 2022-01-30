using System;
using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace AronDev.Utility
{
	public static class SaveUtility
	{
		public static void Save<T>(T instance, string path, string fileName) where T : ScriptableObject
		{
#if UNITY_EDITOR
			var fullPath = path + "/" + fileName + ".asset";
			Debug.Log(fullPath);
			var uniquePath = AssetDatabase.GenerateUniqueAssetPath(fullPath);

			AssetDatabase.CreateAsset(instance, uniquePath);
			AssetDatabase.SaveAssets();
#endif
		}

		public static bool SaveText(string text, string path, string fileName, string extension = ".txt")
		{
#if UNITY_EDITOR
			try
			{
				using (var writer = new StreamWriter(path + fileName + extension, false))
				{
					writer.Write(text);
					writer.Flush();
					writer.Close();
					var str = "Succes save text." + path + fileName + extension + "\n" + text;
					Debug.Log(str);
				}
			}
			catch (Exception e)
			{
				var str = e.Message + "\n";
				str += path + fileName + extension + "\n";
				str += text;
				Debug.LogError(str);
				return false;
			}
#endif
			return true;
		}
	}
}