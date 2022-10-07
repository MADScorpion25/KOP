using InternetShopContracts.BindingModels;
using InternetShopContracts.BusinessLogicsContracts;
using InternetShopContracts.StorageContracts;
using InternetShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopBusinessLogic.BusinessLogic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        public OrderLogic(IOrderStorage OrderStorage)
        {
            _orderStorage = OrderStorage;
        }
        public void CreateOrUpdate(OrderBindingModel model)
        {
            var element = _orderStorage.GetElement(
                new OrderBindingModel
                {
                    CustomerFIO = model.CustomerFIO,
                    OrderStatus = model.OrderStatus,
                    ProductDescription = model.ProductDescription,
                    OrderSum = model.OrderSum
                });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Заказ с таким названием уже существует");
            }
            if (model.Id.HasValue)
            {
                _orderStorage.Update(model);
            }
            else
            {
                _orderStorage.Insert(model);
            }
        }

        public void Delete(OrderBindingModel model)
        {
            var element = _orderStorage.GetElement(new OrderBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Заказ не найден");
            }
            _orderStorage.Delete(model);
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }
    }
}
