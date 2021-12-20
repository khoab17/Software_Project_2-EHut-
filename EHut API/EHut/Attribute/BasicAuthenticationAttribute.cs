using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EHut.Attribute
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        string[] roles = { "Admin", "HR", "Customer", "Accountant", "DM", "Shop" };
        
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var auth = actionContext.Request.Headers.Authorization;
            
            if(actionContext.Request.Headers.Authorization==null)
            {
                
                 actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                
                try
                {
                    string encode = actionContext.Request.Headers.Authorization.Parameter.ToString();
                    string decode = Encoding.UTF8.GetString(Convert.FromBase64String(encode));
                    string[] splitedText = decode.Split(new char[] { ':' });
                    string userPhone = splitedText[0];
                    string password = splitedText[1];


                    ///
                    /// System Authentication ----------------------------------->beginig
                    /// 
                    CredentialService credentialservice = new CredentialService();
                    Credential credential = credentialservice.GetByPhone(userPhone);
                    if (credential == null)
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                    }
                    else
                    {
                        if (credential.Phone == userPhone && credential.Password == password)
                        {
                            string userType = credential.Role;
                            GenericIdentity genericIdentity = new GenericIdentity(userPhone,userType);
                            Thread.CurrentPrincipal = new GenericPrincipal(genericIdentity, roles);
                        }
                        else
                        {
                            actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                        }

                    }
                    
                }
                catch(Exception e)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }
                ///
                /// <----------------------------------- System Authentication ending
                ///

            }
            base.OnAuthorization(actionContext);


        }
    }
}