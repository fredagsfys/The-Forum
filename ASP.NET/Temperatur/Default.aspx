<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" ViewStateMode ="Disabled"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Temperatur</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <h1>Temperatur konverterare</h1>
    <form id="form1" runat="server">
    <div class="OP1">
    <%--Total sammling för alla felmeddelanden--%>
        <asp:ValidationSummary ID="TempConvertValidationSummary" runat="server" 
            ForeColor="Red" HeaderText="Fel inträffade! Återgärda felen och försök igen." />
    </div>
    <div class="OP2">
        <%--Textruta och rubrik--%>
        <asp:Label ID="startTempLabel" runat="server" Text="Starttemperatur"></asp:Label>
        <br />
        <asp:TextBox ID="startTempTextBox" runat="server" ControlToValidate="startTempTextBox"></asp:TextBox>
        <%--Validering för Textbox--%>
        <asp:CompareValidator ID="startTempCompareValidator" runat="server" 
            ErrorMessage="Ange ett heltal på starttemperatur" 
            ControlToValidate="startTempTextBox" Display="Dynamic" ForeColor="Red" 
            Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
        <asp:RequiredFieldValidator ID="startTempRequiredFieldValidator" runat="server" 
            ErrorMessage="Ange en starttemperatur" 
            ControlToValidate="startTempTextBox" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <%--Textruta och rubrik--%>
        <asp:Label ID="endTempLabel" runat="server" Text="Sluttemperatur"></asp:Label>
        <br />
        <asp:TextBox ID="endTempTextBox" runat="server"></asp:TextBox>
        <%--Validering för Textbox--%>
        <asp:RequiredFieldValidator ID="endTempRequiredFieldValidator" runat="server" 
            ErrorMessage="Ange en sluttemperatur" Display="Dynamic" 
            ControlToValidate="endTempTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="endTempCompareValidator" runat="server" 
            ErrorMessage="Ange en större temperatur än starttemperaturen" 
            Operator="GreaterThan" Type="Integer" ValueToCompare="startTempTextBox" 
            Display="Dynamic" Text="*" ControlToCompare="startTempTextBox" 
            ControlToValidate="endTempTextBox" ForeColor="Red"></asp:CompareValidator>
        <br />
        <%--Textruta och rubrik--%>
        <asp:Label ID="levelTempLabel" runat="server" Text="Temperatursteg"></asp:Label>
        <br />
        <asp:TextBox ID="levelTempTextBox" runat="server"></asp:TextBox>
        <%--Validering för Textbox--%>
        <asp:RequiredFieldValidator ID="levelTempRequiredFieldValidator" runat="server" 
            ErrorMessage="Ange ett temperaturssteg" Display="Dynamic" Text="*" 
            ControlToValidate="levelTempTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="levelTempCompareValidator" runat="server" 
            ErrorMessage="Ange ett heltal på temperaturssteg" Type="Integer" 
            Display="Dynamic" ControlToValidate="levelTempTextBox" Operator="DataTypeCheck" 
            ForeColor="Red">*</asp:CompareValidator>
        <asp:RangeValidator ID="levelTempRangeValidator" runat="server" 
            ErrorMessage="Ange ett tal mellan 1 - 100" Display="Dynamic" MaximumValue="100" 
            MinimumValue="1" ControlToValidate="levelTempTextBox" ForeColor="Red" 
            Type="Integer">*</asp:RangeValidator>
        <br />
        <%--Radioknapp, väljer mellan typ av konvertering--%>
    <p>
        <asp:RadioButton ID="RadioButton1" runat="server" 
            Text="Farenheit till Celcius" />
        </p>
        <p>
            <asp:RadioButton ID="RadioButton2" runat="server" 
            Text="Celcius Till Fahrenheit" />
        </p>
    </div>
    <%--Klickbar knapp som startar eventet--%>
    <p>
        <asp:Button ID="convertButton" runat="server" Text="Konvertera" Width="101px" 
            onclick="convertButton_Click" />
    </p>
    <%--Kolumner och spalter, tabell--%>
    <asp:Table ID="TablePresent" runat="server" Width="100px" BackColor="#CCFF99" 
        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
    </asp:Table>

    </form>
</body>
</html>
