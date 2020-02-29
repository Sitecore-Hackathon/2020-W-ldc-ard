using Sitecore.XA.Foundation.Variants.Abstractions.Models;

namespace Hackathon.Boilerplate.Feature.UserGroup.Models
{
    public class UserGroupHeader : VariantsRenderingModel
    {
        public string UserGroupLocationIcon { get; set; }
        public string UserGroupMemberIcon { get; set; }
        public string UserGroupOrganiserICon { get; set; }
        public string UserGroupLocation { get; set; }
        public string UserGroupMembers { get; set; }
        public string UserGroupOrganizer { get; set; }
    }
}