<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" ViewStateMode="Disabled"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Galleriet</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body class="op1">
    <h1>Galleriet</h1>
    <asp:Image ID="Image1" runat="server" ImageUrl=' <%# "~/Content/Files/" + DataBinder.Eval(Container,"DataItem") %>' />
    <form id="form1" runat="server">
    <div>
    <div id="lol">
        <asp:Repeater ID="FileRepeater" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <div id="float">
                    <li>
                       <asp:HyperLink ID="PicHyperLink" runat="server" NavigateUrl='<%# String.Format("?name={0}", Container.DataItem) %>'>
                       <asp:Image ID="Thumbnails" runat="server" ImageUrl='<%# String.Format("~/Content/Files/thumbs/{0}", Container.DataItem) %>'>
                       </asp:Image>
                       </asp:HyperLink>
                    </li>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        </div>
        <br />
        <br />
        <br />
        <br />
        <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" 
            style="margin-bottom: 19px" />
        <asp:FileUpload ID="FileUpload" runat="server" Font-Names="Välj fil" 
            ondatabinding="FileUpload_Click" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" 
            ErrorMessage="En fil måste bifogas" Display="Dynamic" Text="*" 
            ForeColor="Red" ControlToValidate="FileUpload"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" 
            ErrorMessage="Filen måste vara av typen .gif, .png, .jpg" 
            ControlToValidate="FileUpload" Display="Dynamic" ForeColor="Red" 
            ValidationExpression="^.*\.(jpg|JPG|gif|GIF|)$">*</asp:RegularExpressionValidator>
        <asp:Button ID="uploadButton" runat="server" Text="Ladda upp" 
            onclick="FileUpload_Click" />
    </div>
    </form>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.1/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="jscript.js"></script>
</body>
</html>
