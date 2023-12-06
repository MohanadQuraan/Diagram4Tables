<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.cs" Inherits="Diagram4Tables._Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxDiagram.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxDiagram" TagPrefix="dx" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    
    <dx:ASPxDiagram   SettingsGrid-Visible="false"  ReadOnly="true" ID="Diagram"  Width="100%"  runat="server" OnNodeDataBound="Diagram_NodeDataBound1"
            Height="100%" SimpleView="true">
            

  
  <Mappings>
      <Node Key="ID" Left="X" Top="Y" Width="Width" Height="Height" ContainerKey="ContainerID" Type="Type" Text="Text" />
      <Edge Key="Key" FromKey="FromKey" ToKey="ToKey" Text="Text" />


  </Mappings>
            <SettingsToolbox>
                <Groups>

                    <dx:DiagramToolboxGroup Category="General" />
                    <dx:DiagramToolboxGroup Category="Containers" />
                </Groups>
            </SettingsToolbox>

        </dx:ASPxDiagram>

</asp:Content>