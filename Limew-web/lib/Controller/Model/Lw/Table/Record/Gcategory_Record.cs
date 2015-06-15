using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LK.Attribute;
using LK.DB;  
using LK.DB.SQLCreater;  
using Limew.Model.Lw.Table;
namespace Limew.Model.Lw.Table.Record
{
	[LkRecord]
	[TableView("GCATEGORY", true)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class Gcategory_Record : RecordBase{
		public Gcategory_Record(){}
		/*欄位資訊 Start*/
		string _GCATEGORY_UUID=null;
		string _GCATEGORY_NAME=null;
		string _GCATEGORY_FULL_NAME=null;
		string _GCATEGORY_FULL_UUID=null;
		int? _GCATEGORY_IS_ACTIVE=null;
		string _GCATEGORY_PARENT_UUID=null;
		/*欄位資訊 End*/

		[ColumnName("GCATEGORY_UUID",true,typeof(string))]
		public string GCATEGORY_UUID
		{
			set
			{
				_GCATEGORY_UUID=value;
			}
			get
			{
				return _GCATEGORY_UUID;
			}
		}

		[ColumnName("GCATEGORY_NAME",false,typeof(string))]
		public string GCATEGORY_NAME
		{
			set
			{
				_GCATEGORY_NAME=value;
			}
			get
			{
				return _GCATEGORY_NAME;
			}
		}

		[ColumnName("GCATEGORY_FULL_NAME",false,typeof(string))]
		public string GCATEGORY_FULL_NAME
		{
			set
			{
				_GCATEGORY_FULL_NAME=value;
			}
			get
			{
				return _GCATEGORY_FULL_NAME;
			}
		}

		[ColumnName("GCATEGORY_FULL_UUID",false,typeof(string))]
		public string GCATEGORY_FULL_UUID
		{
			set
			{
				_GCATEGORY_FULL_UUID=value;
			}
			get
			{
				return _GCATEGORY_FULL_UUID;
			}
		}

		[ColumnName("GCATEGORY_IS_ACTIVE",false,typeof(int?))]
		public int? GCATEGORY_IS_ACTIVE
		{
			set
			{
				_GCATEGORY_IS_ACTIVE=value;
			}
			get
			{
				return _GCATEGORY_IS_ACTIVE;
			}
		}

		[ColumnName("GCATEGORY_PARENT_UUID",false,typeof(string))]
		public string GCATEGORY_PARENT_UUID
		{
			set
			{
				_GCATEGORY_PARENT_UUID=value;
			}
			get
			{
				return _GCATEGORY_PARENT_UUID;
			}
		}
		public Gcategory_Record Clone(){
			try{
				return this.Clone<Gcategory_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public Gcategory gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Gcategory ret = new Gcategory(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<Goods_Record> Link_Goods_By_GcategoryUuid()
		{
			try{
				List<Goods_Record> ret= new List<Goods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Goods ___table = new Goods(dbc);
				ret=(List<Goods_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.GCATEGORY_UUID,this.GCATEGORY_UUID))
					.FetchAll<Goods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<Goods_Record> Link_Goods_By_GcategoryUuid(OrderLimit limit)
		{
			try{
				List<Goods_Record> ret= new List<Goods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Goods ___table = new Goods(dbc);
				ret=(List<Goods_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.GCATEGORY_UUID,this.GCATEGORY_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<Goods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public Goods LinkFill_Goods_By_GcategoryUuid()
		{
			try{
				var data = Link_Goods_By_GcategoryUuid();
				Goods ret=new Goods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public Goods LinkFill_Goods_By_GcategoryUuid(OrderLimit limit)
		{
			try{
				var data = Link_Goods_By_GcategoryUuid(limit);
				Goods ret=new Goods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
