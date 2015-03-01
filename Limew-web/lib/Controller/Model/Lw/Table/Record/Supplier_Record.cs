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
	[TableView("SUPPLIER", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class Supplier_Record : RecordBase{
		public Supplier_Record(){}
		/*欄位資訊 Start*/
		string _SUPPLIER_UUID=null;
		string _SUPPLIER_NAME=null;
		string _SUPPLIER_TEL=null;
		string _SUPPLIER_FAX=null;
		string _SUPPLIER_ADDRESS=null;
		string _SUPPLIER_CONTACT_NAME=null;
		string _SUPPLIER_SALES_NAME=null;
		string _SUPPLIER_SALES_PHONE=null;
		string _SUPPLIER_CONTACT_PHONE=null;
		string _SUPPLIER_CONTACT_EMAIL=null;
		string _SUPPLIER_SALES_EMAIL=null;
		string _SUPPLIER_PS=null;
		int? _SUPPLIER_IS_ACTIVE=null;
		/*欄位資訊 End*/

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

		[ColumnName("SUPPLIER_TEL",false,typeof(string))]
		public string SUPPLIER_TEL
		{
			set
			{
				_SUPPLIER_TEL=value;
			}
			get
			{
				return _SUPPLIER_TEL;
			}
		}

		[ColumnName("SUPPLIER_FAX",false,typeof(string))]
		public string SUPPLIER_FAX
		{
			set
			{
				_SUPPLIER_FAX=value;
			}
			get
			{
				return _SUPPLIER_FAX;
			}
		}

		[ColumnName("SUPPLIER_ADDRESS",false,typeof(string))]
		public string SUPPLIER_ADDRESS
		{
			set
			{
				_SUPPLIER_ADDRESS=value;
			}
			get
			{
				return _SUPPLIER_ADDRESS;
			}
		}

		[ColumnName("SUPPLIER_CONTACT_NAME",false,typeof(string))]
		public string SUPPLIER_CONTACT_NAME
		{
			set
			{
				_SUPPLIER_CONTACT_NAME=value;
			}
			get
			{
				return _SUPPLIER_CONTACT_NAME;
			}
		}

		[ColumnName("SUPPLIER_SALES_NAME",false,typeof(string))]
		public string SUPPLIER_SALES_NAME
		{
			set
			{
				_SUPPLIER_SALES_NAME=value;
			}
			get
			{
				return _SUPPLIER_SALES_NAME;
			}
		}

		[ColumnName("SUPPLIER_SALES_PHONE",false,typeof(string))]
		public string SUPPLIER_SALES_PHONE
		{
			set
			{
				_SUPPLIER_SALES_PHONE=value;
			}
			get
			{
				return _SUPPLIER_SALES_PHONE;
			}
		}

		[ColumnName("SUPPLIER_CONTACT_PHONE",false,typeof(string))]
		public string SUPPLIER_CONTACT_PHONE
		{
			set
			{
				_SUPPLIER_CONTACT_PHONE=value;
			}
			get
			{
				return _SUPPLIER_CONTACT_PHONE;
			}
		}

		[ColumnName("SUPPLIER_CONTACT_EMAIL",false,typeof(string))]
		public string SUPPLIER_CONTACT_EMAIL
		{
			set
			{
				_SUPPLIER_CONTACT_EMAIL=value;
			}
			get
			{
				return _SUPPLIER_CONTACT_EMAIL;
			}
		}

		[ColumnName("SUPPLIER_SALES_EMAIL",false,typeof(string))]
		public string SUPPLIER_SALES_EMAIL
		{
			set
			{
				_SUPPLIER_SALES_EMAIL=value;
			}
			get
			{
				return _SUPPLIER_SALES_EMAIL;
			}
		}

		[ColumnName("SUPPLIER_PS",false,typeof(string))]
		public string SUPPLIER_PS
		{
			set
			{
				_SUPPLIER_PS=value;
			}
			get
			{
				return _SUPPLIER_PS;
			}
		}

		[ColumnName("SUPPLIER_IS_ACTIVE",false,typeof(int?))]
		public int? SUPPLIER_IS_ACTIVE
		{
			set
			{
				_SUPPLIER_IS_ACTIVE=value;
			}
			get
			{
				return _SUPPLIER_IS_ACTIVE;
			}
		}
		public Supplier_Record Clone(){
			try{
				return this.Clone<Supplier_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public Supplier gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Supplier ret = new Supplier(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<SupplierGoods_Record> Link_SupplierGoods_By_SupplierUuid()
		{
			try{
				List<SupplierGoods_Record> ret= new List<SupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				SupplierGoods ___table = new SupplierGoods(dbc);
				ret=(List<SupplierGoods_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.SUPPLIER_UUID,this.SUPPLIER_UUID))
					.FetchAll<SupplierGoods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<VGoods_Record> Link_VGoods_By_SupplierUuid()
		{
			try{
				List<VGoods_Record> ret= new List<VGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VGoods ___table = new VGoods(dbc);
				ret=(List<VGoods_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.SUPPLIER_UUID,this.SUPPLIER_UUID))
					.FetchAll<VGoods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<VSupplierGoods_Record> Link_VSupplierGoods_By_SupplierUuid()
		{
			try{
				List<VSupplierGoods_Record> ret= new List<VSupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VSupplierGoods ___table = new VSupplierGoods(dbc);
				ret=(List<VSupplierGoods_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.SUPPLIER_UUID,this.SUPPLIER_UUID))
					.FetchAll<VSupplierGoods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<SupplierGoods_Record> Link_SupplierGoods_By_SupplierUuid(OrderLimit limit)
		{
			try{
				List<SupplierGoods_Record> ret= new List<SupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				SupplierGoods ___table = new SupplierGoods(dbc);
				ret=(List<SupplierGoods_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.SUPPLIER_UUID,this.SUPPLIER_UUID))
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
		/*201303180348*/
		public List<VGoods_Record> Link_VGoods_By_SupplierUuid(OrderLimit limit)
		{
			try{
				List<VGoods_Record> ret= new List<VGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VGoods ___table = new VGoods(dbc);
				ret=(List<VGoods_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.SUPPLIER_UUID,this.SUPPLIER_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<VGoods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<VSupplierGoods_Record> Link_VSupplierGoods_By_SupplierUuid(OrderLimit limit)
		{
			try{
				List<VSupplierGoods_Record> ret= new List<VSupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				VSupplierGoods ___table = new VSupplierGoods(dbc);
				ret=(List<VSupplierGoods_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.SUPPLIER_UUID,this.SUPPLIER_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<VSupplierGoods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public SupplierGoods LinkFill_SupplierGoods_By_SupplierUuid()
		{
			try{
				var data = Link_SupplierGoods_By_SupplierUuid();
				SupplierGoods ret=new SupplierGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public VGoods LinkFill_VGoods_By_SupplierUuid()
		{
			try{
				var data = Link_VGoods_By_SupplierUuid();
				VGoods ret=new VGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public VSupplierGoods LinkFill_VSupplierGoods_By_SupplierUuid()
		{
			try{
				var data = Link_VSupplierGoods_By_SupplierUuid();
				VSupplierGoods ret=new VSupplierGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public SupplierGoods LinkFill_SupplierGoods_By_SupplierUuid(OrderLimit limit)
		{
			try{
				var data = Link_SupplierGoods_By_SupplierUuid(limit);
				SupplierGoods ret=new SupplierGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public VGoods LinkFill_VGoods_By_SupplierUuid(OrderLimit limit)
		{
			try{
				var data = Link_VGoods_By_SupplierUuid(limit);
				VGoods ret=new VGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public VSupplierGoods LinkFill_VSupplierGoods_By_SupplierUuid(OrderLimit limit)
		{
			try{
				var data = Link_VSupplierGoods_By_SupplierUuid(limit);
				VSupplierGoods ret=new VSupplierGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
