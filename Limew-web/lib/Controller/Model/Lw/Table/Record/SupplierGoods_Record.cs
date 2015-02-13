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
	[TableView("SUPPLIER_GOODS", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class SupplierGoods_Record : RecordBase{
		public SupplierGoods_Record(){}
		/*欄位資訊 Start*/
		string _SUPPLIER_GOODS_UUID=null;
		string _SUPPLIER_GOODS_NAME=null;
		string _SUPPLIER_GOODS_UNIT=null;
		string _SUPPLIER_GOODS_SN=null;
		string _SUPPLIER_GOODS_SPEC=null;
		decimal? _SUPPLIER_GOODS_PRICE=null;
		string _SUPPLIER_GOODS_COST=null;
		int? _SUPPLIER_GOODS_IS_ACTIVE=null;
		string _SUPPLIER_UUID=null;
		/*欄位資訊 End*/

		[ColumnName("SUPPLIER_GOODS_UUID",true,typeof(string))]
		public string SUPPLIER_GOODS_UUID
		{
			set
			{
				_SUPPLIER_GOODS_UUID=value;
			}
			get
			{
				return _SUPPLIER_GOODS_UUID;
			}
		}

		[ColumnName("SUPPLIER_GOODS_NAME",false,typeof(string))]
		public string SUPPLIER_GOODS_NAME
		{
			set
			{
				_SUPPLIER_GOODS_NAME=value;
			}
			get
			{
				return _SUPPLIER_GOODS_NAME;
			}
		}

		[ColumnName("SUPPLIER_GOODS_UNIT",false,typeof(string))]
		public string SUPPLIER_GOODS_UNIT
		{
			set
			{
				_SUPPLIER_GOODS_UNIT=value;
			}
			get
			{
				return _SUPPLIER_GOODS_UNIT;
			}
		}

		[ColumnName("SUPPLIER_GOODS_SN",false,typeof(string))]
		public string SUPPLIER_GOODS_SN
		{
			set
			{
				_SUPPLIER_GOODS_SN=value;
			}
			get
			{
				return _SUPPLIER_GOODS_SN;
			}
		}

		[ColumnName("SUPPLIER_GOODS_SPEC",false,typeof(string))]
		public string SUPPLIER_GOODS_SPEC
		{
			set
			{
				_SUPPLIER_GOODS_SPEC=value;
			}
			get
			{
				return _SUPPLIER_GOODS_SPEC;
			}
		}

		[ColumnName("SUPPLIER_GOODS_PRICE",false,typeof(decimal?))]
		public decimal? SUPPLIER_GOODS_PRICE
		{
			set
			{
				_SUPPLIER_GOODS_PRICE=value;
			}
			get
			{
				return _SUPPLIER_GOODS_PRICE;
			}
		}

		[ColumnName("SUPPLIER_GOODS_COST",false,typeof(string))]
		public string SUPPLIER_GOODS_COST
		{
			set
			{
				_SUPPLIER_GOODS_COST=value;
			}
			get
			{
				return _SUPPLIER_GOODS_COST;
			}
		}

		[ColumnName("SUPPLIER_GOODS_IS_ACTIVE",false,typeof(int?))]
		public int? SUPPLIER_GOODS_IS_ACTIVE
		{
			set
			{
				_SUPPLIER_GOODS_IS_ACTIVE=value;
			}
			get
			{
				return _SUPPLIER_GOODS_IS_ACTIVE;
			}
		}

		[ColumnName("SUPPLIER_UUID",false,typeof(string))]
		public string SUPPLIER_UUID
		{
			set
			{
				_SUPPLIER_UUID=value;
			}
			get
			{
				return _SUPPLIER_UUID;
			}
		}
		public SupplierGoods_Record Clone(){
			try{
				return this.Clone<SupplierGoods_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public SupplierGoods gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				SupplierGoods ret = new SupplierGoods(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<Supplier_Record> Link_Supplier_By_SupplierUuid()
		{
			try{
				List<Supplier_Record> ret= new List<Supplier_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Supplier ___table = new Supplier(dbc);
				ret=(List<Supplier_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.SUPPLIER_UUID,this.SUPPLIER_UUID))
					.FetchAll<Supplier_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<Supplier_Record> Link_Supplier_By_SupplierUuid(OrderLimit limit)
		{
			try{
				List<Supplier_Record> ret= new List<Supplier_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Supplier ___table = new Supplier(dbc);
				ret=(List<Supplier_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.SUPPLIER_UUID,this.SUPPLIER_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<Supplier_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public Supplier LinkFill_Supplier_By_SupplierUuid()
		{
			try{
				var data = Link_Supplier_By_SupplierUuid();
				Supplier ret=new Supplier(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public Supplier LinkFill_Supplier_By_SupplierUuid(OrderLimit limit)
		{
			try{
				var data = Link_Supplier_By_SupplierUuid(limit);
				Supplier ret=new Supplier(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}