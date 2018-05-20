using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Agricola
{
	/// <summary>
	/// アクションスペース全般基礎クラス
	/// </summary>
	public abstract class ActionSpace : MonoBehaviour
	{
		public enum Type_e
		{
			Base,
			Additional,
			Round,
		}
		public abstract Type_e Type { get; }

	}

	/// <summary>
	/// ラウンドカード用インターフェイス
	/// </summary>
	public interface IRoundCard
	{

	}

	/// <summary>
	/// 累積スペース基礎クラス
	/// </summary>
	public abstract class AccumulationSpace : ActionSpace
	{

	}
}