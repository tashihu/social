<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SocialStatistic._Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <div>
                        <asp:Label ID="lab" runat="server" Text="Group name"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="TextBox1" runat="server" Text="russianwolfs2" Height="40px" Width="50%"></asp:TextBox>
                    </div>
                </div>
                <div>
                    <asp:Button ID="Button1" runat="server" OnClick="LoadGroup_Click" Text="Load Data" Height="60px" Width="50%" />
                </div>
                <div style="float:left;">
                    <asp:Chart ID="Chart1" runat="server" Width="400px">
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
                <div>
                    <asp:Chart ID="Chart2" runat="server" Width="400px">
                        <Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea2">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
                <div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress runat="server">
            <ProgressTemplate>
                <div style="position:fixed;top:0px;left:0px;width:100%;height:1000px;background-color:black;">
                    <img src="Content/loading.gif"  style="top:30%;left:40%;position:absolute;"/>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>
