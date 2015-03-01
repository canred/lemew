using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LK.Attribute;
using LK.DB;  
using LK.DB.SQLCreater;  
using Limew.Model.Lw.Table;
using Limew.Model.Lw.Table.Record;
namespace Limew.Model.Lw
{
	public partial class LwModel
	{
        public int getCustOrderDetail_By_CustOrderUuid_Count(string pCustOrderUuid)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                CustOrderDetail table = new CustOrderDetail(dbc);
                var sc = new SQLCondition(table);
                sc.Equal(table.CUST_ORDER_UUID, pCustOrderUuid);
                return table.Where(sc)
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<CustOrderDetail_Record> getCustOrderDetail_By_CustOrderUuid(string pCustOrderUuid,OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                CustOrderDetail table = new CustOrderDetail(dbc);
                var sc = new SQLCondition(table);
                sc.Equal(table.CUST_ORDER_UUID, pCustOrderUuid);
                return table.Where(sc)
                    .Limit(orderLimit)
                    .FetchAll < CustOrderDetail_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getCustOrder_By_CustUuid_Count(string pCustUuid)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                CustOrder table = new CustOrder(dbc);
                var sc = new SQLCondition(table);
                sc.Equal(table.CUST_UUID, pCustUuid);                
                return table.Where(sc)
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<CustOrder_Record> getCustOrder_By_CustUuid(string pCustUuid,OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                CustOrder table = new CustOrder(dbc);
                var sc = new SQLCondition(table);
                sc.Equal(table.CUST_UUID, pCustUuid);
                return table.Where(sc)
                    .Limit(orderLimit)
                    .FetchAll<CustOrder_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getCust_By_Keyword_Count(string pKeyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Cust table = new Cust(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.CUST_NAME, pKeyword)
                    .Or()
                    .iBLike(table.CUST_TEL, pKeyword)
                    .Or()
                    .iBLike(table.CUST_FAX, pKeyword)
                    .Or()
                    .iBLike(table.CUST_ADDRESS, pKeyword)
                    .Or()
                    .iBLike(table.CUST_SALES_NAME, pKeyword)
                    .Or()
                    .iBLike(table.CUST_SALES_PHONE, pKeyword)
                    .Or()
                    .iBLike(table.CUST_SALES_EMAIL, pKeyword)
                    .Or()
                    .iBLike(table.CUST_PS, pKeyword)
                    )
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<Cust_Record> getCust_By_Keyword(string pKeyword,OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Cust table = new Cust(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.CUST_NAME, pKeyword)
                    .Or()
                    .iBLike(table.CUST_TEL, pKeyword)
                    .Or()
                    .iBLike(table.CUST_FAX, pKeyword)
                    .Or()
                    .iBLike(table.CUST_ADDRESS, pKeyword)
                    .Or()
                    .iBLike(table.CUST_SALES_NAME, pKeyword)
                    .Or()
                    .iBLike(table.CUST_SALES_PHONE, pKeyword)
                    .Or()
                    .iBLike(table.CUST_SALES_EMAIL, pKeyword)
                    .Or()
                    .iBLike(table.CUST_PS, pKeyword)
                    ).Limit(orderLimit)
                    .FetchAll<Cust_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<Supplier_Record> getSupplier_By_Keyword(string pKeyword,OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Supplier table = new Supplier(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.SUPPLIER_NAME, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_TEL, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_FAX, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_ADDRESS, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_CONTACT_NAME, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_CONTACT_EMAIL, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_CONTACT_PHONE, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_SALES_EMAIL, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_SALES_NAME, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_SALES_PHONE, pKeyword)
                    ).Limit(orderlimit)
                    .FetchAll<Supplier_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getSupplier_By_Keyword_Count(string pKeyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Supplier table = new Supplier(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.SUPPLIER_NAME, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_TEL, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_FAX, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_ADDRESS, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_CONTACT_NAME, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_CONTACT_EMAIL, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_CONTACT_PHONE, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_SALES_EMAIL, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_SALES_NAME, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_SALES_PHONE, pKeyword)
                    )
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getSupplierGoods_By_SupplierUuid_Keyword_Count(string pSupplierUuid, string pKeyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                SupplierGoods table = new SupplierGoods(dbc);
                var sc = new SQLCondition(table);
                sc.Equal(table.SUPPLIER_UUID, pSupplierUuid).And();
                if (pKeyword.Trim().Length > 0) {
                    sc.L()
                        .iBLike(table.SUPPLIER_GOODS_NAME,pKeyword).Or()
                        .iBLike(table.SUPPLIER_GOODS_SN, pKeyword)
                        .R();
                }
                sc.CheckSQL();
                return table.Where(sc)
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<SupplierGoods_Record> getSupplierGoods_By_SupplierUuid_Keyword(string pSupplierUuid, string pKeyword,OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                SupplierGoods table = new SupplierGoods(dbc);
                var sc = new SQLCondition(table);
                sc.Equal(table.SUPPLIER_UUID, pSupplierUuid).And();
                if (pKeyword.Trim().Length > 0)
                {
                    sc.L()
                        .iBLike(table.SUPPLIER_GOODS_NAME, pKeyword).Or()
                        .iBLike(table.SUPPLIER_GOODS_SN, pKeyword)
                        .R();
                }
                sc.CheckSQL();
                return table.Where(sc)
                    .Limit(orderLimit)
                    .FetchAll < SupplierGoods_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public System.Data.DataTable getGcategory_By_Root_DataTable()
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Gcategory table = new Gcategory(dbc);
                var result = table.Where(new SQLCondition(table)
                    .IsNull(table.GCATEGORY_PARENT_UUID)
                ).FetchAll();
                return result;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public System.Data.DataTable getGcategory_By_RootUuid_DataTable(string pRootUuid)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Gcategory table = new Gcategory(dbc);
                var result = table.Where(new SQLCondition(table)
                    .Equal(table.GCATEGORY_PARENT_UUID, pRootUuid)
                ).FetchAll();
                return result;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<Gcategory_Record> getGcategoryRoot()
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.Gcategory gcategory = new Limew.Model.Lw.Table.Gcategory(dbc);

                return gcategory
                    .Where(new SQLCondition(gcategory)
                    .IsNull(gcategory.GCATEGORY_PARENT_UUID)
                    ).FetchAll<Gcategory_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<Gcategory_Record> getGcategory_By_StartLikeGcategoryFullUuid(string pGcategoryFullUuid)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.Gcategory gcategory = new Limew.Model.Lw.Table.Gcategory(dbc);
                return gcategory
                    .Where(new SQLCondition(gcategory)
                    .iELike(gcategory.GCATEGORY_FULL_UUID, pGcategoryFullUuid)
                    ).FetchAll<Gcategory_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getVGoods_By_Keyword_Count(string pKeyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VGoods table = new VGoods(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.GCATEGORY_NAME, pKeyword)
                    .Or()
                    .iBLike(table.GOODS_SN, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_NAME, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_PS, pKeyword)
                    )
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VGoods_Record> getVGoods_By_Keyword(string pKeyword,OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VGoods table = new VGoods(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.GCATEGORY_NAME, pKeyword)
                    .Or()
                    .iBLike(table.GOODS_SN, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_NAME, pKeyword)
                    .Or()
                    .iBLike(table.SUPPLIER_PS, pKeyword)
                    ).Limit(orderlimit)
                    .FetchAll<VGoods_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getUnit_By_Keyword_Count(string pKeyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Unit table = new Unit(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.UNIT_NAME, pKeyword)
                    )
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<Unit_Record> getUnit_By_Keyword(string pKeyword,OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Unit table = new Unit(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.UNIT_NAME, pKeyword)
                    )
                    .Limit(orderlimit)
                    .FetchAll < Unit_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getVSupplierGoods_By_SupplierUuid_Keyword_Count(string pSupplierUuid, string pKeyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VSupplierGoods table = new VSupplierGoods(dbc);
                var sc = new SQLCondition(table);
                sc.Equal(table.SUPPLIER_UUID, pSupplierUuid).And();
                if (pKeyword.Trim().Length > 0)
                {
                    sc.L()
                        .iBLike(table.SUPPLIER_GOODS_NAME, pKeyword).Or()
                        .iBLike(table.SUPPLIER_GOODS_SN, pKeyword)
                        .R();
                }
                sc.CheckSQL();
                return table.Where(sc)
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VSupplierGoods_Record> getVSupplierGoods_By_SupplierUuid_Keyword(string pSupplierUuid, string pKeyword, OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VSupplierGoods table = new VSupplierGoods(dbc);
                var sc = new SQLCondition(table);
                sc.Equal(table.SUPPLIER_UUID, pSupplierUuid).And();
                if (pKeyword.Trim().Length > 0)
                {
                    sc.L()
                        .iBLike(table.SUPPLIER_GOODS_NAME, pKeyword).Or()
                        .iBLike(table.SUPPLIER_GOODS_SN, pKeyword)
                        .R();
                }
                sc.CheckSQL();
                return table.Where(sc)
                    .Limit(orderlimit)
                    .FetchAll < VSupplierGoods_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }


        public int getCustOrg_By_Keyword_Count(string pCustUuid,string pKeyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                CustOrg table = new CustOrg(dbc);
                return table.Where(new SQLCondition(table)
                    .Equal(table.CUST_UUID,pCustUuid)
                    .And()
                    .L()
                    .iBLike(table.CUST_ORG_NAME, pKeyword)
                    .Or()
                    .iBLike(table.CUST_ORG_PS, pKeyword)
                    .Or()
                    .iBLike(table.CUST_ORG_SALES_EMAIL, pKeyword)
                    .Or()
                    .iBLike(table.CUST_ORG_SALES_NAME, pKeyword)
                    .Or()
                    .iBLike(table.CUST_ORG_SALES_PHONE, pKeyword)
                    .R()
                    )
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }


        public IList<CustOrg_Record> getCustOrg_By_Keyword(string pCustUuid, string pKeyword, OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                CustOrg table = new CustOrg(dbc);
                return table.Where(new SQLCondition(table)
                    .Equal(table.CUST_UUID, pCustUuid)
                    .And()
                    .L()
                    .iBLike(table.CUST_ORG_NAME, pKeyword)
                    .Or()
                    .iBLike(table.CUST_ORG_PS, pKeyword)
                    .Or()
                    .iBLike(table.CUST_ORG_SALES_EMAIL, pKeyword)
                    .Or()
                    .iBLike(table.CUST_ORG_SALES_NAME, pKeyword)
                    .Or()
                    .iBLike(table.CUST_ORG_SALES_PHONE, pKeyword)
                    .R()
                    )
                    .Limit(orderlimit)
                    .FetchAll<CustOrg_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getVCustOrder_By_CustOrderStatus_CustUuid_Keyword_Count(string pCustOrderStatus,string pCustUuid,string pKeyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VCustOrder table = new VCustOrder(dbc);
                var sc = new SQLCondition(table);
                if (pCustOrderStatus.Trim().Length > 0) {
                    sc.Equal(table.CUST_ORDER_STATUS_UUID, pCustOrderStatus).And();
                }
                if (pCustUuid.Trim().Length > 0) {
                    sc.Equal(table.CUST_UUID, pCustUuid).And();
                }
                if (pKeyword.Trim().Length > 0) {
                    sc.L()
                        .iBLike(table.CUST_ADDRESS,pKeyword).Or()
                        .iBLike(table.CUST_FAX, pKeyword).Or()
                        .iBLike(table.CUST_NAME, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_CUST_NAME, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_DEPT, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_INVOICE_NUMBER, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_PO_NUMBER, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_PRINT_USER_NAME, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_USER_NAME, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_USER_PHONE, pKeyword).Or()
                        .iBLike(table.CUST_ORG_NAME, pKeyword).Or()
                        .iBLike(table.CUST_ORG_PS, pKeyword).Or()
                        .iBLike(table.CUST_ORG_SALES_EMAIL, pKeyword).Or()
                        .iBLike(table.CUST_ORG_SALES_NAME, pKeyword).Or()
                        .iBLike(table.CUST_ORG_SALES_PHONE, pKeyword).Or()
                        .iBLike(table.CUST_SALES_EMAIL, pKeyword).Or()
                        .iBLike(table.CUST_SALES_NAME, pKeyword).Or()
                        .iBLike(table.CUST_SALES_PHONE, pKeyword).Or()
                        .iBLike(table.CUST_TEL, pKeyword)
                        .R();
                }
               
                return table.Where(sc)
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VCustOrder_Record> getVCustOrder_By_CustOrderStatus_CustUuid_Keyword(string pCustOrderStatus, string pCustUuid, string pKeyword,OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VCustOrder table = new VCustOrder(dbc);
                var sc = new SQLCondition(table);
                if (pCustOrderStatus.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_STATUS_UUID, pCustOrderStatus).And();
                }
                if (pCustUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_UUID, pCustUuid).And();
                }
                if (pKeyword.Trim().Length > 0)
                {
                    sc.L()
                        .iBLike(table.CUST_ADDRESS, pKeyword).Or()
                        .iBLike(table.CUST_FAX, pKeyword).Or()
                        .iBLike(table.CUST_NAME, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_CUST_NAME, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_DEPT, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_INVOICE_NUMBER, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_PO_NUMBER, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_PRINT_USER_NAME, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_USER_NAME, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_USER_PHONE, pKeyword).Or()
                        .iBLike(table.CUST_ORG_NAME, pKeyword).Or()
                        .iBLike(table.CUST_ORG_PS, pKeyword).Or()
                        .iBLike(table.CUST_ORG_SALES_EMAIL, pKeyword).Or()
                        .iBLike(table.CUST_ORG_SALES_NAME, pKeyword).Or()
                        .iBLike(table.CUST_ORG_SALES_PHONE, pKeyword).Or()
                        .iBLike(table.CUST_SALES_EMAIL, pKeyword).Or()
                        .iBLike(table.CUST_SALES_NAME, pKeyword).Or()
                        .iBLike(table.CUST_SALES_PHONE, pKeyword).Or()
                        .iBLike(table.CUST_TEL, pKeyword)
                        .R();
                }

                return table.Where(sc)
                    .Limit(orderlimit)
                    .FetchAll<VCustOrder_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

	}
}
