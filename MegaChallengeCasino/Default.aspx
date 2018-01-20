<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MegaChallengeCasino.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="slotImage1" runat="server" Height="174px" Width="143px" />
            <asp:Image ID="slotImage2" runat="server" Height="174px" Width="143px" />
            <asp:Image ID="slotImage3" runat="server" Height="174px" Width="143px" />
            <br />
            <br />
            Your bet: <asp:TextBox ID="betTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="leverButton" runat="server" Text="Pull the Lever!" OnClick="leverButton_Click" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
            <br />
            Player&#39;s Money:
            <asp:Label ID="moneyLabel" runat="server"></asp:Label>
            <br />
            <br />
            1 Cherry = x2 Your Bet<br />
            2 Cherries - x3 Your Bet<br />
            3 Cherries - x4 Your Bet<br />
            4 7s - Jackpot - x100 Your Bet<br />
            HOWERVER ... If there&#39;s even one bar, you win nothing.</div>
    </form>
</body>
</html>
