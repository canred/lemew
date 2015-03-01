using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LK.Attribute;
using LK.DB;  
using log4net;  
using System.Reflection;  
using LK.DB.SQLCreater;  
using Limew.Model.Lw.Table;
namespace Limew.Model.Lw
{
	[ModelName("Lw")]
	[LkDataBase("LIMEW")]
	public partial class LwModel
	{
		public new static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		private LK.Config.DataBase.IDataBaseConfigInfo dbc = null;
		public LwModel(){}
		/*Templete Model A001*/
		public Limew.Model.Lw.Table.Cust getCust_By_CustUuid(string pCUST_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.Cust cust = new Limew.Model.Lw.Table.Cust(dbc);
				cust.Fill_By_PK(pCUST_UUID);
				return cust;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.CustOrder getCustOrder_By_CustOrderUuid(string pCUST_ORDER_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.CustOrder custorder = new Limew.Model.Lw.Table.CustOrder(dbc);
				custorder.Fill_By_PK(pCUST_ORDER_UUID);
				return custorder;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.CustOrderDetail getCustOrderDetail_By_CusrOrderDetailUuid(string pCUSR_ORDER_DETAIL_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.CustOrderDetail custorderdetail = new Limew.Model.Lw.Table.CustOrderDetail(dbc);
				custorderdetail.Fill_By_PK(pCUSR_ORDER_DETAIL_UUID);
				return custorderdetail;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.CustOrderStatus getCustOrderStatus_By_CustOrderStatusUuid(string pCUST_ORDER_STATUS_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.CustOrderStatus custorderstatus = new Limew.Model.Lw.Table.CustOrderStatus(dbc);
				custorderstatus.Fill_By_PK(pCUST_ORDER_STATUS_UUID);
				return custorderstatus;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.Gcategory getGcategory_By_GcategoryUuid(string pGCATEGORY_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.Gcategory gcategory = new Limew.Model.Lw.Table.Gcategory(dbc);
				gcategory.Fill_By_PK(pGCATEGORY_UUID);
				return gcategory;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.Goods getGoods_By_GoodsUuid(string pGOODS_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.Goods goods = new Limew.Model.Lw.Table.Goods(dbc);
				goods.Fill_By_PK(pGOODS_UUID);
				return goods;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.PayMethod getPayMethod_By_PayMethodUuid(string pPAY_METHOD_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.PayMethod paymethod = new Limew.Model.Lw.Table.PayMethod(dbc);
				paymethod.Fill_By_PK(pPAY_METHOD_UUID);
				return paymethod;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.ShippingStatus getShippingStatus_By_ShippingStatusUuid(string pSHIPPING_STATUS_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.ShippingStatus shippingstatus = new Limew.Model.Lw.Table.ShippingStatus(dbc);
				shippingstatus.Fill_By_PK(pSHIPPING_STATUS_UUID);
				return shippingstatus;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.Supplier getSupplier_By_SupplierUuid(string pSUPPLIER_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.Supplier supplier = new Limew.Model.Lw.Table.Supplier(dbc);
				supplier.Fill_By_PK(pSUPPLIER_UUID);
				return supplier;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.SupplierGoods getSupplierGoods_By_SupplierGoodsUuid(string pSUPPLIER_GOODS_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.SupplierGoods suppliergoods = new Limew.Model.Lw.Table.SupplierGoods(dbc);
				suppliergoods.Fill_By_PK(pSUPPLIER_GOODS_UUID);
				return suppliergoods;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.VGoods getVGoods_By_GoodsUuid(string pGOODS_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.VGoods vgoods = new Limew.Model.Lw.Table.VGoods(dbc);
				vgoods.Fill_By_PK(pGOODS_UUID);
				return vgoods;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.Unit getUnit_By_UnitUuid(string pUNIT_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.Unit unit = new Limew.Model.Lw.Table.Unit(dbc);
				unit.Fill_By_PK(pUNIT_UUID);
				return unit;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.VSupplierGoods getVSupplierGoods_By_SupplierGoodsUuid_And_SupplierUuid(string pSUPPLIER_GOODS_UUID,string pSUPPLIER_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.VSupplierGoods vsuppliergoods = new Limew.Model.Lw.Table.VSupplierGoods(dbc);
				vsuppliergoods.Fill_By_PK(pSUPPLIER_GOODS_UUID,pSUPPLIER_UUID);
				return vsuppliergoods;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.CustOrg getCustOrg_By_CustOrgUuid(string pCUST_ORG_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.CustOrg custorg = new Limew.Model.Lw.Table.CustOrg(dbc);
				custorg.Fill_By_PK(pCUST_ORG_UUID);
				return custorg;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.VCustOrder getVCustOrder_By_CustOrderUuid(string pCUST_ORDER_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.VCustOrder vcustorder = new Limew.Model.Lw.Table.VCustOrder(dbc);
				vcustorder.Fill_By_PK(pCUST_ORDER_UUID);
				return vcustorder;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

	}
}
