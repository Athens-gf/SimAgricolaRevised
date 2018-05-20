using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KM.Utility
{
	abstract class LinkerBase<T>
	{
		public List<LinkerBase<T>> Values { get; set; } = new List<LinkerBase<T>>();
		public virtual bool IsMono { get { return false; } }

		public static And<T> operator &(LinkerBase<T> _linker0, LinkerBase<T> _linker1)
		{
			var and = new And<T>();
			and.Values.Add(_linker0);
			and.Values.Add(_linker1);
			return and;
		}

		public static And<T> operator &(LinkerBase<T> _linker, T _val) => _linker & (new Linker<T>(_val));

		public static Or<T> operator |(LinkerBase<T> _linker0, LinkerBase<T> _linker1)
		{
			var or = new Or<T>();
			or.Values.Add(_linker0);
			or.Values.Add(_linker1);
			return or;
		}

		public static Or<T> operator |(LinkerBase<T> _linker, T _val) => _linker | (new Linker<T>(_val));

		public static Then<T> operator +(LinkerBase<T> _linker0, LinkerBase<T> _linker1)
		{
			var then = new Then<T>();
			then.Values.Add(_linker0);
			then.Values.Add(_linker1);
			return then;
		}

		public static Then<T> operator +(LinkerBase<T> _linker, T _val) => _linker + (new Linker<T>(_val));
	}

	class Linker<T> : LinkerBase<T>
	{
		public T Value { get; set; }
		public override bool IsMono { get { return true; } }

		public Linker(T _val) { Value = _val; }
	}

	class And<T> : LinkerBase<T>
	{
		public static And<T> operator &(And<T> _and, LinkerBase<T> _linker)
		{
			var and = new And<T>();
			and.Values.AddRange(_and.Values);
			and.Values.Add(_linker);
			return and;
		}

		public static And<T> operator &(LinkerBase<T> _linker, And<T> _and)
		{
			var and = new And<T>();
			and.Values.Add(_linker);
			and.Values.AddRange(_and.Values);
			return and;
		}

		public static And<T> operator &(And<T> _and, T _val) => _and & (new Linker<T>(_val));
	}

	class Or<T> : LinkerBase<T>
	{
		public static Or<T> operator |(Or<T> _or, LinkerBase<T> _linker)
		{
			var or = new Or<T>();
			or.Values.AddRange(_or.Values);
			or.Values.Add(_linker);
			return or;
		}

		public static Or<T> operator |(LinkerBase<T> _linker, Or<T> _or)
		{
			var or = new Or<T>();
			or.Values.Add(_linker);
			or.Values.AddRange(_or.Values);
			return or;
		}

		public static Or<T> operator |(Or<T> _or, T _val) => _or | (new Linker<T>(_val));
	}

	class Then<T> : LinkerBase<T>
	{
		public static Then<T> operator +(Then<T> _then, LinkerBase<T> _linker)
		{
			var then = new Then<T>();
			then.Values.AddRange(_then.Values);
			then.Values.Add(_linker);
			return then;
		}

		public static Then<T> operator +(LinkerBase<T> _linker, Then<T> _then)
		{
			var then = new Then<T>();
			then.Values.Add(_linker);
			then.Values.AddRange(_then.Values);
			return then;
		}

		public static Then<T> operator +(Then<T> _then, T _val) => _then + (new Linker<T>(_val));
	}
}
