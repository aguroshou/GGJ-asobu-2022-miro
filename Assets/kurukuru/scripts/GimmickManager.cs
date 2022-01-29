using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

	public void AllChange(List<Change> changeList)
	{
		_GimmickList.ForEach(x =>
		{
			var change = changeList.FirstOrDefault(y => x.CurrentID == y.Prev);
			if (change == null)
				return;

			x.Change(change.Next);
		});
	}
}
