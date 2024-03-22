Imports MySql.Data.MySqlClient

Public Class frmmedicine
    Public medID As Integer

    Private Sub frmproduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call med_category()
        Call med_formulation()
        Call med_genericname()
        Call med_unitsize()
    End Sub
    Private Sub med_genericname()
        Try
            ComboBox1.Items.Clear()
            adp.SelectCommand = New MySqlCommand("SELECT * FROM tblproduct", conn)
            adp.Fill(tbl)
            For Each row As DataRow In tbl.Rows
                ComboBox1.Items.Add(row("p_generic"))
            Next
            tbl.Clear()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub med_unitsize()
        Try
            ComboBox2.Items.Clear()
            adp.SelectCommand = New MySqlCommand("SELECT * FROM tblproduct", conn)
            adp.Fill(tbl)
            For Each row As DataRow In tbl.Rows
                ComboBox2.Items.Add(row("p_unitsize"))
            Next
            tbl.Clear()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub med_formulation()
        Try
            ComboBox3.Items.Clear()
            adp.SelectCommand = New MySqlCommand("SELECT * FROM tblproduct", conn)
            adp.Fill(tbl)
            For Each row As DataRow In tbl.Rows
                ComboBox3.Items.Add(row("p_formulation"))
            Next
            tbl.Clear()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub med_category()
        Try
            ComboBox4.Items.Clear()
            adp.SelectCommand = New MySqlCommand("SELECT * FROM tblproduct", conn)
            adp.Fill(tbl)
            For Each row As DataRow In tbl.Rows
                ComboBox4.Items.Add(row("p_category"))
            Next
            tbl.Clear()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub med_information()
        Try
            adp.SelectCommand = New MySqlCommand("SELECT * FROM tblproduct WHERE id = '" & medID & "'", conn)
            adp.Fill(tbl)
            TextBox1.Text = tbl.Rows(0)("p_desc")
            TextBox2.Text = tbl.Rows(0)("p_generic")
            TextBox3.Text = tbl.Rows(0)("p_unitsize")
            TextBox4.Text = tbl.Rows(0)("p_formulation")
            TextBox5.Text = tbl.Rows(0)("p_category")
            TextBox6.Text = tbl.Rows(0)("p_expiration")
            TextBox7.Text = tbl.Rows(0)("p_stocks")
            TextBox8.Text = tbl.Rows(0)("p_price")
            TextBox9.Text = tbl.Rows(0)("p_vat")
            TextBox10.Text = tbl.Rows(0)("p_sellprice")
            tbl.Clear()
            conn.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cleartext()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Len(TextBox1.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox2.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox3.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox4.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox5.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox6.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox7.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox8.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox9.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox10.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub

        Try
            conn.Open()
            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO tblproduct (p_desc,p_generic,p_unitsize,p_formulation,p_category,p_expiration,p_stocks,p_price,p_vat,p_sellprice) VALUES ( '" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "' ,'" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "');"
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("New Medicine is added", MsgBoxStyle.Information, "Save")
            Call med_category()
            Call med_formulation()
            Call med_genericname()
            Call med_unitsize()
            Call cleartext()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Len(TextBox1.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox2.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox3.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox4.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox5.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox6.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox7.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox8.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox9.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If Len(TextBox10.Text) = 0 Then MsgBox("Please fill up all fields", MsgBoxStyle.Exclamation, "Message") : Exit Sub

        Try
            conn.Open()
            cmd.Connection = conn
            cmd.CommandText = "UPDATE tblproduct SET p_desc = '" & TextBox1.Text & "',p_generic = '" & TextBox2.Text & "',p_unitsize = '" & TextBox3.Text & "',p_formulation = '" & TextBox4.Text & "',p_category = '" & TextBox5.Text & "',p_expiration = '" & TextBox6.Text & "',p_stocks = '" & TextBox7.Text & "',p_price = '" & TextBox8.Text & "',p_vat = '" & TextBox9.Text & "',p_sellprice = '" & TextBox10.Text & "' WHERE id = '" & medID & "'"
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Medicine information updated", MsgBoxStyle.Information, "Update")
            Call med_category()
            Call med_formulation()
            Call med_genericname()
            Call med_unitsize()
        Catch ex As Exception

        End Try

    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button1.Enabled = True
        Button2.Enabled = False
        Call cleartext()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        TextBox6.Text = Format(DateTimePicker1.Value, "MMMM dd, yyyy")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmlist.Show()
        frmlist.MdiParent = frmmain
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox2.Text = ComboBox1.Text
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        TextBox3.Text = ComboBox2.Text
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        TextBox4.Text = ComboBox3.Text
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        TextBox5.Text = ComboBox4.Text
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        'If Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
        '    e.Handled = True
        'End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
          Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Then
            e.Handled = False
        End If
    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged
        If TextBox9.Text <> Nothing Then
            Dim n As Double
            n = Val(TextBox9.Text) / 100
            TextBox10.Text = (Val(TextBox8.Text) * n) + Val(TextBox8.Text)
            TextBox10.Text = Format(Val(TextBox10.Text), "# ##0.00")
            Trim(TextBox10.Text)
        End If
    End Sub
    Private Sub TextBox8_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox8.LostFocus
        TextBox8.Text = Format(Val(TextBox8.Text), "# ##0.00")
        TextBox8.Text = Trim(TextBox8.Text)
        If TextBox9.Text <> Nothing Then
            Dim n As Double
            n = Val(TextBox9.Text) / 100
            TextBox10.Text = (Val(TextBox8.Text) * n) + Val(TextBox8.Text)
            TextBox10.Text = Format(Val(TextBox10.Text), "# ##0.00")
            Trim(TextBox10.Text)
        End If
    End Sub

    Private Sub TextBox9_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox9.LostFocus
        If TextBox8.Text = Nothing Then Exit Sub
        Dim n As Double
        n = Val(TextBox9.Text) / 100
        TextBox10.Text = (Val(TextBox8.Text) * n) + Val(TextBox8.Text)
        TextBox10.Text = Format(Val(TextBox10.Text), "# ##0.00")
        Trim(TextBox10.Text)
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        If TextBox8.Text = Nothing Then Exit Sub
        Dim n As Double
        n = Val(TextBox9.Text) / 100
        TextBox10.Text = (Val(TextBox8.Text) * n) + Val(TextBox8.Text)
        TextBox10.Text = Format(Val(TextBox10.Text), "# ##0.00")
        Trim(TextBox10.Text)
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub
End Class
