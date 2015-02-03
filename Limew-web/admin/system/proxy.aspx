<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="proxy.aspx.cs" Inherits="Web.admin.system.proxy"  EnableViewState="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
Ext.onReady(function () {
    WS_PROXYQUERYPANEL = Ext.create('WS.ProxyQueryPanel',{});
    WS_PROXYQUERYPANEL.render('divMain');
});
</script>
			
			<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
<!-- 使用者session的檢查操作，當逾期時自動轉頁至登入頁面 -->
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/keeySession.js")%>'></script>
</asp:Content>

