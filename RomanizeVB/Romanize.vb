Public Module Romanize
    Const simpleTranslationGreek As String = "άβδέζήιίϊΐκλνξόπρσςτυύϋΰφωώ"
    Const simpleTranslationLatin As String = "avdeziiiiiklnxoprsstyyyyfoo"
    Const digraphTranslationGreek As String = "θχψ"
    Const digraphTranslationLatin As String = "thchps"
    Const digraphYpsilonGreek As String = "αεη"
    Const digraphYpsilonLatin As String = "aei"
    Const digraphYpsilonBeta As String = "βγδζλμνραάεέηήιίϊΐοόυύϋΰωώ"
    Const digraphYpsilonPhi As String = "θκξπστφχψ"

    Function RomanizeText(ByRef greekText As String) As String
        Dim result As New System.Text.StringBuilder
        Dim cursor As Integer = 0
        Dim letter, newLetter, previousLetter, nextLetter, thirdLetter As String
        Dim isUpper, isUpper2 As Boolean
        Do While cursor < greekText.Count()
            letter = greekText.Substring(cursor, 1)
            If cursor > 0 Then previousLetter = greekText.Substring(cursor - 1, 1) Else previousLetter = ""
            If cursor < greekText.Count() - 1 Then nextLetter = greekText.Substring(cursor + 1, 1) Else nextLetter = ""
            If cursor < greekText.Count() - 2 Then thirdLetter = greekText.Substring(cursor + 2, 1) Else thirdLetter = ""

            isUpper = (letter.ToUpper() = letter)
            isUpper2 = (nextLetter.ToUpper() = nextLetter)
            letter = letter.ToLower()
            previousLetter = previousLetter.ToLower()
            nextLetter = nextLetter.ToLower()
            thirdLetter = thirdLetter.ToLower()


            If simpleTranslationGreek.Contains(letter) Then
                newLetter = simpleTranslationLatin.Substring(simpleTranslationGreek.IndexOf(letter), 1)
            ElseIf digraphTranslationGreek.Contains(letter) Then
                Dim diphthong_index As Integer = digraphTranslationGreek.IndexOf(letter)
                newLetter = digraphTranslationLatin.Substring(diphthong_index * 2, 2)
            ElseIf digraphYpsilonGreek.Contains(letter) Then
                newLetter = digraphYpsilonLatin.Substring(digraphYpsilonGreek.IndexOf(letter), 1)
                If nextLetter = "υ" Or nextLetter = "ύ" Then
                    If digraphYpsilonBeta.Contains(thirdLetter) Then
                        newLetter += "v"
                        cursor += 1
                    ElseIf digraphYpsilonPhi.Contains(thirdLetter) Then
                        newLetter += "f"
                        cursor += 1
                    End If
                End If
            ElseIf letter = "γ" Then
                If nextLetter = "γ" Then
                    newLetter = "ng"
                    cursor += 1
                ElseIf nextLetter = "ξ" Then
                    newLetter = "nx"
                    cursor += 1
                ElseIf nextLetter = "χ" Then
                    newLetter = "nch"
                    cursor += 1
                Else
                    newLetter = "g"
                End If
            ElseIf letter = "μ" Then
                If nextLetter = "π" Then
                    If previousLetter.Trim() = "" Or thirdLetter.Trim() = "" Then
                        newLetter = "b"
                        cursor += 1
                    Else
                        newLetter = "mp"
                        cursor += 1
                    End If

                Else
                    newLetter = "m"
                End If
            ElseIf letter = "ο" Then

                newLetter = "o"
                If nextLetter = "υ" Or nextLetter = "ύ" Then
                    newLetter += "u"
                    cursor += 1
                End If
            Else
                newLetter = letter
            End If

            If isUpper Then
                newLetter = newLetter.Substring(0, 1).ToUpper & _
                    If(isUpper2, newLetter.Substring(1).ToUpper, newLetter.Substring(1).ToLower())
            End If

            result.Append(newLetter)
            cursor += 1
        Loop
        Return result.ToString()
    End Function
End Module

