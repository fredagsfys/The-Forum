<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" ViewStateMode="Disabled"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa talet</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Focus.js"></script>
</head>
<body>
    <h1>Gissa Talet, Guess the number, Pogodi broj, Rate Zhal</h1>
    <form id="form1" runat="server">
    <div id="OP1">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            HeaderText="Fel inträffade, återgärda felen och försök igen" ForeColor="Red" />
    </div>
    <div id="OP2">
            <asp:Label ID="Label1" runat="server" Text="Ange ett tal mellan 1 - 100:"></asp:Label>
        <asp:TextBox ID="inputTextBox" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" 
            ErrorMessage="Talet måste vara mellan 1 - 100" ControlToValidate="inputTextBox" 
            Display="Dynamic" ForeColor="Red" MaximumValue="100" MinimumValue="1" 
                Type="Integer">*</asp:RangeValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="Ange ett tal!" Display="Dynamic" Text="*" 
            ControlToValidate="inputTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:Button ID="myGuessButton" runat="server" Text="Skicka gissning" 
            onclick="myGuessButton_Click" />

        <br />
    <asp:PlaceHolder ID="PlaceHolderPrevious" runat="server"></asp:PlaceHolder>
    <asp:Literal ID="LiteralPrevious" runat="server"></asp:Literal>
    <asp:PlaceHolder ID="PlaceHolderOutput" runat="server"></asp:PlaceHolder>
    <asp:Literal ID="LiteralOutput" runat="server"></asp:Literal>
        <br />
    <p>
        <asp:Button ID="generateNewButton" runat="server" Text="Slumpa nytt hemligt tal" 
            onclick="generateNewButton_Click" CausesValidation="False" />
    </p>
    </div>
    </form>
</body>
</html>
