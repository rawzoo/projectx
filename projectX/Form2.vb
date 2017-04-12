Imports System.Data.OleDb
Imports System.IO
Public Class Form2
    Dim con As New OleDbConnection
    Dim raju() As Byte
    Dim ms As New System.IO.MemoryStream


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        LoginForm1.Show()
        Me.Hide()
        con.Close()


    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Form3.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim opf As New OpenFileDialog
        If opf.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(opf.FileName)

        End If
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Raju\Desktop\projectX\projectX\Resources\Database2.accdb"
        con.Open()
        make()
    End Sub
    Private Sub make()
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter
        da = New OleDbDataAdapter("select * from details", con)
        da.Fill(dt)
        DataGridView1.DataSource = dt.DefaultView




    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim command As New OleDbCommand

        command = New OleDbCommand("insert into details(st_name,roll,gender,course,email,dob,college,pic)values(@st_name,@roll,@college,@gender,@course,@email,@dob,@pic)", con)
        command.Parameters.Add("@st_name", OleDbType.VarChar).Value = TextBox1.Text

        If RadioButton1.Checked = True Then
            command.Parameters.Add("@gender", OleDbType.VarChar).Value = "Male"
        ElseIf RadioButton2.Checked = True Then
            command.Parameters.Add("@gender", OleDbType.VarChar).Value = "Female"
        Else
            MsgBox("PLS Enter the gender")
        End If

        command.Parameters.Add("@roll", OleDbType.Integer).Value = TextBox2.Text

        If CheckBox1.Checked = True Then
            command.Parameters.Add("@course", OleDbType.VarChar).Value = "B.Tech"
        End If
        If CheckBox2.Checked = True Then
            command.Parameters.Add("@course", OleDbType.VarChar).Value = "M.Tech"
        End If

        command.Parameters.Add("@college", OleDbType.VarChar).Value = TextBox3.Text
        command.Parameters.Add("@email", OleDbType.VarChar).Value = TextBox4.Text

        'DateTimePicker1.Text = DateTimePicker1.Value
        'command.Parameters.Add("@dob", OleDbType.VarChar).Value = DateTimePicker1.Value

        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        raju = ms.GetBuffer
        command.Parameters.Add("@pic", OleDbType.Binary).Value = raju


        If command.ExecuteNonQuery = 1 Then
            MsgBox("Record inserted")
        Else
            MsgBox("Error !pls try again")
        End If


    End Sub


End Class