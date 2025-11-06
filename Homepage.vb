Public Class Form5
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            PictureBox1.Image = Image.FromFile("C:\Users\Personal\Pictures\pict.jpg")


            ' Adjust SizeMode for better display
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

        Catch ex As Exception
            MessageBox.Show("Error loading images: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Button1 - Makeup
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim form6 As New Form6()
        form6.Show()
    End Sub

    ' Button2 - Hair
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Dim form7 As New Form7()
        form7.Show()
    End Sub

    ' Button3 - Skin
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Dim form8 As New Form8()
        form8.Show()
    End Sub
    ' Button4 - fragnance
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Dim form9 As New form9()
        form9.Show()
    End Sub
    ' Button5 - Cart
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Dim form10 As New Form10()
        form10.Show()
    End Sub



End Class