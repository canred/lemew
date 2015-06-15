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
	[TableView("UNIT", true)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class Unit_Record : RecordBase{
		public Unit_Record(){}
		/*欄位資訊 Start*/
		string _UNIT_UUID=null;
		string _UNIT_NAME=null;
		int? _UNIT_IS_ACTIVE=null;
		/*欄位資訊 End*/

		[ColumnName("UNIT_UUID",true,typeof(string))]
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

		[ColumnName("UNIT_IS_ACTIVE",false,typeof(int?))]
		public int? UNIT_IS_ACTIVE
		{
			set
			{
				_UNIT_IS_ACTIVE=value;
			}
			get
			{
				return _UNIT_IS_ACTIVE;
			}
		}
		public Unit_Record Clone(){
			try{
				return this.Clone<Unit_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public Unit gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				Unit ret = new Unit(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<SupplierGoods_Record> Link_SupplierGoods_By_UnitUuid()
		{
			try{
				List<SupplierGoods_Record> ret= new List<SupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				SupplierGoods ___table = new SupplierGoods(dbc);
				ret=(List<SupplierGoods_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UNIT_UUID,this.UNIT_UUID))
					.FetchAll<SupplierGoods_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<SupplierGoods_Record> Link_SupplierGoods_By_UnitUuid(OrderLimit limit)
		{
			try{
				List<SupplierGoods_Record> ret= new List<SupplierGoods_Record>();
				var dbc = LK.Config.DataBase.Factory.getInfo();
				SupplierGoods ___table = new SupplierGoods(dbc);
				ret=(List<SupplierGoods_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UNIT_UUID,this.UNIT_UUID))
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
		/*201303180357*/
		public SupplierGoods LinkFill_SupplierGoods_By_UnitUuid()
		{
			try{
				var data = Link_SupplierGoods_By_UnitUuid();
				SupplierGoods ret=new SupplierGoods(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public SupplierGoods LinkFill_SupplierGoods_By_UnitUuid(OrderLimit limit)
		{
			try{
				var data = Link_SupplierGoods_By_UnitUuid(limit);
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
