using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace PD.Model
{
	/// <summary>
	/// 类Focus。
	/// </summary>
	[Serializable]
	public partial class Focus
	{
		public Focus()
		{}
		#region Model
		private string _id;
		private string _img;
		private int? _sort;
		private string _desc;
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
		public string Img
		{
			set{ _img=value;}
			get{return _img;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Desc
		{
			set{ _desc=value;}
			get{return _desc;}
		}

        public string Href { get; set; }
        public string InsertTime { get; set; }

		#endregion Model



	}
}

