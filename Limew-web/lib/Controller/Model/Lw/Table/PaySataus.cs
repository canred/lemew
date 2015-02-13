using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using LK.Attribute;  
using LK.DB;  
using LK.Config.DataBase;  
using LK.DB.SQLCreater;  
using Limew.Model.Lw.Table.Record  ;  
namespace Limew.Model.Lw.Table
{
	[LkDataBase("LIMEW")]
	[TableView("PAY_SATAUS", false)]
	public partial class PaySataus : TableBase{
	/*固定物件*/
	//LK.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private PaySataus_Record _currentRecord = null;
	private IList<PaySataus_Record> _All_Record = new List<PaySataus_Record>();
		/*建構子*/
		public PaySataus(){}
		public PaySataus(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public PaySataus(IDataBaseConfigInfo dbc): base(dbc){}
		public PaySataus(IDataBaseConfigInfo dbc,PaySataus_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public PaySataus(IList<PaySataus_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public PaySataus_Record CurrentRecord(){
			try{
				if (_currentRecord == null){
					if (this._All_Record.Count > 0){
						_currentRecord = this._All_Record.First();
					}
				}
				return _currentRecord;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public PaySataus_Record CreateNew(){
			try{
				PaySataus_Record newData = new PaySataus_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<PaySataus_Record> AllRecord(){
			try{
				return _All_Record;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public void RemoveAllRecord(){
			try{
				_All_Record = new List<PaySataus_Record>();
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		/*依照資料表與資料表的關係，產生出來的方法*/
	}
}
