'Program Name:  trainingWorkshops
'Developer:     Jason A. Frye
'Date:          9/6/11
'Purpose:       This program will allow the user to view and edit available corporate workshops

Option Strict On
Option Explicit On

Public Class frmDetail
    Private mintSelection As Integer

#Region "Form Events"
    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
	'Gathers data from input fields on the form and compiles it into a new instance of the workshop.vb class. 
	'Then passes new instance and selected index of lstWorkshops back to workshop.vb

        'declare variables
        Dim strNewDays As String
        Dim intNewCat As Integer
        Dim strNewTitle As String
        Dim strNewCost As String
        'create new instance of workshop class
        Dim newWshop As New workshop
        'retrieve data from from
        intNewCat = cboCat.SelectedIndex
        strNewCost = txtCost.Text
        strNewDays = txtDays.Text
        strNewTitle = txtTitle.Text
        'assign user-input data to object properties
        With newWshop
            .Category = CType(intNewCat, workshop.CategoryType)
            .Days = Convert.ToInt32(strNewDays)
            .Title = strNewTitle
            .Cost = Convert.ToDouble(strNewCost)
        End With
        'send new instance back to workshop class shared procedure
        workshop.AdjustCollection(newWshop, mintSelection)

        'hide current form and show main form
        Me.Hide()
        frmMain.Show()

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
	'Hides current window and shows frmMain, no changes are made. 
        Me.Hide() 	
        frmMain.Show()

    End Sub
#End Region

#Region "Validating"
    Private Sub txtCost_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCost.Validating
	'Verifies the data in txtCost is numeric, then tries to convert to Double value and verify that the value is in the acceptable range. 
	'If not successful, presents user with error message and sets focus to txtCost

        Dim dblCost As Double

        If IsNumeric(txtCost.Text) Then
            dblCost = Convert.ToDouble(txtCost.Text)
            If dblCost > -1 And dblCost < 3000 Then
            Else
                MsgBox("Please enter a cost between 0 and 3,000", , "Invalid Cost")
                txtCost.Focus()
            End If
        Else
            MsgBox("Please enter a cost between 0 and 3,000", , "Invalid Cost")
            txtCost.Focus()
        End If
    End Sub

    Private Sub cboCat_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCat.Validating
	'Verifies that selected index > -1 and < 6, if not successful, presents user with error message and sets focus to cboCat
        If cboCat.SelectedIndex = -1 Then
            MsgBox("Please select a workshop category", , "Invalid Category")
            cboCat.Focus()

        End If
    End Sub

    Private Sub txtTitle_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTitle.Validating
	'Verifies that text is present, if not successful, presents user with error message and sets focus to txtTitle

        If txtTitle.Text <> "" Then

        Else
            MsgBox("Please Enter a Workshop Title", , "Invalid Title")
            txtTitle.Clear()
            txtTitle.Focus()
        End If
    End Sub

    Private Sub txtDays_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDays.Validating
	'Verifies the data in txtCost is numeric, then tries to convert to integer value 
	'and verify that the value is in the acceptable range. 
	'If not successful, presents user with error message and sets focus to txtDays
        
	Dim intDays As Integer
        If IsNumeric(txtDays.Text) Then
            Try
                intDays = Convert.ToInt32(txtDays.Text)
                If intDays > 0 And intDays < 6 Then
                Else
                    MsgBox("Please Enter the length of the workshop (1-5)", , "Invalid Length")
                    txtDays.Clear()
                    txtDays.Focus()
                End If
            Catch ex As Exception
                MsgBox("Please Enter the length of the workshop (1-5)", , "Invalid Length")
                txtDays.Clear()
                txtDays.Focus()
        End Try


        Else
        MsgBox("Please Enter the length of the workshop (1-5)", , "Invalid Length")
        txtDays.Clear()
        txtDays.Focus()
        End If
    End Sub

#End Region

#Region "Methods"
    Public Sub EditDetails(ByVal wshop As workshop, ByVal intSelection As Integer)
        'Accepts instance of workshop Class and copies attributes to corresponding 
        'textboxes/comboboxes  for the user to edit

        'set selected index to class variable to be sent back later
        mintSelection = intSelection
        'copy data from object attributes to data values
        Dim strDays As String = wshop.Days.ToString
        Dim intCat As Integer = wshop.Category
        Dim strTitle As String = wshop.Title
        Dim strCost As String = wshop.Cost.ToString
        'copy data values to user controls
        txtCost.Text = strCost
        txtDays.Text = strDays
        txtTitle.Text = strTitle
        cboCat.SelectedIndex = intCat

    End Sub
#End Region

End Class