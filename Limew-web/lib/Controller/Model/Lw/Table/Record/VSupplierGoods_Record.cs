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
	[TableView("V_SUPPLIER_GOODS", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class VSupplierGoods_Record : RecordBase{
		public VSupplierGoods_Record(){}
		/*欄位資訊 Start*/
		string _SUPPLIER_NAME=null;
		string _SUPPLIER_GOODS_UUID=null;
		string _SUPPLIER_GOODS_NAME=null;
		string _UNIT_UUID=null;
		string _SUPPLIER_GOODS_SN=null;
		decimal? _SUPPLIER_GOODS_PRICE=null;
		decimal? _SUPPLIER_GOODS_COST=null;
		int? _SUPPLIER_GOODS_IS_ACTIVE=null;
		string _SUPPLIER_UUID=null;
		string _UNIT_NAME=null;
		/*欄位資訊 End*/

		[ColumnName("SUPPLIER_NAME",false,typeof(string))]
		public string SUPPLIER_NAME
		{
			set
			{
				_SUPPLIER_NAME=value;
			}
			get
			{
				return _SUPPLIER_NAME;
			}
		}

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

		[ColumnName("SUPPLIER_GOODS_COST",false,typeof(decimal?))]
		public decimal? SUPPLIER_GOODS_COST
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

		[ColumnName("SUPPLIER_UUID",true,typeof(string))]
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
		public VSupplierGoods_Record Clone(){
			try{
				return this.Clone<VSupplierGoods_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VSupplierGoods gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VSupplierGoods ret = new VSupplierGoods(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
