﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FakePyramid
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DWKDB")]
	public partial class DWKDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public DWKDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DWKDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DWKDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DWKDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DWKDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DWKDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<UserView> UserViews
		{
			get
			{
				return this.GetTable<UserView>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="FP.User_Insert")]
		public ISingleResult<UserView> User_Insert([global::System.Data.Linq.Mapping.ParameterAttribute(Name="TransID", DbType="VarChar(20)")] string transID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ParentName", DbType="VarChar(30)")] string parentName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PayeeName", DbType="VarChar(30)")] string payeeName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), transID, parentName, payeeName);
			return ((ISingleResult<UserView>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="FP.User_SelectByUserName")]
		public ISingleResult<UserView> User_SelectByUserName([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserName", DbType="VarChar(30)")] string userName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userName);
			return ((ISingleResult<UserView>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="FP.User_UpdateUserName")]
		public ISingleResult<UserView> User_UpdateUserName([global::System.Data.Linq.Mapping.ParameterAttribute(Name="TransID", DbType="VarChar(20)")] string transID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserName", DbType="VarChar(20)")] string userName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), transID, userName);
			return ((ISingleResult<UserView>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="FP.Setting_SelectByKey")]
		public ISingleResult<Setting_SelectByKeyResult> Setting_SelectByKey([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Key", DbType="VarChar(20)")] string key)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), key);
			return ((ISingleResult<Setting_SelectByKeyResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="FP.UserView")]
	public partial class UserView
	{
		
		private string _TransID;
		
		private string _UserName;
		
		private string _ParentName;
		
		private string _PayeeName;
		
		private System.DateTime _JoinDateTime;
		
		private int _InvitedCount;
		
		private string _NextPayeeName;
		
		private System.Nullable<int> _GiftAmount;
		
		public UserView()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransID", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string TransID
		{
			get
			{
				return this._TransID;
			}
			set
			{
				if ((this._TransID != value))
				{
					this._TransID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(30)")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this._UserName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParentName", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string ParentName
		{
			get
			{
				return this._ParentName;
			}
			set
			{
				if ((this._ParentName != value))
				{
					this._ParentName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PayeeName", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string PayeeName
		{
			get
			{
				return this._PayeeName;
			}
			set
			{
				if ((this._PayeeName != value))
				{
					this._PayeeName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_JoinDateTime", DbType="DateTime NOT NULL")]
		public System.DateTime JoinDateTime
		{
			get
			{
				return this._JoinDateTime;
			}
			set
			{
				if ((this._JoinDateTime != value))
				{
					this._JoinDateTime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InvitedCount", DbType="Int NOT NULL")]
		public int InvitedCount
		{
			get
			{
				return this._InvitedCount;
			}
			set
			{
				if ((this._InvitedCount != value))
				{
					this._InvitedCount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NextPayeeName", DbType="VarChar(30)")]
		public string NextPayeeName
		{
			get
			{
				return this._NextPayeeName;
			}
			set
			{
				if ((this._NextPayeeName != value))
				{
					this._NextPayeeName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GiftAmount", DbType="Int")]
		public System.Nullable<int> GiftAmount
		{
			get
			{
				return this._GiftAmount;
			}
			set
			{
				if ((this._GiftAmount != value))
				{
					this._GiftAmount = value;
				}
			}
		}
	}
	
	public partial class Setting_SelectByKeyResult
	{
		
		private string _Value;
		
		public Setting_SelectByKeyResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if ((this._Value != value))
				{
					this._Value = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
