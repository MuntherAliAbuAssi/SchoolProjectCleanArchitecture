namespace SchoolProject.Data.AppMetaData
{
    public static class Router
    {
        public const string SingleRoute = "/{id}";

        public const string root = "Api";
        public const string version = "V1";
        public const string Role = root + "/" + version + "/";

        public static class StudentRouting
        {
            public const string Prefix = Role + "Student";
            public const string List = Prefix + "/List";
            public const string GetstudentByID = Prefix + SingleRoute;
            public const string Create = Prefix + "/Create";
            public const string Update = Prefix + "/Update";
            public const string Delete = Prefix + "/Delete" + SingleRoute;
            public const string Paginated = Prefix + "/Paginated";

        }
        public static class DepartmentRouting
        {
            public const string Prefix = Role + "Department";
            public const string List = Prefix + "/List";
            public const string GetDepartmentByID = Prefix + "/Id";
            public const string Create = Prefix + "/Create";
            public const string Update = Prefix + "/Update";
            public const string Delete = Prefix + "/Delete" + SingleRoute;
            public const string Paginated = Prefix + "/Paginated";

        }
        public static class UserRouting
        {
            public const string Prefix = Role + "User";
            public const string List = Prefix + "/List";
            public const string GetUserID = Prefix + "/Id";
            public const string Create = Prefix + "/Create";
            public const string Update = Prefix + "/Update";
            public const string Delete = Prefix + "/Delete" + SingleRoute;
            public const string Paginated = Prefix + "/Paginated";
            public const string ChangeUserPassword = Prefix + "/Change-Password";

        }
    }
}
