Imports System.Data.OleDb
Public Class Form4
    Dim con As New OleDbConnection
    Dim raju() As Byte
    Dim ms As New System.IO.MemoryStream

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Raju\Desktop\projectX\projectX\Resources\Database2.accdb"
        con.Open()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        LoginForm1.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter
        da = New OleDbDataAdapter("SELECT * FROM USER", con)
        da.Fill(dt)

        Dim command As New OleDbCommand
        command = New OleDbCommand("insert into user (username,password,firstname,lastname)values(@username,@password,@firstname,@lastname)", con)

        command.Parameters.Add("@firstname", OleDbType.VarChar).Value = TextBox1.Text
        command.Parameters.Add("@lastname", OleDbType.VarChar).Value = TextBox2.Text
        command.Parameters.Add("@username", OleDbType.VarChar).Value = TextBox3.Text
        command.Parameters.Add("@password", OleDbType.VarChar).Value = TextBox4.Text

        If command.ExecuteNonQuery = 1 Then
            MsgBox("YOU ARE SUCCESFULLY REGISTERED", MsgBoxStyle.OkOnly, "SUCCEESS")
            Me.Hide()
            LoginForm1.Show()
        Else
            MsgBox("ERROR NOT FOUND")
        End If

    End Sub
End Class