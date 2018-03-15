using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace PD.Model
{
	/// <summary>
	/// 类Info。
	/// </summary>
	[Serializable]
	public partial class Info
	{
		public Info()
		{}
		#region Model
		private string _id;
		private string _name;
		private string _mark;
		private string _content;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mark
		{
			set{ _mark=value;}
			get{return _mark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		#endregion Model



	}
}

