+ Library Class
	+ string Name
	+ List Loanees
	+ List Books
	+ string GetLibrary ()
	+ bool CreateLeanee (ID, Name)
	+ bool CreateLoanee (ID, Name, Email)
	+ bool RemoveLoanee (ID)
	+ bool RemoveLoanee (Email)
	+ string GetLoanee (ID)
	+ string GetLoanee (Email)
	+ bool BorrowBook (Book)
	+ bool ReserveBook (Book)
	+ bool ReturnBook (Book)
	+ Book GetBook (ISBNCode)
	+ List GetBooksBy (Author)
	+ List GetBooksBy (Title)
	+ List GetBooksBy (Category)
	+ List GetBooksBy (DateOfLending)
	+ void SaveState
	+ void LoadState

+ Loanee : Person
	+ int ID
	+ string Name

+ Person
	+ string Name
	+ string Email
	+ List BorrowedBooks

+ Book
	+ string Title
	+ string Author
	+ strig ISBNCode
	+ Category
	+ bool IsBorrowed
	+ Datetime DateOfLending
