<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="MTakip.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <div class="widget mainForm">
        <div class="head">
            <h5 class="iUsers2">Admin</h5>
        </div>
        <div class="rowElem">
            <label>Yetki :</label><div class="formRight">
                <asp:RadioButtonList ID="rbtnYetki" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yönetici</asp:ListItem>
                    <asp:ListItem Value="2">Teknik Eleman</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Kullanıcı Adı :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbK_Ad"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Şifre :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbPass" ></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Mail :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbMail"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>        
        <div class="rowElem">
            <asp:Button runat="server" ID="btnKaydet" Text="Kaydet" CssClass="nomargin submitForm redBtn" OnClick="btnKaydet_Click" />
            <div class="fix"></div>
        </div>
        <br />
    </div>

    <div class="rowElem" style="padding:0px;">
            <div class="table" id="TableAdmin" runat="server">
                <div class="head">
                    <h5 class="iFrames">Adminler</h5>
                </div>
                <table cellpadding="0" cellspacing="0" border="0" class="display" id="example">
                    <thead>
                        <tr>
                            <th>Kullanıcı AD</th>
                            <th>Son Giriş</th>
                            <th>Düzenle</th>
                            <th>Sil</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptAdmin" runat="server" OnItemCommand="rptAdmin_ItemCommand" >
                            <ItemTemplate>
                                <tr class="gradeA">
                                    <td class="center"><%# Eval("K_AD") %></td>
                                    <td class="center"><%# Eval("SON_GRS") %></td>
                                    <td class="center">
                                        <asp:Button runat="server" ID="btnEdit" Text="Düzenle" CssClass="nomargin greenBtn"  CommandName="Edit" CommandArgument='<%# Eval("ID") %>' />
                                    </td>
                                    <td class="center">
                                        <asp:Button runat="server" ID="btnSil" Text="Sil" CssClass="nomargin redBtn"  CommandName="Sil" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('Silme işlemini onaylıyor musunuz?');" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="fix"></div>
        </div>
</asp:Content>
