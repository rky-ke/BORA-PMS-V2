Public Class frmuserlogin


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "admin" And TextBox2.Text = "admin" Then
            Me.Hide()
            frmmain.Show()
            Me.Close()
        End If
    End Sub

    Private Sub frmuserlogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text = "admin" And TextBox2.Text = "admin" Then
                Me.Hide()
                frmmain.Show()
                Me.Close()
            End If
        End If
        If e.KeyCode = Keys.Escape Then
            End
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmcashierlogin.Show()
        Me.Dispose()
    End Sub
End Class