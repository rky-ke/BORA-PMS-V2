Public Class frmmain

    Private Sub MedicineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MedicineToolStripMenuItem.Click
        frmmedicine.Show()
        frmmedicine.MdiParent = Me
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        frmlist.Show()
        frmlist.MdiParent = Me
    End Sub

    Private Sub UserToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserToolStripMenuItem1.Click
        frmuser.Show()
        frmuser.MdiParent = Me
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If MsgBox("Close application?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Exit") = vbYes Then End
        
    End Sub


    Private Sub frmmain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Close application?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Exit") = vbYes Then
            End
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub SalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReportToolStripMenuItem.Click
        frmsalesreport.Show()
    End Sub

    Private Sub CashRegistryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashRegistryToolStripMenuItem.Click
        frmcashregistry.u_cashier = "admin"
        frmcashregistry.Show()
    End Sub
End Class