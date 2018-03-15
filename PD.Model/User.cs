using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace PD.Model
{
	/// <summary>
	/// 类User。
	/// </summary>
	[Serializable]
	public partial class User
	{

		#region Model
		private string _id;
		private string _name;
		private string _username;
		private string _password;
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
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
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

