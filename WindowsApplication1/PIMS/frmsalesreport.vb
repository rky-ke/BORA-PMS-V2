Imports MySql.Data.MySqlClient

Public Class frmsalesreport
    Private Sub frmsales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox3.Items.Add(Now.Year + 1)
    End Sub

    Private Sub frmsales_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text = Nothing Then MsgBox("Please select a month", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If ComboBox2.Text = Nothing Then MsgBox("Please select a day", MsgBoxStyle.Exclamation, "Message") : Exit Sub
        If ComboBox3.Text = Nothing Then MsgBox("Please select a year", MsgBoxStyle.Exclamation, "Message") : Exit Sub

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ComboBox1.Text = Nothing Then MsgBox("Please select a month", MsgBoxStyle.Exclamation, "Message") : Exit Sub

    End Sub
    Public Sub compute_total()
        Dim i As Integer
        Dim tot As Double
        Try
            TextBox1.Text = "0.00"

            For i = 0 To ListView1.Items.Count - 1
                ListView1.Items(i).Selected = True
                tot += Val(ListView1.SelectedItems(i).SubItems(4).Text)
                'If i = ListView4.Items.Count - 1 Then Exit For
            Next
            'tot = Val(lbltotal.Text)
            TextBox1.Text = Format(Val(tot), "# ##0.00")
            TextBox1.Text = "Total : " & Trim(TextBox1.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text IsNot Nothing And ComboBox2.Text IsNot Nothing And ComboBox3.Text IsNot Nothing Then
            ListView1.Items.Clear()
            Try
                adp.SelectCommand = New MySqlCommand("SELECT * FROM tblsales WHERE s_date LIKE '%" & ComboBox1.Text & " " & ComboBox2.Text & ", " & ComboBox3.Text & "%'", conn)
                adp.Fill(tbl)
                If tbl.Rows.Count = 0 Then tbl.Clear() : conn.Close() : TextBox1.Clear() : Exit Sub
                For Each row As DataRow In tbl.Rows
                    ListView1.Items.Add(row("id"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("p_desc"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("p_sellprice"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("s_qty"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("s_total"))
                Next
                tbl.Clear() : conn.Close()
                Call compute_total()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox1.Text IsNot Nothing And ComboBox2.Text IsNot Nothing And ComboBox3.Text IsNot Nothing Then         
            ListView1.Items.Clear()
            Try
                adp.SelectCommand = New MySqlCommand("SELECT * FROM tblsales WHERE s_date LIKE '%" & ComboBox1.Text & " " & ComboBox2.Text & ", " & ComboBox3.Text & "%'", conn)
                adp.Fill(tbl)
                If tbl.Rows.Count = 0 Then tbl.Clear() : conn.Close() : TextBox1.Clear() : Exit Sub

                For Each row As DataRow In tbl.Rows
                    ListView1.Items.Add(row("id"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("p_desc"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("p_sellprice"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("s_qty"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("s_total"))
                Next
                tbl.Clear() : conn.Close()
                Call compute_total()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox1.Text IsNot Nothing And ComboBox2.Text IsNot Nothing And ComboBox3.Text IsNot Nothing Then
           
            ListView1.Items.Clear()
            Try

                adp.SelectCommand = New MySqlCommand("SELECT * FROM tblsales WHERE s_date LIKE '" & ComboBox1.Text & " " & ComboBox2.Text & ", " & ComboBox3.Text & "%'", conn)
                adp.Fill(tbl)
                If tbl.Rows.Count = 0 Then tbl.Clear() : conn.Close() : TextBox1.Clear() : Exit Sub

                For Each row As DataRow In tbl.Rows
                    ListView1.Items.Add(row("id"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("p_desc"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("p_sellprice"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("s_qty"))
                    ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("s_total"))

                Next
                tbl.Clear() : conn.Close()
                Call compute_total()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub
End Class