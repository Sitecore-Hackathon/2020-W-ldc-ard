using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Boilerplate.Feature.Social.Models
{
    public class ShareIconModel : VariantsRenderingModel
    {
        public string FacebookIcon { get; set; }
        public string TwitterIcon { get; set; }
        public string LinkedinIcon { get; set; }
    }
}