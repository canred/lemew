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
	[TableView("MY_ORDER", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class MyOrder_Record : RecordBase{
		public MyOrder_Record(){}
		/*欄位資訊 Start*/
		string _MY_ORDER_UUID=null;
		DateTime? _MY_ORDER_DATE=null;
		string _MY_ORDER_SUPPLIER_NAME=null;
		string _MY_ORDER_SUPPLIER_TEL=null;
		string _MY_ORDER_SUPPLIER_MAN=null;
		string _MY_ORDER_GOODS_NAME=null;
		int? _MY_ORDER_GOODS_COUNT=null;
		decimal? _MY_ORDER_PRICE=null;
		decimal? _MY_ORDER_TOTAL_PRICE=null;
		string _MY_ORDER_PS=null;
		int? _MY_ORDER_IS_FINISH=null;
		string _MY_ORDER_PAY_METHOD=null;
		int? _MY_ORDER_IS_ACTIVE=null;
		string _MY_ORDER_ATTENDANT_UUID=null;
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

		[ColumnName("MY_ORDER_DATE",false,typeof(DateTime?))]
		public DateTime? MY_ORDER_DATE
		{
			set
			{
				_MY_ORDER_DATE=value;
			}
			get
			{
				return _MY_ORDER_DATE;
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

		[ColumnName("MY_ORDER_SUPPLIER_MAN",false,typeof(string))]
		public string MY_ORDER_SUPPLIER_MAN
		{
			set
			{
				_MY_ORDER_SUPPLIER_MAN=value;
			}
			get
			{
				return _MY_ORDER_SUPPLIER_MAN;
			}
		}

		[ColumnName("MY_ORDER_GOODS_NAME",false,typeof(string))]
		public string MY_ORDER_GOODS_NAME
		{
			set
			{
				_MY_ORDER_GOODS_NAME=value;
			}
			get
			{
				return _MY_ORDER_GOODS_NAME;
			}
		}

		[ColumnName("MY_ORDER_GOODS_COUNT",false,typeof(int?))]
		public int? MY_ORDER_GOODS_COUNT
		{
			set
			{
				_MY_ORDER_GOODS_COUNT=value;
			}
			get
			{
				return _MY_ORDER_GOODS_COUNT;
			}
		}

		[ColumnName("MY_ORDER_PRICE",false,typeof(decimal?))]
		public decimal? MY_ORDER_PRICE
		{
			set
			{
				_MY_ORDER_PRICE=value;
			}
			get
			{
				return _MY_ORDER_PRICE;
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

		[ColumnName("MY_ORDER_IS_FINISH",false,typeof(int?))]
		public int? MY_ORDER_IS_FINISH
		{
			set
			{
				_MY_ORDER_IS_FINISH=value;
			}
			get
			{
				return _MY_ORDER_IS_FINISH;
			}
		}

		[ColumnName("MY_ORDER_PAY_METHOD",false,typeof(string))]
		public string MY_ORDER_PAY_METHOD
		{
			set
			{
				_MY_ORDER_PAY_METHOD=value;
			}
			get
			{
				return _MY_ORDER_PAY_METHOD;
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

		[ColumnName("MY_ORDER_ATTENDANT_UUID",false,typeof(string))]
		public string MY_ORDER_ATTENDANT_UUID
		{
			set
			{
				_MY_ORDER_ATTENDANT_UUID=value;
			}
			get
			{
				return _MY_ORDER_ATTENDANT_UUID;
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
	}
}
