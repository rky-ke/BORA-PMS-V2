Imports MySql.Data.MySqlClient

Module Module1
    Public conn As New MySqlConnection("server=127.0.0.1;uid=root;password=;database=pmisdb;")
    Public cmd As New MySqlCommand
    Public tbl As New DataTable
    Public adp As New MySqlDataAdapter
End Module
