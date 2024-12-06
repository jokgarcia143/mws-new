
UPDATE CustomersSummary
SET Reading2 = 0.00
WHERE ISNUMERIC(Reading) <> 1

UPDATE CustomersSummary
SET Reading2 = Reading
WHERE ISNUMERIC(Reading) = 1

UPDATE CustomersSummary
SET Consumed2 = 0
WHERE ISNUMERIC(Consumed) <> 1

UPDATE CustomersSummary
SET Consumed2 = Consumed
WHERE ISNUMERIC(Consumed) = 1



--AmountBilled
UPDATE CustomersSummary
SET AmountBilled = REPLACE(AmountBilled, ',', '')

UPDATE CustomersSummary
SET AmountBilled2 = 0
WHERE ISNUMERIC(AmountBilled) <> 1

UPDATE CustomersSummary
SET AmountBilled2 = AmountBilled
WHERE ISNUMERIC(AmountBilled) = 1

--AmountPaid
UPDATE CustomersSummary
SET AmountPaid = REPLACE(AmountPaid, ',', ''), currentBill = REPLACE(AmountPaid, ',', ''), MonthNo = 0;

UPDATE CustomersSummary
SET AmountPaid2 = 0.00
WHERE AmountPaid IN ('NA','UNPAID')

UPDATE CustomersSummary
--SET AmountPaid2 = TRY_CAST(AmountPaid AS DECIMAL(18, 2))
SET AmountPaid2 = AmountPaid
WHERE AmountPaid NOT IN ('NA','UNPAID')

--DatePaid
UPDATE CustomersSummary
SET DatePaid2 = TRY_CAST(DatePaid AS datetime)
WHERE ISDATE(DatePaid) = 1

--Balance
UPDATE CustomersSummary
SET Balance = REPLACE(Balance, ',', '')
UPDATE CustomersSummary
SET Balance2 = 0.00
WHERE ISNUMERIC(Balance) <> 1
UPDATE CustomersSummary
SET Balance2 = TRY_CAST(Balance AS DECIMAL(18, 2))
WHERE ISNUMERIC(Balance) = 1

--Prev Balance
UPDATE CustomersSummary
SET PrevBal = REPLACE(PrevBal, ',', '')
UPDATE CustomersSummary
SET PrevBal2 = 0.00
WHERE ISNUMERIC(PrevBal) <> 1
UPDATE CustomersSummary
SET PrevBal2 = TRY_CAST(PrevBal AS DECIMAL(18, 2))
WHERE ISNUMERIC(PrevBal) = 1

--prevDate
UPDATE CustomersSummary
SET prevDate2 = TRY_CAST(prevDate AS datetime)
WHERE ISDATE(prevDate) = 1
UPDATE CustomersSummary
SET prevDate2 = '1894-10-19'
WHERE ISDATE(prevDate) <> 1

--dueDate
UPDATE CustomersSummary
SET dueDate2 = TRY_CAST(dueDate AS datetime)
WHERE ISDATE(dueDate) = 1
UPDATE CustomersSummary
SET dueDate2 = '1894-10-19'
WHERE ISDATE(dueDate) <> 1

--currentBill
UPDATE CustomersSummary
SET currentBill2 = 0.00
WHERE ISNUMERIC(currentBill) <> 1
UPDATE CustomersSummary
SET currentBill2 = TRY_CAST(currentBill AS DECIMAL(18, 2))
WHERE ISNUMERIC(currentBill) = 1

--others
UPDATE CustomersSummary
SET Others = REPLACE(Others, ',', '')
UPDATE CustomersSummary
SET Others2 = 0.00
WHERE ISNUMERIC(Others) <> 1
UPDATE CustomersSummary
SET Others2 = TRY_CAST(Others AS DECIMAL(18, 2))
WHERE ISNUMERIC(Others) = 1

--prevBal
UPDATE CustomersSummary
SET prevBal = REPLACE(prevBal, ',', '')
UPDATE CustomersSummary
SET prevBal2 = 0.00
WHERE ISNUMERIC(prevBal) <> 1
UPDATE CustomersSummary
SET prevBal2 = TRY_CAST(prevBal AS DECIMAL(18, 2))
WHERE ISNUMERIC(prevBal) = 1

--prevRead
UPDATE CustomersSummary
SET prevRead = REPLACE(prevRead, ',', '')
UPDATE CustomersSummary
SET prevRead2 = 0.00
WHERE ISNUMERIC(prevRead) <> 1
UPDATE CustomersSummary
SET prevRead2 = TRY_CAST(prevRead AS DECIMAL(18, 2))
WHERE ISNUMERIC(prevRead) = 1




UPDATE CustomersSummary
SET presDate2 = '01-01-1900'
WHERE presDate IN ('UNPAID','NA')

UPDATE CustomersSummary
SET presDate2 = TRY_CAST(presDate AS datetime)
WHERE presDate NOT IN ('UNPAID','NA')


SELECT TOP (1000) 
      [AmountPaid]
  FROM [MWSWeb].[dbo].[CustomersSummary] GROUP BY AmountPaid

SELECT * FROM CustomersSummary
--WHERE AmountPaid <> 'UNPAID' OR AmountPaid <> 'NA'
--WHERE AmountPaid2 IS NULL


--Water Bill
UPDATE WaterBill
SET PrevBal = REPLACE(PrevBal, ',', '')
UPDATE WaterBill
SET PrevBal2 = 0.00
WHERE ISNUMERIC(PrevBal) <> 1
UPDATE WaterBill
SET PrevBal2 = TRY_CAST(PrevBal AS DECIMAL(18, 2))
WHERE ISNUMERIC(PrevBal) = 1

UPDATE WaterBill
SET prevDate2 = TRY_CAST(prevDate AS datetime)
WHERE ISDATE(prevDate) = 1
UPDATE WaterBill
SET prevDate2 = '1894-10-19'
WHERE ISDATE(prevDate) <> 1

UPDATE WaterBill
SET prevRead2 = 0.00
WHERE ISNUMERIC(prevRead) <> 1

UPDATE WaterBill
SET prevRead2 = prevRead
WHERE ISNUMERIC(prevRead) = 1

