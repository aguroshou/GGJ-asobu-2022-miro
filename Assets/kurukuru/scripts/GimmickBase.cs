using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBase : MonoBehaviour
{
	/// <summary>
	/// GimmickID 経書先で設定すること
	/// </summary>
	public virtual GimmickID ID { get; }
	/// <summary>
	/// Changeが呼ばれて、役目を始まる時に呼ばれる処理
	/// 継承先でOverrideすること
	/// </summary>
	/// <param name="prev">以前のGimmick</param>
	public virtual void Enter(GimmickID prev)
	{
		enabled = true;
	}
	/// <summary>
	/// Changeが呼ばれて、役目を終わるときに呼ばれる処理
	/// 継承先でOverrideすること
	/// </summary>
	/// <param name="next">次のGimmick</param>
	public virtual void Exit(GimmickID next)
	{
		enabled = false;
	}
}
