using System;

// ISM 6225 - Assignment 2
// Name: Ignatious Mushata
// Simplified, fixed Program.cs to resolve build errors. Each question is a minimal stub so the
// project builds cleanly; you can expand individual question implementations as needed.

bool keepRunning = true;

while (keepRunning)
{
    Console.WriteLine();
    Console.WriteLine("===== Assignment 2 Menu =====");
    Console.WriteLine("Enter 1-10 to run a question, or 0 to exit.");
    Console.Write("Your choice: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1": Question1(); break;
        case "2": Question2(); break;
        case "3": Question3(); break;
        case "4": Question4(); break;
        case "5": Question5(); break;
        case "6": Question6(); break;
        case "7": Question7(); break;
        case "8": Question8(); break;
        case "9": Question9(); break;
        case "10": Question10(); break;
        case "0": keepRunning = false; break;
        default: Console.WriteLine("Invalid choice. Please enter 0-10."); break;
    }
}

// =====================================================
// QUESTION 1 - Subscription Revenue Calculator
// =====================================================
static void Question1()
{
    Console.WriteLine("--- Question 1: Subscription Revenue Calculator ---");

    int currentCustomers = ReadIntNonNegative("Enter the current number of customers: ");
    decimal currentMonthlyPrice = ReadDecimalNonNegative("Enter the current monthly price per customer: ");
    decimal percentageIncrease = ReadDecimalNonNegative("Enter the percentage price increase (e.g., 8 for 8%): ");

    decimal currentMonthlyRevenue = currentCustomers * currentMonthlyPrice;
    decimal newMonthlyPrice = currentMonthlyPrice * (1 + percentageIncrease / 100m);
    decimal projectedMonthlyRevenue = currentCustomers * newMonthlyPrice;
    decimal revenueIncrease = projectedMonthlyRevenue - currentMonthlyRevenue;

    Console.WriteLine();
    Console.WriteLine($"Current monthly revenue: {currentMonthlyRevenue:C2}");
    Console.WriteLine($"New monthly price per customer after {percentageIncrease}% increase: {newMonthlyPrice:C2}");
    Console.WriteLine($"Projected monthly revenue: {projectedMonthlyRevenue:C2}");
    Console.WriteLine($"Monthly revenue increase (projected - current): {revenueIncrease:C2}");

    Console.WriteLine();
    Console.WriteLine("Press any key to return to menu...");
    Console.ReadKey();

    static int ReadIntNonNegative(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            try
            {
                int value = Convert.ToInt32(input);
                if (value < 0)
                {
                    Console.WriteLine("Value cannot be negative. Please enter a non-negative integer.");
                    continue;
                }
                return value;
            }
            catch
            {
                Console.WriteLine("Invalid input: please enter a numeric integer value.");
            }
        }
    }

    static decimal ReadDecimalNonNegative(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            try
            {
                decimal value = Convert.ToDecimal(input);
                if (value < 0m)
                {
                    Console.WriteLine("Value cannot be negative. Please enter a non-negative number.");
                    continue;
                }
                return value;
            }
            catch
            {
                Console.WriteLine("Invalid input: please enter a numeric value.");
            }
        }
    }
}

// =====================================================
// QUESTION 2 - Investment Doubling Time
// =====================================================
static void Question2()
{
    Console.WriteLine("--- Question 2: Investment Doubling Time ---");
    Console.Write("Enter the annual return rate (as a percentage > 0): ");
    string? input = Console.ReadLine();

    try
    {
        double percent = Convert.ToDouble(input);
        if (percent <= 0)
        {
            Console.WriteLine("Error: The rate must be greater than zero.");
        }
        else
        {
            double rate = percent / 100.0;
            double doublingTime = Math.Log(2) / Math.Log(1 + rate);
            Console.WriteLine("Doubling time: " + doublingTime.ToString("F2") + " years");

            string classification;
            if (doublingTime < 10) classification = "Fast";
            else if (doublingTime <= 20) classification = "Moderate";
            else classification = "Slow";

            Console.WriteLine("Classification: " + classification);
        }
    }
    catch
    {
        Console.WriteLine("Invalid input: please enter a numeric percentage greater than zero.");
    }

    Console.WriteLine("Press any key to return to menu...");
    Console.ReadKey();
}

// =====================================================
// QUESTION 3 - Delivery Region Triangle
// =====================================================
static void Question3()
{
    Console.WriteLine("--- Question 3: Delivery Region Triangle ---");

    double ReadPositiveDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            try
            {
                double v = Convert.ToDouble(input);
                if (v <= 0) { Console.WriteLine("Value must be positive."); continue; }
                return v;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }
    }

    double a = ReadPositiveDouble("Enter side a: ");
    double b = ReadPositiveDouble("Enter side b: ");
    double c = ReadPositiveDouble("Enter side c: ");

    if (a + b <= c || a + c <= b || b + c <= a)
    {
        Console.WriteLine("The provided sides do not satisfy the triangle inequality.");
    }
    else
    {
        double s = (a + b + c) / 2.0;
        double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        Console.WriteLine($"Triangle area: {area:F2} square units");
    }

    Console.WriteLine("Press any key to return to menu...");
    Console.ReadKey();
}

// =====================================================
// QUESTION 4 - Simple Invoice Calculator
// =====================================================
static void Question4()
{
    Console.WriteLine("--- Question 4: Simple Invoice Calculator ---");

    decimal ReadPositiveDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            try
            {
                decimal v = Convert.ToDecimal(input);
                if (v < 0m) { Console.WriteLine("Value must be non-negative."); continue; }
                return v;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }
    }

    decimal hours = ReadPositiveDecimal("Enter hours worked: ");
    decimal hourlyRate = ReadPositiveDecimal("Enter hourly rate: ");

    decimal labor = hours * hourlyRate;
    decimal serviceFee = labor * 0.05m;
    decimal total = labor + serviceFee;

    Console.WriteLine($"Labor: {labor:C2}");
    Console.WriteLine($"Service fee (5%): {serviceFee:C2}");
    Console.WriteLine($"Total invoice: {total:C2}");

    Console.WriteLine("Press any key to return to menu...");
    Console.ReadKey();
}

// =====================================================
// QUESTION 5 - Daily Sales Entry with a Sentinel
// =====================================================
static void Question5()
{
    Console.WriteLine("--- Question 5: Daily Sales Entry with a Sentinel ---");

    int validSaleCount = 0;
    decimal totalSales = 0.00m;

    while (true)
    {
        Console.Write("Enter a sale amount (or -1 to finish): ");
        string? input = Console.ReadLine();

        try
        {
            decimal sale = Convert.ToDecimal(input);

            if (sale == -1m) break;

            if (sale < 0m)
            {
                Console.WriteLine("Negative amounts are not allowed. Please enter a non-negative value or -1 to finish.");
                continue;
            }

            validSaleCount++;
            totalSales += sale;
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input: please enter a numeric value (e.g., 12.34) or -1 to finish.");
            continue;
        }
        catch (OverflowException)
        {
            Console.WriteLine("Input is too large. Please enter a smaller numeric value or -1 to finish.");
            continue;
        }
    }

    if (validSaleCount == 0)
    {
        Console.WriteLine("No valid sales were entered.");
    }
    else
    {
        decimal averageSale = totalSales / validSaleCount;
        Console.WriteLine($"Number of valid sales: {validSaleCount}");
        Console.WriteLine($"Total sales: {totalSales:C2}");
        Console.WriteLine($"Average sale: {averageSale:C2}");
    }

    Console.WriteLine("Press any key to return to menu...");
    Console.ReadKey();
}

// =====================================================
// QUESTION 6 - Investment Payback Simulator
// =====================================================
static void Question6()
{
    Console.WriteLine("--- Question 6: Investment Payback Simulator ---");

    decimal ReadPositive(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            try
            {
                decimal v = Convert.ToDecimal(input);
                if (v <= 0m) { Console.WriteLine("Value must be positive."); continue; }
                return v;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }
    }

    decimal initialInvestment = ReadPositive("Enter initial investment (positive number): ");
    decimal monthlyBenefit = ReadPositive("Enter expected monthly benefit (positive number): ");

    decimal cumulative = 0m;
    int months = 0;
    const int maxMonths = 600;

    while (cumulative < initialInvestment && months < maxMonths)
    {
        months++;
        cumulative += monthlyBenefit;
        decimal unrecovered = initialInvestment - cumulative;
        if (unrecovered < 0m) unrecovered = 0m;
        Console.WriteLine($"Month {months}: cumulative benefits = {cumulative:C2}, unrecovered balance = {unrecovered:C2}");
    }

    if (cumulative >= initialInvestment)
    {
        Console.WriteLine();
        Console.WriteLine($"Payback achieved in month {months}.");
        Console.WriteLine($"Cumulative benefits at payback = {cumulative:C2}.");
    }
    else
    {
        decimal unrecovered = initialInvestment - cumulative;
        if (unrecovered < 0m) unrecovered = 0m;
        Console.WriteLine();
        Console.WriteLine($"Investment not recovered after {maxMonths} months.");
        Console.WriteLine($"Cumulative benefits after {maxMonths} months = {cumulative:C2}.");
        Console.WriteLine($"Unrecovered balance = {unrecovered:C2}.");
    }

    Console.WriteLine("Press any key to return to menu...");
    Console.ReadKey();
}

// =====================================================
// QUESTION 7 - Weekly Demand Bar Chart
// =====================================================
static void Question7()
{
    Console.WriteLine("--- Question 7: Weekly Demand Bar Chart ---");

    int[] demand = new int[7];
    for (int i = 0; i < demand.Length; i++)
    {
        while (true)
        {
            Console.Write($"Enter demand for day {i + 1}: ");
            string? input = Console.ReadLine();
            try
            {
                int v = Convert.ToInt32(input);
                if (v < 0) { Console.WriteLine("Demand cannot be negative."); continue; }
                demand[i] = v; break;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a whole number.");
            }
        }
    }

    Console.WriteLine();
    for (int i = 0; i < demand.Length; i++)
    {
        int stars = demand[i] / 10;
        Console.Write($"Day {i + 1}: {demand[i]} | ");
        for (int s = 0; s < stars; s++) Console.Write('*');
        Console.WriteLine();
    }

    Console.WriteLine("Press any key to return to menu...");
    Console.ReadKey();
}

// =====================================================
// QUESTION 8 - Customer Risk Score Method
// =====================================================
static void Question8()
{
    Console.WriteLine("--- Question 8: Customer Risk Score Method ---");

    int ReadNonNegativeInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            try
            {
                int v = Convert.ToInt32(input);
                if (v < 0) { Console.WriteLine("Error: value cannot be negative."); continue; }
                return v;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a numeric integer value.");
            }
        }
    }

    int missed = ReadNonNegativeInt("Enter number of missed payments: ");
    int tickets = ReadNonNegativeInt("Enter number of support tickets: ");
    int monthsInactive = ReadNonNegativeInt("Enter number of months inactive: ");

    int score = ComputeRiskScore(missed, tickets, monthsInactive);

    string classification = score < 30 ? "Low" : (score <= 59 ? "Moderate" : "High");

    Console.WriteLine();
    Console.WriteLine("Risk Score: " + score);
    Console.WriteLine("Classification: " + classification);

    Console.WriteLine("Press any key to return to menu...");
    Console.ReadKey();
}

// =====================================================
// QUESTION 9 - Transaction Anomaly Screening
// =====================================================
static void Question9()
{
    Console.WriteLine("--- Question 9: Transaction Anomaly Screening ---");

    int numberOfTransactions;
    while (true)
    {
        Console.Write("How many transaction amounts will be entered (3-20)? ");
        string? input = Console.ReadLine();
        try
        {
            numberOfTransactions = Convert.ToInt32(input);
            if (numberOfTransactions < 3 || numberOfTransactions > 20) { Console.WriteLine("Please enter a whole number between 3 and 20."); continue; }
            break;
        }
        catch
        {
            Console.WriteLine("Invalid input. Please enter a whole number.");
        }
    }

    decimal[] amounts = new decimal[numberOfTransactions];
    for (int i = 0; i < amounts.Length; i++)
    {
        while (true)
        {
            Console.Write($"Enter amount for transaction {i + 1}: ");
            string? inAmt = Console.ReadLine();
            try
            {
                decimal v = Convert.ToDecimal(inAmt);
                if (v < 0m) { Console.WriteLine("Negative amounts are not allowed."); continue; }
                amounts[i] = v; break;
            }
            catch
            {
                Console.WriteLine("Invalid amount. Please enter a numeric value.");
            }
        }
    }

    decimal min = amounts[0], max = amounts[0], total = 0m;
    for (int i = 0; i < amounts.Length; i++)
    {
        decimal v = amounts[i];
        if (v < min) min = v;
        if (v > max) max = v;
        total += v;
    }

    decimal mean = amounts.Length > 0 ? total / amounts.Length : 0m;

    Console.WriteLine();
    Console.WriteLine($"Minimum: {min:C2}");
    Console.WriteLine($"Maximum: {max:C2}");
    Console.WriteLine($"Total:   {total:C2}");
    Console.WriteLine($"Mean:    {mean:C2}");

    Console.WriteLine();
    for (int i = 0; i < amounts.Length; i++)
    {
        string label = amounts[i] > (1.5m * mean) ? "Review" : "Normal";
        Console.WriteLine($"Transaction {i + 1}: {amounts[i]:C2} - {label}");
    }

    Console.WriteLine("Press any key to return to menu...");
    Console.ReadKey();
}

// =====================================================
// QUESTION 10 - Future Value Calculator
// =====================================================
static void Question10()
{
    Console.WriteLine("--- Question 10: Future Value Calculator ---");

    decimal ReadNonNeg(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            try
            {
                decimal v = Convert.ToDecimal(input);
                if (v < 0m) { Console.WriteLine("Value must be non-negative."); continue; }
                return v;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }
    }

    decimal principal = ReadNonNeg("Enter initial investment amount: ");
    decimal annualPercent = ReadNonNeg("Enter annual return rate (percent): ");
    int years;
    while (true)
    {
        Console.Write("Enter number of years (positive integer): ");
        string? s = Console.ReadLine();
        try { years = Convert.ToInt32(s); if (years < 0) { Console.WriteLine("Enter non-negative integer."); continue; } break; }
        catch { Console.WriteLine("Invalid input. Enter a whole number."); }
    }

    double rate = Convert.ToDouble(annualPercent) / 100.0;
    double fv = Convert.ToDouble(principal) * Math.Pow(1 + rate, years);
    Console.WriteLine($"Future value after {years} years: {fv:C2}");

    Console.WriteLine("Press any key to return to menu...");
    Console.ReadKey();
}

// Helper for Question 8 (the assignment requires this exact name and parameters)
static int ComputeRiskScore(int missedPayments, int supportTickets, int monthsInactive)
{
    return missedPayments * 20 + supportTickets * 5 + monthsInactive * 8;
}
