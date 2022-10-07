using InternetShopContracts.BindingModels;
using InternetShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopContracts.StorageContracts
{
    public interface IOrderStatusStorage
    {
        List<OrderStatusViewModel> GetFullList();
        List<OrderStatusViewModel> GetFilteredList(OrderStatusBindingModel model);
        OrderStatusViewModel GetElement(OrderStatusBindingModel model);
        void Insert(OrderStatusBindingModel model);
        void Update(OrderStatusBindingModel model);
        void Delete(OrderStatusBindingModel model);
    }
}
