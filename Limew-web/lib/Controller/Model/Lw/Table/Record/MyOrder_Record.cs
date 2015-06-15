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
	[TableView("MY_ORDER", true)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class MyOrder_Record : RecordBase{
		public MyOrder_Record(){}
		/*欄位資訊 Start*/
		string _MY_ORDER_UUID=null;
		string _SUPPLIER_UUID=null;
		string _MY_ORDER_SUPPLIER_NAME=null;
		string _MY_ORDER_SUPPLIER_TEL=null;
		string _MY_ORDER_SUPPLIER_FAX=null;
		string _MY_ORDER_SUPPLIER_ADDRESS=null;
		string _MY_ORDER_CONTACT_NAME=null;
		string _MY_ORDER_CONTACT_PHONE=null;
		string _MY_ORDER_CONTACT_EMAIL=null;
		string _MY_ORDER_PS=null;
		DateTime? _MY_ORDER_CR=null;
		decimal? _MY_ORDER_TOTAL_PRICE=null;
		int? _MY_ORDER_IS_ACTIVE=null;
		string _MY_ORDER_ID=null;
		/*欄位資訊 End*/

		[ColumnName("MY_ORDER_UUID",true,typeof(string))]
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

		[ColumnName("MY_ORDER_SUPPLIER_NAME",false,typeof(string))]
		public string MY_ORDER_SUPPLIER_NAME
		{
			set
			{
				_MY_ORDER_SUPPLIER_NAME=value;
			}
			get
			{
				return _MY_ORDER_SUPPLIER_NAME;
			}
		}

		[ColumnName("MY_ORDER_SUPPLIER_TEL",false,typeof(string))]
		public string MY_ORDER_SUPPLIER_TEL
		{
			set
			{
				_MY_ORDER_SUPPLIER_TEL=value;
			}
			get
			{
				return _MY_ORDER_SUPPLIER_TEL;
			}
		}

		[ColumnName("MY_ORDER_SUPPLIER_FAX",false,typeof(string))]
		public string MY_ORDER_SUPPLIER_FAX
		{
			set
			{
				_MY_ORDER_SUPPLIER_FAX=value;
			}
			get
			{
				return _MY_ORDER_SUPPLIER_FAX;
			}
		}

		[ColumnName("MY_ORDER_SUPPLIER_ADDRESS",false,typeof(string))]
		public string MY_ORDER_SUPPLIER_ADDRESS
		{
			set
			{
				_MY_ORDER_SUPPLIER_ADDRESS=value;
			}
			get
			{
				return _MY_ORDER_SUPPLIER_ADDRESS;
			}
		}

		[ColumnName("MY_ORDER_CONTACT_NAME",false,typeof(string))]
		public string MY_ORDER_CONTACT_NAME
		{
			set
			{
				_MY_ORDER_CONTACT_NAME=value;
			}
			get
			{
				return _MY_ORDER_CONTACT_NAME;
			}
		}

		[ColumnName("MY_ORDER_CONTACT_PHONE",false,typeof(string))]
		public string MY_ORDER_CONTACT_PHONE
		{
			set
			{
				_MY_ORDER_CONTACT_PHONE=value;
			}
			get
			{
				return _MY_ORDER_CONTACT_PHONE;
			}
		}

		[ColumnName("MY_ORDER_CONTACT_EMAIL",false,typeof(string))]
		public string MY_ORDER_CONTACT_EMAIL
		{
			set
			{
				_MY_ORDER_CONTACT_EMAIL=value;
			}
			get
			{
				return _MY_ORDER_CONTACT_EMAIL;
			}
		}

		[ColumnName("MY_ORDER_PS",false,typeof(string))]
		public string MY_ORDER_PS
		{
			set
			{
				_MY_ORDER_PS=value;
			}
			get
			{
				return _MY_ORDER_PS;
			}
		}

		[ColumnName("MY_ORDER_CR",false,typeof(DateTime?))]
		public DateTime? MY_ORDER_CR
		{
			set
			{
				_MY_ORDER_CR=value;
			}
			get
			{
				return _MY_ORDER_CR;
			}
		}

		[ColumnName("MY_ORDER_TOTAL_PRICE",false,typeof(decimal?))]
		public decimal? MY_ORDER_TOTAL_PRICE
		{
			set
			{
				_MY_ORDER_TOTAL_PRICE=value;
			}
			get
			{
				return _MY_ORDER_TOTAL_PRICE;
			}
		}

		[ColumnName("MY_ORDER_IS_ACTIVE",false,typeof(int?))]
		public int? MY_ORDER_IS_ACTIVE
		{
			set
			{
				_MY_ORDER_IS_ACTIVE=value;
			}
			get
			{
				return _MY_ORDER_IS_ACTIVE;
			}
		}

		[ColumnName("MY_ORDER_ID",false,typeof(string))]
		public string MY_ORDER_ID
		{
			set
			{
				_MY_ORDER_ID=value;
			}
			get
			{
				return _MY_ORDER_ID;
			}
		}
		public MyOrder_Record Clone(){
			try{
				return this.Clone<MyOrder_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public MyOrder gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				MyOrder ret = new MyOrder(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<MyOrderDetail_Record> Link_MyOrderDetail_By_MyOrderUuid()
		{
			try{
				List<MyOrderDetail_Record> ret= new List<MyOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				MyOrderDetail ___table = new MyOrderDetail(dbc);
				ret=(List<MyOrderDetail_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.MY_ORDER_UUID,this.MY_ORDER_UUID))
					.FetchAll<MyOrderDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<MyOrderDetail_Record> Link_MyOrderDetail_By_MyOrderUuid(OrderLimit limit)
		{
			try{
				List<MyOrderDetail_Record> ret= new List<MyOrderDetail_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				MyOrderDetail ___table = new MyOrderDetail(dbc);
				ret=(List<MyOrderDetail_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.MY_ORDER_UUID,this.MY_ORDER_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<MyOrderDetail_Record>() ; 
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
		/*201303180357*/
		public MyOrderDetail LinkFill_MyOrderDetail_By_MyOrderUuid()
		{
			try{
				var data = Link_MyOrderDetail_By_MyOrderUuid();
				MyOrderDetail ret=new MyOrderDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public MyOrderDetail LinkFill_MyOrderDetail_By_MyOrderUuid(OrderLimit limit)
		{
			try{
				var data = Link_MyOrderDetail_By_MyOrderUuid(limit);
				MyOrderDetail ret=new MyOrderDetail(data);
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
