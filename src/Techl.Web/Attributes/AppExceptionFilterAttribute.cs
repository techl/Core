// Copyright (c) techl.com All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Techl.Web
{
    public class AppExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.HttpContext.Request.IsAjaxRequest() && context.Exception != null)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new JsonResult
                (
                    new
                    {
                        context.Exception.Message,
                        context.Exception.StackTrace
                    }
                );
            }
            else
            {
                base.OnException(context);
            }
        }
    }
}
