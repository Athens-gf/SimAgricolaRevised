using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KM.Unity
{
	class CSVReader
	{
		private List<string[]> data = new List<string[]>();
		public string this[int _row, int _column]
		{
			get
			{
				try
				{
					return data[_row][_column];
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}
		public int Row { get { return data.Count; } }
		public int MaxColumn { get { return data.Max(sl => sl.Length); } }
		public int MinColumn { get { return data.Min(sl => sl.Length); } }

		public CSVReader(string _filePath)
		{
			StringReader reader = new StringReader((Resources.Load(_filePath) as TextAsset).text);
			while (reader.Peek() > -1)
				data.Add(reader.ReadLine().Split(','));
		}

		delegate bool TryParse<T>(string _str, out T _result);
		public T Get<T>(int _row, int _column, Func<string, T> _fParce) { return _fParce(this[_row, _column]); }
		public int GetInt(int _row, int _column) { return int.Parse(this[_row, _column]); }
		public uint GetUInt(int _row, int _column) { return uint.Parse(this[_row, _column]); }
		public long GetLong(int _row, int _column) { return long.Parse(this[_row, _column]); }
		public ulong GetULong(int _row, int _column) { return ulong.Parse(this[_row, _column]); }
		public float GetFloat(int _row, int _column) { return float.Parse(this[_row, _column]); }
		public double GetDouble(int _row, int _column) { return double.Parse(this[_row, _column]); }
		public bool GetBool(int _row, int _column) { return bool.Parse(this[_row, _column]); }
	}
}