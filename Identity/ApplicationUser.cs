
using Microsoft.AspNetCore.Identity;

namespace Taf.Cor.Net
{
    public class ApplicationUser:IdentityUser<int>
    {
        public override int    Id                { get; set; }
        public          string AuthenticationType{ get; set; }
        public          bool   IsAuthenticated   { get; set; }
        public          string Name              { get; set; }
    }
}
