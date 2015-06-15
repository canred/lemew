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
        public IList<CustOrder_Record> getCustOrder_By_CustOrderUuid(List<Object> pArrCUST_ORDER_UUID)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.CustOrder custorder = new Limew.Model.Lw.Table.CustOrder(dbc);
                return custorder.Where(new SQLCondition(custorder).In(custorder.CUST_ORDER_UUID, pArrCUST_ORDER_UUID))
                    .FetchAll<CustOrder_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<CustOrg_Record> getCustOrg_By_CustUuid_CustOrgIsDefault(string pCustUuid,string pCustOrgIsDefatul)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.CustOrg custorg = new Limew.Model.Lw.Table.CustOrg(dbc);
                return custorg.Where(new SQLCondition(custorg).Equal(custorg.CUST_UUID, pCustUuid)
                    .And()
                    .Equal(custorg.CUST_ORG_IS_DEFAULT, pCustOrgIsDefatul)
                    ).FetchAll<CustOrg_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<CustOrg_Record> getCustOrg_By_CustUuid(string pCustUuid)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.CustOrg custorg = new Limew.Model.Lw.Table.CustOrg(dbc);
                return custorg.Where(new SQLCondition(custorg).Equal(custorg.CUST_UUID, pCustUuid)
                    
                    ).FetchAll<CustOrg_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

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
                sc.Equal(table.CUST_ORDER_UUID, pCustOrderUuid).And()
                    .Equal(table.CUST_ORDER_DETAIL_IS_ACTIVE,1);
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
        public IList<CustOrderDetail_Record> getCustOrderDetail_By_CustOrderUuid(List<Object> arrCustOrderUuid, OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                CustOrderDetail table = new CustOrderDetail(dbc);
                var sc = new SQLCondition(table);
                if (arrCustOrderUuid.Count == 0) {
                    return new List<CustOrderDetail_Record>();
                }
                sc.In(table.CUST_ORDER_UUID, arrCustOrderUuid);
                return table.Where(sc)
                    .Limit(orderLimit)
                    .FetchAll<CustOrderDetail_Record>();
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

        public IList<CustOrder_Record> getCustOrder_By_CustOrderId(string pCustOrderId, OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                CustOrder table = new CustOrder(dbc);
                var sc = new SQLCondition(table);
                sc.Equal(table.CUST_ORDER_ID, pCustOrderId);
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


        public int getCustOrg_By_Keyword_Count(string pCustUuid, string pKeyword, string pShowIsDefault)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                CustOrg table = new CustOrg(dbc);
                return table.Where(new SQLCondition(table)
                    .Equal(table.CUST_UUID,pCustUuid)
                    .And()
                    .Equal(table.CUST_ORG_IS_DEFAULT, pShowIsDefault)
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

        public int getCustOrg_By_Keyword_Count(string pCustUuid, string pKeyword)
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
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getCustOrgV_By_Keyword_Count(string pCustUuid, string pKeyword,List<object> arrCustIsActive)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                CustOrgV table = new CustOrgV(dbc);
                var sc = new SQLCondition(table);
                if (pCustUuid.Trim().Length > 0)
                    sc.Equal(table.CUST_UUID, pCustUuid).And();

                if (arrCustIsActive.Count > 0) {
                    sc.In(table.CUST_IS_ACTIVE, arrCustIsActive).And();
                }

                if(pKeyword.Trim().Length>0)
                {
                    sc.L()
                       .iBLike(table.CUST_ORG_NAME, pKeyword)
                       .Or()
                       .iBLike(table.CUST_ORG_PS, pKeyword)
                       .Or()
                       .iBLike(table.CUST_ORG_SALES_EMAIL, pKeyword)
                       .Or()
                       .iBLike(table.CUST_ORG_SALES_NAME, pKeyword)
                       .Or()
                       .iBLike(table.CUST_ORG_SALES_PHONE, pKeyword)
                       .Or()
                       .iBLike(table.CUST_ADDRESS, pKeyword)
                       .Or()
                       .iBLike(table.CUST_FAX, pKeyword)
                       .Or()
                       .iBLike(table.CUST_NAME, pKeyword)
                       .Or()
                       .iBLike(table.CUST_PS, pKeyword)
                       .Or()
                       .iBLike(table.CUST_SALES_EMAIL, pKeyword)
                       .Or()
                       .iBLike(table.CUST_SALES_NAME, pKeyword)
                       .Or()
                       .iBLike(table.CUST_SALES_PHONE, pKeyword)
                       .Or()
                       .iBLike(table.CUST_TEL, pKeyword)
                       .Or()
                       .iBLike(table.CUST_UNIFORM_NUM, pKeyword)
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
        public IList<CustOrg_Record> getCustOrg_By_Keyword(string pCustUuid, string pKeyword, string pShowIsDefault, OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                CustOrg table = new CustOrg(dbc);
                return table.Where(new SQLCondition(table)
                    .Equal(table.CUST_UUID, pCustUuid)
                    .And()
                    .Equal(table.CUST_ORG_IS_DEFAULT, pShowIsDefault)
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

        public IList<CustOrgV_Record> getCustOrgV_By_Keyword(string pCustUuid, string pKeyword,List<object> arrCustIsActive ,OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                CustOrgV table = new CustOrgV(dbc);

                var sc = new SQLCondition(table);
                if (pCustUuid.Trim().Length > 0)
                    sc.Equal(table.CUST_UUID, pCustUuid).And();

                if (arrCustIsActive.Count > 0)
                {
                    sc.In(table.CUST_IS_ACTIVE, arrCustIsActive).And();
                }

                if (pKeyword.Trim().Length > 0)
                {
                    sc.L()
                       .iBLike(table.CUST_ORG_NAME, pKeyword)
                       .Or()
                       .iBLike(table.CUST_ORG_PS, pKeyword)
                       .Or()
                       .iBLike(table.CUST_ORG_SALES_EMAIL, pKeyword)
                       .Or()
                       .iBLike(table.CUST_ORG_SALES_NAME, pKeyword)
                       .Or()
                       .iBLike(table.CUST_ORG_SALES_PHONE, pKeyword)
                       .Or()
                       .iBLike(table.CUST_ADDRESS, pKeyword)
                       .Or()
                       .iBLike(table.CUST_FAX, pKeyword)
                       .Or()
                       .iBLike(table.CUST_NAME, pKeyword)
                       .Or()
                       .iBLike(table.CUST_PS, pKeyword)
                       .Or()
                       .iBLike(table.CUST_SALES_EMAIL, pKeyword)
                       .Or()
                       .iBLike(table.CUST_SALES_NAME, pKeyword)
                       .Or()
                       .iBLike(table.CUST_SALES_PHONE, pKeyword)
                       .Or()
                       .iBLike(table.CUST_TEL, pKeyword)
                       .Or()
                       .iBLike(table.CUST_UNIFORM_NUM, pKeyword)
                       .R();
                }
                sc.CheckSQL();


                return table.Where(sc)
                    .Limit(orderlimit)
                    .FetchAll<CustOrgV_Record>();
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


        public int getVCustOrder_By_Keyword_CustOrderTypeUuid_CompanyUuid_CustUuid_CustOrderStatus_ShippingStatusUuid_PayStatusUuid_Count(string pKeyword,string pCustOrderType,string pCompanyUuid,string pCustUuid,string pCustOrderStatusUuid,string pShippingStatusUuid,string pPayStatusUuid)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VCustOrder table = new VCustOrder(dbc);
                var sc = new SQLCondition(table);
                if (pCustOrderType.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_TYPE, pCustOrderType).And();
                }

                if (pCompanyUuid.Trim().Length > 0)
                {
                    sc.Equal(table.COMPANY_UUID, pCompanyUuid).And();
                }

                if (pCustUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_UUID, pCustUuid).And();
                }

                if (pCustOrderStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_STATUS_UUID, pCustOrderStatusUuid).And();
                }

                if (pShippingStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.SHIPPING_STATUS_UUID, pShippingStatusUuid).And();
                }

                if (pPayStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.PAY_STATUS_UUID, pPayStatusUuid).And();
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
        public int getVCustOrder_By_Keyword_CustOrderTypeUuid_CompanyUuid_CustUuid_CustOrderStatus_ShippingStatusUuid_PayStatusUuid_Count(string pKeyword, string pCustOrderType, string pCompanyUuid, string pCustUuid, string pCustOrderStatusUuid, string pShippingStatusUuid,string start_date,string end_date, List<Object> pPayStatusUuid)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VCustOrder table = new VCustOrder(dbc);
                var sc = new SQLCondition(table);
                if (pCustOrderType.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_TYPE, pCustOrderType).And();
                }

                if (pCompanyUuid.Trim().Length > 0)
                {
                    sc.Equal(table.COMPANY_UUID, pCompanyUuid).And();
                }

                if (pCustUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_UUID, pCustUuid).And();
                }

                if (pCustOrderStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_STATUS_UUID, pCustOrderStatusUuid).And();
                }

                if (pShippingStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.SHIPPING_STATUS_UUID, pShippingStatusUuid).And();
                }

                if (pPayStatusUuid.Count>0)
                {
                    sc.In(table.PAY_STATUS_UUID, pPayStatusUuid).And();
                }

                if (start_date.Trim().Length > 0 && end_date.Trim().Length > 0)
                {
                    var s = Convert.ToDateTime(start_date);
                    var e = Convert.ToDateTime(end_date);
                    e = e.AddDays(1).AddMilliseconds(-1);

                    sc.L()
                        .OverThen(table.CUST_ORDER_CR, s)
                        .And()
                        .LessThen(table.CUST_ORDER_CR, e)
                        .R().And();

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
                        .iBLike(table.CUST_TEL, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_TOTAL_PRICE,pKeyword)
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
        public int getVCustOrderSearch_By_Keyword_CustOrderTypeUuid_CompanyUuid_CustUuid_CustOrderStatus_ShippingStatusUuid_PayStatusUuid_Count(DateTime s , DateTime e, string pKeyword, string pCustOrderType, string pCompanyUuid, string pCustUuid, string pCustOrderStatusUuid, string pShippingStatusUuid, string pPayStatusUuid)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VCustOrderSearch table = new VCustOrderSearch(dbc);
                var sc = new SQLCondition(table);

                sc.OverThen(table.CUST_ORDER_CR, s).And()
                    .LessThen(table.CUST_ORDER_CR, e).And();

                if (pCustOrderType.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_TYPE, pCustOrderType).And();
                }

                if (pCompanyUuid.Trim().Length > 0)
                {
                    sc.Equal(table.COMPANY_UUID, pCompanyUuid).And();
                }

                if (pCustUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_UUID, pCustUuid).And();
                }

                if (pCustOrderStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_STATUS_UUID, pCustOrderStatusUuid).And();
                }

                if (pShippingStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.SHIPPING_STATUS_UUID, pShippingStatusUuid).And();
                }

                if (pPayStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.PAY_STATUS_UUID, pPayStatusUuid).And();
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
                        .iBLike(table.CUST_TEL, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_DETAIL_GOODS_NAME, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_TOTAL_PRICE,pKeyword).Or()
                        .iBLike(table.CUST_ORDER_DETAIL_TOTAL_PRICE,pKeyword)
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

        public IList<VCustOrderSearch_Record> getVCustOrderSearch_By_Keyword_CustOrderTypeUuid_CompanyUuid_CustUuid_CustOrderStatus_ShippingStatusUuid_PayStatusUuid(DateTime s, DateTime e, string pKeyword, string pCustOrderType, string pCompanyUuid, string pCustUuid, string pCustOrderStatusUuid, string pShippingStatusUuid, string pPayStatusUuid,OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VCustOrderSearch table = new VCustOrderSearch(dbc);
                var sc = new SQLCondition(table);

                sc.OverThen(table.CUST_ORDER_CR, s).And()
                    .LessThen(table.CUST_ORDER_CR, e).And();

                if (pCustOrderType.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_TYPE, pCustOrderType).And();
                }

                if (pCompanyUuid.Trim().Length > 0)
                {
                    sc.Equal(table.COMPANY_UUID, pCompanyUuid).And();
                }

                if (pCustUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_UUID, pCustUuid).And();
                }

                if (pCustOrderStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_STATUS_UUID, pCustOrderStatusUuid).And();
                }

                if (pShippingStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.SHIPPING_STATUS_UUID, pShippingStatusUuid).And();
                }

                if (pPayStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.PAY_STATUS_UUID, pPayStatusUuid).And();
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
                        .iBLike(table.CUST_TEL, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_DETAIL_GOODS_NAME, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_TOTAL_PRICE, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_DETAIL_TOTAL_PRICE, pKeyword)
                        .R();
                }
                sc.CheckSQL();
                return table.Where(sc)
                    .Limit(orderLimit)
                    .FetchAll<VCustOrderSearch_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getVCustOrderForReport_Count(string pStartDate, string pEndDate, string pIsGroup, string pGroupType, string pCompanyUuid, string pCustUuid, string pCustOrgUuid, string pKeyword
            , string pCustOrderStatusUuid,string pShippingStatusUuid,string pPayStatusUuid)
        {
            //            cust_order_status_uuid = 'COS_FINISH' 
            //shipping_status_uuid ='SS_FINISH'
            //pay_status_uuid = 'pay_status_2'
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VCustOrder table = new VCustOrder(dbc);
                var sc = new SQLCondition(table);

                if (pStartDate.Trim().Length > 0 && pEndDate.Trim().Length>0)
                {
                    sc.L().OverEqual(table.CUST_ORDER_SHIPPING_DATE, pStartDate,true).And().LessEqual(table.CUST_ORDER_SHIPPING_DATE, pEndDate,true).R().And();
                }

                if (pCompanyUuid.Trim().Length > 0)
                {
                    sc.Equal(table.COMPANY_UUID, pCompanyUuid).And();
                }

                if (pCustUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_UUID, pCustUuid).And();
                }

                if (pCustOrgUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORG_UUID, pCustOrgUuid).And();
                }

                if (pCustOrderStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_STATUS_UUID, pCustOrderStatusUuid).And();
                }

                if (pShippingStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.SHIPPING_STATUS_UUID, pShippingStatusUuid).And();
                }

                if (pPayStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.PAY_STATUS_UUID, pPayStatusUuid).And();
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


        public IList<VCustOrder_Record> getVCustOrderForReport(string pStartDate, string pEndDate, string pIsGroup, string pGroupType, string pCompanyUuid, string pCustUuid, string pCustOrgUuid, string pKeyword, string pCustOrderStatusUuid, string pShippingStatusUuid, string pPayStatusUuid, OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VCustOrder table = new VCustOrder(dbc);
                var sc = new SQLCondition(table);

                if (pStartDate.Trim().Length > 0 && pEndDate.Trim().Length > 0)
                {
                    sc.L().OverEqual(table.CUST_ORDER_SHIPPING_DATE, pStartDate).And().LessEqual(table.CUST_ORDER_SHIPPING_DATE, pEndDate).R().And();
                }

                if (pCompanyUuid.Trim().Length > 0)
                {
                    sc.Equal(table.COMPANY_UUID, pCompanyUuid).And();
                }

                if (pCustUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_UUID, pCustUuid).And();
                }

                if (pCustOrgUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORG_UUID, pCustOrgUuid).And();
                }
                if (pCustOrderStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_STATUS_UUID, pCustOrderStatusUuid).And();
                }

                if (pShippingStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.SHIPPING_STATUS_UUID, pShippingStatusUuid).And();
                }

                if (pPayStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.PAY_STATUS_UUID, pPayStatusUuid).And();
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
                sc.CheckSQL();
                return table.Where(sc)
                    .Limit(orderLimit)
                    .FetchAll<VCustOrder_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getVCustOrderForShipping_By_Keyword_CustOrderTypeUuid_CompanyUuid_CustUuid_CustOrderStatus_ShippingStatusUuid_Count(string pKeyword, string pCustOrderType, string pCompanyUuid, string pCustUuid, string pCustOrderStatusUuid, string pShippingStatusUuid)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VCustOrder table = new VCustOrder(dbc);
                var sc = new SQLCondition(table);
                //sc.IsNotNull(table.SHIPPING_ADDRESS).And();
                if (pCustOrderType.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_TYPE, pCustOrderType).And();
                }

                if (pCompanyUuid.Trim().Length > 0)
                {
                    sc.Equal(table.COMPANY_UUID, pCompanyUuid).And();
                }

                if (pCustUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_UUID, pCustUuid).And();
                }

                if (pCustOrderStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_STATUS_UUID, pCustOrderStatusUuid).And();
                }

                if (pShippingStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.SHIPPING_STATUS_UUID, pShippingStatusUuid).And();
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
                        .iBLike(table.CUST_TEL, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_TOTAL_PRICE,pKeyword)
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

        public IList<VCustOrder_Record> getVCustOrder_By_Keyword_CustOrderTypeUuid_CompanyUuid_CustUuid_CustOrderStatus_ShippingStatusUuid_PayStatusUuid(string pKeyword, string pCustOrderType, string pCompanyUuid, string pCustUuid, string pCustOrderStatusUuid, string pShippingStatusUuid,string pPayStatusUuid,OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VCustOrder table = new VCustOrder(dbc);
                var sc = new SQLCondition(table);
                if (pCustOrderType.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_TYPE, pCustOrderType).And();
                }

                if (pCompanyUuid.Trim().Length > 0)
                {
                    sc.Equal(table.COMPANY_UUID, pCompanyUuid).And();
                }

                if (pCustUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_UUID, pCustUuid).And();
                }

                if (pCustOrderStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_STATUS_UUID, pCustOrderStatusUuid).And();
                }

                if (pShippingStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.SHIPPING_STATUS_UUID, pShippingStatusUuid).And();
                }
                if (pPayStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.PAY_STATUS_UUID, pPayStatusUuid).And();
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
                sc.CheckSQL();
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
        public IList<VCustOrder_Record> getVCustOrder_By_Keyword_CustOrderTypeUuid_CompanyUuid_CustUuid_CustOrderStatus_ShippingStatusUuid_PayStatusUuid(string pKeyword, string pCustOrderType, string pCompanyUuid, string pCustUuid, string pCustOrderStatusUuid, string pShippingStatusUuid,string start_date,string end_date, List<Object> pPayStatusUuid, OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VCustOrder table = new VCustOrder(dbc);
                var sc = new SQLCondition(table);
                if (pCustOrderType.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_TYPE, pCustOrderType).And();
                }

                if (pCompanyUuid.Trim().Length > 0)
                {
                    sc.Equal(table.COMPANY_UUID, pCompanyUuid).And();
                }

                if (pCustUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_UUID, pCustUuid).And();
                }

                if (pCustOrderStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_STATUS_UUID, pCustOrderStatusUuid).And();
                }

                if (pShippingStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.SHIPPING_STATUS_UUID, pShippingStatusUuid).And();
                }
                if (pPayStatusUuid.Count>0)
                {
                    sc.In(table.PAY_STATUS_UUID, pPayStatusUuid).And();
                    //sc.Equal(table.PAY_STATUS_UUID, pPayStatusUuid).And();
                }
                if (start_date.Trim().Length > 0 && end_date.Trim().Length > 0)
                {
                    var s = Convert.ToDateTime(start_date);
                    var e = Convert.ToDateTime(end_date);
                    e = e.AddDays(1).AddMilliseconds(-1);

                    sc.L()
                        .OverThen(table.CUST_ORDER_CR, s)
                        .And()
                        .LessThen(table.CUST_ORDER_CR, e)
                        .R().And();

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
                        .iBLike(table.CUST_TEL, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_TOTAL_PRICE, pKeyword)
                        .R();
                }
                sc.CheckSQL();
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
        public IList<VCustOrder_Record> getVCustOrderForShipping_By_Keyword_CustOrderTypeUuid_CompanyUuid_CustUuid_CustOrderStatus_ShippingStatusUuid(string pKeyword, string pCustOrderType, string pCompanyUuid, string pCustUuid, string pCustOrderStatusUuid, string pShippingStatusUuid, OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VCustOrder table = new VCustOrder(dbc);
                var sc = new SQLCondition(table);
                //sc.IsNotNull(table.SHIPPING_ADDRESS).And();
                if (pCustOrderType.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_TYPE, pCustOrderType).And();
                }

                if (pCompanyUuid.Trim().Length > 0)
                {
                    sc.Equal(table.COMPANY_UUID, pCompanyUuid).And();
                }

                if (pCustUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_UUID, pCustUuid).And();
                }

                if (pCustOrderStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_ORDER_STATUS_UUID, pCustOrderStatusUuid).And();
                }

                if (pShippingStatusUuid.Trim().Length > 0)
                {
                    sc.Equal(table.SHIPPING_STATUS_UUID, pShippingStatusUuid).And();
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
                        .iBLike(table.CUST_TEL, pKeyword).Or()
                        .iBLike(table.CUST_ORDER_TOTAL_PRICE, pKeyword)
                        .R();
                }
                sc.CheckSQL();
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

        public int getCustOrderStatus_By_Keyword_Count(string pKeyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                CustOrderStatus table = new CustOrderStatus(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.CUST_ORDER_STATUS_NAME, pKeyword)
                    )
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<CustOrderStatus_Record> getCustOrderStatus_By_Keyword(string pKeyword,OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                CustOrderStatus table = new CustOrderStatus(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.CUST_ORDER_STATUS_NAME, pKeyword)
                    )
                    .Limit(orderlimit)
                    .FetchAll<CustOrderStatus_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getPayStatus_By_Keyword_Count(string pKeyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                PayStatus table = new PayStatus(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.PAY_STATUS_NAME, pKeyword)
                    )
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<PayStatus_Record> getPayStatus_By_Keyword(string pKeyword,OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                PayStatus table = new PayStatus(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.PAY_STATUS_NAME, pKeyword)
                    )
                    .Limit(orderlimit)
                    .FetchAll<PayStatus_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getPayMethod_By_Keyword_Count(string pKeyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                PayMethod table = new PayMethod(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.PAY_METHOD_NAME, pKeyword)
                    )
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<PayMethod_Record> getPayMethod_By_Keyword(string pKeyword, OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                PayMethod table = new PayMethod(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.PAY_METHOD_NAME, pKeyword)
                    )
                    .Limit(orderlimit)
                    .FetchAll<PayMethod_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }


        public int getShippingStatus_By_Keyword_Count(string pKeyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                ShippingStatus table = new ShippingStatus(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.SHIPPING_STATUS_NAME, pKeyword)
                    )
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<ShippingStatus_Record> getShippingStatus_By_Keyword(string pKeyword, OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                ShippingStatus table = new ShippingStatus(dbc);
                return table.Where(new SQLCondition(table).iBLike(table.SHIPPING_STATUS_NAME, pKeyword)
                    )
                    .Limit(orderlimit)
                    .FetchAll<ShippingStatus_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<File_Record> getFile_By_FilegroupUuid(string pFILEGROUP_UUID)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.File file = new Limew.Model.Lw.Table.File(dbc);
                return file.Where(new SQLCondition(file)
                    .Equal(file.FILEGROUP_UUID, pFILEGROUP_UUID))
                    .FetchAll<File_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<File_Record> getFile_By_FilegroupUuid(List<object> arrFILEGROUP_UUID)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.File file = new Limew.Model.Lw.Table.File(dbc);
                return file.Where(new SQLCondition(file)
                    .In(file.FILEGROUP_UUID, arrFILEGROUP_UUID))
                    .FetchAll<File_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getVFilegroup_By_Keyword_Count(string pFilegroupUuid,string pKeyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VFilegroup table = new VFilegroup(dbc);
                return table.Where(new SQLCondition(table)
                    .Equal(table.FILEGROUP_UUID,pFilegroupUuid)
                    .And()
                    .L()
                    .iBLike(table.FILE_NAME, pKeyword)
                    .Or()
                    .iBLike(table.FILE_PS,pKeyword)
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

        public IList<VFilegroup_Record> getVFilegroup_By_Keyword(string pFilegroupUuid,string pKeyword,OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VFilegroup table = new VFilegroup(dbc);
                return table.Where(new SQLCondition(table).Equal(table.FILEGROUP_UUID, pFilegroupUuid)
                    .And()
                    .L()
                    .iBLike(table.FILE_NAME, pKeyword)
                    .Or()
                    .iBLike(table.FILE_PS, pKeyword)
                    .R()
                    )
                    .Limit(orderlimit)
                    .FetchAll<VFilegroup_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getVCustOrderDetail_By_CustOrderUuid_Count(string pCustOrderUuid)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VCustOrderDetail table = new VCustOrderDetail(dbc);
                var sc = new SQLCondition(table);
                sc.Equal(table.CUST_ORDER_UUID, pCustOrderUuid)
                    .And()
                    .Equal(table.CUST_ORDER_DETAIL_IS_ACTIVE,1);
                return table.Where(sc)
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VCustOrderDetail_Record> getVCustOrderDetail_By_CustOrderUuid(string pCustOrderUuid,OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VCustOrderDetail table = new VCustOrderDetail(dbc);
                var sc = new SQLCondition(table);
                sc.Equal(table.CUST_ORDER_UUID, pCustOrderUuid)
                    .And()
                    .Equal(table.CUST_ORDER_DETAIL_IS_ACTIVE, 1);
                return table.Where(sc)
                    .Limit(orderlimit)
                    .FetchAll<VCustOrderDetail_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VCustAddress_Record> getVCustAddress_By_CustUuid_Or_CustOrgUuid(string pCUST_UUID, string pCUST_ORG_UUID)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.VCustAddress vcustaddress = new Limew.Model.Lw.Table.VCustAddress(dbc);
                return vcustaddress.Where(new SQLCondition(vcustaddress)
                .Equal(vcustaddress.CUST_UUID, pCUST_UUID)
                .Or()
                .Equal(vcustaddress.CUST_ORG_UUID,pCUST_UUID)
                ).FetchAll<VCustAddress_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public Int32 getMyOrder_By_Keyword_SupplierUuid_IsActive_Count(string pKeyword,string pSupplierUuid,string pIsActive)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.MyOrder myorder = new Limew.Model.Lw.Table.MyOrder(dbc);
                var sc = new SQLCondition(myorder);

                if(pSupplierUuid.Trim().Length>0){
                    sc.Equal(myorder.SUPPLIER_UUID,pSupplierUuid).And();
                }

                if(pIsActive.Trim().Length>0){
                sc.Equal(myorder.MY_ORDER_IS_ACTIVE,pIsActive).And();
                }

                if(pKeyword.Trim().Length>0){

                    sc.L().iBLike(myorder.MY_ORDER_SUPPLIER_NAME, pKeyword).Or()
                .iBLike(myorder.MY_ORDER_SUPPLIER_TEL, pKeyword).Or()
                .iBLike(myorder.MY_ORDER_SUPPLIER_FAX, pKeyword).Or()
                .iBLike(myorder.MY_ORDER_SUPPLIER_ADDRESS, pKeyword).Or()
                .iBLike(myorder.MY_ORDER_CONTACT_NAME, pKeyword).Or()
                .iBLike(myorder.MY_ORDER_CONTACT_PHONE, pKeyword).Or()
                .iBLike(myorder.MY_ORDER_CONTACT_EMAIL, pKeyword).Or()
                .iBLike(myorder.MY_ORDER_PS, pKeyword).R();
                }

                sc.CheckSQL();
                

                


                return myorder.Where(sc
                    )
                    .FetchCount();                
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<MyOrder_Record> getMyOrder_By_Keyword_SupplierUuid_IsActive(string pKeyword, string pSupplierUuid, string pIsActive, OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.MyOrder myorder = new Limew.Model.Lw.Table.MyOrder(dbc);
                var sc = new SQLCondition(myorder);

                if (pSupplierUuid.Trim().Length > 0)
                {
                    sc.Equal(myorder.SUPPLIER_UUID, pSupplierUuid).And();
                }

                if (pIsActive.Trim().Length > 0)
                {
                    sc.Equal(myorder.MY_ORDER_IS_ACTIVE, pIsActive).And();
                }

                if (pKeyword.Trim().Length > 0)
                {

                    sc.L().iBLike(myorder.MY_ORDER_SUPPLIER_NAME, pKeyword).Or()
                .iBLike(myorder.MY_ORDER_SUPPLIER_TEL, pKeyword).Or()
                .iBLike(myorder.MY_ORDER_SUPPLIER_FAX, pKeyword).Or()
                .iBLike(myorder.MY_ORDER_SUPPLIER_ADDRESS, pKeyword).Or()
                .iBLike(myorder.MY_ORDER_CONTACT_NAME, pKeyword).Or()
                .iBLike(myorder.MY_ORDER_CONTACT_PHONE, pKeyword).Or()
                .iBLike(myorder.MY_ORDER_CONTACT_EMAIL, pKeyword).Or()
                .iBLike(myorder.MY_ORDER_PS, pKeyword).R();
                }

                sc.CheckSQL();
                return myorder.Where(sc)
                    .Limit(orderLimit)
                    .FetchAll < MyOrder_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public Int32 getMyOrderDetail_By_MyOrderUuid_Keyword_Count(string pMyOrderUuid,string pKeyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.MyOrderDetail myorderdetail = new Limew.Model.Lw.Table.MyOrderDetail(dbc);
                return myorderdetail.Where(new SQLCondition(myorderdetail)
                .Equal(myorderdetail.MY_ORDER_UUID, pMyOrderUuid).And()
                .L()
                .iBLike(myorderdetail.MY_ORDER_DETAIL_GOODS_NAME, pKeyword)                
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

        public IList<MyOrderDetail_Record> getMyOrderDetail_By_MyOrderUuid_Keyword(string pMyOrderUuid, string pKeyword, OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.MyOrderDetail myorderdetail = new Limew.Model.Lw.Table.MyOrderDetail(dbc);
                return myorderdetail.Where(new SQLCondition(myorderdetail)
                .Equal(myorderdetail.MY_ORDER_UUID, pMyOrderUuid).And()
                .L()
                .iBLike(myorderdetail.MY_ORDER_DETAIL_GOODS_NAME, pKeyword)
                .R()
                    )
                    .Limit(orderLimit)
                    .FetchAll<MyOrderDetail_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public Int32 getVMyOrderDetail_By_MyOrderUuid_SupplierUuid_Keyword_Count(string pMY_ORDER_UUID, string pSupplierUuid, string pKeyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.VMyOrderDetail vmyorderdetail = new Limew.Model.Lw.Table.VMyOrderDetail(dbc);
                var sc = new SQLCondition(vmyorderdetail);

                if (pMY_ORDER_UUID.Trim().Length > 0)
                {
                    sc.Equal(vmyorderdetail.MY_ORDER_UUID, pMY_ORDER_UUID).And();
                };

                if (pSupplierUuid.Trim().Length > 0)
                {
                    sc.Equal(vmyorderdetail.SUPPLIER_UUID, pSupplierUuid).And();
                };

                if (pKeyword.Trim().Length > 0)
                {
                    sc.L()
                        .iBLike(vmyorderdetail.MY_ORDER_CONTACT_EMAIL, pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_CONTACT_NAME, pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_CONTACT_PHONE, pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_DETAIL_GOODS_NAME, pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_PS, pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_SUPPLIER_ADDRESS, pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_SUPPLIER_FAX, pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_SUPPLIER_NAME, pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_SUPPLIER_TEL, pKeyword)
                        .R();
                };

                sc.CheckSQL();


                return vmyorderdetail.Where(sc)
                   .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<VMyOrderDetail_Record> getVMyOrderDetail_By_MyOrderUuid_SupplierUuid_Keyword(string pMY_ORDER_UUID,string pSupplierUuid,string pKeyword,OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.VMyOrderDetail vmyorderdetail = new Limew.Model.Lw.Table.VMyOrderDetail(dbc);
                var sc = new SQLCondition(vmyorderdetail);

                if(pMY_ORDER_UUID.Trim().Length>0){
                    sc.Equal(vmyorderdetail.MY_ORDER_UUID,pMY_ORDER_UUID).And();
                };

                if(pSupplierUuid.Trim().Length>0){
                    sc.Equal(vmyorderdetail.SUPPLIER_UUID, pSupplierUuid).And();
                };

                if(pKeyword.Trim().Length>0){
                    sc.L()
                        .iBLike(vmyorderdetail.MY_ORDER_CONTACT_EMAIL,pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_CONTACT_NAME,pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_CONTACT_PHONE,pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_DETAIL_GOODS_NAME,pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_PS,pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_SUPPLIER_ADDRESS,pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_SUPPLIER_FAX,pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_SUPPLIER_NAME,pKeyword).Or()
                        .iBLike(vmyorderdetail.MY_ORDER_SUPPLIER_TEL,pKeyword)
                        .R();
                };


                sc.CheckSQL();

                return vmyorderdetail.Where(sc)
                    .Limit(orderLimit)
                    .FetchAll<VMyOrderDetail_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<MyOrderDetail_Record> getMyOrderDetail_By_MyOrderUuid(string pMY_ORDER_UUID)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.MyOrderDetail myorderdetail = new Limew.Model.Lw.Table.MyOrderDetail(dbc);
                return myorderdetail.Where(new SQLCondition(myorderdetail).Equal(myorderdetail.MY_ORDER_UUID, pMY_ORDER_UUID))
                    .FetchAll<MyOrderDetail_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<Cust_Record> getCust_By_CustUuid_CustIsActive(string pCUST_UUID,string pCustIsActive,OrderLimit orderlimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.Cust cust = new Limew.Model.Lw.Table.Cust(dbc);
                return cust.Where(new SQLCondition(cust).Equal(cust.CUST_UUID, pCUST_UUID).And().Equal(cust.CUST_IS_ACTIVE, pCustIsActive))
                    .Limit(orderlimit)
                    .FetchAll<Cust_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getCust_By_Keyword_CustIsActive_Count(string pKeyword,string pCustIsActive)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Cust table = new Cust(dbc);

                var sc = new SQLCondition(table);
                if (pCustIsActive.Trim().Length > 0)
                {
                    if (pCustIsActive.IndexOf('|') != -1)
                    {
                        sc.L();
                        foreach (var c in pCustIsActive.Split('|')) {
                            sc.Equal(table.CUST_IS_ACTIVE,c).Or();
                        }
                        sc.CheckSQL();
                        sc.R().And();
                    }
                    else {
                        sc.Equal(table.CUST_IS_ACTIVE, pCustIsActive).And();
                    }
                    
                }

                if (pKeyword.Trim().Length > 0)
                {
                    sc.L()
                        .iBLike(table.CUST_NAME, pKeyword)
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
                        .R();
                };

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

        public IList<Cust_Record> getCust_By_Keyword_CustIsActive(string pKeyword, string pCustIsActive,OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Cust table = new Cust(dbc);
                var sc = new SQLCondition(table);
                if (pCustIsActive.Trim().Length > 0)
                {
                    if (pCustIsActive.IndexOf('|') != -1)
                    {
                        sc.L();
                        foreach (var c in pCustIsActive.Split('|'))
                        {
                            sc.Equal(table.CUST_IS_ACTIVE, c).Or();
                        }
                        sc.CheckSQL();
                        sc.R().And();
                    }
                    else
                    {
                        sc.Equal(table.CUST_IS_ACTIVE, pCustIsActive).And();
                    }

                }

                if(pKeyword.Trim().Length>0){
                sc.L()
                    .iBLike(table.CUST_NAME, pKeyword)
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
                    .R();
                };
                sc.CheckSQL();
                    
                    
                return table.Where(sc
                    )
                    .Limit(orderLimit)
                    .FetchAll<Cust_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getSupplier_By_Keyword_SupplierIsActive_Count(string pKeyword, string pSupplierIsActive)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Supplier table = new Supplier(dbc);
                var sc = new SQLCondition(table);                   
                    
                if (pSupplierIsActive.Trim().Length > 0)
                {
                    if (pSupplierIsActive.IndexOf('|') != -1)
                    {
                        sc.L();
                        foreach (var c in pSupplierIsActive.Split('|'))
                        {
                            sc.Equal(table.SUPPLIER_IS_ACTIVE, c).Or();
                        }
                        sc.CheckSQL();
                        sc.R().And();
                    }
                    else
                    {
                        sc.Equal(table.SUPPLIER_IS_ACTIVE, pSupplierIsActive).And();
                    }

                }

                if(pKeyword.Trim().Length>0){
                    sc.L().iBLike(table.SUPPLIER_NAME, pKeyword)
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
                    .R();
                }

                sc.CheckSQL();

                return table.Where(sc
                    )
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<Supplier_Record> getSupplier_By_Keyword_SupplierIsActive(string pKeyword, string pSupplierIsActive,OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Supplier table = new Supplier(dbc);
                var sc = new SQLCondition(table);
                if (pSupplierIsActive.Trim().Length > 0)
                {
                    if (pSupplierIsActive.IndexOf('|') != -1)
                    {
                        sc.L();
                        foreach (var c in pSupplierIsActive.Split('|'))
                        {
                            sc.Equal(table.SUPPLIER_IS_ACTIVE, c).Or();
                        }
                        sc.CheckSQL();
                        sc.R().And();
                    }
                    else
                    {
                        sc.Equal(table.SUPPLIER_IS_ACTIVE, pSupplierIsActive).And();
                    }

                }

                if (pKeyword.Trim().Length > 0)
                {
                    sc.L().iBLike(table.SUPPLIER_NAME, pKeyword)
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
                    .R();
                }

                sc.CheckSQL();

                return table.Where(sc
                    )
                    .Limit(orderLimit)
                    .FetchAll<Supplier_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<Billing_Record> getBilling_By_BillingId(string pBillingId, OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Billing table = new Billing(dbc);
                var sc = new SQLCondition(table);
                sc.Equal(table.BILLING_ID, pBillingId);
                return table.Where(sc)
                    .Limit(orderLimit)
                    .FetchAll<Billing_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<BillingDetail_Record> getBillingDetail_By_BillingUuid(string pBILLING_UUID)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.BillingDetail billingdetail = new Limew.Model.Lw.Table.BillingDetail(dbc);
                return billingdetail
                    .Where(new SQLCondition(billingdetail).Equal(billingdetail.BILLING_UUID, pBILLING_UUID))
                    .FetchAll<BillingDetail_Record>();
                //return billingdetail;
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getVBillingDetail_By_BillingUuid_Count(string pBillingUuid)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VBillingDetail table = new VBillingDetail(dbc);
                var sc = new SQLCondition(table);
                sc.Equal(table.BILLING_UUID, pBillingUuid)
                   ;
                return table.Where(sc)
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VBillingDetail_Record> getVBillingDetail_By_BillingUuid(string pBillingUuid,OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                VBillingDetail table = new VBillingDetail(dbc);
                var sc = new SQLCondition(table);
                sc.Equal(table.BILLING_UUID, pBillingUuid)
                   ;
                return table.Where(sc)
                    .Limit(orderLimit)
                    .FetchAll<VBillingDetail_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getBilling_By_CustUuid_Keyword_Count(string pCustUuid,string pBillingIsActive, string keyword)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Billing table = new Billing(dbc);
                var sc = new SQLCondition(table);
                if (pCustUuid.Trim().Length > 0) {
                    sc.Equal(table.CUST_UUID, pCustUuid).And();
                }

                if (keyword.Trim().Length > 0) {
                    sc.L()
                        .iBLike(table.BILLING_ARREARS_PRICE, keyword).Or()
                        .iBLike(table.BILLING_BACK_ACCOUNT_NAME, keyword).Or()
                        .iBLike(table.BILLING_BACK_ACCOUNT_NUMBER, keyword).Or()
                        .iBLike(table.BILLING_BACK_NAME, keyword).Or()
                        .iBLike(table.BILLING_BACK_SUB_NAME, keyword).Or()
                        .iBLike(table.BILLING_CHECK_MM, keyword).Or()
                        .iBLike(table.BILLING_CHECK_TITLE, keyword).Or()
                        .iBLike(table.BILLING_CONTACT_USER_NAME, keyword).Or()
                        .iBLike(table.BILLING_CUST_ADDRESS, keyword).Or()
                        .iBLike(table.BILLING_CUST_NAME, keyword).Or()
                        .iBLike(table.BILLING_CUST_UNIFORM_NUM, keyword).Or()
                        .iBLike(table.BILLING_DISCOUNT, keyword).Or()
                        .iBLike(table.BILLING_ID, keyword).Or()
                        .iBLike(table.BILLING_PS, keyword).Or()
                        .iBLike(table.BILLING_SALES_NAME, keyword).Or()
                        .iBLike(table.BILLING_SUM_PRICE, keyword).Or()
                        .iBLike(table.BILLING_TEL, keyword).Or()
                        .iBLike(table.BILLING_TOTAL_PRICE, keyword)
                        .R().And();

                }
                
                if (pBillingIsActive.Trim().Length > 0) {
                    sc.Equal(table.BILLING_IS_ACTIVE, pBillingIsActive).And();
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

        public IList<Billing_Record> getBilling_By_CustUuid_Keyword(string pCustUuid, string pBillingIsActive,string keyword,OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Billing table = new Billing(dbc);
                var sc = new SQLCondition(table);
                if (pCustUuid.Trim().Length > 0)
                {
                    sc.Equal(table.CUST_UUID, pCustUuid).And();
                }

                if (keyword.Trim().Length > 0)
                {
                    sc.L()
                        .iBLike(table.BILLING_ARREARS_PRICE, keyword).Or()
                        .iBLike(table.BILLING_BACK_ACCOUNT_NAME, keyword).Or()
                        .iBLike(table.BILLING_BACK_ACCOUNT_NUMBER, keyword).Or()
                        .iBLike(table.BILLING_BACK_NAME, keyword).Or()
                        .iBLike(table.BILLING_BACK_SUB_NAME, keyword).Or()
                        .iBLike(table.BILLING_CHECK_MM, keyword).Or()
                        .iBLike(table.BILLING_CHECK_TITLE, keyword).Or()
                        .iBLike(table.BILLING_CONTACT_USER_NAME, keyword).Or()
                        .iBLike(table.BILLING_CUST_ADDRESS, keyword).Or()
                        .iBLike(table.BILLING_CUST_NAME, keyword).Or()
                        .iBLike(table.BILLING_CUST_UNIFORM_NUM, keyword).Or()
                        .iBLike(table.BILLING_DISCOUNT, keyword).Or()
                        .iBLike(table.BILLING_ID, keyword).Or()
                        .iBLike(table.BILLING_PS, keyword).Or()
                        .iBLike(table.BILLING_SALES_NAME, keyword).Or()
                        .iBLike(table.BILLING_SUM_PRICE, keyword).Or()
                        .iBLike(table.BILLING_TEL, keyword).Or()
                        .iBLike(table.BILLING_TOTAL_PRICE, keyword)
                        .R().And();

                }

                if (pBillingIsActive.Trim().Length > 0)
                {
                    sc.Equal(table.BILLING_IS_ACTIVE, pBillingIsActive).And();
                }

                sc.CheckSQL();

                return table.Where(sc)
                    .Limit(orderLimit)
                    .FetchAll < Billing_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VBillingExp_Record> getVBillingExp_By_BillingUuid(string pBillingUuid,OrderLimit orderLimit)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.VBillingExp vbillingexp = new Limew.Model.Lw.Table.VBillingExp(dbc);
                return vbillingexp.Where(new SQLCondition(vbillingexp).Equal(vbillingexp.BILLING_UUID, pBillingUuid))
                    .Limit(orderLimit)
                    .FetchAll<VBillingExp_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<Goods_Record> getGoods_By_SupplierUuid(string pSupplierUuid)
        {
            try
            {
                dbc = LK.Config.DataBase.Factory.getInfo();
                Limew.Model.Lw.Table.Goods goods = new Limew.Model.Lw.Table.Goods(dbc);
                return goods.Where(new SQLCondition(goods).Equal(goods.SUPPLIER_UUID, pSupplierUuid))
                    .FetchAll<Goods_Record>();
                //return goods;
            }
            catch (Exception ex)
            {
                log.Error(ex); LK.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

	}
}
