Imports System.Data.SqlClient

Public Class Form12
    Dim connectionString As String = "Data Source=DESKTOP-D9BHUCJ\SQLEXPRESS;Initial Catalog=data;Integrated Security=True"

    ' Show all products from all product tables
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "
                SELECT 'Makeup' AS Category, ProductID, ProductName, Price, Quantity FROM Make_products
                UNION ALL
                SELECT 'Hair' AS Category, ProductID, ProductName, Price, Quantity FROM Hair_products
                UNION ALL
                SELECT 'Skin' AS Category, ProductID, ProductName, Price, Quantity FROM Skin_products
                UNION ALL
                SELECT 'Perfume' AS Category, ProductID, ProductName, Price, Quantity FROM Per_products
            "
            Dim adapter As New SqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        End Using
    End Sub

    ' Show all customer registrations and their purchases
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Using conn As New SqlConnection(connectionString)

            conn.Open()
            Dim query As String = "
   
      select * from Customers"





            Dim adapter As New SqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Form2 As New Form2()
        Form2.Show()
        Me.Hide()

    End Sub


End Class
