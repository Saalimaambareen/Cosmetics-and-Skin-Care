Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form2
    Private userlogin As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim adminname As String = TextBox1.Text
        Dim password As String = TextBox2.Text

        ' Update the connection string with your SQL Server details
        Dim connectionString As String = "Data Source=DESKTOP-D9BHUCJ\SQLEXPRESS;Initial Catalog=data;Integrated Security=True"
        Dim query As String = "SELECT password FROM Admin WHERE admin_name=@AdminName"

        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@AdminName", adminname)

            Try
                conn.Open()
                Dim storedPassword As Object = cmd.ExecuteScalar()

                If storedPassword Is Nothing Then
                    MessageBox.Show("Wrong username!")
                ElseIf storedPassword.ToString() <> password Then
                    MessageBox.Show("Wrong password!")
                Else
                    MessageBox.Show("Login successful!")
                    ' Proceed to the next form or functionality
                    Dim Form12 As New Form12()
                    Form12.Show()
                    Me.Hide()
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using

    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Form1 As New form1()
        Form1.Show()
    End Sub
End Class
