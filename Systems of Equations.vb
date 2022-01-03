Public Class Form1

    Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
        Dim row1() As Decimal = {Val(Me.txt11.Text), Val(Me.txt12.Text), Val(Me.txt13.Text), Val(Me.txt14.Text)}
        Dim row2() As Decimal = {Val(Me.txt21.Text), Val(Me.txt22.Text), Val(Me.txt23.Text), Val(Me.txt24.Text)}
        Dim row3() As Decimal = {Val(Me.txt31.Text), Val(Me.txt32.Text), Val(Me.txt33.Text), Val(Me.txt34.Text)}

        If row1(0) <> 1 Then
            row1(1) /= row1(0)
            row1(2) /= row1(0)
            row1(3) /= row1(0)

            row1(0) /= row1(0)          'happens after so that it does not affect previous
        End If

        If row2(0) <> 0 Then
            row2(1) -= row2(0) * row1(1)
            row2(2) -= row2(0) * row1(2)
            row2(3) -= row2(0) * row1(3)

            row2(0) -= row2(0) * row1(0)
        End If

        If row3(0) <> 0 Then
            row3(1) -= row3(0) * row1(1)
            row3(2) -= row3(0) * row1(2)
            row3(3) -= row3(0) * row1(3)

            row3(0) -= row3(0) * row1(0)
        End If

        If row2(1) <> 1 Then
            row2(0) /= row2(1)
            row2(2) /= row2(1)
            row2(3) /= row2(1)

            row2(1) /= row2(1)
        End If

        If row1(1) <> 0 Then
            row1(0) -= row1(1) * row2(0)
            row1(2) -= row1(1) * row2(2)
            row1(3) -= row1(1) * row2(3)

            row1(1) -= row1(1) * row2(1)
        End If

        If row3(1) <> 0 Then
            row3(0) -= row3(1) * row2(0)
            row3(2) -= row3(1) * row2(2)
            row3(3) -= row3(1) * row2(3)

            row3(1) -= row3(1) * row2(1)
        End If

        If row3(2) <> 1 Then
            row3(0) /= row3(2)
            row3(1) /= row3(2)
            row3(3) /= row3(2)

            row3(2) /= row3(2)
        End If

        If row1(2) <> 0 Then
            row1(0) -= row1(2) * row3(0)
            row1(1) -= row1(2) * row3(1)
            row1(3) -= row1(2) * row3(3)

            row1(2) -= row1(2) * row3(2)
        End If

        If row2(2) <> 0 Then
            row2(0) -= row2(2) * row3(0)
            row2(1) -= row2(2) * row3(1)
            row2(3) -= row2(2) * row3(3)

            row2(2) -= row2(2) * row3(2)
        End If

        row1(3) = Math.Round(row1(3), 2)
        row2(3) = Math.Round(row2(3), 2)
        row3(3) = Math.Round(row3(3), 2)

        Me.lblAnswer.Text = "x = " & row1(3) & ", y = " & row2(3) & ", z = " & row3(3)
    End Sub

    Private Sub lblEquation1_Click(sender As Object, e As EventArgs) Handles lblEquation1.Click

    End Sub
End Class
