Imports System.Data.OleDb

Public Class LoginForm1
    Dim con As New OleDbConnection

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim cmd As OleDbCommand = New OleDbCommand("Select * FROM [user] where [username]='" & UsernameTextBox.Text & "' AND [password] = '" & PasswordTextBox.Text & "'", con)
        Dim dr As OleDbDataReader = cmd.ExecuteReader

        'the following variable is hold true if user is found ,and false if user is not found
        Dim userfound As Boolean = False
        Dim firstname As String = ""
        Dim lastname As String = ""


        While dr.Read
            userfound = True
            firstname = dr("firstname").ToString
            lastname = dr("lastname").ToString

        End While
        If userfound = True Then
            Form2.Show()
            Me.Hide()

        Else
            MsgBox("Sorry, username or password not found", MsgBoxStyle.OkOnly, "invalid login")

        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        
        If MsgBox("ARE YOU SURE WANT TO EXIT?", MsgBoxStyle.YesNo, "clear") = MsgBoxResult.Yes Then
            UsernameTextBox.Text = ""
            PasswordTextBox.Text = ""
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("ARE YOU SURE WANT TO EXIT?", MsgBoxStyle.OkCancel, "EXIT") = MsgBoxResult.Ok Then
            Me.Hide()
            con.Close()

        End If
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Raju\Desktop\projectX\projectX\Resources\Database2.accdb"
        con.Open()


    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        Form4.Show()
        con.Close()
    End Sub
End Class
