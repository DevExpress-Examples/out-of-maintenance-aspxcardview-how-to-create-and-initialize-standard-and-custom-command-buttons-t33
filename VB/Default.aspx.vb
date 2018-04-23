Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Utils
Imports DevExpress.Web

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            TryCast(ASPxCardView1.CardLayoutProperties.Items(0), CardViewCommandLayoutItem).CustomButtons.Add(CreateCustomButton())
        End If
    End Sub

    Private Function CreateCustomButton() As CardViewCustomCommandButton
        Dim customBtn As New CardViewCustomCommandButton()
        customBtn.ID = "CustomBtn"
        customBtn.Text = "Custom button"
        Return customBtn
    End Function

    Protected Sub ASPxCardView1_CommandButtonInitialize(ByVal sender As Object, ByVal e As ASPxCardViewCommandButtonEventArgs)
        If e.VisibleIndex = -1 Then
            Return
        End If

        Select Case e.ButtonType
            Case CardViewCommandButtonType.Edit
                e.Visible = EditButtonVisibleCriteria(DirectCast(sender, ASPxCardView), e.VisibleIndex)
            Case CardViewCommandButtonType.Delete
                e.Visible = DeleteButtonVisibleCriteria(DirectCast(sender, ASPxCardView), e.VisibleIndex)
        End Select
    End Sub
    Private Function EditButtonVisibleCriteria(ByVal grid As ASPxCardView, ByVal visibleIndex As Integer) As Boolean
        Dim card As Object = grid.GetDataRow(visibleIndex)
        Return DirectCast(card, DataRow)("ProductName").ToString().Contains("a")
    End Function
    Private Function DeleteButtonVisibleCriteria(ByVal grid As ASPxCardView, ByVal visibleIndex As Integer) As Boolean
        Dim card As Object = grid.GetDataRow(visibleIndex)
        Return DirectCast(card, DataRow)("ProductName").ToString().Contains("b")
    End Function
    Protected Sub ASPxCardView1_CustomButtonInitialize(ByVal sender As Object, ByVal e As ASPxCardViewCustomCommandButtonEventArgs)
        If e.VisibleIndex = -1 Then
            Return
        End If

        If e.ButtonID = "CustomBtn" AndAlso e.VisibleIndex Mod 2 <> 0 Then
            e.Visible = DefaultBoolean.False
        End If
    End Sub
End Class