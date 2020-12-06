+ Library Class
	+ string Name
	+ List Loanees
	+ List Books
	+ string GetLibrary ()
	+ bool CreateLeanee (ID, Name)
	+ bool CreateLoanee (ID, Name, Email)
	+ bool RemoveLoanee (ID)
	+ bool RemoveLoanee (Email)
	+ Loanee GetLoanee (ID)
	+ Loanee GetLoanee (Email)
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
	+ List BorrowedBooks

+ Person
	+ string Name
	+ string Email
	
+ Book
	+ string Title
	+ string Author
	+ strig ISBNCode
	+ Category
	+ bool IsBorrowed
	+ Datetime DateOfLending
