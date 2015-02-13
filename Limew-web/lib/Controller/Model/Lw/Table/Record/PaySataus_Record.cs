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
	[TableView("PAY_SATAUS", false)]
	[LkDataBase("LIMEW")]
	[Serializable]
	public class PaySataus_Record : RecordBase{
		public PaySataus_Record(){}
		/*欄位資訊 Start*/
		/*欄位資訊 End*/
		public PaySataus_Record Clone(){
			try{
				return this.Clone<PaySataus_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public PaySataus gotoTable(){
			try{
				var dbc = LK.Config.DataBase.Factory.getInfo();
				PaySataus ret = new PaySataus(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
