namespace Agricola
{
	public class AS_Forest : AccumulationSpace
	{
		public override Type_e Type { get; } = Type_e.Base;

		/// <summary>
		/// セットアップ
		/// </summary>
		public void Setup() => Setup("森林", Goods_e.Wood, 3);


		void Start()
		{
			Setup();
		}
	}
}