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
		public Limew.Model.Lw.Table.CustOrderDetail getCustOrderDetail_By_CustOrderDetailUuid(string pCUST_ORDER_DETAIL_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.CustOrderDetail custorderdetail = new Limew.Model.Lw.Table.CustOrderDetail(dbc);
				custorderdetail.Fill_By_PK(pCUST_ORDER_DETAIL_UUID);
				return custorderdetail;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.PayStatus getPayStatus_By_PayStatusUuid(string pPAY_STATUS_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.PayStatus paystatus = new Limew.Model.Lw.Table.PayStatus(dbc);
				paystatus.Fill_By_PK(pPAY_STATUS_UUID);
				return paystatus;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.Filegroup getFilegroup_By_FilegroupUuid(string pFILEGROUP_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.Filegroup filegroup = new Limew.Model.Lw.Table.Filegroup(dbc);
				filegroup.Fill_By_PK(pFILEGROUP_UUID);
				return filegroup;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.File getFile_By_FileUuid(string pFILE_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.File file = new Limew.Model.Lw.Table.File(dbc);
				file.Fill_By_PK(pFILE_UUID);
				return file;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.VFilegroup getVFilegroup_By_FileUuid(string pFILE_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.VFilegroup vfilegroup = new Limew.Model.Lw.Table.VFilegroup(dbc);
				vfilegroup.Fill_By_PK(pFILE_UUID);
				return vfilegroup;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.VCustOrderDetail getVCustOrderDetail_By_CustOrderDetailUuid(string pCUST_ORDER_DETAIL_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.VCustOrderDetail vcustorderdetail = new Limew.Model.Lw.Table.VCustOrderDetail(dbc);
				vcustorderdetail.Fill_By_PK(pCUST_ORDER_DETAIL_UUID);
				return vcustorderdetail;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.VCustAddress getVCustAddress_By_CustUuid_And_CustOrgUuid(string pCUST_UUID,string pCUST_ORG_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.VCustAddress vcustaddress = new Limew.Model.Lw.Table.VCustAddress(dbc);
				vcustaddress.Fill_By_PK(pCUST_UUID,pCUST_ORG_UUID);
				return vcustaddress;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.CustOrderId getCustOrderId_By_CustOrderIdUuid(string pCUST_ORDER_ID_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.CustOrderId custorderid = new Limew.Model.Lw.Table.CustOrderId(dbc);
				custorderid.Fill_By_PK(pCUST_ORDER_ID_UUID);
				return custorderid;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.ShippingId getShippingId_By_ShippingIdUuid(string pSHIPPING_ID_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.ShippingId shippingid = new Limew.Model.Lw.Table.ShippingId(dbc);
				shippingid.Fill_By_PK(pSHIPPING_ID_UUID);
				return shippingid;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.MyOrder getMyOrder_By_MyOrderUuid(string pMY_ORDER_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.MyOrder myorder = new Limew.Model.Lw.Table.MyOrder(dbc);
				myorder.Fill_By_PK(pMY_ORDER_UUID);
				return myorder;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.MyOrderDetail getMyOrderDetail_By_MyOrderDetailUuid(string pMY_ORDER_DETAIL_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.MyOrderDetail myorderdetail = new Limew.Model.Lw.Table.MyOrderDetail(dbc);
				myorderdetail.Fill_By_PK(pMY_ORDER_DETAIL_UUID);
				return myorderdetail;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public Limew.Model.Lw.Table.VMyOrderDetail getVMyOrderDetail_By_MyOrderUuid_And_MyOrderDetailUuid(string pMY_ORDER_UUID,string pMY_ORDER_DETAIL_UUID){
			try{
				dbc = LK.Config.DataBase.Factory.getInfo();
				Limew.Model.Lw.Table.VMyOrderDetail vmyorderdetail = new Limew.Model.Lw.Table.VMyOrderDetail(dbc);
				vmyorderdetail.Fill_By_PK(pMY_ORDER_UUID,pMY_ORDER_DETAIL_UUID);
				return vmyorderdetail;
			}
			catch (Exception ex){
				log.Error(ex);LK.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

	}
}
