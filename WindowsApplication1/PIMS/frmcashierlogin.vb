Imports MySql.Data.MySqlClient

Public Class frmcashierlogin
    Private Sub u_list()
        Try
            ComboBox1.Items.Clear()
            adp.SelectCommand = New MySqlCommand("SELECT * FROM tbluser WHERE u_type LIKE '" & "Cashier" & "%' ORDER BY id ", conn)
            adp.Fill(tbl)
            If tbl.Rows.Count = 0 Then conn.Close() : Exit Sub
            For Each row As DataRow In tbl.Rows
                ComboBox1.Items.Add(row("u_fullname"))
            Next
            tbl.Clear()
            conn.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            adp.SelectCommand = New MySqlCommand("SELECT * FROM tbluser WHERE u_fullname = '" & TextBox1.Text & "' AND u_password = '" & TextBox2.Text & "' ", conn)
            adp.Fill(tbl)
            If tbl.Rows.Count = 0 Then MsgBox("incorrect password", MsgBoxStyle.Exclamation, "Warning") : tbl.Clear() : conn.Close() : Exit Sub
            Me.Hide()
            frmcashregistry.TextBox2.Text = "CASHIER : " & Me.TextBox1.Text & "          |  DATE : " & Format(Now, "MMMM dd, yyyy") & "         |  TIME : " & Format(Now.ToString("t"))
            frmcashregistry.u_cashier = TextBox1.Text
            frmcashregistry.Timer2.Enabled = True
            frmcashregistry.Show()
            tbl.Clear()
            conn.Close()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
       
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Text = ComboBox1.Text
    End Sub

    Private Sub frmcashierlogin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmcashierlogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call u_list()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmuserlogin.Show()
        Me.Dispose()
    End Sub
End Class