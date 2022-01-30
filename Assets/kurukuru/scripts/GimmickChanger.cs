using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickChanger : MonoBehaviour
{
	[SerializeField] GimmickID FirstID = GimmickID.Ame;

	Dictionary<GimmickID, GimmickBase> _GimmickDict = new Dictionary<GimmickID, GimmickBase>();
	GimmickBase _Current = null;

	public GimmickID CurrentID { get { return _Current.ID; } }

	private void Awake()
	{
		var manager = FindObjectOfType<GimmickManager>();
		manager.Register(this);

		var components = GetComponents<GimmickBase>();
		foreach (var c in components)
		{
			_GimmickDict.Add(c.ID, c);
			c.enabled = false;
		}

		_Current = _GimmickDict[FirstID];
		_Current.Enter(GimmickID.None);
	}

	private void OnDestroy()
	{
		var manager = FindObjectOfType<GimmickManager>();
		if (manager != null)
		{
			manager.Unregister(this);
		}
	}

	public void Change(GimmickID next)
	{
		_Current.Exit(next);
		var gimmick = _GimmickDict[next];
		gimmick.Enter(_Current.ID);
		_Current = gimmick;
	}
}
