Imports System.Net.Mail
Public Class Form3

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = "raju.raw.zoo@gmail.com"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim smtp As New SmtpClient()
            Dim mail As New MailMessage()
            smtp.Credentials = New Net.NetworkCredential(TextBox1.Text, TextBox3.Text)
        smtp.EnableSsl = True

            smtp.Port = 587
        smtp.Host = "smtp.gmail.com"

            mail = New MailMessage()
            mail.From = New MailAddress(TextBox1.Text)
            mail.Subject = TextBox4.Text
        mail.To.Add(TextBox2.Text)
            mail.Body = TextBox5.Text
            smtp.Send(mail)
        MsgBox("mail send")


    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class