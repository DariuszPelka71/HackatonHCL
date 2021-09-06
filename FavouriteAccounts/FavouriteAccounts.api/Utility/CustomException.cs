﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FavouriteAccounts.api.Utility
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
        public CustomException(string message, Exception innerException) : base(message, innerException) { }
    }
}