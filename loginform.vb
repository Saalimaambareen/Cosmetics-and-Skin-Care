Public Class form1

    Inherits System.Windows.Forms.Form

    Private Sub Button1_click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim adminloginform As New Form2()
        Form2.Show()
    End Sub
    Private Sub Button2_click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim customerregistrationform As New Form3()
        Form3.Show()
    End Sub


End Class


