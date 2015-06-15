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
	[TableView("GOODS", true)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class Goods_Record : RecordBase{
		public Goods_Record(){}
		/*欄位資訊 Start*/
		string _GOODS_UUID=null;
		string _GOODS_SN=null;
		decimal? _GOODS_COST=null;
		decimal? _GOODS_SALE=null;
		decimal? _GOODS_PRICE=null;
		int? _GOODS_FOCUS=null;
		int? _GOODS_IS_ACTIVE=null;
		string _SUPPLIER_UUID=null;
		string _GCATEGORY_UUID=null;
		string _GOODS_NAME=null;
		string _GOODS_PS=null;
		/*欄位資訊 End*/

		[ColumnName("GOODS_UUID",true,typeof(string))]
		public string GOODS_UUID
		{
			set
			{
				_GOODS_UUID=value;
			}
			get
			{
				return _GOODS_UUID;
			}
		}

		[ColumnName("GOODS_SN",false,typeof(string))]
		public string GOODS_SN
		{
			set
			{
				_GOODS_SN=value;
			}
			get
			{
				return _GOODS_SN;
			}
		}

		[ColumnName("GOODS_COST",false,typeof(decimal?))]
		public decimal? GOODS_COST
		{
			set
			{
				_GOODS_COST=value;
			}
			get
			{
				return _GOODS_COST;
			}
		}

		[ColumnName("GOODS_SALE",false,typeof(decimal?))]
		public decimal? GOODS_SALE
		{
			set
			{
				_GOODS_SALE=value;
			}
			get
			{
				return _GOODS_SALE;
			}
		}

		[ColumnName("GOODS_PRICE",false,typeof(decimal?))]
		public decimal? GOODS_PRICE
		{
			set
			{
				_GOODS_PRICE=value;
			}
			get
			{
				return _GOODS_PRICE;
			}
		}

		[ColumnName("GOODS_FOCUS",false,typeof(int?))]
		public int? GOODS_FOCUS
		{
			set
			{
				_GOODS_FOCUS=value;
			}
			get
			{
				return _GOODS_FOCUS;
			}
		}

		[ColumnName("GOODS_IS_ACTIVE",false,typeof(int?))]
		public int? GOODS_IS_ACTIVE
		{
			set
			{
				_GOODS_IS_ACTIVE=value;
			}
			get
			{
				return _GOODS_IS_ACTIVE;
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

		[ColumnName("GCATEGORY_UUID",false,typeof(string))]
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

		[ColumnName("GOODS_NAME",false,typeof(string))]
		public string GOODS_NAME
		{
			set
			{
				_GOODS_NAME=value;
			}
			get
			{
				return _GOODS_NAME;
			}
		}

		[ColumnName("GOODS_PS",false,typeof(string))]
		public string GOODS_PS
		{
			set
			{
				_GOODS_PS=value;
			}
			get
			{
				return _GOODS_PS;
			}
		}
		public Goods_Record Clone(){
			try{
				return this.Clone<Goods_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public Goods gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Goods ret = new Goods(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<CustOrderDetail_Record> Link_CustOrderDetail_By_GoodsUuid()
		{
			try{
				List<CustOrderDetail_Record> ret= new List<CustOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderDetail ___table = new CustOrderDetail(dbc);
				ret=(List<CustOrderDetail_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.GOODS_UUID,this.GOODS_UUID))
					.FetchAll<CustOrderDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<CustOrderDetail_Record> Link_CustOrderDetail_By_GoodsUuid(OrderLimit limit)
		{
			try{
				List<CustOrderDetail_Record> ret= new List<CustOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderDetail ___table = new CustOrderDetail(dbc);
				ret=(List<CustOrderDetail_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.GOODS_UUID,this.GOODS_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<CustOrderDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<Gcategory_Record> Link_Gcategory_By_GcategoryUuid()
		{
			try{
				List<Gcategory_Record> ret= new List<Gcategory_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Gcategory ___table = new Gcategory(dbc);
				ret=(List<Gcategory_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.GCATEGORY_UUID,this.GCATEGORY_UUID))
					.FetchAll<Gcategory_Record>() ; 
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
		public List<Gcategory_Record> Link_Gcategory_By_GcategoryUuid(OrderLimit limit)
		{
			try{
				List<Gcategory_Record> ret= new List<Gcategory_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Gcategory ___table = new Gcategory(dbc);
				ret=(List<Gcategory_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.GCATEGORY_UUID,this.GCATEGORY_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<Gcategory_Record>() ; 
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
		/*201303180357*/
		public CustOrderDetail LinkFill_CustOrderDetail_By_GoodsUuid()
		{
			try{
				var data = Link_CustOrderDetail_By_GoodsUuid();
				CustOrderDetail ret=new CustOrderDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public CustOrderDetail LinkFill_CustOrderDetail_By_GoodsUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrderDetail_By_GoodsUuid(limit);
				CustOrderDetail ret=new CustOrderDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public Gcategory LinkFill_Gcategory_By_GcategoryUuid()
		{
			try{
				var data = Link_Gcategory_By_GcategoryUuid();
				Gcategory ret=new Gcategory(data);
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
		public Gcategory LinkFill_Gcategory_By_GcategoryUuid(OrderLimit limit)
		{
			try{
				var data = Link_Gcategory_By_GcategoryUuid(limit);
				Gcategory ret=new Gcategory(data);
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
