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
	public partial class EventsPerCyclusbladClassDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertEventsPerCyclusblad(EventsPerCyclusblad instance);
    partial void UpdateEventsPerCyclusblad(EventsPerCyclusblad instance);
    partial void DeleteEventsPerCyclusblad(EventsPerCyclusblad instance);
    #endregion
		
		public EventsPerCyclusbladClassDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["LPG_DEVConnectionString1"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public EventsPerCyclusbladClassDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EventsPerCyclusbladClassDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EventsPerCyclusbladClassDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EventsPerCyclusbladClassDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<EventsPerCyclusblad> EventsPerCyclusblads
		{
			get
			{
				return this.GetTable<EventsPerCyclusblad>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.EventsPerCyclusblad")]
	public partial class EventsPerCyclusblad : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _volgorde;
		
		private string _baan;
		
		private string _naam;
		
		private int _codeEvent;
		
		private string _codeCyclusblad;
		
		private int _versnelling;
		
		private int _snelheid;
		
		private int _frequentie;
		
		private byte _Cel1;
		
		private byte _Cel2;
		
		private byte _Cel3;
		
		private byte _Cel4;
		
		private byte _Cel5;
		
		private byte _Cel6;
		
		private byte _Cel7;
		
		private byte _Cel8;
		
		private byte _Cel9;
		
		private byte _Cel10;
		
		private byte _Cel11;
		
		private byte _Cel12;
		
		private byte _Cel13;
		
		private byte _Cel14;
		
		private byte _Cel15;
		
		private byte _Cel16;
		
		private byte _Cel17;
		
		private byte _Cel18;
		
		private byte _Cel19;
		
		private byte _Cel20;
		
		private byte _Cel21;
		
		private byte _Cel22;
		
		private byte _Cel23;
		
		private byte _Cel24;
		
		private byte _Cel25;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnvolgordeChanging(int value);
    partial void OnvolgordeChanged();
    partial void OnbaanChanging(string value);
    partial void OnbaanChanged();
    partial void OnnaamChanging(string value);
    partial void OnnaamChanged();
    partial void OncodeEventChanging(int value);
    partial void OncodeEventChanged();
    partial void OncodeCyclusbladChanging(string value);
    partial void OncodeCyclusbladChanged();
    partial void OnversnellingChanging(int value);
    partial void OnversnellingChanged();
    partial void OnsnelheidChanging(int value);
    partial void OnsnelheidChanged();
    partial void OnfrequentieChanging(int value);
    partial void OnfrequentieChanged();
    partial void OnCel1Changing(byte value);
    partial void OnCel1Changed();
    partial void OnCel2Changing(byte value);
    partial void OnCel2Changed();
    partial void OnCel3Changing(byte value);
    partial void OnCel3Changed();
    partial void OnCel4Changing(byte value);
    partial void OnCel4Changed();
    partial void OnCel5Changing(byte value);
    partial void OnCel5Changed();
    partial void OnCel6Changing(byte value);
    partial void OnCel6Changed();
    partial void OnCel7Changing(byte value);
    partial void OnCel7Changed();
    partial void OnCel8Changing(byte value);
    partial void OnCel8Changed();
    partial void OnCel9Changing(byte value);
    partial void OnCel9Changed();
    partial void OnCel10Changing(byte value);
    partial void OnCel10Changed();
    partial void OnCel11Changing(byte value);
    partial void OnCel11Changed();
    partial void OnCel12Changing(byte value);
    partial void OnCel12Changed();
    partial void OnCel13Changing(byte value);
    partial void OnCel13Changed();
    partial void OnCel14Changing(byte value);
    partial void OnCel14Changed();
    partial void OnCel15Changing(byte value);
    partial void OnCel15Changed();
    partial void OnCel16Changing(byte value);
    partial void OnCel16Changed();
    partial void OnCel17Changing(byte value);
    partial void OnCel17Changed();
    partial void OnCel18Changing(byte value);
    partial void OnCel18Changed();
    partial void OnCel19Changing(byte value);
    partial void OnCel19Changed();
    partial void OnCel20Changing(byte value);
    partial void OnCel20Changed();
    partial void OnCel21Changing(byte value);
    partial void OnCel21Changed();
    partial void OnCel22Changing(byte value);
    partial void OnCel22Changed();
    partial void OnCel23Changing(byte value);
    partial void OnCel23Changed();
    partial void OnCel24Changing(byte value);
    partial void OnCel24Changed();
    partial void OnCel25Changing(byte value);
    partial void OnCel25Changed();
    #endregion
		
		public EventsPerCyclusblad()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_volgorde", DbType="Int NOT NULL")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_baan", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string baan
		{
			get
			{
				return this._baan;
			}
			set
			{
				if ((this._baan != value))
				{
					this.OnbaanChanging(value);
					this.SendPropertyChanging();
					this._baan = value;
					this.SendPropertyChanged("baan");
					this.OnbaanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_naam", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string naam
		{
			get
			{
				return this._naam;
			}
			set
			{
				if ((this._naam != value))
				{
					this.OnnaamChanging(value);
					this.SendPropertyChanging();
					this._naam = value;
					this.SendPropertyChanged("naam");
					this.OnnaamChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codeEvent", DbType="Int NOT NULL")]
		public int codeEvent
		{
			get
			{
				return this._codeEvent;
			}
			set
			{
				if ((this._codeEvent != value))
				{
					this.OncodeEventChanging(value);
					this.SendPropertyChanging();
					this._codeEvent = value;
					this.SendPropertyChanged("codeEvent");
					this.OncodeEventChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codeCyclusblad", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string codeCyclusblad
		{
			get
			{
				return this._codeCyclusblad;
			}
			set
			{
				if ((this._codeCyclusblad != value))
				{
					this.OncodeCyclusbladChanging(value);
					this.SendPropertyChanging();
					this._codeCyclusblad = value;
					this.SendPropertyChanged("codeCyclusblad");
					this.OncodeCyclusbladChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_versnelling", DbType="Int NOT NULL")]
		public int versnelling
		{
			get
			{
				return this._versnelling;
			}
			set
			{
				if ((this._versnelling != value))
				{
					this.OnversnellingChanging(value);
					this.SendPropertyChanging();
					this._versnelling = value;
					this.SendPropertyChanged("versnelling");
					this.OnversnellingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_snelheid", DbType="Int NOT NULL")]
		public int snelheid
		{
			get
			{
				return this._snelheid;
			}
			set
			{
				if ((this._snelheid != value))
				{
					this.OnsnelheidChanging(value);
					this.SendPropertyChanging();
					this._snelheid = value;
					this.SendPropertyChanged("snelheid");
					this.OnsnelheidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_frequentie", DbType="Int NOT NULL")]
		public int frequentie
		{
			get
			{
				return this._frequentie;
			}
			set
			{
				if ((this._frequentie != value))
				{
					this.OnfrequentieChanging(value);
					this.SendPropertyChanging();
					this._frequentie = value;
					this.SendPropertyChanged("frequentie");
					this.OnfrequentieChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel1", DbType="TinyInt NOT NULL")]
		public byte Cel1
		{
			get
			{
				return this._Cel1;
			}
			set
			{
				if ((this._Cel1 != value))
				{
					this.OnCel1Changing(value);
					this.SendPropertyChanging();
					this._Cel1 = value;
					this.SendPropertyChanged("Cel1");
					this.OnCel1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel2", DbType="TinyInt NOT NULL")]
		public byte Cel2
		{
			get
			{
				return this._Cel2;
			}
			set
			{
				if ((this._Cel2 != value))
				{
					this.OnCel2Changing(value);
					this.SendPropertyChanging();
					this._Cel2 = value;
					this.SendPropertyChanged("Cel2");
					this.OnCel2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel3", DbType="TinyInt NOT NULL")]
		public byte Cel3
		{
			get
			{
				return this._Cel3;
			}
			set
			{
				if ((this._Cel3 != value))
				{
					this.OnCel3Changing(value);
					this.SendPropertyChanging();
					this._Cel3 = value;
					this.SendPropertyChanged("Cel3");
					this.OnCel3Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel4", DbType="TinyInt NOT NULL")]
		public byte Cel4
		{
			get
			{
				return this._Cel4;
			}
			set
			{
				if ((this._Cel4 != value))
				{
					this.OnCel4Changing(value);
					this.SendPropertyChanging();
					this._Cel4 = value;
					this.SendPropertyChanged("Cel4");
					this.OnCel4Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel5", DbType="TinyInt NOT NULL")]
		public byte Cel5
		{
			get
			{
				return this._Cel5;
			}
			set
			{
				if ((this._Cel5 != value))
				{
					this.OnCel5Changing(value);
					this.SendPropertyChanging();
					this._Cel5 = value;
					this.SendPropertyChanged("Cel5");
					this.OnCel5Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel6", DbType="TinyInt NOT NULL")]
		public byte Cel6
		{
			get
			{
				return this._Cel6;
			}
			set
			{
				if ((this._Cel6 != value))
				{
					this.OnCel6Changing(value);
					this.SendPropertyChanging();
					this._Cel6 = value;
					this.SendPropertyChanged("Cel6");
					this.OnCel6Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel7", DbType="TinyInt NOT NULL")]
		public byte Cel7
		{
			get
			{
				return this._Cel7;
			}
			set
			{
				if ((this._Cel7 != value))
				{
					this.OnCel7Changing(value);
					this.SendPropertyChanging();
					this._Cel7 = value;
					this.SendPropertyChanged("Cel7");
					this.OnCel7Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel8", DbType="TinyInt NOT NULL")]
		public byte Cel8
		{
			get
			{
				return this._Cel8;
			}
			set
			{
				if ((this._Cel8 != value))
				{
					this.OnCel8Changing(value);
					this.SendPropertyChanging();
					this._Cel8 = value;
					this.SendPropertyChanged("Cel8");
					this.OnCel8Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel9", DbType="TinyInt NOT NULL")]
		public byte Cel9
		{
			get
			{
				return this._Cel9;
			}
			set
			{
				if ((this._Cel9 != value))
				{
					this.OnCel9Changing(value);
					this.SendPropertyChanging();
					this._Cel9 = value;
					this.SendPropertyChanged("Cel9");
					this.OnCel9Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel10", DbType="TinyInt NOT NULL")]
		public byte Cel10
		{
			get
			{
				return this._Cel10;
			}
			set
			{
				if ((this._Cel10 != value))
				{
					this.OnCel10Changing(value);
					this.SendPropertyChanging();
					this._Cel10 = value;
					this.SendPropertyChanged("Cel10");
					this.OnCel10Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel11", DbType="TinyInt NOT NULL")]
		public byte Cel11
		{
			get
			{
				return this._Cel11;
			}
			set
			{
				if ((this._Cel11 != value))
				{
					this.OnCel11Changing(value);
					this.SendPropertyChanging();
					this._Cel11 = value;
					this.SendPropertyChanged("Cel11");
					this.OnCel11Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel12", DbType="TinyInt NOT NULL")]
		public byte Cel12
		{
			get
			{
				return this._Cel12;
			}
			set
			{
				if ((this._Cel12 != value))
				{
					this.OnCel12Changing(value);
					this.SendPropertyChanging();
					this._Cel12 = value;
					this.SendPropertyChanged("Cel12");
					this.OnCel12Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel13", DbType="TinyInt NOT NULL")]
		public byte Cel13
		{
			get
			{
				return this._Cel13;
			}
			set
			{
				if ((this._Cel13 != value))
				{
					this.OnCel13Changing(value);
					this.SendPropertyChanging();
					this._Cel13 = value;
					this.SendPropertyChanged("Cel13");
					this.OnCel13Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel14", DbType="TinyInt NOT NULL")]
		public byte Cel14
		{
			get
			{
				return this._Cel14;
			}
			set
			{
				if ((this._Cel14 != value))
				{
					this.OnCel14Changing(value);
					this.SendPropertyChanging();
					this._Cel14 = value;
					this.SendPropertyChanged("Cel14");
					this.OnCel14Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel15", DbType="TinyInt NOT NULL")]
		public byte Cel15
		{
			get
			{
				return this._Cel15;
			}
			set
			{
				if ((this._Cel15 != value))
				{
					this.OnCel15Changing(value);
					this.SendPropertyChanging();
					this._Cel15 = value;
					this.SendPropertyChanged("Cel15");
					this.OnCel15Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel16", DbType="TinyInt NOT NULL")]
		public byte Cel16
		{
			get
			{
				return this._Cel16;
			}
			set
			{
				if ((this._Cel16 != value))
				{
					this.OnCel16Changing(value);
					this.SendPropertyChanging();
					this._Cel16 = value;
					this.SendPropertyChanged("Cel16");
					this.OnCel16Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel17", DbType="TinyInt NOT NULL")]
		public byte Cel17
		{
			get
			{
				return this._Cel17;
			}
			set
			{
				if ((this._Cel17 != value))
				{
					this.OnCel17Changing(value);
					this.SendPropertyChanging();
					this._Cel17 = value;
					this.SendPropertyChanged("Cel17");
					this.OnCel17Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel18", DbType="TinyInt NOT NULL")]
		public byte Cel18
		{
			get
			{
				return this._Cel18;
			}
			set
			{
				if ((this._Cel18 != value))
				{
					this.OnCel18Changing(value);
					this.SendPropertyChanging();
					this._Cel18 = value;
					this.SendPropertyChanged("Cel18");
					this.OnCel18Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel19", DbType="TinyInt NOT NULL")]
		public byte Cel19
		{
			get
			{
				return this._Cel19;
			}
			set
			{
				if ((this._Cel19 != value))
				{
					this.OnCel19Changing(value);
					this.SendPropertyChanging();
					this._Cel19 = value;
					this.SendPropertyChanged("Cel19");
					this.OnCel19Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel20", DbType="TinyInt NOT NULL")]
		public byte Cel20
		{
			get
			{
				return this._Cel20;
			}
			set
			{
				if ((this._Cel20 != value))
				{
					this.OnCel20Changing(value);
					this.SendPropertyChanging();
					this._Cel20 = value;
					this.SendPropertyChanged("Cel20");
					this.OnCel20Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel21", DbType="TinyInt NOT NULL")]
		public byte Cel21
		{
			get
			{
				return this._Cel21;
			}
			set
			{
				if ((this._Cel21 != value))
				{
					this.OnCel21Changing(value);
					this.SendPropertyChanging();
					this._Cel21 = value;
					this.SendPropertyChanged("Cel21");
					this.OnCel21Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel22", DbType="TinyInt NOT NULL")]
		public byte Cel22
		{
			get
			{
				return this._Cel22;
			}
			set
			{
				if ((this._Cel22 != value))
				{
					this.OnCel22Changing(value);
					this.SendPropertyChanging();
					this._Cel22 = value;
					this.SendPropertyChanged("Cel22");
					this.OnCel22Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel23", DbType="TinyInt NOT NULL")]
		public byte Cel23
		{
			get
			{
				return this._Cel23;
			}
			set
			{
				if ((this._Cel23 != value))
				{
					this.OnCel23Changing(value);
					this.SendPropertyChanging();
					this._Cel23 = value;
					this.SendPropertyChanged("Cel23");
					this.OnCel23Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel24", DbType="TinyInt NOT NULL")]
		public byte Cel24
		{
			get
			{
				return this._Cel24;
			}
			set
			{
				if ((this._Cel24 != value))
				{
					this.OnCel24Changing(value);
					this.SendPropertyChanging();
					this._Cel24 = value;
					this.SendPropertyChanged("Cel24");
					this.OnCel24Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cel25", DbType="TinyInt NOT NULL")]
		public byte Cel25
		{
			get
			{
				return this._Cel25;
			}
			set
			{
				if ((this._Cel25 != value))
				{
					this.OnCel25Changing(value);
					this.SendPropertyChanging();
					this._Cel25 = value;
					this.SendPropertyChanged("Cel25");
					this.OnCel25Changed();
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
