using InternetShopContracts.BindingModels;
using InternetShopContracts.StorageContracts;
using InternetShopContracts.ViewModels;
using InternetShopDatabaseImplement.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternetShopDatabaseImplement.implements
{
    public class OrderStatusStorage : IOrderStatusStorage
    {
        public void Delete(OrderStatusBindingModel model)
        {
            var context = new InternetShopDatabase();
            var orderStatus = context.OrderStatuses.FirstOrDefault(rec => rec.Id == model.Id);
            if (orderStatus != null)
            {
                context.OrderStatuses.Remove(orderStatus);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Статус заказа не найден");
            }
        }

        public OrderStatusViewModel GetElement(OrderStatusBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var context = new InternetShopDatabase();
            var orderStatus = context.OrderStatuses
                .ToList()
                .FirstOrDefault(rec => rec.Id == model.Id);
            return orderStatus != null ? CreateModel(orderStatus) : null;
        }

        public List<OrderStatusViewModel> GetFilteredList(OrderStatusBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<OrderStatusViewModel> GetFullList()
        {
            var context = new InternetShopDatabase();
            return context.OrderStatuses
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public void Insert(OrderStatusBindingModel model)
        {
            var context = new InternetShopDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                OrderStatus order = new OrderStatus
                {
                    Status = model.Status
                };
                context.OrderStatuses.Add(order);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(OrderStatusBindingModel model)
        {
            var context = new InternetShopDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var orderStatus = context.OrderStatuses.FirstOrDefault(rec => rec.Id == model.Id);
                if (orderStatus == null)
                {
                    throw new Exception("Статус заказа не найден");
                }
                orderStatus.Status = model.Status;
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        private OrderStatusViewModel CreateModel(OrderStatus order)
        {
            return new OrderStatusViewModel
            {
                Id = order.Id,
                Status = order.Status
            };
        }
    }
}
