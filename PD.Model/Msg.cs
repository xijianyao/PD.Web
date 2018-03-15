using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace PD.Model
{
	/// <summary>
	/// 类Msg。
	/// </summary>
	[Serializable]
	public partial class Msg
	{
		public Msg()
		{}
		#region Model
		private string _id;
		private string _company;
		private string _name;
		private string _email;
		private string _phone;
		private string _content;
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
		public string Company
		{
			set{ _company=value;}
			get{return _company;}
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
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? InsertTime
		{
			set{ _inserttime=value;}
			get{return _inserttime;}
		}
		#endregion Model



	}
}

