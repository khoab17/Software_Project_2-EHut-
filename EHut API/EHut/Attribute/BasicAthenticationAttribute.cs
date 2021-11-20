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
    public class BasicAthenticationAttribute : AuthorizationFilterAttribute
    {
        
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if(actionContext.Request.Headers.Authorization==null)
            {
                ///
                /// Hard Coded Authentication for Testing-----------------------------------> beginig
                /// 

                // FROMAT: string who = id.ToString() + ':' + userType;    
                /*string admin = "1:Admin";
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(admin), null);*/

                ///
                /// <-----------------------------------Hard Coded Authentication for Testing ending
                ///

                /// Remove comment from line 38 or bellow line to use System Authorization
                 actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                
                string encode = actionContext.Request.Headers.Authorization.ToString();
                string decode = Encoding.UTF8.GetString(Convert.FromBase64String(encode));
                string[] splitedText = decode.Split(new char[] { ':' });
                string userId = splitedText[0];
                string password = splitedText[1];


                ///
                /// System Authentication ----------------------------------->beginig
                /// 
                int id = int.Parse(userId);

                CredentialService credentialservice = new CredentialService();
                Credential credential = credentialservice.GetByUserId(id);
                if (credential == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }
                else
                {
                    if (credential.UserId == id && credential.Password == password)
                    {
                        //Authorized
                        string userType = credential.Role;
                        string who = id.ToString() + ':' + userType;   //UserId and Role as a single string for better accessibility 
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(who), null);
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                    }

                }
                ///
                /// <----------------------------------- System Authentication ending
                ///

            }

        }
    }
}