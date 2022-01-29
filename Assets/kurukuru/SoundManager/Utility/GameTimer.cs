using UnityEngine;

public class GameTimer
{

	//--------------------------
	// private 変数
	//--------------------------
	private float _time;

	private float _limit;

	//--------------------------
	// コンスト
	//--------------------------
	public GameTimer(float limitTime = 1.0f)
	{
		_limit = limitTime;
		_time = 0.0f;
	}

	//--------------------------
	// public property
	//--------------------------
	public bool IsTimeUp
	{
		get { return _time >= _limit; }
	}

	public float TimeRate
	{
		get { return _time / _limit; }
	}

	public float InverseTimeRate
	{
		get { return 1.0f - TimeRate; }
	}

	public float ElapsedTime
	{
		get { return _limit - _time; }
	}

	//--------------------------
	// public 関数
	//--------------------------
	public bool UpdateTimer(float timeScale = 1.0f)
	{
		_time += Time.deltaTime * timeScale;
		return IsTimeUp;
	}

	public void ResetTimer()
	{
		_time = 0.0f;
	}

	public void ResetTimer(float limit)
	{
		_limit = limit;
		_time = 0.0f;
	}

	public void ResetTimerForLoop()
	{
		_time -= _limit;
	}
}
