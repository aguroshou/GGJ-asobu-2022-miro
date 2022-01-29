using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
///     状態遷移
/// </summary>
/// <typeparam name="T"></typeparam>
public class StateMachine<T> where T : struct, IComparable
{
	//--------------------------
	// private class
	//--------------------------
	private class State
	{
		//--------------------------
		// private 変数
		//--------------------------
		private readonly Action<T> _enter;
		private readonly Action<T> _exit;
		private readonly T _state;
		private readonly Action _update;

		//--------------------------
		// コンストラクタ
		//--------------------------
		public State(T state, Action<T> enter, Action update, Action<T> exit)
		{
			_state = state;
			_enter = enter;
			_update = update;
			_exit = exit;
		}

		//--------------------------
		// public property
		//--------------------------
		public T StateValue
		{
			get { return _state; }
		}

		//--------------------------
		// public 関数
		//--------------------------
		public void Enter(T prev)
		{
			_enter(prev);
		}

		public void Update()
		{
			_update();
		}

		public void Exit(T next)
		{
			_exit(next);
		}
	}

	//--------------------------
	// private 変数
	//--------------------------
	private readonly Dictionary<T, State> _stateDict = new Dictionary<T, State>();

	private State _currentState;

	private MonoBehaviour _instance;
	private string _instanceName;

	//--------------------------
	// public property
	//--------------------------
	public T CurrentState
	{
		get { return _currentState.StateValue; }
	}

	//--------------------------
	// public 関数
	//--------------------------
	public void Setup<TU>(TU instance, T first) where TU : MonoBehaviour
	{
		var flags = BindingFlags.NonPublic | BindingFlags.Instance;
		var methods = typeof(TU).GetMethods(flags);
		var len = methods.Length;
		for (var i = 0; i < len; i++)
		{
			var m = methods[i];
			var a = m.GetCustomAttributes(typeof(SetupStateAttribute), false);
			if (a.Length != 0) m.Invoke(instance, null);
		}

		_currentState = _stateDict[first];
		_currentState.Enter(first);

		_instance = instance;
		_instanceName = typeof(TU).ToString();

		LogSetup(first);
	}

	public void Add(T t, Action<T> enter, Action update, Action<T> exit)
	{
		var state = new State(t, enter, update, exit);
		_stateDict.Add(t, state);
	}

	public void UpdateState()
	{
		_currentState.Update();
	}

	public void Change(T next)
	{
		_currentState.Exit(next);
		var prev = _currentState.StateValue;
		_currentState = _stateDict[next];

		LogChange(prev, next);

		_currentState.Enter(prev);
	}


	void LogSetup(T first)
	{
		var frame = $"[F{Time.frameCount.ToString()}]";
		var title = "[StateMachine]";
		var func = "[Setup]";
		var instanceName = $"[{_instanceName}]";
		var state = $"[_ -> {first.ToString()}]";
		var log = $"{frame}{title}{func}{instanceName}{state}";
		Debug.Log(log, _instance);
	}

	void LogChange(T prev, T next)
	{
		var frame = $"[F{Time.frameCount.ToString()}]";
		var title = "[StateMachine]";
		var func = "[Change]";
		var instanceName = $"[{_instanceName}]";
		var state = $"[{prev.ToString()} -> {next.ToString()}]";
		var log = $"{frame}{title}{func}{instanceName}{state}";
		Debug.Log(log, _instance);
	}
}