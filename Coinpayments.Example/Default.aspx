<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Coinpayments.Example.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnBuy" runat="server" Text="$10 in LTCT purchase on Coinpayments" OnClick="btnBuy_Click" />
    </div>
    </form>
</body>
</html>
