Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class form4

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text

        ' Update the connection string with your SQL Server details
        Dim connectionString As String = "Data Source=DESKTOP-D9BHUCJ\SQLEXPRESS;Initial Catalog=data;Integrated Security=True"
        Dim query As String = "SELECT Password FROM Customers WHERE Name=@Name"

        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Name", username)

            Try
                conn.Open()
                Dim storedPassword As Object = cmd.ExecuteScalar()

                If storedPassword Is Nothing Then
                    MessageBox.Show("Wrong username!")
                ElseIf storedPassword.ToString() <> password Then
                    MessageBox.Show("Wrong password!")
                Else
                    MessageBox.Show("Login successful!")
                    ' Open Form5 after successful login
                    Dim form5 As New Form5()
                    form5.Show()
                    Me.Hide()
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Form1 As New form1()
        Form1.Show()
        Me.Hide()


    End Sub
End Class


