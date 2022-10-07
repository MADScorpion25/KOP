using InternetShopContracts.BindingModels;
using InternetShopContracts.BusinessLogicsContracts;
using InternetShopContracts.StorageContracts;
using InternetShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopBusinessLogic.BusinessLogic
{
    public class OrderStatusLogic : IOrderStatusLogic
    {
        private readonly IOrderStatusStorage _orderStatusStorage;
        public OrderStatusLogic(IOrderStatusStorage orderStatusStorage)
        {
            _orderStatusStorage = orderStatusStorage;
        }
        public void CreateOrUpdate(OrderStatusBindingModel model)
        {
            var element = _orderStatusStorage.GetElement(
                new OrderStatusBindingModel
                {
                    Status = model.Status
                });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Статус заказа уже существует");
            }
            if (model.Id.HasValue)
            {
                _orderStatusStorage.Update(model);
            }
            else
            {
                _orderStatusStorage.Insert(model);
            }
        }

        public void Delete(OrderStatusBindingModel model)
        {
            var element = _orderStatusStorage.GetElement(new OrderStatusBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Статус заказа не найден");
            }
            _orderStatusStorage.Delete(model);
        }

        public List<OrderStatusViewModel> Read(OrderStatusBindingModel model)
        {
            if (model == null)
            {
                return _orderStatusStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderStatusViewModel> { _orderStatusStorage.GetElement(model) };
            }
            return _orderStatusStorage.GetFilteredList(model);
        }
    }
}
