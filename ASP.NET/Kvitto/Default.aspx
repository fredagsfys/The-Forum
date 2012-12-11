<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" EnableViewState = "false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Kassakvitto</h1>
    <p>Total köpesumma:</p>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="inputTextbox" runat="server" 
            ontextchanged="inputTextbox_TextChanged"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ErrorMessage="Ange ett heltal större än 0" Display="Dynamic" 
            ControlToValidate="inputTextbox" ForeColor="Red" Operator="GreaterThan" 
            Type="Double" ValueToCompare="0,0"></asp:CompareValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="Ange total köpesumma" Display="Dynamic" 
            ControlToValidate="inputTextbox" ForeColor="Red"></asp:RequiredFieldValidator>

    </div>

    <p>
        <asp:Button ID="calcButton" runat="server" Text="Beräkna rabatt" />
    </p>
    </form>
</body>
</html>
