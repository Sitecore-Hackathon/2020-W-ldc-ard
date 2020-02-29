using Hackathon.Boilerplate.Feature.UserGroup.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using Sitecore.XA.Foundation.RenderingVariants.Repositories;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Hackathon.Boilerplate.Foundation.DependencyInjection;

namespace Hackathon.Boilerplate.Feature.UserGroup.Repositories
{
    [Service(typeof(IUserGroupHeaderRepository))]
    public class UserGroupHeaderRepository : VariantsRepository, IUserGroupHeaderRepository
    {
        public override IRenderingModelBase GetModel()
        {
            UserGroupHeader viewModel = new UserGroupHeader();
            UserGroupHeaderProperties(viewModel);
            FillBaseProperties(viewModel);
            return base.GetModel();
        }

        public void UserGroupHeaderProperties(UserGroupHeader model)
        {
            string dataSource = RenderingContext.Current.Rendering.DataSource;
            if(string.IsNullOrEmpty(dataSource))
            {
                Item itemUserGroupHeader = Sitecore.Context.Database.GetItem(dataSource);
                Item currentItem = Sitecore.Context.Item;
                if(itemUserGroupHeader != null && currentItem != null)
                {
                    
                    ImageField userGroupLocationId = itemUserGroupHeader.Fields[UserGroupConstant.UserGroupLocationIcon];
                    model.UserGroupLocationIcon = GetIconUrl(userGroupLocationId);
                    ImageField userGroupMemberIconId = itemUserGroupHeader.Fields[UserGroupConstant.UserGroupMemberIcon];
                    model.UserGroupMemberIcon = GetIconUrl(userGroupMemberIconId);
                    ImageField userGroupOrganisationIconId = itemUserGroupHeader.Fields[UserGroupConstant.UserGroupOrganiserICon];
                    model.UserGroupOrganiserICon = GetIconUrl(userGroupOrganisationIconId);
                    model.UserGroupLocation = currentItem[UserGroupConstant.UserGroupLocation];
                    MultilistField orgainsers = currentItem.Fields[UserGroupConstant.UserGroupOrganizer];
                    Item[] _organizers = orgainsers.GetItems();
                    
                    if(_organizers.Length > 0)
                    {
                        foreach(var item in _organizers)
                        {
                            model.UserGroupOrganizer += item["Name"];
                        }
                    }
                    //ToDo Count the Member using search
                    model.UserGroupMembers = "345";
                }
            }
        }

        private string GetIconUrl(ImageField iconId)
        {
            string iconUrl = string.Empty;
            MediaItem iconItem = new MediaItem(iconId.MediaItem);
            iconUrl = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(iconItem));
            return iconUrl;
        }
    }
}