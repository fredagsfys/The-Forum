<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="ram">
         <asp:ObjectDataSource ID="ServiceObjectDataSource" runat="server" SelectMethod="GetContacts"
                TypeName="Service" DataObjectTypeName="Contact" DeleteMethod="DeleteContact"
                InsertMethod="SaveContact" UpdateMethod="SaveContact" 
             OldValuesParameterFormatString="original_{0}" />


                   <asp:ListView ID="ContactListView" runat="server" DataSourceID="ServiceObjectDataSource"
                DataKeyNames="ContactId" InsertItemPosition="FirstItem" >
                <LayoutTemplate>
                    <table class="grid">
                        <tr>
                            <th>
                                Namn
                            </th>
                            <th>
                                Efternamn
                            </th>
                            <th>
                                Email
                            </th>
                            <th>
                            </th>
                        </tr>
                        <%-- Platshållare för nya rader --%>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <%-- Mall för nya rader, varannan rad med klassen alternate. --%>
                    <tr>
                        <td>
                            <asp:Label ID="FirstName" runat="server" Text='<%# Eval("FirstName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="LastName" runat="server" Text='<%# Eval("LastName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EmailAddress" runat="server" Text='<%# Eval("EmailAdress") %>' />
                        </td>
                        <td class="command">
                            <%-- "Kommandknappar" för att ta bort och redigera kunduppgifter. Kommandonamnen är VIKTIGA! --%>
                            <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandName="Delete" Text="Ta bort" />
                            <asp:LinkButton ID="EditLinkButton" runat="server" CommandName="Edit" Text="Redigera" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <%-- Detta visas då kunduppgifter saknas i databasen. --%>
                    <table class="grid">
                        <tr>
                            <td>
                                Kunduppgifter saknas.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <%-- Mall för rad i tabellen för att lägga till nya kunduppgifter. Visas bara om InsertItemPosition 
                     har värdet FirstItemPosition eller LasItemPosition.--%>
                    <tr>
                        <td>
                            <asp:TextBox ID="FirstName" runat="server" Text='<%# Bind("FirstName") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="LastName" runat="server" Text='<%# Bind("LastName") %>' />
                        </td>
                        <td>
                            <asp:Textbox ID="EmailAddress" runat="server" Text='<%# Bind("EmailAdress") %>' />
                        </td>
                        <td>
                            <%-- "Kommandknappar" för att lägga till en ny kunduppgift och rensa texfälten. Kommandonamnen är VIKTIGA! --%>
                            <asp:LinkButton ID="InsertLinkButton" runat="server" CommandName="Insert" Text="Lägg till" />
                            <asp:LinkButton ID="CancelLinkButton" runat="server" CommandName="Cancel" Text="Rensa" />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <EditItemTemplate>
                    <%-- Mall för rad i tabellen för att redigera kunduppgifter. --%>
                    <tr>
                        <td>
                            <asp:Textbox ID="FirstName" runat="server" Text='<%# Bind("FirstName") %>' />
                        </td>
                        <td>
                            <asp:Textbox ID="LastName" runat="server" Text='<%# Bind("LastName") %>' />
                        </td>
                        <td>
                            <asp:Textbox ID="EmailAddress" runat="server" Text='<%# Bind("EmailAdress") %>' />
                        </td>
                        <td>
                            <%-- "Kommandknappar" för att uppdatera en kunduppgift och avbryta. Kommandonamnen är VIKTIGA! --%>
                            <asp:LinkButton ID="UpdateLinkButton" runat="server" CommandName="Update" Text="Spara" />
                            <asp:LinkButton ID="CancelLinkButton" runat="server" CommandName="Cancel" Text="Avbryt" />
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
            </div>
            <div id="pager">
        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ContactListView">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                    ShowLastPageButton="True" />
            </Fields>
        </asp:DataPager>
        </div>
    </div>
    </form>
</body>
</html>
