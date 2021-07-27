namespace firstTUT.Contract.V1
{
    public static class ApiRoutes
    {
        public const string version = "v1";
        public const string root = "api";
        public const string Base = root + "/" + version;
        public static class Books
        {
            public const string GetAll = Base  + "/Get-All-Books";
            public const string Get = Base  + "/Get/{id}";
            
            public const string GetBookById = Base  + "/Get-Book-By-Id/{id}";
            public const string AddBook = Base  + "/Add-Books";
            public const string DeleteBookById = Base  + "/Delete-Book/{id}";
            public const string GetBookByTitle = Base  + "/Get-Book-By-Title/{title}";
            public const string DeleteAllBooks = Base  + "/Delete-All-Books";
            public const string ChangeBookById = Base  + "/Change-Book/{id}";
        }

        public static class Author
        {
            public const string GetAuthor = Base + "/Get-Author/{id}";
            public const string Get = Base + "/Get/{id}";
            public const string AddAuthor = Base + "/Add-Author";
            public const string DeleteAuthor = Base + "/Delete-Author/{id}";
        }

        public static class Publisher
        {
            public const string GetPublisher = Base + "/Get-Publisher/{id}";
            public const string AddPublisher = Base + "/Add-Publisher";
            public const string Get = Base + "/Get/{id}";           
        }
        public static class User
        {
            public const string Login = Base + "/Identity/Login";
            public const string Register = Base + "/Identity/Register";
            
        }
    }
}