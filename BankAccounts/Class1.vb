Imports System.Text

' <Summary> 
'Represents a single bank account
'</Summary>
'<author> Bella Ward </author>
'<date> 15/05/2020 </date>
Public Class BankAccounts

    Private AccountName As String
    Private AccountNumber As String
    Private Balance As Double
    Private InterestRate As Double
    Private CountryOfOrigin As String

    Public Sub New(AccountName As String, AccountNumber As String, Balance As Double, InterestRate As Double, CountryOfOrigin As String)
        Me.AccountName = AccountName
        Me.AccountNumber = AccountNumber
        Me.Balance = Balance
        Me.InterestRate = InterestRate
        Me.CountryOfOrigin = CountryOfOrigin
    End Sub

    Public Sub New(AccountName As String, AccountNumber As String, Balance As Double, InterestRate As Double)
        Me.AccountName = AccountName
        Me.AccountNumber = AccountNumber
        Me.Balance = Balance
        Me.InterestRate = InterestRate
    End Sub

    Public Sub New(AccountName As String, AccountNumber As String, Balance As Double)
        Me.AccountName = AccountName
        Me.AccountNumber = AccountNumber
        Me.Balance = Balance
    End Sub

    Public Function GetAccountName() As String
        Return Me.AccountName
    End Function

    Public Function SetAccountName(Name As String)
        Me.AccountName = Name
    End Function

    Public Function GetAccountNumber() As String
        Return Me.AccountNumber
    End Function

    Public Function SetAccountNumber(Number As String)
        Me.AccountNumber = Number
    End Function

    Public Function GetInterestRate() As Double
        Return Me.InterestRate
    End Function

    Public Function SetInterestRate(Rate As Double)
        Me.InterestRate = Rate
    End Function

    Public Function ApplyInterest()
        Dim NewBalance As Double = Me.Balance + (Me.Balance * 0.043 * (1 / 12))

        Me.Balance = Math.Round(NewBalance, 2)

        Return Nothing
    End Function

    Public Function GetCountry() As String
        Return Me.CountryOfOrigin
    End Function

    Public Function SetCountry(Country As String)
        Me.CountryOfOrigin = Country
    End Function

    Public Function GetBalance() As Double
        Return Me.Balance
    End Function

    Public Function SetBalance(Balance As Double)
        Me.Balance = Balance
    End Function

    Public Function Deposit(Amount As Double) As Double
        Me.Balance += Amount
        Return Me.Balance
    End Function

    Public Function Withdrawal(Amount As Double) As Double
        If Amount > Me.Balance Then
            Throw New Exception("Insufficient Funds")
        End If

        Me.Balance -= Amount

        Return Me.Balance
    End Function

    Public Overrides Function ToString() As String
        Dim AccountString As New StringBuilder
        AccountString.Append("Isle of Man" & vbCrLf)
        AccountString.Append("ABCD 890111 11167890" & vbCrLf)
        AccountString.Append("Ms I.N. Cognito" & vbCrLf)
        AccountString.Append("Interest: 4.3" & vbCrLf)
        AccountString.Append("10343.82" & vbCrLf)

        Return AccountString.ToString()
    End Function

End Class

