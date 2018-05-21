using System;

namespace Agricola
{
	public abstract class Action
	{
		/// <summary>
		/// アクション名
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="_name">Name.</param>
		public Action(string _name) { Name = _name; }
	}
}
