Imports MySql.Data.MySqlClient

Public Class frmuser
    Dim uID As Integer

    Private Sub frmuser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call user_list()
    End Sub

    Private Sub frmuser_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub user_list()
        Try
            ListView1.Items.Clear()
            adp.SelectCommand = New MySqlCommand("SELECT * FROM tbluser ORDER BY id ", conn)
            adp.Fill(tbl)
            If tbl.Rows.Count = 0 Then conn.Close() : Exit Sub
            For Each row As DataRow In tbl.Rows
                ListView1.Items.Add(row("id"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("u_fullname"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("u_password"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("u_type"))
            Next
            tbl.Clear()
            conn.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub user_type()
        Try
            ComboBox1.Items.Clear()
            'ComboBox1.Items.Add("Cashier")
            adp.SelectCommand = New MySqlCommand("SELECT * FROM tbluser", conn)
            adp.Fill(tbl)
            For Each row As DataRow In tbl.Rows
                ComboBox1.Items.Add(row("u_type"))
            Next
            tbl.Clear()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Len(TextBox1.Text) = 0 Then MsgBox("Name is required", MsgBoxStyle.Critical, "Message") : Exit Sub
        If Len(TextBox2.Text) = 0 Then MsgBox("Password is required", MsgBoxStyle.Critical, "Message") : Exit Sub
        If Len(TextBox3.Text) = 0 Then MsgBox("User type is required", MsgBoxStyle.Critical, "Message") : Exit Sub

        Try
            conn.Open()
            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO tbluser (u_fullname,u_password,u_type) VALUES ( '" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "');"
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("New user is added", MsgBoxStyle.Information, "Save")
            Call user_list()
            Call user_type()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Len(TextBox1.Text) = 0 Then MsgBox("Name is required", MsgBoxStyle.Critical, "Message") : Exit Sub
        If Len(TextBox2.Text) = 0 Then MsgBox("Password is required", MsgBoxStyle.Critical, "Message") : Exit Sub
        If Len(TextBox3.Text) = 0 Then MsgBox("User type is required", MsgBoxStyle.Critical, "Message") : Exit Sub

        Try
            conn.Open()
            cmd.Connection = conn
            cmd.CommandText = "UPDATE tbluser SET u_fullname = '" & TextBox1.Text & "',u_password = '" & TextBox2.Text & "',u_type = '" & TextBox3.Text & "' WHERE id = '" & uID & "'"
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Medicine information updated", MsgBoxStyle.Information, "Update")
            Call user_list()
            Call user_type()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If MsgBox("Delete this user from record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Delete") = vbYes Then
                conn.Open()
                cmd.Connection = conn
                cmd.CommandText = "DELETE FROM tbluser WHERE id = '" & uID & "'"
                cmd.ExecuteNonQuery()
                conn.Close()

                MsgBox("Record deleted.", MsgBoxStyle.Information, "Message")
                Call user_list()
                Call user_type()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                Button1.Enabled = True
                Button2.Enabled = False
                Button3.Enabled = False
                uID = Nothing
            End If
        Catch ex As Exception

        End Try
       
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call user_list()
        Call user_type()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        uID = Nothing
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            If ListView1.SelectedItems.Count > 0 Then uID = Val(ListView1.SelectedItems(0).SubItems(0).Text)
            adp.SelectCommand = New MySqlCommand("SELECT * FROM tbluser WHERE id = '" & uID & "' ", conn)
            adp.Fill(tbl)
            TextBox1.Text = tbl.Rows(0)("u_fullname")
            TextBox2.Text = tbl.Rows(0)("u_password")
            TextBox3.Text = tbl.Rows(0)("u_type")
            tbl.Clear()
            conn.Close()
            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox3.Text = ComboBox1.Text
    End Sub

    
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = StrConv(TextBox1.Text, vbProperCase)
        TextBox1.SelectionStart = Len(TextBox1.Text)
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        TextBox3.Text = StrConv(TextBox3.Text, vbProperCase)
        TextBox3.SelectionStart = Len(TextBox3.Text)
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class