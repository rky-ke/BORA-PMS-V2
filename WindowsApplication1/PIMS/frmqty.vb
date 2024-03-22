Imports MySql.Data.MySqlClient

Public Class frmqty
    Dim qty_conn As New MySqlConnection("server=localhost;uid=root;pwd='';database=pmisdb")
    Dim qty_cmd As New MySqlCommand
    Dim qty_adp As New MySqlDataAdapter
    Dim qty_tbl As New DataTable
    Public strvat, strprice As String
    Public qty As Integer
    Private Sub frmqty_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'If Val(TextBox6.Text) > Val(TextBox3.Text) Then TextBox6.Text = TextBox3.Text
        'Dim t As Double
        't = Val(TextBox2.Text) * Val(TextBox6.Text)
        'TextBox5.Text = Format(Val(t), "# ##0.00")
        'TextBox5.Text = Trim(TextBox5.Text)

        Me.Dispose()
    End Sub

    Private Sub frmqty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then
            If frmcashregistry.itemindex = 0 Then frmcashregistry.ListView4.Focus()
            If frmcashregistry.cartindex = 0 Then frmcashregistry.ListView1.Focus()
            Me.Close()
        End If

        If frmcashregistry.cartindex = 0 And e.KeyCode = Keys.Enter Then
            'If frmcashregistry.ListView4.Items.Count = 0 Then
            frmcashregistry.ListView4.Items.Add(frmcashregistry.itemindex)
            frmcashregistry.ListView4.Items(frmcashregistry.ListView4.Items.Count - 1).SubItems.Add(TextBox1.Text)
            frmcashregistry.ListView4.Items(frmcashregistry.ListView4.Items.Count - 1).SubItems.Add(TextBox2.Text)
            frmcashregistry.ListView4.Items(frmcashregistry.ListView4.Items.Count - 1).SubItems.Add(TextBox6.Text)
            frmcashregistry.ListView4.Items(frmcashregistry.ListView4.Items.Count - 1).SubItems.Add(TextBox5.Text)
            frmcashregistry.ListView4.Items(frmcashregistry.ListView4.Items.Count - 1).SubItems.Add(TextBox3.Text)
            frmcashregistry.ListView4.Items(frmcashregistry.ListView4.Items.Count - 1).SubItems.Add(strvat)
            frmcashregistry.ListView4.Items(frmcashregistry.ListView4.Items.Count - 1).SubItems.Add(strprice)
            frmcashregistry.ListView1.SelectedItems.Clear()
            frmcashregistry.ListView4.Focus()
            frmcashregistry.Timer1.Enabled = True
            If frmcashregistry.ListView4.Items.Count > 0 Then
                Dim i As Integer
                i = Val(frmcashregistry.ListView4.Items.Count - 1)
                frmcashregistry.ListView4.Items(i).Focused = True
            End If
            Me.Close()
            'ElseIf frmcashregistry.ListView4.Items.Count > 0 Then
            '    Dim i As Integer

            'End If
        End If
        If frmcashregistry.itemindex = 0 And e.KeyCode = Keys.Enter Then
            frmcashregistry.ListView4.Items.Add(frmcashregistry.cartindex)
            frmcashregistry.ListView4.Items(frmcashregistry.ListView4.Items.Count - 1).SubItems.Add(TextBox1.Text)
            frmcashregistry.ListView4.Items(frmcashregistry.ListView4.Items.Count - 1).SubItems.Add(TextBox2.Text)
            frmcashregistry.ListView4.Items(frmcashregistry.ListView4.Items.Count - 1).SubItems.Add(TextBox6.Text)
            frmcashregistry.ListView4.Items(frmcashregistry.ListView4.Items.Count - 1).SubItems.Add(TextBox5.Text)
            frmcashregistry.ListView4.Items(frmcashregistry.ListView4.Items.Count - 1).SubItems.Add(TextBox3.Text)
            frmcashregistry.ListView4.Items(frmcashregistry.ListView4.Items.Count - 1).SubItems.Add(strvat)
            frmcashregistry.ListView4.Items(frmcashregistry.ListView4.Items.Count - 1).SubItems.Add(strprice)
            frmcashregistry.ListView4.Focus()
            frmcashregistry.Timer1.Enabled = True
            Me.Close()
            Dim i As Integer
            i = Val(frmcashregistry.ListView4.FocusedItem.Index)
            frmcashregistry.ListView4.FocusedItem.Remove()
        End If

    End Sub

    
    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        If Val(TextBox6.Text) > Val(TextBox3.Text) Then TextBox6.Text = TextBox3.Text
        Dim t As Double
        t = Val(TextBox2.Text) * Val(TextBox6.Text)
        TextBox5.Text = Format(Val(t), "# ##0.00")
        TextBox5.Text = Trim(TextBox5.Text)
    End Sub

    Private Sub frmqty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox6.Text = Me.qty
        TextBox6.Select()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
End Class