﻿namespace Library.Common
{
    public static class ValidationConstants
    {
        public static class UserValidation
        {
            public const int UserNameMinLength = 5;
            public const int UserNameMaxLength = 20;
            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;
            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;
        }

        public static class BookValidation
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;
            public const int AuthorMinLength = 5;
            public const int AuthorMaxLength = 50;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 5000;
            public const string RatingMinValue = "0.00";
            public const string RatingMaxValue = "10.00";
        }

        public static class CategoryValidation
        {
            public const int CategoryNameMinLength = 5;
            public const int CategoryNameMaxLength = 50;
        }
    }
}
