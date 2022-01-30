using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : SingletonMonobehavior<SoundManager>
{
	//--------------------------
	// 定数
	//--------------------------
	public enum BGM
	{
		Game,
		StageSelect,
		Clear,
	}

	public enum SE
	{
		Button,
		Jump01,
		Jump02,
	}


	//--------------------------
	//--------------------------
	private List<AudioSourceEx> _audioList = new List<AudioSourceEx>();

	[SerializeField] private List<SoundAssetUserData> _bgmList = new List<SoundAssetUserData>();
	[SerializeField] private List<SoundAssetUserData> _seList = new List<SoundAssetUserData>();

	//--------------------------
	// Unity 関数
	//--------------------------
	private void Awake()
	{
		var components = FindObjectsOfType<SoundManager>();
		if (components.Length != 1)
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		_audioList = GetComponentsInChildren<AudioSourceEx>().ToList();
		for (var i = 0; i < _audioList.Count; i++)
			_audioList[i].Index = i;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	//--------------------------
	// public 関数
	//--------------------------
	public void Load()
	{
	}

	public void PlayBGM(BGM bgm, bool isLoop = false)
	{
		Debug.Log("Play BGM" + bgm.ToString());


		for (var i = 0; i < 4; i++)
		{
			StopBGM(i);
		}

		var asset = _bgmList[(int)bgm];
		PlayBGM(asset.Clip, isLoop, 0.5f, asset.VolumeRate);
	}

	public void PlaySE(SE se)
	{
		Debug.Log("Play SE" + se.ToString());
		var s = GetAudioSource(4);
		var asset = _seList[(int)se];
		s.PlaySE(asset.Clip, asset.VolumeRate);
	}

	public int PlayBGM(AudioClip clip, bool isLoop, float fade = 0.5f, float volume = 1.0f)
	{
		var audioSource = _audioList.FirstOrDefault(x => !x.IsPlaying);
		if (audioSource == null)
		{
			Debug.LogError("足りまへん");
			return -1;
		}

		var index = audioSource.PlayBgm(clip, isLoop, fade, volume);
		//Debug.LogWarning(index + ":" + Time.frameCount);
		return index;
	}

	public bool StopBGM(int index, float fade = 0.5f)
	{
		var audioSource = _audioList.FirstOrDefault(x => x.Index == index);
		if (audioSource == null)
			return false;
		if (audioSource.IsPlaying == false)
			return false;

		audioSource.Stop(fade);
		return true;
	}

	public AudioSourceEx GetAudioSource(int index)
	{
		var audioSource = _audioList.FirstOrDefault(x => x.Index == index);
		return audioSource;
	}

	private int _seVolume = 3;
	private int _bgmVolume = 3;
	private static int Max = 7;

	public void SetSEVolume(int val)
	{
		_seVolume = val;
		var s = GetAudioSource(4);
		s.SetVolume(val / (float)7);
	}

	public void SetBGMVolume(int val)
	{
		_bgmVolume = val;
		for (var i = 0; i < 4; i++)
		{
			var s = GetAudioSource(i);
			s.SetVolume(val / (float)7);
		}
	}

	public int GetSEVolume()
	{
		return _seVolume;
	}

	public int GetBGMVolume()
	{
		return _bgmVolume;
	}

	public void ResumeBGM()
	{
		var val = 7;
		for (var i = 0; i < 4; i++)
		{
			var s = GetAudioSource(i);
			s.SetVolume(val / (float)7);
		}
	}

	public void PauseBGM()
	{
		var val = 0.0f;
		for (var i = 0; i < 4; i++)
		{
			var s = GetAudioSource(i);
			s.SetVolume(val / (float)7);
		}
	}
}
