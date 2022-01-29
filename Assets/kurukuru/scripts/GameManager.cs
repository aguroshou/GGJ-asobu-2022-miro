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

	State _CurrentState = State.GameStart;

	public bool IsPlaying { get { return _CurrentState == State.Playing; } }

	[SerializeField] Text _text;

	float _CountDown = 4.0f;

	void Start()
	{
		FindObjectOfType<PlayerController>().IsPlaying = false;
	}

	public void Clear()
	{
		_CurrentState = State.Clear;
		FindObjectOfType<PlayerController>().IsPlaying = false;
		_CountDown = 4.0f;

		SoundManager.I.PauseBGM();
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
				if (_CountDown < 0.0f)
				{
					FindObjectOfType<PlayerController>().IsPlaying = true;
					_CurrentState = State.Playing;
					_text.text = "";

					SoundManager.I.PlayBGM(SoundManager.BGM.Game, true);
				}
				break;
			case State.Playing:
				break;
			case State.Clear:
				_text.text = "Clear";
				_CountDown -= Time.deltaTime;
				if (_CountDown < 0.0f)
				{
					SceneManager.LoadScene("GameSelect");
				}
				break;
		}
	}
}
