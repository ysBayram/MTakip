<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ariza.aspx.cs" Inherits="MTakip.ariza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <div class="widget mainForm">
        <div class="head">
            <h5 class="iUsers2">Arıza Paneli</h5>
        </div>
        <div class="rowElem">
            <label>Sorumlu Admin :</label><div class="formRight">
                <asp:DropDownList ID="ddlAdmin" runat="server"></asp:DropDownList>
                <asp:CustomValidator ID="cvAdmin" runat="server" ErrorMessage="***Lütfen Sorumlu Seçiniz!" ControlToValidate="ddlAdmin" ClientValidationFunction="ClientValidate" ></asp:CustomValidator>
                <asp:CheckBox ID="cbOnay" runat="server" Text="Arıza Onay" CssClass="floatright" />
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Arızaya Sahip Müşteri</label>
            <div class="formRight searchDrop">
                <asp:DropDownList ID="ddlMusteri" runat="server" data-placeholder="Müşteri Seçin..." class="chzn-select" Style="width: 350px;" TabIndex="2"></asp:DropDownList>
                <asp:CustomValidator ID="cvMusteri" runat="server" ErrorMessage="***Lütfen Müşteri Seçiniz!" ControlToValidate="ddlMusteri" ClientValidationFunction="ClientValidate" ></asp:CustomValidator>
            </div>
        </div>
        <div class="rowElem">
            <label>Tarih :</label><div class="formRight">
                <asp:TextBox ID="tbTarih" runat="server" CssClass="maskDate"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Not :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbNot" TextMode="MultiLine" CssClass="auto"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <asp:Button runat="server" ID="btnKaydet" Text="Kaydet" CssClass="nomargin submitForm redBtn" OnClick="btnKaydet_Click" />
            <div class="fix"></div>
        </div>
        <br />
    </div>

    <div class="rowElem" style="padding: 0px;">
        <div class="table" id="TableAdmin" runat="server">
            <div class="head">
                <h5 class="iFrames">Arızalar</h5>
            </div>
            <table cellpadding="0" cellspacing="0" border="0" class="display" id="example">
                <thead>
                    <tr>
                        <th>Müşteri</th>
                        <th>Sorumlu</th>
                        <th>Tarih</th>
                        <th>Düzenle</th>
                        <th>Sil</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptAriza" runat="server" OnItemCommand="rptAriza_ItemCommand">
                        <ItemTemplate>
                            <tr class="gradeA">
                                <td class="center"><a href='Musteri?id=<%# Eval("M_ID") %>'><%# MTakip.Facade.MUSTERICRUD.IdyeGoreMUSTERIGetir(Convert.ToInt32(Eval("M_ID"))).AD %></a></td>
                                <td class="center"><%# MTakip.Facade.ADMINCRUD.IdyeGoreADMINGetir(Convert.ToInt32(Eval("A_ID"))).K_AD %></td>
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
        <div class="fix"></div>
    </div>
</asp:Content>
