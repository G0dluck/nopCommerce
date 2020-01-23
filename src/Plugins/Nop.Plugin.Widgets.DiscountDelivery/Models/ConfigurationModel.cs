using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.DiscountDelivery.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }
        
        [NopResourceDisplayName("Plugins.Widgets.DiscountDelivery.TextDiscount")]
        public string TextDiscount { get; set; }
        public bool TextDiscount_OverrideForStore { get; set; }
    }
}