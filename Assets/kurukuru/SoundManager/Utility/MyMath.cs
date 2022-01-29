
public static class MyMath
{
	public static float Wrap(float val, float min, float max)
	{
		if (val < min)
		{
			var sub = max - min;
			while (val >= min)
				val += sub;
			return val;
		}

		if (val > max)
		{
			var sub = max - min;
			while (val <= max)
				val -= sub;
			return val;
		}

		return val;
	}

	public static float Range(float val, float min, float max)
	{
		if (val < min)
			return min;

		if (val > max)
			return max;

		return val;
	}
}