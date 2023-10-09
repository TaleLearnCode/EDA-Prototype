CREATE TABLE Purchase.PurchaseStatus
(
  PurchaseStatusId   INT NOT NULL,
  PurchaseStatusName VARCHAR(100) NOT NULL,
  CONSTRAINT pkcPurchaseStatus PRIMARY KEY CLUSTERED (PurchaseStatusId)
)