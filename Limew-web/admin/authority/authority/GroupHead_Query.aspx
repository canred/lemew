<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/mpStand.Master" CodeBehind="GroupHead_Query.aspx.cs" Inherits="Web.admin.authority.authority.GroupHead_Query"  EnableViewState="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">

Ext.onReady(function () {


    // var fld_attendant_uuid = new Ext.form.TextField({
    //     readOnly: true,
    //     xtype: 'textfield',
    //     name: 'fld_attendant_uuid',
    //     id: 'fld_attendant_uuid',
    //     emptyText: '',
    //     allowBlank: true,
    //     width: 160,
    //     hidden: true
    // });

    // var btn_attendant = new Ext.create('Ext.Button', {
    //     xtype: 'button',
    //     style: 'margin-right:65px;margin-left:2px;',
    //     text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/mouse_select_left.gif" style="height:18px;vertical-align:middle;margin-top:-2px;margin-left:5px;margin-right:5px;">',

    //     handler: function () {
    //         var companyUuid = '<%= getUser().COMPANY_UUID %>';
    //         if (AttendantQueryForm == undefined) {
    //             AttendantQueryForm = Ext.create('AttendantPicker', {});
    //             AttendantQueryForm.on('selectedEvent', function (record) {
    //                 Ext.getCmp('display_attendant_uuid').setValue(record.data["C_NAME"]);
    //                 Ext.getCmp('fld_attendant_uuid').setValue(record.data["UUID"]);
    //                 Ext.getCmp('btnQuery').handler();
    //                 AttendantQueryForm.hide();
    //             });
    //         }            
    //         AttendantQueryForm.companyUuid = companyUuid;
    //         AttendantQueryForm.show();
    //     }
    // });
    WS_GROUPQUERYPANEL = Ext.create('WS.GroupQueryPanel',{
        param:{
            companyUuid:"<%= this.getUser().COMPANY_UUID %>"
        }
    });

    WS_GROUPQUERYPANEL.render('divMain');
});
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
<!-- 使用者session的檢查操作，當逾期時自動轉頁至登入頁面 -->
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/keeySession.js")%>'></script>      
</asp:Content>