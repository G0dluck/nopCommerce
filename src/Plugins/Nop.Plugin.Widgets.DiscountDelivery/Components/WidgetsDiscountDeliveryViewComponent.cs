using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.DiscountDelivery.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;
using System;

namespace Nop.Plugin.Widgets.DiscountDelivery.Components
{
    [ViewComponent(Name = "WidgetsDiscountDelivery")]
    public class WidgetsDiscountDeliveryViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _cacheManager;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        public WidgetsDiscountDeliveryViewComponent(IStoreContext storeContext,
            IStaticCacheManager cacheManager,
            ISettingService settingService,
            IWebHelper webHelper)
        {
            _storeContext = storeContext;
            _cacheManager = cacheManager;
            _settingService = settingService;
            _webHelper = webHelper;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var discountDeliverySettings = _settingService.LoadSetting<DiscountDeliverySettings>(_storeContext.CurrentStore.Id);

            var model = new PublicInfoModel
            {
                TextDiscount = discountDeliverySettings.TextDiscount
            };

            return View("~/Plugins/Nop.Plugin.Widgets.DiscountDelivery/Views/PublicInfo.cshtml", model);
        }
    }
}
