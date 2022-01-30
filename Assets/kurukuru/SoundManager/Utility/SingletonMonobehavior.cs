using UnityEngine;

public class SingletonMonobehavior<T> : MonoBehaviour where T : SingletonMonobehavior<T>
{
	//--------------------------
	// private static 変数
	//--------------------------
	private static T _instance;

	//--------------------------
	// public static property
	//--------------------------
	public static T I
	{
		get
		{
			if (_instance != null)
				return _instance;

			var obj = FindObjectOfType<T>();
			_instance = obj;
			return _instance;
		}
	}
}