using InternetShopContracts.BindingModels;
using InternetShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopContracts.StorageContracts
{
    public interface IOrderStorage
    {
        List<OrderViewModel> GetFullList();
        List<OrderViewModel> GetFilteredList(OrderBindingModel model);
        OrderViewModel GetElement(OrderBindingModel model);
        void Insert(OrderBindingModel model);
        void Update(OrderBindingModel model);
        void Delete(OrderBindingModel model);
    }
}
