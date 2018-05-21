using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Agricola
{
	public struct Worker
	{
		public enum Type_e
		{
			NotYetReleased, // 未登場
			Unexploded,     // 未行動
			Activated,      // 行動済
			Newborn,        // 新生児
		}

		/// <summary>
		/// このワーカーを所持しているプレイヤー
		/// </summary>
		public Player Player { get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="_player">このワーカーを所持しているプレイヤー</param>
		public Worker(Player _player) { Player = _player; }
	}

	public class Player : MonoBehaviour
	{
		/// <summary>
		/// 所持する品物
		/// </summary>
		public Dictionary<Goods_e, uint> Goods { get; } = new Dictionary<Goods_e, uint>();

		/// <summary>
		/// プレイヤー色
		/// </summary>
		public Color Color { get; set; }

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		/// <summary>
		/// 初期化
		/// </summary>
		public void Setup()
		{
			foreach (Goods_e go in Enum.GetValues(typeof(Goods_e)))
				Goods[go] = 0;
		}

		/// <summary>
		/// 品物を得る
		/// </summary>
		/// <param name="_goods">品物の種類</param>
		/// <param name="_amount">個数</param>
		public void Obtain(Goods_e _goods, uint _amount) => Goods[_goods] += _amount;

		/// <summary>
		/// 品物をコストとして支払う
		/// </summary>
		/// <param name="_goods">品物の種類</param>
		/// <param name="_amount">個数</param>
		public bool PayCost(Goods_e _goods, uint _amount)
		{
			if (Goods[_goods] < _amount) return false;
			Goods[_goods] -= _amount;
			return true;
		}
	}
}
