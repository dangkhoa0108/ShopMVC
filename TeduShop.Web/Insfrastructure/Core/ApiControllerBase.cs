using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;

namespace TeduShop.Web.Insfrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private IErrorService _errorService;

        public ApiControllerBase(IErrorService errorService)
        {
            this._errorService = errorService;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage httpRequestMessage,
            Func<HttpResponseMessage> function)
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
                LogError(ex);
                if (ex.InnerException != null)
                    response = httpRequestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (DbUpdateException dbEx)
            {
                LogError(dbEx);
                if (dbEx.InnerException != null)
                    response = httpRequestMessage.CreateResponse(HttpStatusCode.BadRequest,
                        dbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = httpRequestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }
        private void LogError(Exception e)
        {
            try
            {
                Error error = new Error
                {
                    CreateDate = DateTime.Now,
                    Message = e.Message,
                    StackTrace = e.StackTrace
                };
                _errorService.CreateError(error);
                _errorService.Save();
            }
            catch
            {

            }
        }
    }
}
