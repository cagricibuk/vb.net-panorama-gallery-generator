Public Class Form1
    Public sayi As Integer
    Public Shared projeAdi As String
    Public Shared ciktiYolu As String
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        sayi = NumericUpDown1.Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sayi = NumericUpDown1.Value
        ciktiYolu = Label2.Text
        projeAdi = TextBox1.Text
        Form2.Show()
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        projeAdi = InputBox("Proje Adını girin", "Proje Adı", "-")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FolderBrowserDialog1.ShowDialog()
        Label2.Text = FolderBrowserDialog1.SelectedPath


    End Sub


End Class
