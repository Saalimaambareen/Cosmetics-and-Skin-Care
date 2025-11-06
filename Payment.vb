
Imports System.Data.SqlClient
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class Form11
    Private totalAmount As Decimal
    Dim connectionString As String = "Data Source=DESKTOP-D9BHUCJ\SQLEXPRESS;Initial Catalog=data;Integrated Security=True"

    Public Sub New(amount As Decimal)
        InitializeComponent()
        totalAmount = amount
    End Sub

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = totalAmount.ToString("0.00")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Store payment info
        Using conn As New SqlConnection(connectionString)
            conn.Open()

            ' Insert payment info
            Dim cmd As New SqlCommand("INSERT INTO Payments (TotalAmount, PaymentDate) VALUES (@amount, GETDATE())", conn)
            cmd.Parameters.AddWithValue("@amount", totalAmount)
            cmd.ExecuteNonQuery()

            ' Generate PDF with cart items
            GeneratePDF(conn)
        End Using

        MessageBox.Show("Payment Successful and Invoice Generated!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Form5.Show()
    End Sub

    Private Sub GeneratePDF(conn As SqlConnection)
        Try
            Dim doc As New Document()
            Dim filePath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Invoice_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".pdf"
            PdfWriter.GetInstance(doc, New FileStream(filePath, FileMode.Create))
            doc.Open()

            doc.Add(New Paragraph("Purchase Invoice"))
            doc.Add(New Paragraph("Date: " & DateTime.Now.ToString()))
            doc.Add(New Paragraph(" "))

            Dim table As New PdfPTable(4)
            table.AddCell("Product ID")
            table.AddCell("Product Name")
            table.AddCell("Price")
            table.AddCell("Quantity")

            Dim cmd As New SqlCommand("SELECT ProductID, ProductName, Price, Quantity FROM Cart", conn)
            Using reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    table.AddCell(reader("ProductID").ToString())
                    table.AddCell(reader("ProductName").ToString())
                    table.AddCell(reader("Price").ToString())
                    table.AddCell(reader("Quantity").ToString())
                End While
            End Using

            doc.Add(table)
            doc.Add(New Paragraph(" "))
            doc.Add(New Paragraph("Total Amount: ₹" & totalAmount.ToString("0.00")))
            doc.Close()

            MessageBox.Show("PDF generated at: " & filePath)
        Catch ex As Exception
            MessageBox.Show("Error generating PDF: " & ex.Message)
        End Try
    End Sub

End Class
