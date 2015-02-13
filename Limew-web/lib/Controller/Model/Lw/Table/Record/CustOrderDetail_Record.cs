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
	[TableView("CUST_ORDER_DETAIL", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class CustOrderDetail_Record : RecordBase{
		public CustOrderDetail_Record(){}
		/*欄位資訊 Start*/
		string _CUSR_ORDER_DETAIL_UUID=null;
		string _CUST_ORDER_UUID=null;
		string _GOODS_UUID=null;
		string _CUST_ORDER_DETAIL_GOOGDS_NAME=null;
		int? _CUST_ORDER_DETAIL_COUNT=null;
		string _CUST_ORDER_DETAIL_UNIT=null;
		decimal? _CUST_ORDER_DETAIL_PRICE=null;
		decimal? _CUST_ORDER_DETAIL_TOTAL_PRICE=null;
		string _CUST_ORDER_DETAIL_PS=null;
		DateTime? _CUST_ORDER_DETAIL_CR=null;
		/*欄位資訊 End*/

		[ColumnName("CUSR_ORDER_DETAIL_UUID",true,typeof(string))]
		public string CUSR_ORDER_DETAIL_UUID
		{
			set
			{
				_CUSR_ORDER_DETAIL_UUID=value;
			}
			get
			{
				return _CUSR_ORDER_DETAIL_UUID;
			}
		}

		[ColumnName("CUST_ORDER_UUID",false,typeof(string))]
		public string CUST_ORDER_UUID
		{
			set
			{
				_CUST_ORDER_UUID=value;
			}
			get
			{
				return _CUST_ORDER_UUID;
			}
		}

		[ColumnName("GOODS_UUID",false,typeof(string))]
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

		[ColumnName("CUST_ORDER_DETAIL_GOOGDS_NAME",false,typeof(string))]
		public string CUST_ORDER_DETAIL_GOOGDS_NAME
		{
			set
			{
				_CUST_ORDER_DETAIL_GOOGDS_NAME=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_GOOGDS_NAME;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_COUNT",false,typeof(int?))]
		public int? CUST_ORDER_DETAIL_COUNT
		{
			set
			{
				_CUST_ORDER_DETAIL_COUNT=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_COUNT;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_UNIT",false,typeof(string))]
		public string CUST_ORDER_DETAIL_UNIT
		{
			set
			{
				_CUST_ORDER_DETAIL_UNIT=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_UNIT;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_PRICE",false,typeof(decimal?))]
		public decimal? CUST_ORDER_DETAIL_PRICE
		{
			set
			{
				_CUST_ORDER_DETAIL_PRICE=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_PRICE;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_TOTAL_PRICE",false,typeof(decimal?))]
		public decimal? CUST_ORDER_DETAIL_TOTAL_PRICE
		{
			set
			{
				_CUST_ORDER_DETAIL_TOTAL_PRICE=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_TOTAL_PRICE;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_PS",false,typeof(string))]
		public string CUST_ORDER_DETAIL_PS
		{
			set
			{
				_CUST_ORDER_DETAIL_PS=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_PS;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_CR",false,typeof(DateTime?))]
		public DateTime? CUST_ORDER_DETAIL_CR
		{
			set
			{
				_CUST_ORDER_DETAIL_CR=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_CR;
			}
		}
		public CustOrderDetail_Record Clone(){
			try{
				return this.Clone<CustOrderDetail_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public CustOrderDetail gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrderDetail ret = new CustOrderDetail(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<CustOrder_Record> Link_CustOrder_By_CustOrderUuid()
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				ret=(List<CustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORDER_UUID,this.CUST_ORDER_UUID))
					.FetchAll<CustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<Goods_Record> Link_Goods_By_GoodsUuid()
		{
			try{
				List<Goods_Record> ret= new List<Goods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Goods ___table = new Goods(dbc);
				ret=(List<Goods_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.GOODS_UUID,this.GOODS_UUID))
					.FetchAll<Goods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<CustOrder_Record> Link_CustOrder_By_CustOrderUuid(OrderLimit limit)
		{
			try{
				List<CustOrder_Record> ret= new List<CustOrder_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				CustOrder ___table = new CustOrder(dbc);
				ret=(List<CustOrder_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.CUST_ORDER_UUID,this.CUST_ORDER_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<CustOrder_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<Goods_Record> Link_Goods_By_GoodsUuid(OrderLimit limit)
		{
			try{
				List<Goods_Record> ret= new List<Goods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Goods ___table = new Goods(dbc);
				ret=(List<Goods_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.GOODS_UUID,this.GOODS_UUID))
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
		/*2013031800428*/
		public CustOrder LinkFill_CustOrder_By_CustOrderUuid()
		{
			try{
				var data = Link_CustOrder_By_CustOrderUuid();
				CustOrder ret=new CustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public Goods LinkFill_Goods_By_GoodsUuid()
		{
			try{
				var data = Link_Goods_By_GoodsUuid();
				Goods ret=new Goods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public CustOrder LinkFill_CustOrder_By_CustOrderUuid(OrderLimit limit)
		{
			try{
				var data = Link_CustOrder_By_CustOrderUuid(limit);
				CustOrder ret=new CustOrder(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public Goods LinkFill_Goods_By_GoodsUuid(OrderLimit limit)
		{
			try{
				var data = Link_Goods_By_GoodsUuid(limit);
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
