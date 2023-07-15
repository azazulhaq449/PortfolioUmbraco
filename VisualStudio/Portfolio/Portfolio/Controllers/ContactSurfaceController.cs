using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Portfolio.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Portfolio.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        private IPublishedContentQuery _publishedContentQuery;

        public ContactSurfaceController(IPublishedContentQuery publishedContentQuery)
        {
            _publishedContentQuery = publishedContentQuery;
        }

        public ActionResult RenderForm()
        {
            return View("Contact.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ContactModel model)
        {
            var a = UmbracoContext.Content.GetByRoute("/contact");
            var b = UmbracoContext.Content.GetRouteById(1083);
            if (ModelState.IsValid)
            {
                SendEmail(model);
                return RedirectToCurrentUmbracoPage();
            }

            return CurrentUmbracoPage();
        }

        private void SendEmail(ContactModel contact)
        {
            MailMessage message = new MailMessage(contact.Email, "");

        }
    }
}