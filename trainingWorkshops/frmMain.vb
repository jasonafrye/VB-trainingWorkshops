'Program Name:  trainingWorkshops
'Developer:     Jason A. Frye
'Date:          9/6/11
'Purpose:       This program will allow the user to view and edit available corporate workshops

Option Strict On
Option Explicit On

Public Class frmMain
    
#Region "Form Events"

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	' Opens file dialogue, finds file, and attempts to send string value to workshop.LoadWorkshops(), 
	' if not successful, presents error message and closes application

	ofdSource.ShowDialog()
        Dim strFile As String = ofdSource.FileName
        Try
            'attempt to call procedure
            workshop.LoadWorkshops(strFile)
        Catch ex As Exception
            'present error message and close program
            MsgBox("Invalid Source File!", , "Error")
            Close()
        End Try

    End Sub

    Private Sub btnDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetail.Click, lstWorkshops.DoubleClick
        'Validates that an item is selected from lstWorkshops and sends selected index to workshop.Index(), 
        'if not successful, presents error message and sets focus to lstWorkshops
	
	Dim intSelection As Integer = lstWorkshops.SelectedIndex
        'verify that item is selected from listbox
        If intSelection > -1 And intSelection <= lstWorkshops.Items.Count Then

            'hide current form, display next form
            Me.Hide()
            frmDetail.Show()
            'pass selected index to workshop class shared procedure
            workshop.Index(intSelection)
        Else
            'display error and re-set focus
            MsgBox("Please select a workshop for more details.", , "Error!")
            lstWorkshops.Focus()
        End If

    End Sub

#End Region

#Region "Methods"

    Public Sub Populate(ByVal strOut As String)
	'adds strOut to lstWorkshops.items

	lstWorkshops.Items.Add(strOut)
    End Sub

    Public Sub AdjustItem(ByVal strOut As String, ByVal intSelected As Integer)
	'removes selected index in lstWorkshops and adds new strOut value

        lstWorkshops.Items.RemoveAt(intSelected)
        lstWorkshops.Items.Add(strOut)
    End Sub

#End Region

End Class