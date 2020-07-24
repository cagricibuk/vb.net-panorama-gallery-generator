Imports System.Text.RegularExpressions
Public Class Form2

    Public Shared resimler As New List(Of String)
    Public Shared basliklar As New List(Of String)
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ysayi As Integer = 15
        Dim xsayi As Integer = 15

        For i As Integer = 1 To Form1.sayi


            Dim myTextBox = New TextBox
            Dim button = New Button

            button.Location = New Point(xsayi + 120, ysayi)
            button.Name = "Button" & i
            button.Text = "Resim ekle:" & i

            myTextBox.Name = "TextBox" & i
            myTextBox.Location = New Point(xsayi, ysayi)
            myTextBox.Text = "Control Number:" & i

            AddHandler myTextBox.TextChanged, AddressOf OnTextBox_Changed
            AddHandler button.Click, AddressOf OnButton_Click
            Me.Controls.Add(button)
            Me.Controls.Add(myTextBox)
            ysayi += 40
            If ysayi > 450 Then
                ysayi = 15
                xsayi += 240
            End If

        Next



    End Sub
    Private Sub OnTextBox_Changed(sender As Object, e As EventArgs)
        Dim txt = DirectCast(sender, TextBox)
        MessageBox.Show(txt.Name & "Değişti")
    End Sub
    Private Sub OnButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim btn As New Button
        Dim regex As Regex = New Regex("\d+")



        btn = CType(sender, Button)

        MessageBox.Show(btn.Name & " Clicked ")
        Dim match As Match = regex.Match(btn.Name)
        OpenFileDialog1.ShowDialog()
        If match.Success Then
            MessageBox.Show(match.Value - 1)
            resimler.Insert(match.Value - 1, OpenFileDialog1.FileName)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show(resimler.Count)
        For i As Integer = 0 To resimler.Count - 1

            MessageBox.Show(resimler(i))
        Next

        Form3.Show()
        Close()
    End Sub


End Class