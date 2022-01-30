using UnityEngine;

public class BgmParam
{
	private readonly AudioSourceEx _audio;
	private readonly float _bpm;
	private bool _isPlay;

	public BgmParam(AudioSourceEx audio, float bpm)
	{
		_audio = audio;
		_bpm = bpm;
	}

	public int Index
	{
		get { return _audio.Index; }
	}

	private float Bps
	{
		get { return _bpm / 60.0f; }
	}

	public float BeatRate(float count)
	{
		var beatFloat = _audio.Time * Bps * count;
		var beatCount = Mathf.Floor(beatFloat);
		var mod = beatFloat - beatCount;
		var rate = mod;
		return rate;
	}
}