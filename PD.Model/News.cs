using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace PD.Model
{
	/// <summary>
	/// 类News。
	/// </summary>
	[Serializable]
	public partial class News
	{
		public News()
		{
        
        }
		#region Model
		private string _id;
		private string _name;
		private DateTime? _inserttime;
		private string _uid;
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
		public DateTime? InsertTime
		{
			set{ _inserttime=value;}
			get{return _inserttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		[CurrentUser]
        public string UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
        public int? Type { get; set; }
		#endregion Model



	}
}

