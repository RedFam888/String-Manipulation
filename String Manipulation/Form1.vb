Option Strict On
Option Infer Off
Option Explicit On
Imports System.Diagnostics.Eventing.Reader
Imports System.Net.Sockets
Imports System.Security.Cryptography
'Program: String Manipulation
'Purpose: Chapter 7 of Visual Basic Book
'Name:Mason Merritt
'Date: March 11th,2023
Public Class Form1

    'Declare class level Variable for Guess Letter Application

    Private randomLetter As String

    Private Sub btnF1Calc_Click(sender As Object, e As EventArgs) Handles btnF1Calc.Click

        'Length Property Practice F-1 Examples( Take in a User String, Trim and leading and trailing spaces by using the (.Trim method)
        'Then find how many "Characters" are within the String Array by using the (.Length method). Display Results

        Dim userInput As Double = txtF1String.Text.Trim.Length

        txtF1Results.Text = userInput.ToString
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'Build an App that will take in User Input for a Product ID. If the ID is not 5 Characters then display a message to user to 
        'enter the correct length, if it is correct add it to the listbox

        Dim userInput As String

        userInput = txtFiveCharacters.Text.ToUpper.Trim

        If userInput.Length = 5 Then
            lstFiveCharacters.Items.Add(userInput)
        Else
            MessageBox.Show("Please enter the correct length Product ID", "Incorrect Length", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnInsertMethod_Click(sender As Object, e As EventArgs) Handles btnInsertMethod.Click

        'F-2 Insert Method Practice-- Build an App that will take in a User's name and whether they are male or female. Based upon choice
        'Insert using the ( string.Insert(startIndex, value) syntax with Value being what you want inserted into the string
        'Mr. or Miss, If the female is married put Mrs.

        Dim userInput As String

        userInput = txtInsertMethod.Text.Trim

        If radMale.Checked Then
            userInput = userInput.Insert(0, "Mr. ")
            lstInsertNames.Items.Add(userInput)
        ElseIf radFemale.Checked AndAlso chkMarried.Checked Then
            userInput = userInput.Insert(0, "Mrs. ")
            lstInsertNames.Items.Add(userInput)
        ElseIf radFemale.Checked Then
            userInput = userInput.Insert(0, "Miss ")
            lstInsertNames.Items.Add(userInput)
        End If
    End Sub

    Private Sub btnDisplayPadding_Click(sender As Object, e As EventArgs) Handles btnDisplayPadding.Click

        'PadLeft and PadRight Practice Methods
        'Take in UserInput if is a Number Pad left with with asteriks and display in listbox allowing for 7 characters from a 3 digit number including the period and dollar sign
        'If is a name PadRight in textbox and by using a total of 25 chars for string length

        Dim userInput As String = txtPaddingPractice.Text

        If chkPadding.Checked And IsNumeric(userInput) Then
            Dim userNumber As Double
            Double.TryParse(userInput, userNumber)
            userInput = userNumber.ToString("C2").PadLeft(9, "*"c)
            lstPadLeft.Items.Add(userInput)
        Else
            userInput = userInput.PadRight(25)
            txtPadRight.Text = userInput
        End If
    End Sub

    Private Sub btnNetPayFormat_Click(sender As Object, e As EventArgs) Handles btnNetPayFormat.Click

        ''The Net Pay Application-- Take in a User's Net Pay. Fomrat into a Number with 2 Decimal Places. PadLeft 10 Charecters using Asteriks(*) and then add the Dollar Sign($) in the front

        'Variables

        Dim userPay As Double
        Dim formattedresults As String

        'TryParse to Input String to a Number

        Double.TryParse(txtUserNetPay.Text, userPay)

        'Format into results variable as a Number with 2 decimal places.

        formattedresults = userPay.ToString("N2")

        'Add PadLeft using 10Chars total filling with Asteriks(*)

        formattedresults = formattedresults.PadLeft(10, "*"c)

        'Add the Dollar Sign($) to thr Front of string

        formattedresults = formattedresults.Insert(0, "$")

        'Display Results in Textbox

        txtNetPayResults.Text = formattedresults
    End Sub

    Private Sub btnYCDOIT1_Click(sender As Object, e As EventArgs) Handles btnYCDOIT1.Click

        'You can Do it #1--Build A Program that will take in a User Input. If the User input is Numeric and betwee 2 - 7 characters then format it by making the 2nd char a # sign
        'then PadRight a Total of 10 Characters using Asteriks(*) as the fill string display results in the text label or display a message box for error

        'Variables

        Dim userInput As String = txtYCDOIT1.Text
        Dim formattedString As String

        If IsNumeric(userInput) And userInput.Length >= 2 And userInput.Length <= 7 Then
            formattedString = userInput.Insert(1, "#")
            formattedString = formattedString.PadRight(10, "*"c)
            txtYCDOIT1Results.Text = formattedString
        Else
            MessageBox.Show("Please Enter a Numeric Value using Digits", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub

    Private Sub btnConandIndexPractice_Click(sender As Object, e As EventArgs) Handles btnConandIndexPractice.Click

        'F-4 Contains and IndexOf Methods Practice-- Build a Program that Takes in a User's Name and determines if there is the Letter I in it.
        'If so display in a message box the results either yes or no then in the text box display the IndexOf the Space in the Name entered
        'the syntax for Contains is---- string.Contains(substring(what you're looking for))
        'syntax for IndexOf is----- string.IndexOf(substring, startindexLocation)

        Dim userName As String = txtContainsandIndexPractice.Text.ToUpper.Trim

        If userName.Contains("I") Then
            MessageBox.Show("Your name has the letter I in it", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Your name doesn't have the letter I in it", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Dim nameIndex As Integer = userName.IndexOf(" ")

        txtContainsandIndexResults.Text = "The location of the space between your first and last name is in the number " & nameIndex.ToString & " index location."
    End Sub

    Private Sub btnCityState_Click(sender As Object, e As EventArgs) Handles btnCityState.Click

        'City and State Application-- Allow a User to enter their City ans State Name then find the Index Of the Space in the Name

        Dim userInput As String = txtCityStateName.Text.ToUpper.Trim
        Dim inputIndex As Integer = userInput.IndexOf(" ")
        userInput = userInput.Insert(inputIndex, ","c)

        If inputIndex <> -1 Then
            txtCityStateResults.Text = "The index of the space is at the " & inputIndex.ToString & " location " & userInput.ToString
        Else
            MessageBox.Show("There is no space. Please enter a space between the city and state name.")
        End If
    End Sub

    Private Sub btnDoIt2_Click(sender As Object, e As EventArgs) Handles btnDoIt2.Click

        'You Can Do it #2--Build a Programs that determines if there is a period int he string entered by the user. Display whether that is TRUE OR FALSE
        'then also display the INDEXOF the period if the string does contain one.

        Dim userInput As String = txtDoIt2.Text.Trim

        If userInput.Contains("."c) Then
            Dim inputIndex As Integer = userInput.IndexOf("."c)
            txtDoIt2Results.Text = "True" & vbCrLf & "The index of the (.) is at the " & inputIndex.ToString & " location."
        Else
            MessageBox.Show("There is no period in your string", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub

    Private Sub btnSwapName_Click(sender As Object, e As EventArgs) Handles btnSwapName.Click

        'Rearrange Name Application-- Build an App that take sin a User's Name. Find the index of the space between first and last name
        'Using the SubString method -- string.SubString(start Index, number of Characters to access)
        'Swap the Last Name and First Name Positions and Display in txtResults

        Dim userName As String = txtSwapName.Text.Trim
        Dim nameIndex As Integer = userName.IndexOf(" ")
        Dim firstName As String = ""
        Dim lastName As String = ""

        If nameIndex <> -1 Then
            firstName = userName.Substring(0, nameIndex)
            lastName = userName.Substring(nameIndex + 1)
            userName = lastName & ", " & firstName
            txtSwapNameResults.Text = userName
        Else
            MessageBox.Show("There was no space found in your name", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnFirstName_Click(sender As Object, e As EventArgs) Handles btnFirstName.Click

        'First Name Application-- A string is nothing more than a "CHARACTER ARRAY" This means if I have a Variable STRNAME = JULIA. Really in the computer 
        'the charaters are stored with a substring value on the charater array. making the variable look like this when broken down into the primitive
        'character array-- strName(0) = "J", strName(1) = "U" ,  strName(2) = "L",  strName(3) = "I", and lastly  strName(4) = "A" alternatively you could write
        'the variables like this and return the same value---  strName.Substring(0, 1) = "J",  strName(1, 1) = "U",  strName(2, 1) = "L",  strName(3, 1) = "I",  strName(4, 1) = "A"

        'In this program take in a User's Name through a string then display the Individual Characters of the Array in the listbox 1 by 1

        Dim userName As String = txtFirstName.Text.Trim
        Dim nameIndex As Integer

        While nameIndex <= userName.Length - 1
            lstFirstName.Items.Add(userName(nameIndex))
            nameIndex += 1
        End While
    End Sub

    Private Sub btnYouCan3_Click(sender As Object, e As EventArgs) Handles btnYouCan3.Click

        'You Can Do It #3-- Build an App that creates the alphabet in a variable then only display the letters O, P , Q, R, S in the text box.
        'Use the SubString Method-- string.SubString(start Index, Number of characters to Access)

        Dim alphabet As String = "A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z"

        alphabet = alphabet.Substring(42, 15)

        txtYouCan3Results.Text = alphabet
    End Sub

    Private Sub btnCanDo4Event1_Click(sender As Object, e As EventArgs) Handles btnCanDo4Event1.Click

        'You Can Do It #4--Build an App that has a String Variable set to the letter A-J the first 10 letters of the Aplhabet. Event 1 will Display the 5th
        'Letter "E" using the proper substring from the Character Array and Event 2 will use a loop to display the letter C D E F using the appropriate indexes

        Dim alphabet As String = "A, B, C, D, E, F, G, H, I, J"

        txtCanDo4.Text = alphabet(12).ToString
    End Sub

    Private Sub btnCanDoEvent2_Click(sender As Object, e As EventArgs) Handles btnCanDoEvent2.Click

        'You Can Do It #4--Build an App that has a String Variable set to the letter A-J the first 10 letters of the Aplhabet. Event 1 will Display the 5th
        'Letter "E" using the proper substring from the Character Array and Event 2 will use a loop to display the letter C D E F using the appropriate indexes

        Dim alphabet As String = "A, B, C, D, E, F, G, H, I, J"
        Dim alphaIndex As Integer = 6
        Dim results As String = ""

        While alphaIndex <= 15
            results += alphabet(alphaIndex)
            txtCanDo4.Text = results
            alphaIndex += 1
        End While
    End Sub

    Private Sub btnInteger_Click(sender As Object, e As EventArgs) Handles btnInteger.Click

        'Program I saw needed help on Reddit== Take in a UserNumber then print the corresponding number of # in the results label.

        Dim userNumber As Integer
        Dim count As Integer = 1
        'Dim results As String = ""
        Integer.TryParse(txtInteger.Text, userNumber)
        While count <= userNumber
            'results = results & "#"
            txtIntegerResults.Text += "#"
            count += 1
        End While
    End Sub

    Private Sub btnRemoveOne_Click(sender As Object, e As EventArgs) Handles btnRemoveOne.Click

        'Build a Procedure that removes the first 9 characters of A string Inputted

        Dim userInput As String = txtRemoveMethodInput.Text

        userInput = userInput.Remove(0, 9)

        txtRemoveMethodResults.Text = userInput
    End Sub

    Private Sub btnRemoveTwo_Click(sender As Object, e As EventArgs) Handles btnRemoveTwo.Click

        'Build a Procedure that removes the characters starting at index 7 of A string inputted

        Dim userInput As String = txtRemoveMethodInput.Text

        userInput = userInput.Remove(7)

        txtRemoveMethodResults.Text = userInput
    End Sub

    Private Sub btnRemoveThree_Click(sender As Object, e As EventArgs) Handles btnRemoveThree.Click

        'Build a Procedure that removes the 2nd index character from a string inputted

        Dim userInput As String = txtRemoveMethodInput.Text

        userInput = userInput.Remove(2, 1)

        txtRemoveMethodResults.Text = userInput
    End Sub

    Private Sub btnTrim_Click(sender As Object, e As EventArgs) Handles btnTrim.Click

        'Build A Procedure that Trims any spaces in the Input

        Dim userInput As String = txtTrimInput.Text.Trim

        txtTrimResults.Text = userInput
    End Sub

    Private Sub btnTrimStart_Click(sender As Object, e As EventArgs) Handles btnTrimStart.Click

        'Build A Procedure that Trims the $$$ and Space from the beginning of Input

        Dim userInput As String = txtTrimInput.Text.TrimStart("$"c, " "c)

        txtTrimResults.Text = userInput
    End Sub

    Private Sub btnTrimEnd_Click(sender As Object, e As EventArgs) Handles btnTrimEnd.Click

        'Build A Procedure that Trims the % sign from the end of Input

        Dim userInput As String = txtTrimInput.Text.TrimEnd("%"c)

        txtTrimResults.Text = userInput
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Load percents into Tax Calculator App

        Dim percents As Double = 0.02

        While percents <= 0.07
            lstTaxCalculator.Items.Add(percents.ToString("P0"))
            percents += 0.01
        End While

        'Add the Shipping Choices into List Box for Excercise 10

        lstExcercise10.Items.Add("Mail-Standard")
        lstExcercise10.Items.Add("Mail-Priority")
        lstExcercise10.Items.Add("FedEx-Standard")
        lstExcercise10.Items.Add("FedEx-Overnight")
        lstExcercise10.Items.Add("UPS")
    End Sub

    Private Sub btnTaxApp_Click(sender As Object, e As EventArgs) Handles btnTaxApp.Click

        'Build an App that Will display the Amount of Sales Tax the sale will incur based upon the rate selected

        Dim sales As Double
        Dim rate As Double
        Dim taxTotal As Double

        Double.TryParse(txtTaxApp.Text, sales)
        Double.TryParse(lstTaxCalculator.SelectedItem.ToString.TrimEnd("%"c), rate)
        rate /= 100

        taxTotal = sales * rate

        txtTaxAppResults.Text = taxTotal.ToString("C2")
    End Sub

    Private Sub btnReplace1_Click(sender As Object, e As EventArgs) Handles btnReplace1.Click

        'Build a Procedure that Replaces any # 2 with the string two

        Dim userInput As String = txtReplaceInput.Text.Replace("2", "Two")

        txtReplaceResults.Text = userInput
    End Sub

    Private Sub btnReplace2_Click(sender As Object, e As EventArgs) Handles btnReplace2.Click


        'Build a Procedure that Replaces any (-) with the nothing.Essentially removing dashes from the string

        Dim userInput As String = txtReplaceInput.Text.Replace("-", "")

        txtReplaceResults.Text = userInput
    End Sub

    Private Sub btnLike1_Click(sender As Object, e As EventArgs) Handles btnLike1.Click

        'Build  a Procedure that compares the Input to be Like---- B?LL-- The ? mark represents any single Charcter even a space

        Dim userInput As String = txtLikeInput.Text.ToUpper.Trim

        If userInput Like "B?LL" Then
            MessageBox.Show("Your Input matches", "Input Match")
        Else
            MessageBox.Show("Your input did not match the Operator (B?LL with the ? being any single character input)")
        End If
    End Sub

    Private Sub btnLike2_Click(sender As Object, e As EventArgs) Handles btnLike2.Click

        'Build  a Procedure that compares the Input to be Like----(K*) with the asterik representing from zero to any number of following characters
        'The statement will compare true as long as there is an UPPERCASE K in the beginning.

        Dim userInput As String = txtLikeInput.Text.ToUpper.Trim

        If userInput Like "K*" Then
            MessageBox.Show("Your Input matches", "Input Match")
        Else
            MessageBox.Show("Your input did not match the Operator (K*) with the * being any number of following character inputs")
        End If
    End Sub

    Private Sub btnLike3_Click(sender As Object, e As EventArgs) Handles btnLike3.Click

        'Build  a Procedure that compares the Input to be Like----  "###*"-- this means the statement will evaulate true as long as it starts with 3 digits
        'followed by any number of single characters between 0 - infinite

        Dim userInput As String = txtLikeInput.Text.Trim.ToUpper


        While userInput Like "###*"
            Dim x As Integer
            x = MessageBox.Show("Your input matches", "Input Match", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If x = vbYes Then
                Exit While
            End If
        End While
    End Sub

    Private Sub btnLike4_Click(sender As Object, e As EventArgs) Handles btnLike4.Click

        'Build  a Procedure that compares the Input to be Like---- T[OI]M--- this means the statement will only evaluate true for TOM or TIM
        'the [OI] is a character list and has to be there to evaluate true.

        Dim userINput As String = txtLikeInput.Text.Trim.ToUpper

        If userINput Like "T[OI]M" Then
            MessageBox.Show("Your Input matches", "Input Match")
        Else
            MessageBox.Show("Your input did not match the Operator (T[OI]M) with the [OI] being a character list of characters to search for and compare to")
        End If
    End Sub

    Private Sub btnLike5_Click(sender As Object, e As EventArgs) Handles btnLike5.Click

        'Build  a Procedure that compares the Input to be Like---- [a-z]--- this means the statement will evaluate true to 
        'the string is just ONE single lowercase letter otherwise false.

        Dim userInput As String = txtLikeInput.Text.ToLower.Trim

        If userInput Like "[a-z]" Then
            MessageBox.Show("Your Input matches", "Input Match")
        Else
            MessageBox.Show("Your input did not match the Operator ([a-z]) with the [a-z] being a single lowercase letter.")
        End If
    End Sub

    Private Sub btnLike6_Click(sender As Object, e As EventArgs) Handles btnLike6.Click

        'Build  a Procedure that compares the Input to see if it is a letter. If it is not a letter than add 1 to a counter and display results
        'make a not character list use an Exclamiation! ----- [!A-Z]-- this means the statement qill return true if the character found is
        'NOT an UPPERCASE letter

        Dim userInput As String = txtLikeInput.Text.Trim.ToUpper
        Dim inputIndex As Integer
        Dim nonLetterCount As Integer

        While inputIndex <= userInput.Length - 1
            Dim inputChar As String = userInput(inputIndex).ToString.ToUpper
            If inputChar Like "[!A-Z]" Then
                nonLetterCount += 1
            End If
            inputIndex += 1
        End While

        MessageBox.Show("The input is " & userInput & vbCrLf & "There are " & nonLetterCount.ToString & " characters that aren't letters in your input")
    End Sub

    Private Sub btnLike7_Click(sender As Object, e As EventArgs) Handles btnLike7.Click

        'Build  a Procedure that compares the Input to be Like---- (*.*)-- this means the condition will evaluate true as long as there is a period somewhere in the string
        'the * asteriks represents any # of characters from 0 to infinite before and after.

        Dim userInput As String = txtLikeInput.Text.Trim.ToUpper

        If userInput Like "*.*" Then
            MessageBox.Show("Your Input matches", "Input Match")
        Else
            MessageBox.Show("Your input did not match the Operator (*.*) with the asteriks * representing any number of characters 0- infinite.")
        End If
    End Sub

    Private Sub btnLike8_Click(sender As Object, e As EventArgs) Handles btnLike8.Click

        'Build  a Procedure that compares the Input to be Like---- "[A-Z][A-Z]##"-- this will evaluate to true when the input is equal to two Uppercase Letters and two Numbers

        Dim userInput As String = txtLikeInput.Text.Trim.ToUpper

        If userInput Like "[A-Z][A-Z]##" Then
            MessageBox.Show("Your Input matches", "Input Match")
        Else
            MessageBox.Show("Your input did not match the Operator ([A-Z][A-Z]##) meaning two uppercase letters and two digits")
        End If
    End Sub

    Private Sub btnInventoryApp_Click(sender As Object, e As EventArgs) Handles btnInventoryApp.Click

        'Build an App that takes in a User Input  and compares it to the ID Checker of-- "[A-Z][A-Z][A-Z]##"-- 
        'which means 3 Uppercase Letters and 2 Digits.

        Dim userInput As String = txtInventoryApp.Text.Trim.ToUpper

        If userInput Like "[A-Z][A-Z][A-Z]##" Then
            lstInventoryapp.Items.Add(userInput)
        Else
            MessageBox.Show("Your input did not match the Operator ([A-Z][A-Z][A-Z]##) meaning three uppercase letters and two digits")
        End If
    End Sub

    Private Sub btnDoIt5_Click(sender As Object, e As EventArgs) Handles btnDoIt5.Click

        'Build an App that takes in a UserInput and compares it to the operator-- "##*"-- Meaning 2 digits then any number of Characters from 0 to infinite

        Dim userInput As String = txtDoIt5.Text.Trim.ToUpper

        If userInput Like "##*" Then
            txtDoIt5Results.Text = "Your Input matches"
        Else
            txtDoIt5Results.Text = "Input doesn't match '##*' which means 2 digits followed by any number of characters 0 to infinite."
        End If
    End Sub

    Private Sub btnCheckDigit_Click(sender As Object, e As EventArgs) Handles btnCheckDigit.Click

        'Build a Check Digit Program-- Algorithm--
        'Step 1--Starting with the 2nd digit multiply every other digit by 3 and then add the sums together.(#2, #4, #6, #8, #10, #12)
        'Step 2-- Each digit skipped in Step 1(#1, #3, #5, #7, #9, #11) will be added together
        'Step 3-- Add the sums from Step 1 and Step 2 together
        'Step 4-- Divide the Sum from Step 3 by 10 and find the Remainder
        'Step 5-- If remainder = 0 then Check Digit equals 0 --else-- subtract the remainder from 10 and the result is the check digit.

        'Variables

        Dim userInput As String = txtCheckDigit.Text.Trim.ToUpper
        Dim userIndexOdd As Integer = 1
        Dim userIndexEven As Integer = 0
        Dim userCharOdd As String
        Dim userCharEven As String
        Dim userNumberStep1 As Double
        Dim userNumberStep2 As Double
        Dim step1Results As Double
        Dim step2Results As Double
        Dim step3Results As Double
        Dim step4Results As Double
        Dim checkDigit As Double

        'Step 1 Procedure

        If userInput.Length = 12 Then
            While userIndexOdd <= userInput.Length - 1
                userCharOdd = userInput(userIndexOdd)
                Double.TryParse(userCharOdd, userNumberStep1)
                step1Results += userNumberStep1 * 3
                userIndexOdd += 2
            End While
        Else
            MessageBox.Show("ISBN Number not the Correct Length", "Length Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        'Step 2 Procedures

        While userIndexEven <= userInput.Length - 1
            userCharEven = userInput(userIndexEven)
            Double.TryParse(userCharEven, userNumberStep2)
            step2Results += userNumberStep2
            userIndexEven += 2
        End While

        'Step 3 Procedures

        step3Results = step1Results + step2Results

        'Step 4 Procedure

        step4Results = step3Results Mod 10

        'Step 5 Procedure

        If step4Results <> 0 Then
            checkDigit = 10 - step4Results
        End If

        'Final Display of results

        userInput = userInput.Insert(12, checkDigit.ToString)

        txtCheckDigitResults.Text = userInput
    End Sub

    Private Sub btnPasswordApp_Click(sender As Object, e As EventArgs) Handles btnPasswordApp.Click

        'Build a Program that takes in a User Input and creates a password out of the 1st letter from each word and Based upon how many words are in the input
        'assign the second Character of the Password as the integer representing the number of words. so if the input is ---
        ' May the Force Be With You" the password would be--
        ' M6TFBWY

        'Variables

        Dim userInput As String = txtPasswordApp.Text.Trim.ToUpper
        Dim userIndex As Integer = userInput.IndexOf(" ")
        Dim password As String = userInput(0)

        'Procedure

        If userInput <> String.Empty Then

            While userIndex <> -1
                password = password & userInput(userIndex + 1)
                userIndex = userInput.IndexOf(" ", userIndex + 1)
            End While

            password = password.Insert(1, password.Length.ToString)

            txtPasswordResults.Text = password

        End If
    End Sub

    Private Sub btnRandom1_Click(sender As Object, e As EventArgs) Handles btnRandom1.Click

        'Random Number Generation Practice Syntax----
        'Dim randomObject as New Random
        'randomObject.Next(minValue, maxValue)
        'Example 1

        Dim randGen As New Random
        Dim number As Integer

        number = randGen.Next(1, 51)

        txtRandomPracticeResults.Text = number.ToString

        'This will display a RANDOM INTEGER from (1 - 50) --- See how the number 51 is entered in the max value location but the number 50 is assigned max value.
    End Sub

    Private Sub btnRandom2_Click(sender As Object, e As EventArgs) Handles btnRandom2.Click

        'Random Number Generation Practice Syntax----
        'Dim randomObject as New Random
        'randomObject.Next(minValue, maxValue)
        'Example 2

        Dim randGen As New Random
        Dim number As Integer

        number = randGen.Next(-10, 20)

        txtRandomPracticeResults.Text = number.ToString

        'This will display a RANDOM INTEGER from (-10 - 19) --- See how the number 20 is entered in the max value location but the number 19 is assigned max value.
    End Sub

    Private Sub btnGuessLetterNewGame_Click(sender As Object, e As EventArgs) Handles btnGuessLetterNewGame.Click

        'A-4 Apply The Concepts Lesson--Guess Letter Application
        'In this Application allow the user to enter a Letter and if the Letter matches the Letter Randomly assigned at the beginning of Game then message box to user
        'they won the game and the New game button will start the game over.

        'Delcare Alphabet constant [A-Z]
        'declare random generator and number to assign it to
        'using random number generated select a letter from Alphabet Constant and assign it to the Constant randomLetter
        'Prepare the game by clearing guesses, any guess agin text, re-enabling the check guess button and focus check guess

        'Declares a Constant Variable
        Const ALPHABET As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

        'Generates a Random Number between 0 which is the starting index of  the string array "ALPHABET" : to 25 which is the end of the index of the String Array "ALPHABET"
        Dim randGen As New Random
        Dim letterNumber As Integer = randGen.Next(0, 26)

        'Assigns the variable randomLetter as a String equal to the Letter found at the Index location of the random number generated
        randomLetter = ALPHABET(letterNumber)

        'Clears Labels and TextBoxes

        lblGuessLetterAgain.Text = ""
        txtGuessLetter.Text = ""
        txtGuessedLetters.Text = ""

        'Adds focus to txtGuessLetter Input and Enables user to Check Guess

        txtGuessLetter.Focus()
        btnGuesLetterGuess.Enabled = True
        btnGuessLetterNewGame.Enabled = False

    End Sub

    Private Sub btnGuesLetterGuess_Click(sender As Object, e As EventArgs) Handles btnGuesLetterGuess.Click

        'A-4 Apply The Concepts Lesson--Guess Letter Application
        'In this Application allow the user to enter a Letter and if the Letter matches the Letter Randomly assigned at the beginning of Game then message box to user
        'they won the game and the New game button will start the game over.

        'Declare userInput variable for Guess and assign it to the textInput trimmed and UpperCase
        'Add Guess to previous guesses
        'If userLetter equals randomLetter then message box "You Won!" and disable check guess button else display in guess again label to "Guess Again!"
        'Clear txtInput and focus txtInput

        'Vaiable for UserInput

        Dim userLetter As String = txtGuessLetter.Text.Trim.ToUpper

        'Procedure to Check userInput to Random Letter

        If userLetter = randomLetter Then
            MessageBox.Show("You Won the correct letter was " & randomLetter, "WINNER!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnGuesLetterGuess.Enabled = False
            btnGuessLetterNewGame.Enabled = True
        Else
            txtGuessedLetters.Text += userLetter
            lblGuessLetterAgain.Text = "Guess Again!"
        End If

        'Clear UnserInput textbox

        txtGuessLetter.Text = ""
    End Sub

    Private Sub btnNewWordApp_Click(sender As Object, e As EventArgs) Handles btnNewWordApp.Click

        'In this game there will be 2 players-- Player 1 Will enter a a 5 letter word into the new word textbox. The input will be masked so that Player 2 can not see the word
        'the results label will contain 5 Hyphens in lieu of the words letters. PLayer 2 will enter a guess if the NewWord contains the letter guessed by Player 2 the Hyphen will be replaced
        'with the letter.

        'New Word Pseudocode - if word contains 5 letters then groupbox new word disabled enable groupbox letter display 5 hyphens in result label focus txtletter.
        'else display enter 5 letters message

        If txtNewWord.Text.Trim.ToUpper Like "[A-Z][A-Z][A-Z][A-Z][A-Z]" Then
            grpUserGuess.Enabled = True
            grpNewWord.Enabled = False
            txtGuessWordResults.Text = "-----"
            txtTryLetter.Focus()
        Else
            MessageBox.Show("Please enter a word with 5 Letters", "Incorrect Word Length", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnTryLetter_Click(sender As Object, e As EventArgs) Handles btnTryLetter.Click

        'In this game there will be 2 players-- Player 1 Will enter a a 5 letter word into the new word textbox. The input will be masked so that Player 2 can not see the word
        'the results label will contain 5 Hyphens in lieu of the words letters. PLayer 2 will enter a guess if the NewWord contains the letter guessed by Player 2 the Hyphen will be replaced
        'with the letter.

        'Declaring Variables

        Dim word As String = txtNewWord.Text.Trim.ToUpper
        Dim wordIndex As Integer = 0
        Dim userLetter As String = txtTryLetter.Text.Trim.ToUpper

        'Setting the results back to the output from the loop 
        Dim results As String = txtGuessWordResults.Text

        'Procedure to test for User Guess

        'if guess letter is in the word then
        If word.Contains(userLetter) Then

            'Traverse the string array of the word
            While wordIndex <= word.Length - 1
                'If the letter found at the index of the sring array matches the user guess then
                If word(wordIndex) = userLetter Then
                    'remove the character at this index
                    results = results.Remove(wordIndex, 1)
                    'Insert the user guess letter into the place where removed
                    results = results.Insert(wordIndex, userLetter)
                End If
                'check the next index
                wordIndex += 1
            End While
        End If

        'Output results to txtlabel to reassign the results string with the replaced information
        txtGuessWordResults.Text = results

        'check for winner
        If results.Contains("-"c) = False Then
            MessageBox.Show("You guessed it the word was " & word)
            grpNewWord.Enabled = True
            grpUserGuess.Enabled = False
            txtGuessWordResults.Text = ""
            txtNewWord.Focus()
        Else
            txtTryLetter.Text = ""
        End If
    End Sub

    Private Sub btnExcercise5_Click(sender As Object, e As EventArgs) Handles btnExcercise5.Click

        'Build a Program that will take in a user input and compare to an operator of having 5 Characters with the 3rd character indicating color:
        'the colors are RED GREEN BLUE and WHITE and will be chosen using the Upper and Lower case letter of the first letter in each word: Rr, Ww, Gg, Bb
        'the procedure should display an error if the ID isn't 5 characters long or if the 3rd character doesn't match the operators set.

        'Variables

        Dim userInput As String = txtExcercise5Input.Text.ToUpper.Trim

        'Procedure will test if input is at least 5 characters including spaces
        If userInput Like "?????" Then
            'Procedure will test the substring at index 2 location if one of the operators then display proper color else error
            If userInput(2) Like "[R,r]" Then
                userInput = "Red"
                txtExcercise5Results.Text = userInput
            ElseIf userInput(2) Like "[G,g]" Then
                userInput = "Green"
                txtExcercise5Results.Text = userInput
            ElseIf userInput(2) Like "[B,b]" Then
                userInput = "Blue"
                txtExcercise5Results.Text = userInput
            ElseIf userInput(2) Like "[W,w]" Then
                userInput = "White"
                txtExcercise5Results.Text = userInput
            Else
                MessageBox.Show("The 3rd Character doesn't indicate a color of Red Green Blue or White using the first letter of the word as the key")
            End If
        Else
            MessageBox.Show("The input is not 5 Characters long")
        End If
    End Sub

    Private Sub btnDigit2_Click(sender As Object, e As EventArgs) Handles btnDigit2.Click

        'Excercise 1-Check Digit Application
        'Modifications- User will be allowed to Enter Hyphens in the textbox ISBN number.
        'Whether or not the user enters the hyphens the Input should still be formatted to display this way to the user 978-1-337-10212-4

        'Build a Check Digit Program-- Algorithm--
        'Step 1--Starting with the 2nd digit multiply every other digit by 3 and then add the sums together.(#2, #4, #6, #8, #10, #12)
        'Step 2-- Each digit skipped in Step 1(#1, #3, #5, #7, #9, #11) will be added together
        'Step 3-- Add the sums from Step 1 and Step 2 together
        'Step 4-- Divide the Sum from Step 3 by 10 and keep the Remainder
        'Step 5-- If remainder = 0 then Check Digit equals 0 --else-- subtract the remainder from 10 and the result is the check digit.

        'Variables

        'takes input from textbox and assigns it to the userInput variable
        Dim userInput As String = txtDigitInput2.Text

        'assigns a variable to traverse the string array but only looking at the odd numbers
        Dim userIndexOdd As Integer = 1

        'assigns a variable to traverse the string array but only looking at the even numbers
        Dim userIndexEven As Integer = 0

        'assigns a variable to house the try parse from string to number in step 1
        Dim userNumberStep1 As Double

        'assigns a variable to house the try parse from string to number in step 2
        Dim userNumberStep2 As Double

        'assigns a variable to house results to calculation from step 1 in the algorithm which is to multiple each digit by 3
        Dim step1Results As Double

        'assigns a variable to house results to calculation from step 2 in the algorithm which is to add all the numbers together
        Dim step2Results As Double

        'assigns a final value which will be the check digit value
        Dim total As Double

        'Step 1 Procedure

        'this will check to see if the input is 12-16 characters including allowable hyphens
        If userInput.Length >= 12 And userInput.Length <= 16 Then
            'remove any hyphens if present
            userInput = userInput.Replace("-", "")
            'while the userIndexOdd which is set to 1 already, is equal to the length minus 1 because the index is a number first set to 0 and the length a value first set to 1 and we are looking at the array by index then do something
            While userIndexOdd <= userInput.Length - 1
                'this will take the value found in the string array "userInput" at the substring value of userIndexOdd and tryparse it from string datatype to double datatype in the variable userNumberStep1
                Double.TryParse(userInput(userIndexOdd), userNumberStep1)
                'the variable step1Results will keep a sum total of the value found at each iteration of the loop where the variable userNumberStep1 will multiply by 3
                step1Results += userNumberStep1 * 3
                'the loop count which is the next value of the substring in the "userInput" string array while add 2 and continue to do so until the end of length - 1 which equals end of the string array index
                userIndexOdd += 2
            End While
        Else
            'if the userInput does not equal 12 - 16 characters error message will show
            MessageBox.Show("ISBN Number not the Correct Length", "Length Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        'Step 2 Procedures
        'while the variable "userIndexEven" which is set to 0 already, is equal to the length minus 1 because the index is a number first set to 0 and the length a value first set to 1 and we are looking at the array by index do something
        While userIndexEven <= userInput.Length - 1
            'this will take the value found in the string array "userInput" at the substring value of "userIndexOdd" and tryparse it from string datatype to double datatype into the variable "userNumberStep2"
            Double.TryParse(userInput(userIndexEven), userNumberStep2)
            'the variable "step2Results" will keep a sum total of the value found at each iteration of the loop where the variable "userNumberStep2" is assigned the value from the index location of "userInput(userIndexEven)"
            step2Results += userNumberStep2
            'the loop count which is the next value of the substring in the "userInput" string array while add 2 and continue to do so until the end of length - 1 which equals end of the string array index
            userIndexEven += 2
        End While

        'Step 3 Procedures

        'the variable "total" will house the summation of the variables "step1Results" and "Step2Results"
        total = step1Results + step2Results

        'Step 4 Procedure

        'the variable "total" will be divided by 10 and keep the remainder value assigning it back to the variable "total"
        total = total Mod 10

        'Step 5 Procedure

        'if the variable "total" does not equal 0 then  if it does equal 0 then the variable "total" will equal 0
        If total <> 0 Then
            'total will equal 10 minus the value of the variable "total"
            total = 10 - total
        Else
            'if the variable "total" does equal 0 then the variable "total" will equal 0
            total = 0
        End If

        'Final Display of results

        'Take the variable "userInput" and insert a Hyphen at index loaction 3
        userInput = userInput.Insert(3, "-"c)

        'Take the variable "userInput" and insert a Hyphen at index loaction 5
        userInput = userInput.Insert(5, "-"c)

        'Take the variable "userInput" and insert a Hyphen at index loaction 9
        userInput = userInput.Insert(9, "-"c)

        'Take the variable "userInput" and insert a Hyphen at index loaction 15
        userInput = userInput.Insert(15, "-"c)

        'Take the variable "userInput" and insert a Hyphen at index loaction 16
        userInput = userInput.Insert(16, total.ToString)

        'Display the variable "userInput" in the textbox txtDigit2Results.text
        txtDigit2Results.Text = userInput
    End Sub

    Private Sub btnExcercise3_Click(sender As Object, e As EventArgs) Handles btnExcercise3.Click
        'Excercise 3--Check Digit Application
        'Modifications- User will be allowed to Enter a 13 digit ISBN number.
        'the Iput will check the last digit of the ISBN input and compre it to the total found from the algroithm



        'Build a Check Digit Program-- Algorithm--
        'Step 1--Starting with the 2nd digit multiply every other digit by 3 and then add the sums together.(#2, #4, #6, #8, #10, #12)
        'Step 2-- Each digit skipped in Step 1(#1, #3, #5, #7, #9, #11) will be added together
        'Step 3-- Add the sums from Step 1 and Step 2 together
        'Step 4-- Divide the Sum from Step 3 by 10 and keep the Remainder
        'Step 5-- If remainder = 0 then Check Digit equals 0 --else-- subtract the remainder from 10 and the result is the check digit.

        'Variables

        'takes input from textbox and assigns it to the userInput variable
        Dim userInput As String = txtExcercise3Input.Text

        'assigns a variable to traverse the string array but only looking at the odd numbers
        Dim userIndexOdd As Integer = 1

        'assigns a variable to traverse the string array but only looking at the even numbers
        Dim userIndexEven As Integer = 0

        'assigns a variable to house the try parse from string to number in step 1
        Dim userNumberStep1 As Double

        'assigns a variable to house the try parse from string to number in step 2
        Dim userNumberStep2 As Double

        'assigns a variable to house results to calculation from step 1 in the algorithm which is to multiple each digit by 3
        Dim step1Results As Double

        'assigns a variable to house results to calculation from step 2 in the algorithm which is to add all the numbers together
        Dim step2Results As Double

        'assigns a final value which will be the check digit value
        Dim total As Double

        'Step 1 Procedure

        'this will check to see if the input is 13 characters long
        If userInput.Length = 13 Then
            'remove last digit
            userInput = userInput.Remove(12, 1)
            'while the userIndexOdd which is set to 1 already, is equal to the length minus 1 because the index is a number first set to 0 and the length a value first set to 1 and we are looking at the array by index then do something
            While userIndexOdd <= userInput.Length - 1
                'this will take the value found in the string array "userInput" at the substring value of userIndexOdd and tryparse it from string datatype to double datatype in the variable userNumberStep1
                Double.TryParse(userInput(userIndexOdd), userNumberStep1)
                'the variable step1Results will keep a sum total of the value found at each iteration of the loop where the variable userNumberStep1 will multiply by 3
                step1Results += userNumberStep1 * 3
                'the loop count which is the next value of the substring in the "userInput" string array while add 2 and continue to do so until the end of length - 1 which equals end of the string array index
                userIndexOdd += 2
            End While
        Else
            'if the userInput does not equal 13 characters error message will show
            MessageBox.Show("ISBN Number not the Correct Length", "Length Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        'Step 2 Procedures
        'while the variable "userIndexEven" which is set to 0 already, is equal to the length minus 1 because the index is a number first set to 0 and the length a value first set to 1 and we are looking at the array by index do something
        While userIndexEven <= userInput.Length - 1
            'this will take the value found in the string array "userInput" at the substring value of "userIndexOdd" and tryparse it from string datatype to double datatype into the variable "userNumberStep2"
            Double.TryParse(userInput(userIndexEven), userNumberStep2)
            'the variable "step2Results" will keep a sum total of the value found at each iteration of the loop where the variable "userNumberStep2" is assigned the value from the index location of "userInput(userIndexEven)"
            step2Results += userNumberStep2
            'the loop count which is the next value of the substring in the "userInput" string array while add 2 and continue to do so until the end of length - 1 which equals end of the string array index
            userIndexEven += 2
        End While

        'Step 3 Procedures

        'the variable "total" will house the summation of the variables "step1Results" and "Step2Results"
        total = step1Results + step2Results

        'Step 4 Procedure

        'the variable "total" will be divided by 10 and keep the remainder value assigning it back to the variable "total"
        total = total Mod 10

        'Step 5 Procedure

        'if the variable "total" does not equal 0 then  if it does equal 0 then the variable "total" will equal 0
        If total <> 0 Then
            'total will equal 10 minus the value of the variable "total"
            total = 10 - total
        Else
            'if the variable "total" does equal 0 then the variable "total" will equal 0
            total = 0
        End If

        'Return value of textbox to variable "userInput"
        userInput = txtExcercise3Input.Text

        'Compare string value of total to string value of userinput and display valid or inavlid
        If total.ToString = userInput(12) Then
            txtExcercise3Results.Text = "Valid"
        Else
            txtExcercise3Results.Text = "Invalid"
        End If
    End Sub

    Private Sub btnExcercise2_Click(sender As Object, e As EventArgs) Handles btnExcercise2.Click

        'Excercise 2 ---MODIFICATIONS to PASSWORD APPLICATION
        'Build a Program that takes in a User Input and creates a password out of the 1st letter from each word and Based upon how many words are in the input
        'assign the second Character to be a Zero(0) followed by an integer representing the number of words the user entered. so if the input is ---
        ' May the Force Be With You" the password would be--
        ' M06TFBWY

        'Variables

        'takes text from TextBox and assign it the the variable "userInput" as a string trimmed and uppercase
        Dim userInput As String = txtExcercise2Input.Text.Trim.ToUpper

        'assigns the variable "userindex" as an integer = to the index of SPACES(" ") found so while traversing the string array variable "userInput" we can locate the where th 1st space is since
        'the method (.IndexOf) returns the number of the index where whatever searching for is found in this case the SPACES.
        Dim userIndex As Integer = userInput.IndexOf(" ")

        'Sets our password variable to the 1st character in the string array "userInput" since there will not be a space in front to search and assign in the loop
        Dim password As String = userInput(0)

        'Procedure

        'if the user enters information do something else error will show
        If userInput <> String.Empty Then

            'while  the variable "userIndex" <> -1 (which means not found) then we will do something
            While userIndex <> -1
                'assigns the variable "password" to what it was previously plus whatever character was found in the string array "UserInput" at substring(index) location PLUS 1 which means the character after the space we searched for.
                password = password & userInput(userIndex + 1)
                'assigns the variable "userIndex" back to the space in the UserInput but looks for the NEXT space by adding 1 to the  variable "userIndex". when no more spaces are found a -1 will return and the loop will exit
                userIndex = userInput.IndexOf(" ", userIndex + 1)
            End While

            'will assign the variable "password" to have the the length of the password in number for assigned to the index location of 1 the 2nd item
            password = password.Insert(1, password.Length.ToString)

            'will reassign the variable "password" to have the the character of ZERO(0)  assigned to the index location of 1 instead o fthe length which will now follow
            password = password.Insert(1, "0")

            'Display Password Results to user
            txtExcercise2Results.Text = password
        Else
            MessageBox.Show("Please enter a string of words to create a password", "How to create a password")
        End If
    End Sub

    Private Sub btnExcercise4_Click(sender As Object, e As EventArgs) Handles btnExcercise4.Click

        'Excercise 4--MODIFICATIONS to PASSWORD APPLICATION

        'Modify program where if the character found after a space is found the password assignment will only concatenate if the next index is not a space

        'Build a Program that takes in a User Input and creates a password out of the 1st letter from each word and Based upon how many words are in the input
        'assign the second Character of the Password as the integer representing the number of words. so if the input is ---
        ' May the Force Be With You" the password would be--
        ' M6TFBWY

        'Variables

        'Assigns the vaiable "userInput' with the value from textbox trimmed and uppercase
        Dim userInput As String = txtexcercise4Input.Text.Trim.ToUpper

        'Sets the variable "userIndex" to index value of the 1st space found in the string array "userInput"
        Dim userIndex As Integer = userInput.IndexOf(" ")

        'Sets the variable "password' to be equal to the character found at the substring value(index value), ZERO(0) of the string array "userInput"
        Dim password As String = userInput(0)

        'Procedure

        'code will execute if the string is not empty
        If userInput <> String.Empty Then

            'while the variable "userIndex" does not equal -1(meaning that while a space is found in the string array "userInput" then do something
            While userIndex <> -1
                'if the character found at the substring location of the string array "userInput(userIndex + 1){meaning the value AFTER finding the space} is anything but a space then execute password code line
                If userInput(userIndex + 1) Like "[! ]" Then
                    password = password & userInput(userIndex + 1)
                End If
                'reiterates the loop to looking for the next space until no more spaces are found making the variable "userIndex" = -1
                userIndex = userInput.IndexOf(" ", userIndex + 1)
            End While

            'Formats the password to insert the length as the 2nd character in the string
            password = password.Insert(1, password.Length.ToString)

            'displays the Password created to the user in the textbox.
            txtExcercise4results.Text = password
        End If
    End Sub

    Private Sub btnExcercise6_Click(sender As Object, e As EventArgs) Handles btnExcercise6.Click

        'Excercise 6--Build An App that will take in a User's name first and last. If there are spaces in the front and rear trim it. Also if there is more than one space between words remove them
        'Reformat the string so that the first letter of each name is captialized.

        Dim userInput As String = txtExcercise6Input.Text.Trim
        Dim spaceIndex As Integer = userInput.IndexOf(" ")
        Dim firstnameLetter As String = userInput(0).ToString.ToUpper
        Dim lastnameLetter As String = ""
        Dim firstName As String = ""
        Dim lastName As String = ""
        Dim formattedString As String = ""


        If userInput <> String.Empty Then

            While spaceIndex <> -1
                If userInput(spaceIndex + 1) Like "[! ]" Then
                    lastnameLetter = userInput(spaceIndex + 1).ToString.ToUpper
                    firstName = userInput.Substring(1, spaceIndex)
                    firstName = firstName.Replace(" ", "")
                    lastName = userInput.Substring(spaceIndex + 2)
                    lastName = lastName.Replace(" ", "")
                    formattedString = firstnameLetter & firstName & " " & lastnameLetter & lastName
                End If
                spaceIndex = userInput.IndexOf(" ", spaceIndex + 1)
            End While
        End If

        txtExcercise6Results.Text = formattedString
    End Sub

    Private Sub btnZipcode_Click(sender As Object, e As EventArgs) Handles btnZipcode.Click

        'Excercise 7--Build a program that takes in a User's Zipcode. To be valid the first 4 digits must be 4210
        'the last digit can be 2, 3, or 4. Valid and Invalid displays in results label.

        Dim userInput As String = txtZipCodeInput.Text.Trim

        If userInput Like "4210[234]" Then
            txtZipcodeResults.Text = "Valid"
        Else
            txtZipcodeResults.Text = "Zipcode in Invalid"
        End If
    End Sub


    Private Sub btnExcercise8_Click(sender As Object, e As EventArgs) Handles btnExcercise8.Click

        'EXCERCISE 8-- USe only 1 For loop to complete the Check Digit Application

        'Build a Check Digit Program-- Algorithm--
        'Step 1--Starting with the 2nd digit multiply every other digit by 3 and then add the sums together.(#2, #4, #6, #8, #10, #12)
        'Step 2-- Each digit skipped in Step 1(#1, #3, #5, #7, #9, #11) will be added together
        'Step 3-- Add the sums from Step 1 and Step 2 together
        'Step 4-- Divide the Sum from Step 3 by 10 and find the Remainder
        'Step 5-- If remainder = 0 then Check Digit equals 0 --else-- subtract the remainder from 10 and the result is the check digit.

        'Variables

        Dim userInput As String = txtEx8Input.Text.Trim.ToUpper
        Dim total As Double
        Dim remainder As Double
        Dim isbncalcDigit As Integer
        Dim checkDigit As Double

        'Step 1 Procedure,Step 2 Procedures and Step 3 Procedures

        If userInput.Length = 12 Then

            For isbnNum As Integer = 0 To userInput.Length - 1
                Integer.TryParse(userInput(isbnNum), isbncalcDigit)
                If isbnNum Mod 2 = 0 Then
                    total += isbncalcDigit
                Else
                    total += isbncalcDigit * 3
                End If
            Next isbnNum

        End If

        'Step 4 Procedure

        remainder = total Mod 10

        'Step 5 Procedure

        If remainder <> 0 Then
            checkDigit = 10 - remainder
        End If

        'Final Display of results

        userInput = userInput.Insert(12, checkDigit.ToString)

        txtEx8Results.Text = userInput
    End Sub

    Private Sub btnExcercise9_Click(sender As Object, e As EventArgs) Handles btnExcercise9.Click

        'EXCERCISE 9-- Modify the password application from previously in the chapter.
        ''Add a string constant equal to the Alphabet in UPPERCASE
        'when the user enters a string take the first letter of each word and assign it as a letter in the Password
        'the password's last character will be a number equal to the first word's(first letter) in comparison to the Alphabet string
        'so if the string is "SHOW ME tHE MONEY" the password created will be "SMTM19" since the letter S is the 19th letter in the Aplhabet

        Dim userInput As String = txtExcer9Input.Text.ToUpper.Trim
        Dim spaceIndex As Integer = userInput.IndexOf(" ")
        Const alphabet As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim password As String = userInput(0)

        While spaceIndex <> -1
            password += userInput(spaceIndex + 1)
            spaceIndex = userInput.IndexOf(" ", spaceIndex + 1)
        End While

        Dim endofPassword As Integer = password.Length - 1

        For alphaIndex As Integer = 0 To alphabet.Length - 1
            If password(0) Like alphabet(alphaIndex) Then
                alphaIndex += 1
                password = password.Insert(endofPassword + 1, alphaIndex.ToString)
            End If
        Next alphaIndex

        txtExcer9Results.Text = password
    End Sub

    Private Sub btnEX11_Click(sender As Object, e As EventArgs) Handles btnEX11.Click, btnEX11.Click

        'EXCERCISE 11-- Modify the password application from previously in the chapter.
        'when the user enters a string take the first letter of each word and assign it as a letter in the Password
        'the password's 2nd character will be a number equal to the password's length
        'if the Letter in the from the Input was capital then make it lowercase and if Uppercase make it lowercase

        Dim userInput As String = txtEX11Input.Text.Trim
        Dim spaceIndex As Integer = userInput.IndexOf(" ")
        Dim password As String = userInput(0)
        Dim results As String = ""

        While spaceIndex <> -1
            password += userInput(spaceIndex + 1)
            spaceIndex = userInput.IndexOf(" ", spaceIndex + 1)
        End While

        For passwordIndex As Integer = 0 To password.Length - 1
            If password(passwordIndex).ToString Like "[A-Z]" Then
                results += password(passwordIndex).ToString.ToLower()
            Else
                results += password(passwordIndex).ToString.ToUpper()

            End If
        Next

        results = results.Insert(1, results.Length.ToString)

        txtEX11Results.Text = results
    End Sub

    Private Sub btnEX10_Click(sender As Object, e As EventArgs) Handles btnEX10.Click

        'EXCERCISE 10---Build a program that takes in a User's shipping code consisting of 2 digits and either 1 Letter or 2 Letters
        'MS(mail standard), MP(mail priority), FS(fedex standard), FO(fedex overnight), U(ups). based upon the last two letters
        'select the approproate Shipping chice from the list box else display an error.

        Dim userInput As String = txtEX10Input.Text.ToUpper.Trim

        If userInput Like "##[MFU]" Or userInput Like "##[MF][SPO]" Then
            If userInput Like "##[U]" Then
                lstExcercise10.SelectedItem = "UPS"
            ElseIf userInput Like "##[M][S]" Then
                lstExcercise10.SelectedItem = "Mail-Standard"
            ElseIf userInput Like "##[M][P]" Then
                lstExcercise10.SelectedItem = "Mail-Priority"
            ElseIf userInput Like "##[F][S]" Then
                lstExcercise10.SelectedItem = "FedEx-Standard"
            ElseIf userInput Like "##[F][O]" Then
                lstExcercise10.SelectedItem = "FedEx-Overnight"
            End If
        Else
            MessageBox.Show("Invalid shipping code please try again", "Shipping Code Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnExcercise12_Click(sender As Object, e As EventArgs) Handles btnExcercise12.Click

        'Excercise 12--Build An App that will take in a User's name first and last and a middle name or middle inital. If there are spaces in the front and rear trim it. Also if there is more than one space between words remove them
    'Reformat the string so that the first letter of each name is captialized.

End Class
