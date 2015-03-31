<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="goodsRecord.aspx.cs" Inherits="Limew.admin.limew.goodsRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
    Ext.onReady(function () {
        WS_MYORDERQUERYPANEL = Ext.create('WS.MyOrderQueryPanel', {
            subWinMyOrder: 'WS.MyOrderWindow'
        });
        WS_MYORDERQUERYPANEL.render('divMain');
        UTIL.runAll();
    });
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
</asp:Content>
