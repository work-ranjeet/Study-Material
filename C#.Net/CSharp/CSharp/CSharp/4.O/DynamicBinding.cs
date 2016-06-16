using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Dynamic;

namespace DemoCSharp_4.O
{
	public class DynamicBinding
	{
		public void test()
		{
			var ds = new DataSet();
			//ds = new DataColumn();

			dynamic dds = new DataSet();
			dds = new DataColumn();
		}
	}

	public class Duck: DynamicObject
	{
		public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
		{
			Console.WriteLine(binder.Name + " method was called");
			result = null;
			return true;
		}
	}

}
