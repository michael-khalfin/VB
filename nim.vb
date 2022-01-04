Public Class Form1
    Dim totalStones As Integer

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call Restart()
    End Sub

    Private Sub TakeStones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTakeStones.Click
        Dim takeStonesUser As Integer = Val(Me.txtNumberofStones.Text)
        Dim continueOrnot As Boolean = CheckUserAmnt(takeStonesUser)

        If continueOrnot = True Then
            totalStones = totalStones - takeStonesUser
            Me.lblStonesinPile.Text = "Stones in pile: " & totalStones
            Dim checkStoneInPile As Boolean = CheckStonesInPileUser()
            If checkStoneInPile = True Then
                Me.txtNumberofStones.Text = Nothing
                Me.Timer1.Enabled = True
            End If
        Else
            MessageBox.Show("Please enter a valid amount.")
        End If

        Me.btnTakeStones.Enabled = False
    End Sub

    Function CheckStonesInPileUser()
        If totalStones = 0 Then
            MessageBox.Show("You lose. Press ok to restart")
            Call Restart()
            Return False
        Else
            Return True
        End If
    End Function

    Sub Restart()
        Randomize()
        totalStones = 16 * Rnd() + 15
        Me.lblStonesinPile.Text = "Stones in pile: " & totalStones
        Me.btnTakeStones.Enabled = True
    End Sub

    Function CheckUserAmnt(ByRef takeStonesUser As Integer)
        If totalStones < takeStonesUser Then
            Return False
        ElseIf takeStonesUser = 1 Or takeStonesUser = 2 Or takeStonesUser = 3 Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub Computer()
        Dim takeStonesComp As Integer
        Randomize()
        If totalStones >= 3 Then
            takeStonesComp = 2 * Rnd() + 1
        ElseIf totalStones = 2 Then
            takeStonesComp = Rnd() + 1
        Else
            takeStonesComp = 1
        End If

        totalStones = totalStones - takeStonesComp
        Me.lblComputer.Text = "Computer took " & takeStonesComp & " stone(s)."
        Me.lblStonesinPile.Text = "Stones in pile: " & totalStones

        Dim checkStoneInPile As Boolean = CheckStonesInPileComputer()
        If checkStoneInPile = True Then
            Me.txtNumberofStones.Text = Nothing
            Me.btnTakeStones.Enabled = True
        End If
    End Sub

    'Logic for 1, 2, 3 stones remaining will go here

    Function CheckStonesInPileComputer()
        If totalStones = 0 Then
            MessageBox.Show("You win. Press ok to restart.")
            Call Restart()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub NewGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewGame.Click
        Call Restart()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Timer1.Enabled = False
        Call Computer()
    End Sub
End Class
