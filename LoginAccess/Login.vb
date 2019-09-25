Imports System.Runtime.InteropServices
Imports Domain
Imports Common

Public Class Login

#Region "Form Behaviors"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

#End Region
#Region "Drag Form"
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMgs As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
#End Region
#Region "Customize Controls"
    Private Sub CustomizeComponents()
        'txtEmail
        txtEmail.AutoSize = False
        txtEmail.Size = New Size(350, 35)
        'txtPassword
        txtPassword.AutoSize = False
        txtPassword.Size = New Size(350, 35)
        txtPassword.UseSystemPasswordChar = True
    End Sub
    Private Sub Button1_Paint(sender As Object, e As PaintEventArgs) Handles Button1.Paint
        Dim ButtomPath As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
        Dim myRectangle As Rectangle = Button1.ClientRectangle
        myRectangle.Inflate(0, 30)
        ButtomPath.AddEllipse(myRectangle)
        Button1.Region = New Region(ButtomPath)
    End Sub
#End Region
    Public Sub New()
        InitializeComponent()

        CustomizeComponents()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim userModel As New UserModel()
        Dim validLogin = userModel.Login(txtEmail.Text, txtPassword.Text)
        If validLogin = True Then
            Dim frm As New FormPrincipal()
            frm.Show()
            AddHandler frm.FormClosed, AddressOf Me.Logout
            Me.Hide()
        Else
            MessageBox.Show("Incorrect username or password entered." + vbNewLine + "Please try again.")
            txtPassword.Clear()
            txtPassword.Focus()
        End If
    End Sub
End Class
