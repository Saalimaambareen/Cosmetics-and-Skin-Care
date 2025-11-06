Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class form3

    Private Sub form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate the ComboBox with gender options
        ComboBox1.Items.Add("Male")
        ComboBox1.Items.Add("Female")
        ComboBox1.Items.Add("Others")
    End Sub

    ' Button1 - Register (Save in DBMS for new customers)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim userid As String = TextBox1.Text
        Dim name As String = TextBox2.Text
        Dim gender As String = ComboBox1.SelectedItem?.ToString()
        Dim email As String = TextBox3.Text
        Dim phoneno As String = TextBox4.Text
        Dim address As String = TextBox5.Text
        Dim password As String = TextBox6.Text

        ' Validate phone number
        If String.IsNullOrWhiteSpace(phoneno) OrElse Not IsNumeric(phoneno) OrElse phoneno.Length <> 10 Then
            MessageBox.Show("Please enter a valid 10-digit phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox4.Focus()
            Return
        End If

        ' Validate email address
        If Not email.Contains("@") OrElse Not email.Contains(".") OrElse Not email.EndsWith(".com") Then
            MessageBox.Show("Please enter a valid email address that contains '@', '.', and ends with '.com'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return
        End If

        Dim conn As SqlConnection = New SqlConnection("Data Source=DESKTOP-D9BHUCJ\SQLEXPRESS;Initial Catalog=data;Integrated Security=True")
        Dim query As String = "INSERT INTO Customers (UserID, Name, Gender, Email, Phoneno, Address, Password) VALUES (@UserID, @Name, @Gender, @Email, @Phoneno, @Address, @Password)"

        Try
            conn.Open()
            Using cmd As SqlCommand = New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@UserID", userid)
                cmd.Parameters.AddWithValue("@Name", name)
                cmd.Parameters.AddWithValue("@Gender", gender)
                cmd.Parameters.AddWithValue("@Email", email)
                cmd.Parameters.AddWithValue("@Phoneno", phoneno)
                cmd.Parameters.AddWithValue("@Address", address)
                cmd.Parameters.AddWithValue("@Password", password)
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Registration successful!")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Button2 - Login (Existing Customer)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Open form4 for login (existing customer)
        Me.Hide()
        form4.Show()
    End Sub

End Class
