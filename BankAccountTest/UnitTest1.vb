Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1
    <TestMethod()> Public Sub TestMethod1()

        Dim AccountName As String = "Ms I.N. Congnito"
        Dim AccountNumber As String = "ABCD 890111 11167890"
        Dim InterestRate As Double = 4.3
        Dim CountryOfOrigin As String = "Isle of Man"
        Dim Balance As Double = 10343.82

        Dim Account1 As New BankAccounts.BankAccounts(AccountName, AccountNumber, Balance, InterestRate, CountryOfOrigin)
        Dim Account2 As New BankAccounts.BankAccounts(AccountName, AccountNumber, Balance, InterestRate)
        Dim Account3 As New BankAccounts.BankAccounts(AccountName, AccountNumber, Balance)

        Assert.IsNotNull(Account1)
        Assert.IsNotNull(Account2)
        Assert.IsNotNull(Account3)

    End Sub

    <TestMethod()> Public Sub TestGetAccountName()
        Dim AccountName As String = "Ms I.N. Congnito"
        Dim AccountNumber As String = "ABCD 890111 11167890"
        Dim InterestRate As Double = 4.3
        Dim CountryOfOrigin As String = "Isle of Man"
        Dim Balance As Double = 10343.82
        Dim Account1 As New BankAccounts.BankAccounts(AccountName, AccountNumber, Balance, InterestRate, CountryOfOrigin)

        Dim Name As String = Account1.GetAccountName()
        Dim Number As String = Account1.GetAccountNumber()
        Dim Interest As Double = Account1.GetInterestRate()
        Dim Country As String = Account1.GetCountry()
        Dim Balancee As Double = Account1.GetBalance()

        Assert.AreEqual(Name, "Ms I.N. Congnito")
        Assert.AreEqual(Number, "ABCD 890111 11167890")
        Assert.AreEqual(Interest, 4.3)
        Assert.AreEqual(Country, "Isle of Man")
        Assert.AreEqual(Balance, 10343.82)
    End Sub

    <TestMethod()> Public Sub TestSetAccountName()
        Dim Account1 As BankAccounts.BankAccounts = Me.NewAccount

        Account1.SetInterestRate(5.1)
        Account1.SetAccountName("Ms I.N. Congnito")
        Account1.SetAccountNumber("ABCD 890111 11167890")
        Account1.SetCountry("Isle Of Man")
        Account1.SetBalance(10343.82)

        Assert.AreEqual(5.1, Account1.GetInterestRate())
        Assert.AreEqual("Ms I.N. Congnito", Account1.GetAccountName())
        Assert.AreEqual("ABCD 890111 11167890", Account1.GetAccountNumber())
        Assert.AreEqual("Isle Of Man", Account1.GetCountry())
        Assert.AreEqual(10343.82, Account1.GetBalance())
    End Sub

    <TestMethod()> Public Sub TestApplyInterestRate()
        Dim Account1 As BankAccounts.BankAccounts = Me.NewAccount()

        Account1.ApplyInterest()

        Assert.AreEqual(Account1.GetBalance(), 10380.89)
    End Sub

    <TestMethod()> Public Sub TestToStringMethod()

        Dim ExpectedValueString As New StringBuilder()
        ExpectedValueString.Append("Isle of Man" & vbCrLf)
        ExpectedValueString.Append("ABCD 890111 11167890" & vbCrLf)
        ExpectedValueString.Append("Ms I.N. Cognito" & vbCrLf)
        ExpectedValueString.Append("Interest: 4.3" & vbCrLf)
        ExpectedValueString.Append("10343.82" & vbCrLf)
        Console.WriteLine(ExpectedValueString.ToString())

        Dim Account1 As BankAccounts.BankAccounts = NewAccount()
        Dim ActualString = Account1.ToString()
        Console.WriteLine(ActualString)

        Assert.AreEqual(ExpectedValueString.ToString(), ActualString)

    End Sub

    <TestMethod()> Public Sub TestDeposit()

        Dim Account1 As BankAccounts.BankAccounts = Me.NewAccount
        Dim ExpectedValue As Double = 10343.82 + 700
        Dim ActualValue As Double = Account1.Deposit(700)

        Assert.AreEqual(ExpectedValue, ActualValue)
    End Sub

    <TestMethod()> Public Sub TestWithdrawalSmall()

        Dim Account1 As BankAccounts.BankAccounts = Me.NewAccount()
        Dim ExpectedVal As Double = 10343.82 - 700.0

        Dim NewBalance = Account1.Withdrawal(700.0)

            Assert.AreEqual(ExpectedVal, Account1.GetBalance())

    End Sub

    <TestMethod()> Public Sub TestWithdrawalLarge()
        Dim Account1 As BankAccounts.BankAccounts = Me.NewAccount()
        Dim ExpectedVal As Double = 10343.82

        Try
            Dim NewBalance = Account1.Withdrawal(11000.0)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Assert.AreEqual(ExpectedVal, Account1.GetBalance())

    End Sub


    Private Function NewAccount() As BankAccounts.BankAccounts
        Dim AccountName As String = "Ms I.N. Cognito"
        Dim AccountNumber As String = "ABCD 890111 11167890"
        Dim InterestRate As Double = 4.3
        Dim Balance As Double = 10343.82
        Dim CountryOfOrigin As String = "Isle of Man"
        Return New BankAccounts.BankAccounts(AccountName, AccountNumber, Balance, InterestRate, CountryOfOrigin)
    End Function

End Class