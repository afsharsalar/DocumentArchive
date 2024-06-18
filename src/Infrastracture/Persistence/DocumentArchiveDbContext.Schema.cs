namespace DocumentArchive.Infrastructure.Persistence
{
    public static class DocumentArchiveDbContextSchema
    {
        public const string DefaultSchema = "document";
        public const string DefaultConnectionStringName = "DbContext";


        public static class UserRoleDbSchema
        {
            public const string TableName = "UserRoles";
        }

        public static class UserTokenDbSchema
        {
            public const string TableName = "UserTokens";
        }
        public static class UserLoginDbSchema
        {
            public const string TableName = "UserLogins";
        }
        public static class UserDbSchema
        {
            public const string TableName = "Users";
        }

        public static class RoleDbSchema
        {
            public const string TableName = "Roles";
        }

        public static class CustomerDbSchema
        {
            public const string TableName = "Customers";

            public const string CategoryId = "CategoryId";


            public const string AddressCity = "Address_City";
            public const string AddressStreet = "Address_Street";
            public const string AddressPostalCode = "Address_PostalCode";
        }

        public static class DocumentDbSchema
        {
            public const string TableName = "Documents";
            public const string ForeignKey = "DocumentId";

            public const string CommentIdsTableName = "DocumentCommentIds";

            public const string CommentIdsBackField = "_commentIds";


            public const string TagTableName = "Tags";

            public const string TagsBackField = "_tags";


            public const string CategoryId = "CategoryId";

            public const string CustomerId = "CustomerId";


        }

        public static class CategoryDbSchema
        {
            public const string TableName = "Categories";
        }


        public static class CommentDbSchema
        {
            public const string TableName = "Comments";

            public const string DocumentId = "DocumentId";

        }

    }
}
