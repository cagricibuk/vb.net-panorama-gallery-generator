Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WebBrowser1.Navigate(Form1.ciktiYolu & " \ " & Form1.projeAdi & "\index.html")

    End Sub
End Class