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
	public partial class VariantenClassDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertVarianten(Varianten instance);
    partial void UpdateVarianten(Varianten instance);
    partial void DeleteVarianten(Varianten instance);
    #endregion
		
		public VariantenClassDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["LPG_DEVConnectionString1"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public VariantenClassDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public VariantenClassDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public VariantenClassDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public VariantenClassDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Varianten> Variantens
		{
			get
			{
				return this.GetTable<Varianten>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Varianten")]
	public partial class Varianten : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _volgorde;
		
		private string _procedureCode;
		
		private string _variantCode;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnvolgordeChanging(int value);
    partial void OnvolgordeChanged();
    partial void OnprocedureCodeChanging(string value);
    partial void OnprocedureCodeChanged();
    partial void OnvariantCodeChanging(string value);
    partial void OnvariantCodeChanged();
    #endregion
		
		public Varianten()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_volgorde", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int volgorde
		{
			get
			{
				return this._volgorde;
			}
			set
			{
				if ((this._volgorde != value))
				{
					this.OnvolgordeChanging(value);
					this.SendPropertyChanging();
					this._volgorde = value;
					this.SendPropertyChanged("volgorde");
					this.OnvolgordeChanged();
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
