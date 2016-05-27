using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SIGHT1.model;
using SIGHT1.mail;

namespace SIGHT1.Controller.API
{
    public class MessageController : ApiController
    {


        // POST: api/Message
        public HttpResponseMessage Post(MessageModel messageModel)
        {
            try
            {
                 mailBLL.sendMessage(messageModel);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
