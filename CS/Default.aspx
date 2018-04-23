<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <dx:ASPxCardView ID="ASPxCardView1" runat="server" DataSourceID="AccessDataSource1" OnCustomButtonInitialize="ASPxCardView1_CustomButtonInitialize" OnCommandButtonInitialize="ASPxCardView1_CommandButtonInitialize" KeyFieldName="ProductID" AutoGenerateColumns="False">
        <ClientSideEvents CustomButtonClick="function(s, e) {        
            alert('keyValue = ' + s.GetCardKey(e.visibleIndex));	
}" />
        <SettingsBehavior AllowFocusedCard="true" />
        <Columns>
            <dx:CardViewTextColumn FieldName="ProductID" VisibleIndex="2" ReadOnly="True">
            </dx:CardViewTextColumn>
            <dx:CardViewTextColumn FieldName="ProductName" VisibleIndex="0">
            </dx:CardViewTextColumn>
            <dx:CardViewTextColumn FieldName="UnitPrice" VisibleIndex="1">
            </dx:CardViewTextColumn>
        </Columns>
        <CardLayoutProperties>
            <Items>
                <dx:CardViewCommandLayoutItem HorizontalAlign="Right" ShowDeleteButton="True" ShowEditButton="True">
                </dx:CardViewCommandLayoutItem>
                <dx:CardViewColumnLayoutItem ColumnName="ProductID">
                </dx:CardViewColumnLayoutItem>
                <dx:CardViewColumnLayoutItem ColumnName="Product Name">
                </dx:CardViewColumnLayoutItem>
                <dx:CardViewColumnLayoutItem ColumnName="UnitPrice">
                </dx:CardViewColumnLayoutItem>                
            </Items>
        </CardLayoutProperties>        
        </dx:ASPxCardView>  
    <br />
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
        SelectCommand="SELECT [ProductID], [ProductName], [UnitPrice] FROM [Products]" DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = ?" InsertCommand="INSERT INTO [Products] ([ProductID], [ProductName], [UnitPrice]) VALUES (?, ?, ?)" UpdateCommand="UPDATE [Products] SET [ProductName] = ?, [UnitPrice] = ? WHERE [ProductID] = ?" >
        <DeleteParameters>
            <asp:Parameter Name="ProductID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ProductID" Type="Int32" />
            <asp:Parameter Name="ProductName" Type="String" />
            <asp:Parameter Name="UnitPrice" Type="Decimal" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ProductName" Type="String" />
            <asp:Parameter Name="UnitPrice" Type="Decimal" />
            <asp:Parameter Name="ProductID" Type="Int32" />
        </UpdateParameters>
        </asp:AccessDataSource>
    </div>
    </form>
</body>
</html>
