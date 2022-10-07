using InternetShopContracts.BindingModels;
using InternetShopContracts.ViewModels;
using System.Collections.Generic;

namespace InternetShopContracts.BusinessLogicsContracts
{
    public interface IOrderStatusLogic
    {
        List<OrderStatusViewModel> Read(OrderStatusBindingModel model);
        void CreateOrUpdate(OrderStatusBindingModel model);
        void Delete(OrderStatusBindingModel model);
    }
}
