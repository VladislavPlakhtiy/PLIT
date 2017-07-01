Create DATABASE DBShop

Use  DBShop


CREATE TABLE [Product] (
	Id int NOT NULL,
	Name nvarchar(250) NOT NULL UNIQUE,
	Description nvarchar(MAX),
	SpecOffer nvarchar(MAX),
	Price decimal(18,2) NOT NULL,
	Category int NOT NULL,
	DateCreate datetime NOT NULL,
	Quantity int,
	Existence binary,
	OrdersHistoryId int,
  CONSTRAINT [PK_PRODUCT] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Photo] (
	ProductId int NOT NULL,
	Priority binary NOT NULL,
	PhotoUrl nvarchar(MAX) NOT NULL
)
GO
CREATE TABLE [OrdersHistory] (
	Id int NOT NULL,
	Sum decimal(18,2) NOT NULL,
	Delivery int NOT NULL,
	ClientName nvarchar(250) NOT NULL,
	Email nvarchar(250) NOT NULL,
	Phone nvarchar(250) NOT NULL,
	Sity nvarchar(250),
	Comments nvarchar (MAX),
	DateOrder datetime NOT NULL,
	Status int NOT NULL,
  CONSTRAINT [PK_ORDERSHISTORY] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Reviews] (
	Id int NOT NULL,
	ClientName nvarchar(250) NOT NULL,
	ClientFeedback nvarchar(MAX) NOT NULL,
	Rating int,
	DateFeedback datetime NOT NULL,
  CONSTRAINT [PK_REVIEWS] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [Product] WITH CHECK ADD CONSTRAINT [Product_fk0] FOREIGN KEY ([OrdersHistoryId]) REFERENCES [OrdersHistory]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Product] CHECK CONSTRAINT [Product_fk0]
GO

ALTER TABLE [Photo] WITH CHECK ADD CONSTRAINT [Photo_fk0] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Photo] CHECK CONSTRAINT [Photo_fk0]
GO



