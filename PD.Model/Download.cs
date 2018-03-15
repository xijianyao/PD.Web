using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace PD.Model
{
	/// <summary>
	/// 类Download。
	/// </summary>
	[Serializable]
	public partial class Download
	{
		public Download()
		{}
		#region Model
		private string _id;
		private string _name;
		private string _file;
		private string _desc;
		private DateTime? _inserttime;
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
		public string File
		{
			set{ _file=value;}
			get{return _file;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Desc
		{
			set{ _desc=value;}
			get{return _desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? InsertTime
		{
			set{ _inserttime=value;}
			get{return _inserttime;}
		}
        public int? Times { get; set; }
		#endregion Model

	}
}

