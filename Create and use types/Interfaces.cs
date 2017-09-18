using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsfdfs
{
	class Interfaces
	{
		public static void MyMethod()
		{
			var NII = new Graduate();
			((IConsulent) NII).Skills = true;	//IConsulent.Skills
			((IDeveloper) NII).Skills = true;	//IDeveloper.Skills
			NII.Skills = true;					//IGraduate.Skills
			NII.GetSkills();

			IConsulent ssq = new Graduate();
			ssq.Skills = true;                  //IConsulent.Skills
			ssq.GetSkills();

			IDeveloper art = new Graduate();
			art.Skills = true;                  //IDeveloper.Skilss
			art.GetSkills();
		}
	}

	public class Graduate : IConsulent, IDeveloper
	{
		public bool Skills { get; set ; }		//Implicit	
		bool IDeveloper.Skills { get ; set ; }  //Explicit

		public void GetSkills()                 //Implicit
		{
			Console.WriteLine("Im a Graduate");
		}

		void IDeveloper.GetSkills()             //Explicit
		{
			Console.WriteLine("Im a Graduate From IDeveloper");
		}
		void IConsulent.GetSkills()             //Explicit
		{
			Console.WriteLine("Im a Graduate From IConsulent");
		}
	}

	public interface IConsulent
	{
		bool Skills { get; set; }
		void GetSkills();
	}

	public interface IDeveloper 
	{
		bool Skills { get; set; }
		void GetSkills();
	}
}
