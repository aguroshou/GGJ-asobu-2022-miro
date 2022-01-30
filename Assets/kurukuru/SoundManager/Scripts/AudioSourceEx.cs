using System;
using UnityEngine;

public class AudioSourceEx : MonoBehaviour
{
	//--------------------------
	// 定数
	//--------------------------
	private enum State
	{
		None,
		FadeIn,
		Play,
		FadeOut
	}

	//--------------------------
	// private 関数
	//--------------------------
	private readonly StateMachine<State> _stateMachine = new StateMachine<State>();

	private AudioSource _audioSource;

	GameTimer _timer = new GameTimer();

	float _targetVolume = 0.0f;

	float _currentVolume = 0.0f;

	private float _settingVolume = 1.0f;
	//--------------------------
	// public property
	//--------------------------
	public bool IsPlaying
	{
		get { return _audioSource.isPlaying; }
	}

	public float Time
	{
		get { return _audioSource.time; }
	}

	public int Index { get; set; }

	//--------------------------
	// Unity関数
	//--------------------------
	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
		_stateMachine.Setup(this, State.None);
	}

	private void Update()
	{
		_stateMachine.UpdateState();
	}

	//--------------------------
	// public 関数
	//--------------------------
	public int PlayBgm(AudioClip clip, bool isLoop, float fade, float volume)
	{
		_audioSource.clip = clip;
		_audioSource.loop = isLoop;
		_timer.ResetTimer(fade);
		_targetVolume = volume;
		_stateMachine.Change(State.FadeIn);
		return Index;
	}

	public void Stop()
	{
		_stateMachine.Change(State.None);
	}

	public void Stop(float fade)
	{
		if (_stateMachine.CurrentState == State.None)
			return;
		if (_stateMachine.CurrentState == State.FadeOut)
			return;

		_timer.ResetTimer(fade);
		_stateMachine.Change(State.FadeOut);
	}

	public void Log()
	{
		if (_audioSource.isPlaying == false)
			return;
		var str = string.Format("sound : {0} : {1}", _audioSource.clip.name, Time);
		Debug.Log(str);
	}

	public void PlaySE(AudioClip clip, float volumeRate)
	{
		_currentVolume = volumeRate * _settingVolume;
		_audioSource.volume = _currentVolume;
		_audioSource.PlayOneShot(clip, 1.0f);
	}

	//--------------------------
	// private 関数
	//--------------------------
	[SetupState]
	private void SetupStateNone()
	{
		var state = State.None;
		Action<State> enter = prev =>
		{
			_audioSource.Stop();
			_audioSource.clip = null;
		};
		Action update = () => { };
		Action<State> exit = next => { };
		_stateMachine.Add(state, enter, update, exit);
	}

	[SetupState]
	private void SetupStateFadeIn()
	{
		const State state = State.FadeIn;
		Action<State> enter = (prev) =>
		{
			_audioSource.volume = 0.0f;
			_audioSource.Play();
		};
		Action update = () =>
		{
			_timer.UpdateTimer();
			_currentVolume = _timer.TimeRate * _targetVolume * _settingVolume;
			_audioSource.volume = _currentVolume;

			if (_timer.IsTimeUp)
			{
				_stateMachine.Change(State.Play);
			}
		};
		Action<State> exit = (next) => { };
		_stateMachine.Add(state, enter, update, exit);
	}

	[SetupState]
	private void SetupStatePlay()
	{
		const State state = State.Play;
		Action<State> enter = (prev) =>
		{
			_currentVolume = _targetVolume * _settingVolume;
			_audioSource.volume = _targetVolume * _settingVolume;
		};
		Action update = () => { };
		Action<State> exit = (next) => { };
		_stateMachine.Add(state, enter, update, exit);
	}

	[SetupState]
	private void SetupStateFadeOut()
	{
		const State state = State.FadeOut;
		Action<State> enter = (prev) =>
		{

		};
		Action update = () =>
		{
			_timer.UpdateTimer();
			_audioSource.volume = _timer.InverseTimeRate * _currentVolume;

			if (_timer.IsTimeUp)
			{
				_stateMachine.Change(State.None);
			}
		};
		Action<State> exit = (next) => { };
		_stateMachine.Add(state, enter, update, exit);
	}

	public void SetVolume(float f)
	{
		_settingVolume = f;
		_currentVolume = _targetVolume * _settingVolume;
		_audioSource.volume = _currentVolume;
	}
}