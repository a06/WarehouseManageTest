ALTER  PROCEDURE dbo.spCreateStoreBalanceItem (@StoreBalanceID int)
AS
BEGIN
	DECLARE @LastEndDate datetime
	SET @LastEndDate=(SELECT MAX(EndDate) FROM StoreBalances WHERE StoreBalanceID<>@StoreBalanceID)
	
	----
	SELECT i.ProductID, (i.BeginQty + i.PurchaseQty - i.PurchaseReturnQty - i.SaleQty + i.SaleReturnQty + i.StoreBalanceQty) AS EndQty
	INTO #LastItems
	FROM StoreBalances h
	INNER JOIN StoreBalanceItems i ON h.StoreBalanceID=i.StoreBalanceID
	WHERE DATEDIFF(DAY, h.EndDate, @LastEndDate)=0
	AND (i.BeginQty + i.PurchaseQty - i.PurchaseReturnQty - i.SaleQty + i.SaleReturnQty + i.StoreBalanceQty)<>0
	
	----
	SELECT i.ProductID, SUM(Quantity) AS PurchaseQty
	INTO #PurchaseItems
	FROM Purchases h
	INNER JOIN PurchaseItems i ON h.PurchaseID=i.PurchaseID
	WHERE h.BillDate>@LastEndDate
	GROUP BY i.ProductID
	
	SELECT i.ProductID, SUM(Quantity) AS PurchaseReturnQty
	INTO #PurchaseReturnItems
	FROM PurchaseReturns h
	INNER JOIN PurchaseReturnItems i ON h.PurchaseReturnID=i.PurchaseReturnID
	WHERE h.BillDate>@LastEndDate
	GROUP BY i.ProductID
	
	SELECT i.ProductID, SUM(Quantity) AS SaleQty
	INTO #SaleItems
	FROM Sales h
	INNER JOIN SaleItems i ON h.SaleID=i.SaleID
	WHERE h.BillDate>@LastEndDate
	GROUP BY i.ProductID
	
	SELECT i.ProductID, SUM(Quantity) AS SaleReturnQty
	INTO #SaleReturnItems
	FROM SaleReturns h
	INNER JOIN SaleReturnItems i ON h.SaleReturnID=i.SaleReturnID
	WHERE h.BillDate>@LastEndDate
	GROUP BY i.ProductID

	----
	INSERT INTO StoreBalanceItems(StoreBalanceID
		, SortID
		, ProductID
		, BeginQty
		, PurchaseQty
		, PurchaseReturnQty
		, SaleQty
		, SaleReturnQty
		, StoreBalanceQty
		, Description)
	SELECT @StoreBalanceID
		, (select COUNT(1) from Products where ProductID <= p.ProductID) as SortID
		, p.ProductID
		, ISNULL(l.EndQty, 0.00) AS BeginQty
		, ISNULL(pi.PurchaseQty, 0.00) AS PurchaseQty
		, ISNULL(pri.PurchaseReturnQty, 0.00) AS PurchaseReturnQty
		, ISNULL(si.SaleQty, 0.00) AS SaleQty
		, ISNULL(sri.SaleReturnQty, 0.00) AS SaleReturnQty
		, (0.00) AS StoreBalanceQty
		, (NULL) AS Description
	FROM Products p
	LEFT JOIN #LastItems l ON p.ProductID=l.ProductID
	LEFT JOIN #PurchaseItems pi ON p.ProductID=pi.ProductID
	LEFT JOIN #PurchaseReturnItems pri ON p.ProductID=pri.ProductID
	LEFT JOIN #SaleItems si ON p.ProductID=si.ProductID
	LEFT JOIN #SaleReturnItems sri ON p.ProductID=sri.ProductID
	ORDER BY ProductCode
END