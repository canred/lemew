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
	[TableView("MY_ORDER_DETAIL", true)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class MyOrderDetail_Record : RecordBase{
		public MyOrderDetail_Record(){}
		/*欄位資訊 Start*/
		string _MY_ORDER_DETAIL_UUID=null;
		string _MY_ORDER_DETAIL_GOODS_NAME=null;
		int? _MY_ORDER_DETAIL_GOODS_COUNT=null;
		decimal? _MY_ORDER_DETAIL_PRICE=null;
		decimal? _MY_ORDER_DETAIL_TOTAL_PRICE=null;
		int? _MY_ORDER_DETAIL_IS_FINISH=null;
		int? _MY_ORDER_DETAIL_IS_ACTIVE=null;
		string _MY_ORDER_DETAIL_ATTENDANT_UUID=null;
		string _SUPPLIER_GOODS_UUID=null;
		string _MY_ORDER_UUID=null;
		string _UNIT_UUID=null;
		string _MY_ORDER_DETAIL_PS=null;
		/*欄位資訊 End*/

		[ColumnName("MY_ORDER_DETAIL_UUID",true,typeof(string))]
		public string MY_ORDER_DETAIL_UUID
		{
			set
			{
				_MY_ORDER_DETAIL_UUID=value;
			}
			get
			{
				return _MY_ORDER_DETAIL_UUID;
			}
		}

		[ColumnName("MY_ORDER_DETAIL_GOODS_NAME",false,typeof(string))]
		public string MY_ORDER_DETAIL_GOODS_NAME
		{
			set
			{
				_MY_ORDER_DETAIL_GOODS_NAME=value;
			}
			get
			{
				return _MY_ORDER_DETAIL_GOODS_NAME;
			}
		}

		[ColumnName("MY_ORDER_DETAIL_GOODS_COUNT",false,typeof(int?))]
		public int? MY_ORDER_DETAIL_GOODS_COUNT
		{
			set
			{
				_MY_ORDER_DETAIL_GOODS_COUNT=value;
			}
			get
			{
				return _MY_ORDER_DETAIL_GOODS_COUNT;
			}
		}

		[ColumnName("MY_ORDER_DETAIL_PRICE",false,typeof(decimal?))]
		public decimal? MY_ORDER_DETAIL_PRICE
		{
			set
			{
				_MY_ORDER_DETAIL_PRICE=value;
			}
			get
			{
				return _MY_ORDER_DETAIL_PRICE;
			}
		}

		[ColumnName("MY_ORDER_DETAIL_TOTAL_PRICE",false,typeof(decimal?))]
		public decimal? MY_ORDER_DETAIL_TOTAL_PRICE
		{
			set
			{
				_MY_ORDER_DETAIL_TOTAL_PRICE=value;
			}
			get
			{
				return _MY_ORDER_DETAIL_TOTAL_PRICE;
			}
		}

		[ColumnName("MY_ORDER_DETAIL_IS_FINISH",false,typeof(int?))]
		public int? MY_ORDER_DETAIL_IS_FINISH
		{
			set
			{
				_MY_ORDER_DETAIL_IS_FINISH=value;
			}
			get
			{
				return _MY_ORDER_DETAIL_IS_FINISH;
			}
		}

		[ColumnName("MY_ORDER_DETAIL_IS_ACTIVE",false,typeof(int?))]
		public int? MY_ORDER_DETAIL_IS_ACTIVE
		{
			set
			{
				_MY_ORDER_DETAIL_IS_ACTIVE=value;
			}
			get
			{
				return _MY_ORDER_DETAIL_IS_ACTIVE;
			}
		}

		[ColumnName("MY_ORDER_DETAIL_ATTENDANT_UUID",false,typeof(string))]
		public string MY_ORDER_DETAIL_ATTENDANT_UUID
		{
			set
			{
				_MY_ORDER_DETAIL_ATTENDANT_UUID=value;
			}
			get
			{
				return _MY_ORDER_DETAIL_ATTENDANT_UUID;
			}
		}

		[ColumnName("SUPPLIER_GOODS_UUID",false,typeof(string))]
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

		[ColumnName("MY_ORDER_UUID",false,typeof(string))]
		public string MY_ORDER_UUID
		{
			set
			{
				_MY_ORDER_UUID=value;
			}
			get
			{
				return _MY_ORDER_UUID;
			}
		}

		[ColumnName("UNIT_UUID",false,typeof(string))]
		public string UNIT_UUID
		{
			set
			{
				_UNIT_UUID=value;
			}
			get
			{
				return _UNIT_UUID;
			}
		}

		[ColumnName("MY_ORDER_DETAIL_PS",false,typeof(string))]
		public string MY_ORDER_DETAIL_PS
		{
			set
			{
				_MY_ORDER_DETAIL_PS=value;
			}
			get
			{
				return _MY_ORDER_DETAIL_PS;
			}
		}
		public MyOrderDetail_Record Clone(){
			try{
				return this.Clone<MyOrderDetail_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public MyOrderDetail gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				MyOrderDetail ret = new MyOrderDetail(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<MyOrder_Record> Link_MyOrder_By_MyOrderUuid()
		{
			try{
				List<MyOrder_Record> ret= new List<MyOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				MyOrder ___table = new MyOrder(dbc);
				ret=(List<MyOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.MY_ORDER_UUID,this.MY_ORDER_UUID))
					.FetchAll<MyOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<SupplierGoods_Record> Link_SupplierGoods_By_SupplierGoodsUuid()
		{
			try{
				List<SupplierGoods_Record> ret= new List<SupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				SupplierGoods ___table = new SupplierGoods(dbc);
				ret=(List<SupplierGoods_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.SUPPLIER_GOODS_UUID,this.SUPPLIER_GOODS_UUID))
					.FetchAll<SupplierGoods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<MyOrder_Record> Link_MyOrder_By_MyOrderUuid(OrderLimit limit)
		{
			try{
				List<MyOrder_Record> ret= new List<MyOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				MyOrder ___table = new MyOrder(dbc);
				ret=(List<MyOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.MY_ORDER_UUID,this.MY_ORDER_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<MyOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<SupplierGoods_Record> Link_SupplierGoods_By_SupplierGoodsUuid(OrderLimit limit)
		{
			try{
				List<SupplierGoods_Record> ret= new List<SupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				SupplierGoods ___table = new SupplierGoods(dbc);
				ret=(List<SupplierGoods_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.SUPPLIER_GOODS_UUID,this.SUPPLIER_GOODS_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<SupplierGoods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public MyOrder LinkFill_MyOrder_By_MyOrderUuid()
		{
			try{
				var data = Link_MyOrder_By_MyOrderUuid();
				MyOrder ret=new MyOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public SupplierGoods LinkFill_SupplierGoods_By_SupplierGoodsUuid()
		{
			try{
				var data = Link_SupplierGoods_By_SupplierGoodsUuid();
				SupplierGoods ret=new SupplierGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public MyOrder LinkFill_MyOrder_By_MyOrderUuid(OrderLimit limit)
		{
			try{
				var data = Link_MyOrder_By_MyOrderUuid(limit);
				MyOrder ret=new MyOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public SupplierGoods LinkFill_SupplierGoods_By_SupplierGoodsUuid(OrderLimit limit)
		{
			try{
				var data = Link_SupplierGoods_By_SupplierGoodsUuid(limit);
				SupplierGoods ret=new SupplierGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
