using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
	List<GimmickChanger> _GimmickList = new List<GimmickChanger>();

	public void Register(GimmickChanger gimmick)
	{
		_GimmickList.Add(gimmick);
	}

	public void Unregister(GimmickChanger gimmick)
	{
		_GimmickList.Remove(gimmick);
	}

	public void AllChange()
	{
		_GimmickList.ForEach(x =>
		{
			switch (x.CurrentID)
			{
				case GimmickID.Ame:
					x.Change(GimmickID.Gumi);
					break;
				case GimmickID.Gumi:
					x.Change(GimmickID.Cookie);
					break;
				case GimmickID.Cookie:
					x.Change(GimmickID.Ame);
					break;
			}
		});
	}
}
