using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

		/// <summary>
		/// アクションスペース名
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// UIコンポーネントのButton
		/// </summary>
		public Button Button { get; private set; }

		/// <summary>
		/// セットアップ
		/// </summary>
		/// <param name="_name">アクションスペース名</param>
		public virtual void Setup(string _name)
		{
			Button = GetComponent<Button>();
			Name = _name;
		}

		/// <summary>
		/// ターン開始時の処理
		/// </summary>
		public virtual void SetupByTurn() { }

		/// <summary>
		/// アクションスペースを使った時の動作
		/// </summary>
		/// <param name="_player">使用したプレイヤー</param>
		public abstract void UseActionSpace(Player _player);
	}

	/// <summary>
	/// ラウンドカード用インターフェイス
	/// </summary>
	public interface IRoundCard
	{
		/// <summary>
		/// 第何ステージに登場するか
		/// </summary>
		uint Stage { get; }

		/// <summary>
		/// 公開されたかどうか
		/// </summary>
		bool IsOpen { get; }

		/// <summary>
		/// ラウンドカードを公開する
		/// </summary>
		void Open();
	}

	/// <summary>
	/// 累積スペース基礎クラス
	/// </summary>
	public abstract class AccumulationSpace : ActionSpace
	{
		/// <summary>
		/// 累積対象の品物
		/// </summary>
		public Goods_e Goods { get; private set; }

		/// <summary>
		/// 1ターンごとに累積する量
		/// </summary>
		public uint AmountIncreasePerTurn { get; private set; }

		public Text TeValue { get; private set; }

		/// <summary>
		/// 現在の累積量
		/// </summary>
		private uint m_Accumulation;
		public uint Accumulation
		{
			get { return m_Accumulation; }
			set
			{
				m_Accumulation = value;
				TeValue.text = value.ToString();
			}
		}

		/// <summary>
		/// セットアップ
		/// </summary>
		/// <param name="_name">アクションスペース名</param>
		/// <param name="_goods">累積品物</param>
		/// <param name="_amountIncreasePerTurn">ターンごとに累積する量</param>
		public virtual void Setup(string _name, Goods_e _goods, uint _amountIncreasePerTurn)
		{
			TeValue = transform.Find("Accumulation").Find("TeValue").GetComponent<Text>();
			Setup(_name);
			Goods = _goods;
			AmountIncreasePerTurn = _amountIncreasePerTurn;
			Accumulation = 0;
		}

		/// <summary>
		/// 累積スペースの品物数を増加させる
		/// </summary>
		/// <param name="_amount">増加数</param>
		public void AddAccumulation(uint _amount) => Accumulation += _amount;

		/// <summary>
		/// 累積スペースの品物数を減少させる
		/// </summary>
		/// <param name="_amount">減少数，0指定でMax数</param>
		public bool RemoveAccumulation(uint _amount = 0)
		{
			if (_amount == 0) _amount = Accumulation;
			if (Accumulation < _amount) return false;
			Accumulation -= _amount;
			return true;
		}
		/// <summary>
		/// ターン開始時の処理
		/// </summary>
		public override void SetupByTurn()
		{
			base.SetupByTurn();
			AddAccumulation(Accumulation);
		}

		/// <summary>
		/// アクションスペースを使った時の動作
		/// </summary>
		/// <param name="_player">使用したプレイヤー</param>
		public override void UseActionSpace(Player _player)
		{
			_player.Obtain(Goods, Accumulation);
			RemoveAccumulation();
		}
	}
}