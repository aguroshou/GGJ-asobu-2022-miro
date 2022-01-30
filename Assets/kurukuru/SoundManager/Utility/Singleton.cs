public class Singleton<T> where T : new()
{
	private static T instance;

	public static T I
	{
		get
		{
			if (instance != null) return instance;

			instance = new T();
			return instance;
		}
	}

	public static void Clear()
	{
		instance = default(T);
	}
}