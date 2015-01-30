<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="company.aspx.cs" Inherits="Web.admin.basic.mainpage" EnableViewState="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">

Ext.onReady(function() {
    /*實例化公司編輯的物件*/    
    //var subWinCompany = Ext.create('WS.CompanyWindow',{});

    WS_COMPANYQUERYPANEL = Ext.create('WS.CompanyQueryPanel',{
        /*將實例化的公司編輯物件傳入*/
        'subWinCompany':'WS.CompanyWindow'
    });

    WS_COMPANYQUERYPANEL.render('divMain');
});

</script>
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
<!-- 使用者session的檢查操作，當逾期時自動轉頁至登入頁面 -->
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pagejs/keeySession.js")%>'></script>           
</asp:Content>





