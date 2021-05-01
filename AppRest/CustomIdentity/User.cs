using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Share.Entities;

namespace WEBAPI_CustomAuth.CustomIdentity
{
    public class User : IUser
    {
        public string UserName { get; set; }
        public string Id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string password { get; set; }
        public string rol { get; set; }
        public string SecurityStamp { get; internal set; }
    }
}