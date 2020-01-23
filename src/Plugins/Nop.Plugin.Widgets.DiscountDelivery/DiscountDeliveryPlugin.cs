using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.DiscountDelivery
{
    public class DiscountDeliveryPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        public DiscountDeliveryPlugin(ILocalizationService localizationService,
            ISettingService settingService,
            IWebHelper webHelper)
        {
            _localizationService = localizationService;
            _settingService = settingService;
            _webHelper = webHelper;
        }

        public bool HideInWidgetList => false;

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsDiscountDelivery";
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.ProductDetailsDiscountDelivery };
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsDiscountDelivery/Configure";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //settings
            var settings = new DiscountDeliverySettings
            {
                TextDiscount = "При заказе до 1 декабря скидка на доставку 50%",
            };

            _settingService.SaveSetting(settings);

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.DiscountDelivery.TextDiscount", "Text Discount");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.DiscountDelivery.TextDiscount.Hint", "Enter text discount.");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<DiscountDeliverySettings>();

            //locales
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.DiscountDelivery.TextDiscount");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.DiscountDelivery.TextDiscount.Hint");

            base.Uninstall();
        }
    }
}
