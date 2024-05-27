--prevRead
UPDATE Fees
SET ConnectionFee = REPLACE(ConnectionFee, ',', '')

UPDATE WaterBill
SET prevRead = REPLACE(prevRead, ',', '')
UPDATE WaterBill
SET prevRead2 = 0.00
WHERE ISNUMERIC(prevRead) <> 1
UPDATE WaterBill
SET prevRead2 = TRY_CAST(prevRead AS DECIMAL(18, 2))
WHERE ISNUMERIC(prevRead) = 1

--prevDate
UPDATE WaterBill
SET prevDate2 = TRY_CAST(prevDate AS datetime)
WHERE ISDATE(prevDate) = 1
UPDATE WaterBill
SET prevDate2 = '1894-10-19'
WHERE ISDATE(prevDate) <> 1

--prevBal
UPDATE WaterBill
SET prevBal = REPLACE(prevBal, ',', '')
UPDATE WaterBill
SET prevBal2 = 0.00
WHERE ISNUMERIC(prevBal) <> 1
UPDATE WaterBill
SET prevBal2 = TRY_CAST(prevBal AS DECIMAL(18, 2))
WHERE ISNUMERIC(prevBal) = 1