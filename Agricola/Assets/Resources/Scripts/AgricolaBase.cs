using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumExtension;

namespace Agricola
{
	public static class Agricola
	{
		/// <summary>
		/// 品物が建築資材かどうか
		/// </summary>
		public static bool IsBuildingResources(this Goods_e _goods)
		{
			switch (_goods)
			{
				case Goods_e.Wood:
				case Goods_e.Clay:
				case Goods_e.Reed:
				case Goods_e.Stone:
					return true;
				default:
					return false;
			}
		}

		/// <summary>
		/// 品物が農作物かどうか
		/// </summary>
		public static bool IsCrop(this Goods_e _goods)
		{
			switch (_goods)
			{
				case Goods_e.Grain:
				case Goods_e.Vegetable:
					return true;
				default:
					return false;
			}
		}

		/// <summary>
		/// 品物が家畜かどうか
		/// </summary>
		public static bool IsAnimal(this Goods_e _goods)
		{
			switch (_goods)
			{
				case Goods_e.Sheep:
				case Goods_e.WildBoar:
				case Goods_e.Cattle:
					return true;
				default:
					return false;
			}
		}

		/// <summary>
		/// 農場タイルが家かどうか
		/// </summary>
		public static bool IsHouse(this Farmyard_e _farmyard)
		{
			switch (_farmyard)
			{
				case Farmyard_e.WoodenHouse:
				case Farmyard_e.ClayHouse:
				case Farmyard_e.StoneHouse:
					return true;
				default:
					return false;
			}
		}
	}

	/// <summary>
	/// 品物
	/// </summary>
	public enum Goods_e
	{
		[EnumText("食料")] Food,

		// 建築資材
		[EnumText("木材")] Wood,
		[EnumText("レンガ")] Clay,
		[EnumText("葦")] Reed,
		[EnumText("石材")] Stone,

		// 農作物
		[EnumText("小麦")] Grain,
		[EnumText("野菜")] Vegetable,

		// 家畜
		[EnumText("羊")] Sheep,
		[EnumText("猪")] WildBoar,
		[EnumText("牛")] Cattle,
	}

	/// <summary>
	/// 農場タイル
	/// </summary>
	public enum Farmyard_e
	{
		[EnumText("草原")] Grassland,
		[EnumText("木の家")] WoodenHouse,
		[EnumText("レンガの家")] ClayHouse,
		[EnumText("石の家")] StoneHouse,
		[EnumText("畑")] Field,
		[EnumText("牧場")] Pasture,
	}
}