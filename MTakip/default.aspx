<%@ Page Title="Gösterge Paneli" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="MTakip._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">

    <div class="title">
        <h5>Gösterge Paneli</h5>
    </div>

    <!-- Statistics -->
    <div class="stats">
        <ul>
            <li><a id="T_Ariza" runat="server" href="Anasayfa?tb=T_Ariza" class="count grey" title="">52</a><span>Tamamlanan Arıza</span></li>
            <li><a id="B_Ariza" runat="server" href="Anasayfa?tb=B_Ariza" class="count grey" title="">520</a><span>Bekleyen Arızalar</span></li>
            <li><a id="T_Basvuru" runat="server" href="Anasayfa?tb=T_Basvuru" class="count grey" title="">14</a><span>Tamamlanan Başvuru</span></li>
            <li class="last"><a id="B_Basvuru" runat="server" href="Anasayfa?tb=B_Basvuru" class="count grey" title="">48</a><span>Bekleyen Başvuru</span></li>
        </ul>
        <div class="fix"></div>
    </div>
    
    <!-- Dynamic table -->
    <div class="table" id="Tablo_Ariza" runat="server" style="display: none;">
        <div class="head">
            <h5 class="iFrames">Ana Tablo</h5>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" class="display" id="example">
            <thead>
                <tr>
                    <th>Müşteri</th>
                    <th>Sorumlu</th>
                    <th>Tarih</th>
                    <th>Detay</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptAriza" runat="server">
                    <ItemTemplate>
                        <tr class="gradeA">
                            <td class="center"><a href='Musteri?id=<%# Eval("M_ID") %>'><%# MTakip.Facade.MUSTERICRUD.IdyeGoreMUSTERIGetir(Convert.ToInt32(Eval("M_ID"))).AD %></a></td>
                            <td class="center"><%# MTakip.Facade.ADMINCRUD.IdyeGoreADMINGetir(Convert.ToInt32(Eval("A_ID"))).K_AD %></td>
                            <td class="center"><%# Eval("TAR") %></td>
                            <td class="center"><a href='Ariza?id=<%# Eval("ID") %>'><input id="btnDetay" type="button" value="Detay" class="nomargin greenBtn" /></a></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>

    <!-- Dynamic table -->
    <div class="table" id="Tablo_Basvuru" runat="server" style="display: none;">
        <div class="head">
            <h5 class="iFrames">Ana Tablo</h5>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" class="display" id="example2">
            <thead>
                <tr>
                    <th>Ad</th>
                    <th>Cep Telefonu</th>
                    <th>Sorumlu</th>
                    <th>Tarih</th>
                    <th>Detay</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptBasvuru" runat="server">
                    <ItemTemplate>
                        <tr class="gradeA">
                            <td class="center"><%# Eval("AD") %></td>
                            <td class="center"><%# Eval("CEP_TEL") %></td>
                            <td class="center"><%# MTakip.Facade.ADMINCRUD.IdyeGoreADMINGetir(Convert.ToInt32(Eval("A_ID"))).K_AD %></td>
                            <td class="center"><%# Eval("TAR") %></td>
                            <td class="center"><a href='Basvuru?id=<%# Eval("ID") %>'><input id="btnDetay" type="button" value="Detay" class="nomargin greenBtn" /></a></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>

    <center><img src="images/Logo.png" alt="" id="AltLogo" runat="server" style="width:70%;" /></center>

</asp:Content>
