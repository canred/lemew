<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="Web.admin.system.menu"  EnableViewState="false"  %>
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
// var thisTreeStore = undefined;
// var AppPageQuery = undefined;
// var myForm = undefined;
// var AppMenuTaskFlag = false;



// var PARENTUUID = undefined;

// function openOrgn(uuid, parendUuid) {
//     PARENTUUID = parendUuid;
// }
// Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".AppPageAction"));
// Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".MenuAction"));
// Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".ApplicationAction"));

// /*編輯menu的功能*/
// function openMenu(uuid) {

//     /*appMenuForm 變量保存在 Ext.AppMenuForm.js當中*/
//     if (appMenuForm == undefined) {
//         Ext.getBody().mask();
//         appMenuForm = Ext.create('AppMenuForm');
//         appMenuForm.applicationHeadUuid = Ext.getCmp('menu_Query_Application').getValue();

//         /*載入關閉後的事件*/
//         appMenuForm.on('closeEvent', function (obj) {
//             /*重新整理畫面的內容*/
//             var btnQuery = Ext.getCmp('menu.Query.Button');
//             btnQuery.handler.call(btnQuery.scope);
//             Ext.getBody().unmask();
//         });

//         /*設定開啟事內的條件*/
//         appMenuForm.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/menu.png" style="height:20px;vertical-align:middle;margin-right:5px;">選單【編輯】');
//         appMenuForm.uuid = uuid;

//         appMenuForm.show();
//     } else {
//         Ext.getBody().mask();
//         appMenuForm.uuid = uuid;
//         appMenuForm.applicationHeadUuid = Ext.getCmp('menu_Query_Application').getValue();
//         appMenuForm.show();
//     }
// }

// function addChild(a, b) {
//     WS.MenuAction.loadTreeRoot(Ext.getCmp('menu_Query_Application').getValue(), function (data) {
//         PARENTUUID = b;
//         Ext.getBody().mask();

//         /*appMenuForm 變量保存在 Ext.AppMenuForm.js當中*/
//         if (appMenuForm == undefined) {
//             appMenuForm = Ext.create('AppMenuForm');
//             /*載入關閉後的事件*/
//             appMenuForm.on('closeEvent', function (obj) {
//                 /*重新整理畫面的內容*/
//                 var btnQuery = Ext.getCmp('menu.Query.Button');
//                 Ext.getBody().unmask();
//                 btnQuery.handler.call(btnQuery.scope);
//             });
//             /*設定開啟事內的條件*/
//             appMenuForm.uuid = undefined;
//             appMenuForm.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/menu.png" style="height:20px;vertical-align:middle;margin-right:5px;">選單【新增】');
//             appMenuForm.parentUuid = PARENTUUID;
//             appMenuForm.applicationHeadUuid = Ext.getCmp('menu_Query_Application').getValue();
//             appMenuForm.show();
//         } else {
//             appMenuForm.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/menu.png" style="height:20px;vertical-align:middle;margin-right:5px;">選單【新增】');
//             appMenuForm.uuid = undefined;
//             appMenuForm.parentUuid = PARENTUUID;
//             appMenuForm.applicationHeadUuid = Ext.getCmp('menu_Query_Application').getValue();
//             appMenuForm.show();
//         }
//     });

//     AppMenuTaskFlag = true;

// }

// function delMenu(uuid) {
//     Ext.Msg.show({
//         title: '刪除節點操作',
//         msg: '確定執行刪除動作?',
//         buttons: Ext.Msg.YESNO,
//         fn: function (btn) {
//             if (btn == "yes") {
//                 WS.MenuAction.deleteAppMenu(uuid, function (json) {
//                     var btnQuery = Ext.getCmp('menu.Query.Button')
//                     btnQuery.handler.call(btnQuery.scope)
//                     AppMenuTaskFlag = true;
//                 });
//             }
//         }
//     });

// }


Ext.onReady(function () {
    WS_MENUQUERYPANEL = Ext.create('WS.MenuQueryPanel',{
        subWinMenuWindow:'WS.MenuWindow'
    });
    /*設定元件*/
    WS_MENUQUERYPANEL.render('divMain');
});
</script>
			
			<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
<!-- 使用者session的檢查操作，當逾期時自動轉頁至登入頁面 -->
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/keeySession.js")%>'></script>           
</asp:Content>
