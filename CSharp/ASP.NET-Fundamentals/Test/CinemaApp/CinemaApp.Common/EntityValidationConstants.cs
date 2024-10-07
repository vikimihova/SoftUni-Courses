using System;
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
            public const int GenreMaxLength = 20;
            public const int DirectorMaxLength = 80;
            public const int DescriptionMaxLength = 500;
        }
    }
}
