<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="kasa.aspx.cs" Inherits="MTakip.kasa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <div class="title">
        <h5>Kasa Paneli</h5>
    </div>

    <!-- Statistics -->
    <div class="stats">
        <ul>
            <li><a id="G_Gider" runat="server" href="Kasa?tb=G_Gider" class="count grey" title="">52</a><span>Günlük Gider</span></li>
            <li><a id="G_Gelir" runat="server" href="Kasa?tb=G_Gelir" class="count grey" title="">520</a><span>Günlük Gelir</span></li>
            <li><a id="T_Gider" runat="server" href="Kasa?tb=T_Gider" class="count grey" title="">14</a><span>Toplam Gider</span></li>
            <li class="last"><a id="T_Gelir" runat="server" href="Kasa?tb=T_Gelir" class="count grey" title="">48</a><span>Toplam Gelir</span></li>
        </ul>
        <div class="fix"></div>
    </div>

    <!-- Dynamic table -->
    <div class="table">
        <div class="head">
            <h5 class="iFrames">Kasa Tablo</h5>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" class="display" id="example">
            <thead>
                <tr>
                    <th>Tür</th>
                    <th>Sorumlu</th>
                    <th>Açıklama</th>
                    <th>Miktar</th>
                    <th>Tarih</th>
                    <th>Düzenle</th>
                    <th>Sil</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="center">
                        <asp:DropDownList ID="ddlTur" runat="server">
                            <asp:ListItem Text="Gider" Value="Gider" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Gelir" Value="Gelir"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="center">
                        <asp:DropDownList ID="ddlAdmin" runat="server"></asp:DropDownList></td>
                    <td class="center">
                        <asp:TextBox ID="tbAcikla" runat="server"></asp:TextBox></td>
                    <td class="center">
                        <asp:TextBox ID="tbMiktar" runat="server"></asp:TextBox></td>
                    <td class="center">
                        <asp:TextBox ID="tbTarih" runat="server" CssClass="maskDate"></asp:TextBox></td>
                    <td class="center"><asp:Button runat="server" ID="btnKaydet" Text="Kaydet" CssClass="nomargin redBtn" OnClick="btnKaydet_Click" /></td>
                    <td></td>
                </tr>
                <asp:Repeater ID="rptKasa" runat="server" OnItemCommand="rptKasa_ItemCommand">
                    <ItemTemplate>
                        <tr class="<%# rowStyle(Eval("ID").ToString()) %>">
                            <td class="center"><%# Eval("TUR") %></td>
                            <td class="center"><%# MTakip.Facade.ADMINCRUD.IdyeGoreADMINGetir(Convert.ToInt32(Eval("A_ID"))).K_AD %></td>
                            <td class="center"><%# Eval("ACIKLA") %></td>
                            <td class="center"><%# Eval("MIKTAR") %></td>
                            <td class="center"><%# Eval("TAR") %></td>
                            <td class="center">
                                    <asp:Button runat="server" ID="btnEdit" Text="Düzenle" CssClass="nomargin greenBtn" CommandName="Edit" CommandArgument='<%# Eval("ID") %>' />
                                </td>
                            <td class="center">
                                    <asp:Button runat="server" ID="btnSil" Text="Sil" CssClass="nomargin redBtn" CommandName="Sil" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('Silme işlemini onaylıyor musunuz?');" />
                                </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>


</asp:Content>
