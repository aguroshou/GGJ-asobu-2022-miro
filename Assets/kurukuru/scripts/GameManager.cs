using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	enum State
	{
		GameStart,
		Playing,
		Clear,
	}
	static bool _IsRetry = false;

	State _CurrentState = State.GameStart;

	public bool IsPlaying { get { return _CurrentState == State.Playing; } }

	[SerializeField] Text _text;

	float _CountDown = 4.0f;

	void Start()
	{
		FindObjectOfType<PlayerController>().IsPlaying = false;
		SoundManager.I.PauseBGM();
	}

	public void Clear()
	{
		_CurrentState = State.Clear;
		FindObjectOfType<PlayerController>().IsPlaying = false;
		_CountDown = 4.0f;

		SoundManager.I.ResumeBGM();
		SoundManager.I.PlayBGM(SoundManager.BGM.Clear);
	}

	void Update()
	{
		switch (_CurrentState)
		{
			case State.GameStart:
				_CountDown -= Time.deltaTime;
				var c = Mathf.RoundToInt(_CountDown);
				if (c > 3)
				{
					_text.text = "";
				}
				else if (c == 0)
				{
					_text.text = "Start";
				}
				else
				{
					_text.text = c.ToString();
				}
				if (_CountDown < 0.0f || _IsRetry)
				{
					FindObjectOfType<PlayerController>().IsPlaying = true;
					_CurrentState = State.Playing;
					_text.text = "";
					_IsRetry = false;
					SoundManager.I.PlayBGM(SoundManager.BGM.Game, true);
					SoundManager.I.ResumeBGM();
				}
				break;
			case State.Playing:
				if (Input.GetKeyDown(KeyCode.R))
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
					_IsRetry = true;
				}
				if (Input.GetKeyDown(KeyCode.Escape))
				{
					SceneManager.LoadScene("Title");
					_IsRetry = false;
				}
				break;
			case State.Clear:
				_text.text = "Clear";
				_CountDown -= Time.deltaTime;
				if (_CountDown < 0.0f)
				{
					_IsRetry = false;
					SceneManager.LoadScene("GameSelect");
				}
				break;
		}
	}
}
