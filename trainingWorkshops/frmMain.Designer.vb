<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstWorkshops = New System.Windows.Forms.ListBox()
        Me.btnDetail = New System.Windows.Forms.Button()
        Me.ofdSource = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'lstWorkshops
        '
        Me.lstWorkshops.FormattingEnabled = True
        Me.lstWorkshops.Location = New System.Drawing.Point(12, 12)
        Me.lstWorkshops.Name = "lstWorkshops"
        Me.lstWorkshops.Size = New System.Drawing.Size(692, 199)
        Me.lstWorkshops.TabIndex = 0
        '
        'btnDetail
        '
        Me.btnDetail.Location = New System.Drawing.Point(91, 234)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(75, 23)
        Me.btnDetail.TabIndex = 1
        Me.btnDetail.Text = "Edit Details"
        Me.btnDetail.UseVisualStyleBackColor = True
        '
        'ofdSource
        '
        Me.ofdSource.DefaultExt = "txt "
        Me.ofdSource.FileName = "workshops"
        Me.ofdSource.Filter = "Text Files|*.txt|All Files|*.*"""
        Me.ofdSource.InitialDirectory = "desktop"
        '
        'frmMain
        '
        Me.AcceptButton = Me.btnDetail
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 269)
        Me.Controls.Add(Me.btnDetail)
        Me.Controls.Add(Me.lstWorkshops)
        Me.Name = "frmMain"
        Me.Text = "Training Workshops"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstWorkshops As System.Windows.Forms.ListBox
    Friend WithEvents btnDetail As System.Windows.Forms.Button
    Friend WithEvents ofdSource As System.Windows.Forms.OpenFileDialog

End Class
