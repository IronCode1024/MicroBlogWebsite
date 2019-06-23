using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroBlogWebsite
{
    class RequestValidatorDisabled : System.Web.Util.RequestValidator
    {
        protected override bool IsValidRequestString(System.Web.HttpContext context, string value, System.Web.Util.RequestValidationSource requestValidationSource, string collectionKey, out int validationFailureIndex)
        {
            validationFailureIndex = -1; 
            return true;
        }
    }
}