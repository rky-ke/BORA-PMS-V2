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
End Class