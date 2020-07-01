Imports System.Drawing.Imaging
Imports System.Net

Public Class Form1
    Dim Caminho
    Dim Caminho2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim intMinute = Minute(Now)
        Dim intSecond = Second(Now)

        Me.WindowState = FormWindowState.Minimized

        Try
            Me.Hide()
            Dim bounds As Rectangle
            Dim screenshot As System.Drawing.Bitmap
            Dim graph As Graphics

            System.Threading.Thread.Sleep(200)
            bounds = Screen.PrimaryScreen.Bounds
            screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            graph = Graphics.FromImage(screenshot)
            graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
            PictureBox1.Image = screenshot
            Try
                screenshot.Save(Caminho & My.Computer.Name & "_" & Environment.UserName & "_" & intMinute & intSecond & ".jpg", ImageFormat.Jpeg)
                Dim IMGsalva = Caminho & My.Computer.Name & "_" & Environment.UserName & "_" & intMinute & intSecond & ".jpg"

                If My.Computer.FileSystem.FileExists(IMGsalva) Then
                    ToolStripStatusLabel3.Text = "- Print Salvo!"
                    ToolStripStatusLabel3.ForeColor = Color.Green

                Else
                    ToolStripStatusLabel3.Text = "Erro!"
                    ToolStripStatusLabel3.ForeColor = Color.Red
                End If
            Catch
                ToolStripStatusLabel3.Text = " - Erro!"
                ToolStripStatusLabel3.ForeColor = Color.Red


            End Try


        Catch ex As Exception
            MsgBox("Erro : " & ex.Message)
        End Try
        Me.Show()


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Environment.UserDomainName
        Label1.ForeColor = Color.Silver
        If Environment.UserDomainName = "DOMINIO_01" Then 'Coloque o dominio da estação de trabalho
            Label2.Text = Environment.UserDomainName
            Caminho = "\\SERVIDOR01.DOMINIO.LOCAL\prints$\" ' Caminho do fileserver onde ficara salva o print
            Caminho2 = "SERVIDOR01.DOMINIO.LOCAL" ' Caminho do fileserver para validação se o servidor esta online
            Label3.Text = Caminho
        Else
            Label2.Text = Environment.UserDomainName
            Caminho = "\\SERVIDOR02.OUTRO.DOMINIO\prints$\" ' Caso sua rede tenha mais de um dominio adicionao dominio secundário.

            Caminho2 = "SERVIDOR02.OUTRO.DOMINIO" ' Caminho do fileserver para validação se o servidor esta online
            Label3.Text = Caminho

        End If
        Try
            Dim addresslist As IPAddress() = Dns.GetHostAddresses(Caminho2)
            If addresslist(0).ToString().Length > 6 Then
                Label1.Text = "OK"
                Label1.ForeColor = Color.Green
            Else
                Label1.Text = "Sem acesso"
                Label1.ForeColor = Color.Red
            End If
        Catch ex As Sockets.SocketException
            ' | ' You are offline                   |
            ' | ' the host is unkonwn               |
            Label1.Text = "Sem acesso"
            Label1.ForeColor = Color.Red
        Catch ex As Exception
            Label1.Text = "Sem acesso"
            Label1.ForeColor = Color.Red
        End Try

        ToolStripStatusLabel1.Text = My.Computer.Name
        ToolStripStatusLabel2.Text = My.User.Name
        ToolStripStatusLabel3.Text = "- V. 1.2"

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Form2.Show()

    End Sub


    Private Sub Label4_Click_1(sender As Object, e As EventArgs) Handles Label4.Click
        MessageBox.Show("Desenvolvido por Roberson." + Environment.NewLine + Environment.NewLine + "@ roberson_silva@yahoo.com.br" + Environment.NewLine + "Git - https://github.com/RobersonSilva")
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel2.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Me.WindowState = FormWindowState.Normal



    End Sub
End Class
