Imports System.Text.RegularExpressions
Imports System.IO
Public Class Form1
    Public Country As String
    'this array will store all informations that user will input
    Dim Informations(5) As String
    Dim monke As String = "@"
    Dim date_pick As String
    Dim path_user As String
    Dim path_user2 As String = "\"
    Dim path_txt As String = ".txt"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = ""
        Label1.Text = ""
        Timer1.Enabled = True
        Label3.Text = "Country:"
        Label4.Text = "Email:"
        Label5.Text = ""
        Label6.Text = "Name:"
        Label7.Text = "Surname:"
        Label8.Text = "Date of birth:"
        Label9.Text = ""
        Label10.Text = "path where data will be saved"
        Label11.Text = ""
        Informations(0) = "Name: "
        Informations(1) = "Surname: "
        Informations(2) = "Country: "
        Informations(3) = "Date of birth: "
        Informations(4) = "Profile picture: "
        Informations(5) = "Email: "
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'checks surname
        If Not Regex.Match(TextBox2.Text, "^[a-z]*$", RegexOptions.IgnoreCase).Success Or TextBox2.Text = "" Then
            Label2.Text = "You cant type here special characters nor numbers or leave it empty!"
        Else
            Label2.Text = ""
        End If
        'checks name
        If Not Regex.Match(TextBox1.Text, "^[a-z]*$", RegexOptions.IgnoreCase).Success Or TextBox1.Text = "" Then
            Label1.Text = "You cant type here special characters nor numbers or leave it empty!"
        Else
            Label1.Text = ""
        End If
        'checks name
        If Not Regex.Match(TextBox3.Text, monke, RegexOptions.IgnoreCase).Success Or TextBox3.Text = "" Then
            Label5.Text = "Email must contain @!!"
        Else
            Label5.Text = ""
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Country = Me.ComboBox1.GetItemText(Me.ComboBox1.SelectedItem)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pic As New OpenFileDialog
        pic.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif"
        If pic.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Image.FromFile(pic.FileName).Width > 252 Or Image.FromFile(pic.FileName).Height > 203 Then
                Label9.Text = "Image cant be bigger than 252x203px"
            Else
                Label9.Text = ""
                PictureBox1.Image = Image.FromFile(pic.FileName)
                Informations(4) += pic.SafeFileName
            End If
        End If
    End Sub

    Private Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click

        If Label5.Text = "" And Label2.Text = "" And Label1.Text = "" And Not TextBox4.Text = "" Then
            date_pick = DateTimePicker1.Value.Date
            Informations(3) += date_pick
            Informations(5) += TextBox3.Text
            Informations(0) += TextBox1.Text
            Informations(1) += TextBox2.Text
            Informations(2) += Country
            Informations(5) += TextBox3.Text
            path_user = TextBox4.Text
            path_user += path_user2
            path_user += TextBox1.Text + TextBox2.Text
            path_user += path_txt
            Dim n As Integer = 0
            While n < 6
                File.WriteAllLines(path_user, Informations)
                n += 1
            End While
            Label11.Text = "Succesfully registered. You can view your data at:" + path_user
        Else
            Label11.Text = "You must validate email,name or surname"
        End If
    End Sub
End Class
