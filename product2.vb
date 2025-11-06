Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement



Public Class Form7
        Dim connectionString As String = "Data Source=DESKTOP-D9BHUCJ\SQLEXPRESS;Initial Catalog=data;Integrated Security=True"
        Dim selectedProductID As Integer
        Dim selectedProductName As String
        Dim selectedPrice As Decimal
        Dim selectedQuantity As Integer

        Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            LoadHair_products()
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

            ' Populate quantity ComboBox (1 to 10)
            ComboBox1.Items.Clear()
            For i As Integer = 1 To 10
                ComboBox1.Items.Add(i)
            Next
            ComboBox1.SelectedIndex = 0 ' Default to 1
        End Sub
        Private Sub LoadHair_products()
            ListBox1.Items.Clear()
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT ProductName FROM Hair_products", conn)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    ListBox1.Items.Add(reader("ProductName").ToString())
                End While
            End Using
        End Sub

        Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
            If ListBox1.SelectedItem Is Nothing Then Exit Sub

            Dim productName As String = ListBox1.SelectedItem.ToString()

            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT * FROM Hair_products WHERE ProductName=@ProductName", conn)
                cmd.Parameters.AddWithValue("@ProductName", productName)
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    selectedProductID = Convert.ToInt32(reader("ProductID"))
                    selectedProductName = reader("ProductName").ToString()
                    selectedPrice = Convert.ToDecimal(reader("Price"))
                    selectedQuantity = 1 ' Default quantity from ComboBox

                    TextBox3.Text = selectedProductID.ToString()
                    TextBox1.Text = selectedPrice.ToString()

                    ComboBox1.SelectedIndex = 0 ' Default quantity
                    ' Image load logic (unchanged)
                    If reader.GetSchemaTable().Rows.Cast(Of DataRow).Any(Function(r) r("ColumnName").ToString() = "ImagePath") Then
                        If Not IsDBNull(reader("ImagePath")) Then
                            Dim imgPath As String = reader("ImagePath").ToString()
                            If File.Exists(imgPath) Then
                                PictureBox1.Image = Image.FromFile(imgPath)
                            Else
                                PictureBox1.Image = Nothing
                            End If
                        Else
                            PictureBox1.Image = Nothing
                        End If
                    End If
                End If
            End Using
        End Sub
        Private Sub AddToCart(productID As Integer, name As String, price As Decimal, quantity As Integer)
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim cmd As New SqlCommand("INSERT INTO Cart (ProductID, ProductName, Price, Quantity) VALUES (@ProductID, @ProductName, @Price, @Quantity)", conn)
                cmd.Parameters.AddWithValue("@ProductID", productID)
                cmd.Parameters.AddWithValue("@ProductName", name)
                cmd.Parameters.AddWithValue("@Price", price)
                cmd.Parameters.AddWithValue("@Quantity", quantity)
                cmd.ExecuteNonQuery()
            End Using
        End Sub



        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            If selectedProductID = 0 Then
                MessageBox.Show("Please select a product first.")
                Exit Sub
            End If

            If ComboBox1.SelectedItem IsNot Nothing Then
                selectedQuantity = Convert.ToInt32(ComboBox1.SelectedItem)
            Else
                MessageBox.Show("Please select a quantity.")
                Exit Sub
            End If

            AddToCart(selectedProductID, selectedProductName, selectedPrice, selectedQuantity)
            MessageBox.Show("Item added successfully to cart.")
        End Sub
        ' Button to open cart form
        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
            Form10.Show()
        End Sub

        Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
            Dim Form5 As New Form5()
            Form5.Show()
            Me.Hide()

        End Sub
    End Class












