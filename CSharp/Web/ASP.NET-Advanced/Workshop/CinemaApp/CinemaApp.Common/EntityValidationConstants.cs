﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common
{
    public static class EntityValidationConstants
    {
        public static class MovieValidationConstants
        {
            public const int TitleMaxLength = 50;
            public const int GenreMinLength = 5;
            public const int GenreMaxLength = 20;
            public const int DirectorMinLength = 10;
            public const int DirectorMaxLength = 80;
            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;
            public const string DateViewFormat = "MM/yyyy";
            public const int MinImageUrlLength = 8;
            public const int MaxImageUrlLength = 2083;
            public const int DurationMinValue = 1;
            public const int DurationMaxValue = 999;
        }

        public static class CinemaValidationConstants
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;
            public const int LocationMaxLength = 85;
            public const int LocationMinLength = 3;
        }

        public static class Manager
        {
            public const int PhoneNumberMinLength = 6;
            public const int PhoneNumberMaxLength = 15;
        }
    }
}
