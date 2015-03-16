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
	[TableView("V_CUST_ORDER_DETAIL", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class VCustOrderDetail_Record : RecordBase{
		public VCustOrderDetail_Record(){}
		/*欄位資訊 Start*/
		string _CUST_ORDER_DETAIL_UUID=null;
		string _CUST_ORDER_UUID=null;
		string _GOODS_UUID=null;
		string _CUST_ORDER_DETAIL_GOODS_NAME=null;
		int? _CUST_ORDER_DETAIL_COUNT=null;
		string _CUST_ORDER_DETAIL_UNIT=null;
		decimal? _CUST_ORDER_DETAIL_PRICE=null;
		decimal? _CUST_ORDER_DETAIL_TOTAL_PRICE=null;
		string _CUST_ORDER_DETAIL_PS=null;
		DateTime? _CUST_ORDER_DETAIL_CR=null;
		int? _CUST_ORDER_DETAIL_CUSTOMIZED=null;
		string _FILEGROUP_UUID=null;
		string _SUPPLIER_GOODS_UUID=null;
		int? _CUST_ORDER_DETAIL_IS_ACTIVE=null;
		string _GCATEGORY_FULL_NAME=null;
		string _GCATEGORY_NAME=null;
		string _GCATEGORY_UUID=null;
		string _GOODS_NAME=null;
		decimal? _GOODS_PRICE=null;
		string _GOODS_PS=null;
		string _GOODS_SN=null;
		string _SUPPLIER_GOODS_NAME=null;
		decimal? _SUPPLIER_GOODS_PRICE=null;
		string _SUPPLIER_GOODS_SN=null;
		string _SUPPLIER_GOODS_UNIT_UUID=null;
		string _UNIT_NAME=null;
		string _CUST_ORDER_DETAIL_UNIT_NAME=null;
		string _FILEGROUP_DISPLAY_NAME=null;
		string _FILEGROUP_TAG=null;
		string _FILE_COUNT=null;
		/*欄位資訊 End*/

		[ColumnName("CUST_ORDER_DETAIL_UUID",true,typeof(string))]
		public string CUST_ORDER_DETAIL_UUID
		{
			set
			{
				_CUST_ORDER_DETAIL_UUID=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_UUID;
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

		[ColumnName("CUST_ORDER_DETAIL_GOODS_NAME",false,typeof(string))]
		public string CUST_ORDER_DETAIL_GOODS_NAME
		{
			set
			{
				_CUST_ORDER_DETAIL_GOODS_NAME=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_GOODS_NAME;
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

		[ColumnName("CUST_ORDER_DETAIL_CUSTOMIZED",false,typeof(int?))]
		public int? CUST_ORDER_DETAIL_CUSTOMIZED
		{
			set
			{
				_CUST_ORDER_DETAIL_CUSTOMIZED=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_CUSTOMIZED;
			}
		}

		[ColumnName("FILEGROUP_UUID",false,typeof(string))]
		public string FILEGROUP_UUID
		{
			set
			{
				_FILEGROUP_UUID=value;
			}
			get
			{
				return _FILEGROUP_UUID;
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

		[ColumnName("CUST_ORDER_DETAIL_IS_ACTIVE",false,typeof(int?))]
		public int? CUST_ORDER_DETAIL_IS_ACTIVE
		{
			set
			{
				_CUST_ORDER_DETAIL_IS_ACTIVE=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_IS_ACTIVE;
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

		[ColumnName("SUPPLIER_GOODS_UNIT_UUID",false,typeof(string))]
		public string SUPPLIER_GOODS_UNIT_UUID
		{
			set
			{
				_SUPPLIER_GOODS_UNIT_UUID=value;
			}
			get
			{
				return _SUPPLIER_GOODS_UNIT_UUID;
			}
		}

		[ColumnName("UNIT_NAME",false,typeof(string))]
		public string UNIT_NAME
		{
			set
			{
				_UNIT_NAME=value;
			}
			get
			{
				return _UNIT_NAME;
			}
		}

		[ColumnName("CUST_ORDER_DETAIL_UNIT_NAME",false,typeof(string))]
		public string CUST_ORDER_DETAIL_UNIT_NAME
		{
			set
			{
				_CUST_ORDER_DETAIL_UNIT_NAME=value;
			}
			get
			{
				return _CUST_ORDER_DETAIL_UNIT_NAME;
			}
		}

		[ColumnName("FILEGROUP_DISPLAY_NAME",false,typeof(string))]
		public string FILEGROUP_DISPLAY_NAME
		{
			set
			{
				_FILEGROUP_DISPLAY_NAME=value;
			}
			get
			{
				return _FILEGROUP_DISPLAY_NAME;
			}
		}

		[ColumnName("FILEGROUP_TAG",false,typeof(string))]
		public string FILEGROUP_TAG
		{
			set
			{
				_FILEGROUP_TAG=value;
			}
			get
			{
				return _FILEGROUP_TAG;
			}
		}

		[ColumnName("FILE_COUNT",false,typeof(string))]
		public string FILE_COUNT
		{
			set
			{
				_FILE_COUNT=value;
			}
			get
			{
				return _FILE_COUNT;
			}
		}
		public VCustOrderDetail_Record Clone(){
			try{
				return this.Clone<VCustOrderDetail_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VCustOrderDetail gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VCustOrderDetail ret = new VCustOrderDetail(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
