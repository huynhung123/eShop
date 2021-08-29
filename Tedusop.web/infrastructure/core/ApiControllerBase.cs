using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tedusop.Service;
using Tedusop.Model.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Tedusop.web.infrastructure.core
{

    public abstract class ApiControllerBase : ApiController
    {
    protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requesMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            try
            {
                response = function.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
            }

            catch (DbUpdateException dbex)
            {
                LogError(dbex);
                response = requesMessage.CreateResponse(HttpStatusCode.BadRequest, dbex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = requesMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        private void LogError(Exception ex)
        {
            try
            {
                Eurrors eurror = new Eurrors();
                eurror.CreatedDate = DateTime.Now;
                eurror.Message = ex.Message;
                eurror.StackTrace = ex.StackTrace;
            }
            catch
            {

            }
        }
    }
}
