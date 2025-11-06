Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form10
    Dim connectionString As String = "Data Source=DESKTOP-D9BHUCJ\SQLEXPRESS;Initial Catalog=data;Integrated Security=True"
    Dim showingCart As Boolean = False



    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAllProducts()
    End Sub

    ' Load all products from 4 tables
    Private Sub LoadAllProducts()
        showingCart = False
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "
                SELECT ProductID, ProductName, Price FROM Make_products
                UNION ALL
                SELECT ProductID, ProductName, Price FROM Hair_products
                UNION ALL
                SELECT ProductID, ProductName, Price FROM Skin_products
                UNION ALL
                SELECT ProductID, ProductName, Price FROM Per_products"
            Dim adapter As New SqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        End Using
    End Sub

    ' Load cart
    Private Sub LoadCart()
        showingCart = True
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim adapter As New SqlDataAdapter("SELECT * FROM Cart", conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

            ' Show total
            Dim total As Decimal = 0
            For Each row As DataRow In table.Rows
                total += Convert.ToDecimal(row("Price")) * Convert.ToDecimal(row("Quantity"))
            Next
            TextBox1.Text = "Total: ₹" & total.ToString("0.00")
        End Using
    End Sub

    ' Add to cart on product click
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Exit Sub

        If Not showingCart Then
            ' Add to cart
            Dim row = DataGridView1.Rows(e.RowIndex)

            Dim id = Convert.ToInt32(row.Cells("ProductID").Value)
            Dim name = row.Cells("ProductName").Value.ToString()
            Dim price = Convert.ToDecimal(row.Cells("Price").Value)

            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim cmd As New SqlCommand("INSERT INTO Cart ( ProductID, ProductName, Price, Quantity) VALUES ( @id, @name, @price, 1)", conn)

                cmd.Parameters.AddWithValue("@id", id)
                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@price", price)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Added to cart!")
        Else
            ' Remove from cart
            Dim cartId = Convert.ToInt32(DataGridView1.Rows(e.RowIndex).Cells("CartID").Value)
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim cmd As New SqlCommand("DELETE FROM Cart WHERE CartID = @id", conn)
                cmd.Parameters.AddWithValue("@id", cartId)
                cmd.ExecuteNonQuery()

            End Using

            LoadCart()
            MessageBox.Show("Item removed.")
        End If
    End Sub

    ' Button: View Cart
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadCart()

    End Sub

    ' Button: Back to Products
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadAllProducts()
    End Sub

    ' Button: Clear Cart
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim cmd As New SqlCommand("DELETE FROM Cart", conn)
            cmd.ExecuteNonQuery()
        End Using
        LoadCart()
        MessageBox.Show("Cart cleared.")
    End Sub

    ' Button: Proceed to Payment
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MessageBox.Show("Proceeding to payment...")
        Dim totalText As String = TextBox1.Text.Replace("Total: ₹", "").Trim()
        Dim totalAmount As Decimal = Convert.ToDecimal(totalText)

        Dim Form11 As New Form11(totalAmount)
        Form11.Show()
        Me.Hide()


    End Sub
End Class
