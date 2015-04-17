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
	[TableView("V_MY_ORDER_DETAIL", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class VMyOrderDetail_Record : RecordBase{
		public VMyOrderDetail_Record(){}
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
		string _MY_ORDER_DETAIL_UUID=null;
		string _MY_ORDER_DETAIL_ATTENDANT_UUID=null;
		int? _MY_ORDER_DETAIL_GOODS_COUNT=null;
		string _MY_ORDER_DETAIL_GOODS_NAME=null;
		decimal? _MY_ORDER_DETAIL_PRICE=null;
		decimal? _MY_ORDER_DETAIL_TOTAL_PRICE=null;
		string _SUPPLIER_GOODS_UUID=null;
		string _MY_ORDER_DETAIL_ATTENDANT_C_NAME=null;
		string _UNIT_UUID=null;
		string _MY_ORDER_DETAIL_UNIT_NAME=null;
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

		[ColumnName("MY_ORDER_DETAIL_ATTENDANT_C_NAME",false,typeof(string))]
		public string MY_ORDER_DETAIL_ATTENDANT_C_NAME
		{
			set
			{
				_MY_ORDER_DETAIL_ATTENDANT_C_NAME=value;
			}
			get
			{
				return _MY_ORDER_DETAIL_ATTENDANT_C_NAME;
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

		[ColumnName("MY_ORDER_DETAIL_UNIT_NAME",false,typeof(string))]
		public string MY_ORDER_DETAIL_UNIT_NAME
		{
			set
			{
				_MY_ORDER_DETAIL_UNIT_NAME=value;
			}
			get
			{
				return _MY_ORDER_DETAIL_UNIT_NAME;
			}
		}
		public VMyOrderDetail_Record Clone(){
			try{
				return this.Clone<VMyOrderDetail_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VMyOrderDetail gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VMyOrderDetail ret = new VMyOrderDetail(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
