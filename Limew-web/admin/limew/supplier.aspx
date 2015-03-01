<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="supplier.aspx.cs" Inherits="Limew.admin.limew.supplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
    Ext.onReady(function () {
        WS_SUPPLIERQUERYPANEL = Ext.create('WS.SupplierQueryPanel', {
            subWinSupplier: 'WS.SupplierWindow'
        });
        WS_SUPPLIERQUERYPANEL.render('divMain');
        UTIL.session.fnKeep();
    });
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
</asp:Content>


