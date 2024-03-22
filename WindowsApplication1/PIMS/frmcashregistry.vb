Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Public Class frmcashregistry
    Dim farmacia_conn As New MySqlConnection("server=localhost;uid=root;pwd=;database=pmisdb")
    Dim farmacia_cmd As New MySqlCommand
    Dim farmacia_adp As New MySqlDataAdapter
    Dim farmacia_tbl As New DataTable
    Public itemindex, cartindex As Integer
    Dim transactionno As Integer
    Public u_cashier As String
    Dim WithEvents PrintDoc As PrintDocument
    Dim PrintPreviewDialog As PrintPreviewDialog
    Sub print()
        PrintDoc = New PrintDocument
        PrintPreviewDialog = New PrintPreviewDialog
        PrintDoc.DefaultPageSettings.PaperSize = New System.Drawing.Printing.PaperSize("Rc1", 500, 1000)
        PrintPreviewDialog.Document = PrintDoc
        PrintPreviewDialog.Show()
    End Sub
    Private Sub frmcashregistry_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub frmcashregistry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Home Then
            Call newtransaction()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Hide()
            frmcashierlogin.Show()
            Me.Close()
        End If
        If e.KeyCode = Keys.Delete Then
            If cartindex = 0 Then Exit Sub
            ListView4.FocusedItem.Remove()
            If ListView4.Items.Count > 0 Then
                ListView4.SelectedItems.Clear()
                ListView4.Focus()
                ListView4.Items(0).Selected = True
                ListView4.Items(0).Focused = True
                Call compute_total()
                If Val(lblcash.Text) <> 0 Then
                    frmcash.TextBox1.Text = Val(Me.lblcash.Text)
                    Me.lblchange.Text = Val(frmcash.TextBox1.Text) - Val(Me.lbltotal.Text)
                    Me.lblchange.Text = Format(Val(Me.lblchange.Text), "# ##0.00")
                    Me.lblchange.Text = Trim(Me.lblchange.Text)
                    Me.lblcash.Text = Format(Val(frmcash.TextBox1.Text), "# ##0.00")
                    Me.lblcash.Text = Trim(Me.lblcash.Text)
                End If
                Exit Sub
            End If
            Call compute_total()
        End If
        If e.KeyCode = Keys.F6 AndAlso e.Modifiers = Keys.Control Then
            If ListView1.Items.Count > 0 Then
                ListView1.SelectedItems.Clear()
                ListView1.Focus()
                ListView1.Items(0).Selected = True
                ListView1.Items(0).Focused = True
                Exit Sub
           
            End If
        End If
        If e.KeyCode = Keys.F6 Then
            TextBox1.Clear()
            TextBox1.Focus()
            Exit Sub
        End If
       
        If e.KeyCode = Keys.F7 Then
            If ListView4.Items.Count > 0 Then
                ListView4.SelectedItems.Clear()
                ListView4.Focus()
                ListView4.Items(0).Selected = True
                ListView4.Items(0).Focused = True
                Exit Sub
          
            End If
        End If
        If e.KeyCode = Keys.F10 Then
            frmcash.Text = lblcash.Text
            frmcash.ShowDialog()
        End If
        If e.KeyCode = Keys.F12 Then
            Call savetransaction()
        End If
        If e.KeyCode = Keys.Enter Then
            If itemindex = 0 Then
                Try
                    frmqty.TextBox1.Text = ListView4.SelectedItems(0).SubItems(1).Text
                    frmqty.TextBox2.Text = ListView4.SelectedItems(0).SubItems(2).Text
                    frmqty.TextBox6.Text = ListView4.SelectedItems(0).SubItems(3).Text
                    frmqty.qty = Val(ListView4.SelectedItems(0).SubItems(3).Text)
                    frmqty.TextBox5.Text = ListView4.SelectedItems(0).SubItems(4).Text
                    frmqty.TextBox3.Text = ListView4.SelectedItems(0).SubItems(5).Text
                    frmqty.strvat = ListView4.SelectedItems(0).SubItems(6).Text
                    frmqty.strprice = ListView4.SelectedItems(0).SubItems(7).Text
                    frmqty.ShowDialog()
                    Exit Sub
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            ElseIf cartindex = 0 Then
                Try
                    If Val(ListView1.SelectedItems(0).SubItems(3).Text) = 0 Then Exit Sub
                    frmqty.TextBox1.Text = ListView1.SelectedItems(0).SubItems(1).Text
                    frmqty.TextBox2.Text = ListView1.SelectedItems(0).SubItems(2).Text
                    frmqty.TextBox3.Text = ListView1.SelectedItems(0).SubItems(3).Text
                    frmqty.strvat = ListView1.SelectedItems(0).SubItems(5).Text
                    frmqty.strprice = ListView1.SelectedItems(0).SubItems(6).Text
                    frmqty.ShowDialog()
                    Exit Sub
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If

    End Sub
    Private Sub newtransaction()
        Try
            itemindex = 0
            cartindex = 0
            adp.SelectCommand = New MySqlCommand("SELECT DISTINCT transaction_no  FROM tblsales ", conn)
            adp.Fill(tbl)
            If tbl.Rows.Count = 0 Then lbltransactionno.Text = Format(Val(1), "0000000000") : GoTo NXT
            lbltransactionno.Text = Format(Val(tbl.Rows(tbl.Rows.Count - 1)("transaction_no") + 1), "0000000000")
NXT:
            tbl.Clear()
            conn.Close()
            ListView1.Items.Clear()
            ListView4.Items.Clear()
            lbltotal.Text = "0.00"
            lblcash.Text = "0.00"
            lblchange.Text = "0.00"
            TextBox1.Focus()
            TextBox1.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub savetransaction()
        If Val(lbltransactionno.Text) = 0 Then MsgBox("press new to create new transaction", MsgBoxStyle.Information, "message") : Exit Sub
        If Val(lblchange.Text) = 0 Then MsgBox("finish transaction first before print receipt", MsgBoxStyle.Information, "message") : Exit Sub
       
        Try
            Dim s As Integer
            adp.SelectCommand = New MySqlCommand("SELECT * FROM tblsales WHERE transaction_no = '" & lbltransactionno.Text & "' ", conn)
            adp.Fill(tbl)
            If tbl.Rows.Count = 1 Then MsgBox("you have already printed receipt for this items", MsgBoxStyle.Information, "message") : tbl.Clear() : conn.Close() : Exit Sub
            tbl.Clear()
            conn.Close()

            conn.Open()
            cmd.Connection = conn
            Dim i As Integer
            For i = 0 To ListView4.Items.Count - 1
                ListView4.Items(i).Selected = True
                cmd.CommandText = "INSERT INTO tblsales (s_date,transaction_no,p_id,p_desc,p_sellprice,s_qty,s_total,p_vat,p_price,c_total,c_cash,c_change) VALUES ( '" & Format(Now, "MMMM d, yyyy") & "','" & lbltransactionno.Text & "','" & Val(ListView4.SelectedItems(i).SubItems(0).Text) & "' ,'" & ListView4.SelectedItems(i).SubItems(1).Text & "','" & ListView4.SelectedItems(i).SubItems(2).Text & "','" & Val(ListView4.SelectedItems(i).SubItems(3).Text) & "','" & ListView4.SelectedItems(i).SubItems(4).Text & "','" & ListView4.SelectedItems(i).SubItems(6).Text & "','" & ListView4.SelectedItems(i).SubItems(7).Text & "','" & lbltotal.Text & "','" & lblcash.Text & "','" & lblchange.Text & "');"
                cmd.ExecuteNonQuery()
                adp.SelectCommand = New MySqlCommand("SELECT * FROM tblproduct WHERE id  = '" & Val(ListView4.SelectedItems(i).SubItems(0).Text) & "' ", conn)
                adp.Fill(tbl)
                s = tbl.Rows(0)("p_stocks")
                tbl.Clear()
                cmd.CommandText = "UPDATE tblproduct SET p_stocks = '" & s - Val(ListView4.SelectedItems(i).SubItems(3).Text) & "' WHERE id = '" & Val(ListView4.SelectedItems(i).SubItems(0).Text) & "'"
                cmd.ExecuteNonQuery()
            Next
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Call print()
    End Sub
   
    Private Sub TextBox1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If Len(TextBox1.Text) = 0 Then Exit Sub
        If Val(lbltransactionno.Text) = 0 Then MsgBox("create new transaction", MsgBoxStyle.Exclamation, "error") : Exit Sub
        TextBox1.SelectionStart = Len(TextBox1.Text)
        Try
            ListView1.Items.Clear()
            farmacia_adp.SelectCommand = New MySqlCommand("SELECT * FROM tblproduct WHERE p_desc LIKE '" & TextBox1.Text & "%'", farmacia_conn)
            farmacia_adp.Fill(farmacia_tbl)
            If farmacia_tbl.Rows.Count = 0 Then farmacia_conn.Close() : Exit Sub

            For Each row As DataRow In farmacia_tbl.Rows
                ListView1.Items.Add(row("id"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("p_desc") & " " & row("p_unitsize") & " (" & row("p_generic") & ")")
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("p_sellprice"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("p_stocks"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("p_expiration"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("p_vat"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("p_price"))
            Next

            farmacia_tbl.Clear()
            farmacia_conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListView1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.GotFocus
        Try
            cartindex = 0
            itemindex = Val(ListView1.SelectedItems(0).SubItems(0).Text)
        Catch ex As Exception

        End Try
       
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            itemindex = Val(ListView1.FocusedItem.Text(0))
            'itemindex = Val(ListView1.SelectedItems(0).SubItems(0).Text)
            cartindex = 0

            'itemindex = Val(ListView1.SelectedItems(0).SubItems(0).Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListView4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView4.GotFocus
        Try
            If ListView4.Items.Count > 0 Then
                itemindex = 0
                cartindex = Val(ListView4.FocusedItem.Text(0))
            End If
        Catch ex As Exception

        End Try
       
    End Sub

    Private Sub ListView4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView4.SelectedIndexChanged
        Try
            cartindex = Val(ListView4.FocusedItem.Text(0))

            cartindex = Val(ListView4.SelectedItems(0).SubItems(0).Text)
            'Me.Text = Val(ListView4.FocusedItem.Text(0))
            itemindex = 0
        Catch ex As Exception
        End Try
    End Sub

    Public Sub compute_total()
        Dim i As Integer
        Dim tot As Double
        Try
            lbltotal.Text = "0.00"

            For i = 0 To ListView4.Items.Count - 1
                ListView4.Items(i).Selected = True
                tot += Val(ListView4.SelectedItems(i).SubItems(4).Text)
                'If i = ListView4.Items.Count - 1 Then Exit For
            Next
            lbltotal.Text = Format(Val(tot), "# ##0.00")
            lbltotal.Text = Trim(lbltotal.Text)
        Catch ex As Exception
        End Try
    End Sub
    'Public Sub compute_change()

    '    Me.lblchange.Text = Val(frmcash.TextBox1.Text) - Val(Me.lbltotal.Text)
    '    Me.lblchange.Text = Format(Val(Me.lblchange.Text), "# ##0.00")
    '    Me.lblchange.Text = Trim(Me.lblchange.Text)
    '    Me.lblcash.Text = Format(Val(frmcash.TextBox1.Text), "# ##0.00")
    '    Me.lblcash.Text = Trim(Me.lblcash.Text)
    'End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ListView4.Items.Count = 0 Then Exit Sub
        Call compute_total() : Timer1.Enabled = False
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        TextBox2.Text = "CASHIER : " & u_cashier & "          |  DATE : " & Format(Now, "MMMM dd, yyyy") & "         |  TIME : " & Format(Now.ToString("t"))
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call newtransaction()
      
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmcash.Text = lblcash.Text
        frmcash.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        frmcashierlogin.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call savetransaction()
    End Sub
   
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Dim YAxis As Integer = 0
        Dim totaly As Integer
        Dim str As String
        Dim nctr, xpos, ii, iii As Integer

        e.Graphics.DrawString("BORA PHARMACY", New Font("Times New Roman", 12, FontStyle.Bold), Brushes.Blue, New Point(198, YAxis + 6))
        e.Graphics.DrawString("MANDERA NORTH", New Font("Times New Roman", 10, FontStyle.Bold), Brushes.Blue, New Point(140, YAxis + 22))
        e.Graphics.DrawString("TIN 005-057-119", New Font("Times New Roman", 10, FontStyle.Bold), Brushes.Blue, New Point(192, YAxis + 38))
        e.Graphics.DrawString("_________________________________________________________", New Font("Times New Roman", 12), Brushes.Blue, New Point(5, YAxis + 50))
        e.Graphics.DrawString("_________________________________________________________", New Font("Times New Roman", 12), Brushes.Blue, New Point(5, YAxis + 75))


        e.Graphics.DrawString("Description", _
        New Font("Times New Roman", 11), _
         Brushes.Blue, New Point(10, YAxis + 70))
        e.Graphics.DrawString("Price", _
         New Font("Times New Roman", 11), _
         Brushes.Blue, New Point(220, YAxis + 70))
        e.Graphics.DrawString("Quantity", _
        New Font("Times New Roman", 11), _
        Brushes.Blue, New Point(310, YAxis + 70))
        e.Graphics.DrawString("Sub Total", _
         New Font("Times New Roman", 11), _
         Brushes.Blue, New Point(410, YAxis + 70))


        totaly = 70
        For nctr = 0 To ListView4.Items.Count - 1
            ListView4.Items(nctr).Selected = True
            YAxis += 20
            totaly = totaly + 20
            e.Graphics.DrawString(ListView4.SelectedItems(nctr).SubItems(1).Text, New Font("arial", 10), Brushes.Blue, New Point(10, YAxis + 80))
            e.Graphics.DrawString(ListView4.SelectedItems(nctr).SubItems(3).Text, New Font("arial", 10), Brushes.Blue, New Point(330, YAxis + 80))
            xpos = 260
            Str = ListView4.SelectedItems(nctr).SubItems(2).Text
            iii = Len(ListView4.SelectedItems(nctr).SubItems(2).Text)
            For ii = 1 To Len(ListView4.SelectedItems(nctr).SubItems(2).Text)
                e.Graphics.DrawString(Mid(str, iii, 1), New Font("arial", 10), Brushes.Blue, New Point(xpos, YAxis + 80))
                iii -= 1
                xpos -= 8
            Next
            xpos = 460
            str = ListView4.SelectedItems(nctr).SubItems(4).Text
            iii = Len(ListView4.SelectedItems(nctr).SubItems(4).Text)
            For ii = 1 To Len(ListView4.SelectedItems(nctr).SubItems(4).Text)
                e.Graphics.DrawString(Mid(str, iii, 1), New Font("arial", 10), Brushes.Blue, New Point(xpos, YAxis + 80))
                iii -= 1
                xpos -= 8
            Next
        Next
        totaly = totaly + 20
        e.Graphics.DrawString("_________________________________________________________", New Font("Times New Roman", 12), Brushes.Blue, New Point(5, totaly))
        totaly = totaly + 25
        e.Graphics.DrawString("Total: ", New Font("Times New Roman", 11), Brushes.Blue, New Point(10, totaly))
        xpos = 460
        str = Format(Val(lbltotal.Text), "# ##0.00")
        iii = Len(str)
        For ii = 1 To Len(str)
            e.Graphics.DrawString(Mid(str, iii, 1), New Font("arial", 10), Brushes.Blue, New Point(xpos, totaly))
            iii -= 1
            xpos -= 8
        Next
        totaly = totaly + 20
        e.Graphics.DrawString("Cash: ", New Font("Times New Roman", 11), Brushes.Blue, New Point(10, totaly))
        xpos = 460
        str = Format(Val(lblcash.Text), "# ##0.00")
        iii = Len(str)
        For ii = 1 To Len(str)
            e.Graphics.DrawString(Mid(str, iii, 1), New Font("arial", 10), Brushes.Blue, New Point(xpos, totaly))
            iii -= 1
            xpos -= 8
        Next
       totaly = totaly + 20
        e.Graphics.DrawString("Change: ", New Font("Times New Roman", 11), Brushes.Blue, New Point(10, totaly))
        xpos = 460
        str = Format(Val(lblchange.Text), "# ##0.00")
        iii = Len(str)
        For ii = 1 To Len(str)
            e.Graphics.DrawString(Mid(str, iii, 1), New Font("arial", 10), Brushes.Blue, New Point(xpos, totaly))
            iii -= 1
            xpos -= 8
        Next
        totaly = totaly + 10
        e.Graphics.DrawString("_________________________________________________________", New Font("Times New Roman", 12), Brushes.Blue, New Point(5, totaly))

        'totaly = totaly + 60
        'e.Graphics.DrawString("Date: " & Format(Now, "MMMM d, yyyy"), New Font("Times New Roman", 12), Brushes.Blue, New Point(10, totaly))
        totaly = totaly + 30
        e.Graphics.DrawString("Cashier: " & u_cashier, New Font("Times New Roman", 12), Brushes.Blue, New Point(10, totaly))

    End Sub

End Class