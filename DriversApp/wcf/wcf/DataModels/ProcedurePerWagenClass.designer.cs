﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF.DataModels
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="LPG_DEV")]
	public partial class ProcedurePerWagenClassDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertProceduresPerWagen(ProceduresPerWagen instance);
    partial void UpdateProceduresPerWagen(ProceduresPerWagen instance);
    partial void DeleteProceduresPerWagen(ProceduresPerWagen instance);
    #endregion
		
		public ProcedurePerWagenClassDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["LPG_DEVConnectionString1"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ProcedurePerWagenClassDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProcedurePerWagenClassDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProcedurePerWagenClassDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProcedurePerWagenClassDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ProceduresPerWagen> ProceduresPerWagens
		{
			get
			{
				return this.GetTable<ProceduresPerWagen>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ProceduresPerWagen")]
	public partial class ProceduresPerWagen : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _wagencode;
		
		private string _procedureCode;
		
		private string _variantCode;
		
		private string _voortgang;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnwagencodeChanging(string value);
    partial void OnwagencodeChanged();
    partial void OnprocedureCodeChanging(string value);
    partial void OnprocedureCodeChanged();
    partial void OnvariantCodeChanging(string value);
    partial void OnvariantCodeChanged();
    partial void OnvoortgangChanging(string value);
    partial void OnvoortgangChanged();
    #endregion
		
		public ProceduresPerWagen()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_wagencode", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string wagencode
		{
			get
			{
				return this._wagencode;
			}
			set
			{
				if ((this._wagencode != value))
				{
					this.OnwagencodeChanging(value);
					this.SendPropertyChanging();
					this._wagencode = value;
					this.SendPropertyChanged("wagencode");
					this.OnwagencodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_procedureCode", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string procedureCode
		{
			get
			{
				return this._procedureCode;
			}
			set
			{
				if ((this._procedureCode != value))
				{
					this.OnprocedureCodeChanging(value);
					this.SendPropertyChanging();
					this._procedureCode = value;
					this.SendPropertyChanged("procedureCode");
					this.OnprocedureCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_variantCode", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string variantCode
		{
			get
			{
				return this._variantCode;
			}
			set
			{
				if ((this._variantCode != value))
				{
					this.OnvariantCodeChanging(value);
					this.SendPropertyChanging();
					this._variantCode = value;
					this.SendPropertyChanged("variantCode");
					this.OnvariantCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_voortgang", DbType="VarChar(6) NOT NULL", CanBeNull=false)]
		public string voortgang
		{
			get
			{
				return this._voortgang;
			}
			set
			{
				if ((this._voortgang != value))
				{
					this.OnvoortgangChanging(value);
					this.SendPropertyChanging();
					this._voortgang = value;
					this.SendPropertyChanged("voortgang");
					this.OnvoortgangChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
