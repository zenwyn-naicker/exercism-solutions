static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        float interestRate = balance switch
        {
            < 0 => 3.213f,
            < 1000 => 0.5f,
            < 5000 => 1.621f,
            _ => 2.475f
        };

        return interestRate;
    }

    public static decimal Interest(decimal balance)
        => balance * (decimal)(InterestRate(balance) / 100);

    public static decimal AnnualBalanceUpdate(decimal balance)
        => balance + Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        if (balance >= targetBalance)
        {
            return 0;
        }

        decimal newBalance = balance;
        int counter = 0;

        do
        {
            newBalance = AnnualBalanceUpdate(newBalance);
            counter++;
        }
        while (newBalance < targetBalance);

        return counter;
    }
}