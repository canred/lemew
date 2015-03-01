<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="gcategory.aspx.cs" Inherits="Limew.admin.limew.gcategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
.x-action-col-icon {
    height: 16px;
    width: 16px;
    margin-right: 8px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
Ext.onReady(function () {
    WS_GCATEGORYQUERYPANEL = Ext.create('WS.GcategoryQueryPanel',{
        subWinGcategoryWindow:'WS.GcategoryWindow'
    });    
    WS_GCATEGORYQUERYPANEL.render('divMain');
    UTIL.session.fnKeep();
});
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
</asp:Content>
