Imports MySql.Data.MySqlClient

Public Class frmlist
    Public addstockid As Integer
    Public currentstock As Integer
    Public meddescription As String
    Public Sub med_list()
        Try
            ListView1.Items.Clear()
            adp.SelectCommand = New MySqlCommand("SELECT * FROM tblproduct ORDER BY id ", conn)
            adp.Fill(tbl)

            If tbl.Rows.Count = 0 Then conn.Close() : Exit Sub

            For Each row As DataRow In tbl.Rows
                ListView1.Items.Add(row("id"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("p_desc") & " " & row("p_unitsize") & " (" & row("p_generic") & ")")
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("p_sellprice"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row("p_stocks"))

            Next
            tbl.Clear()
            conn.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmlist_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call med_list()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmmedicine.Button1.Enabled = False
        frmmedicine.Button2.Enabled = True
        Call frmmedicine.med_information()
        Me.Close()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            If ListView1.SelectedItems.Count > 0 Then frmmedicine.medID = Val(ListView1.SelectedItems(0).SubItems(0).Text)
            addstockid = Val(ListView1.SelectedItems(0).SubItems(0).Text)
            meddescription = ListView1.SelectedItems(0).SubItems(1).Text
            currentstock = Val(ListView1.SelectedItems(0).SubItems(3).Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            If addstockid = 0 Then MsgBox("select an item first", MsgBoxStyle.Information, "message") : Exit Sub
            frmaddstock.Text = meddescription
            frmaddstock.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub
End Class