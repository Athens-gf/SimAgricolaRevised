using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Agricola {
	public class PlayerBoard : MonoBehaviour {
		public Dictionary<Goods_e, int> Goods { get; private set; } = new Dictionary<Goods_e, int>();

		// Use this for initialization
		void Start() {

		}

		// Update is called once per frame
		void Update() {

		}

		public void Reset()
		{
			foreach (Goods_e go in Enum.GetValues(typeof(Goods_e)))
				Goods[go] = 0;
		}
	}
}
