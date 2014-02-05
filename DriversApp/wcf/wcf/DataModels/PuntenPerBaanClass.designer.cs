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
	public partial class PuntenPerBaanDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPuntenPerBaan(PuntenPerBaan instance);
    partial void UpdatePuntenPerBaan(PuntenPerBaan instance);
    partial void DeletePuntenPerBaan(PuntenPerBaan instance);
    #endregion
		
		public PuntenPerBaanDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["LPG_DEVConnectionString1"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PuntenPerBaanDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PuntenPerBaanDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PuntenPerBaanDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PuntenPerBaanDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<PuntenPerBaan> PuntenPerBaans
		{
			get
			{
				return this.GetTable<PuntenPerBaan>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PuntenPerBaan")]
	public partial class PuntenPerBaan : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Nr;
		
		private string _codeBaan;
		
		private int _punt;
		
		private string _longitude;
		
		private string _latitude;
		
		private string _radius;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnNrChanging(int value);
    partial void OnNrChanged();
    partial void OncodeBaanChanging(string value);
    partial void OncodeBaanChanged();
    partial void OnpuntChanging(int value);
    partial void OnpuntChanged();
    partial void OnlongitudeChanging(string value);
    partial void OnlongitudeChanged();
    partial void OnlatitudeChanging(string value);
    partial void OnlatitudeChanged();
    partial void OnradiusChanging(string value);
    partial void OnradiusChanged();
    #endregion
		
		public PuntenPerBaan()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nr", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Nr
		{
			get
			{
				return this._Nr;
			}
			set
			{
				if ((this._Nr != value))
				{
					this.OnNrChanging(value);
					this.SendPropertyChanging();
					this._Nr = value;
					this.SendPropertyChanged("Nr");
					this.OnNrChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codeBaan", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string codeBaan
		{
			get
			{
				return this._codeBaan;
			}
			set
			{
				if ((this._codeBaan != value))
				{
					this.OncodeBaanChanging(value);
					this.SendPropertyChanging();
					this._codeBaan = value;
					this.SendPropertyChanged("codeBaan");
					this.OncodeBaanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_punt", DbType="Int NOT NULL")]
		public int punt
		{
			get
			{
				return this._punt;
			}
			set
			{
				if ((this._punt != value))
				{
					this.OnpuntChanging(value);
					this.SendPropertyChanging();
					this._punt = value;
					this.SendPropertyChanged("punt");
					this.OnpuntChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_longitude", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string longitude
		{
			get
			{
				return this._longitude;
			}
			set
			{
				if ((this._longitude != value))
				{
					this.OnlongitudeChanging(value);
					this.SendPropertyChanging();
					this._longitude = value;
					this.SendPropertyChanged("longitude");
					this.OnlongitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_latitude", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string latitude
		{
			get
			{
				return this._latitude;
			}
			set
			{
				if ((this._latitude != value))
				{
					this.OnlatitudeChanging(value);
					this.SendPropertyChanging();
					this._latitude = value;
					this.SendPropertyChanged("latitude");
					this.OnlatitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_radius", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string radius
		{
			get
			{
				return this._radius;
			}
			set
			{
				if ((this._radius != value))
				{
					this.OnradiusChanging(value);
					this.SendPropertyChanging();
					this._radius = value;
					this.SendPropertyChanged("radius");
					this.OnradiusChanged();
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
