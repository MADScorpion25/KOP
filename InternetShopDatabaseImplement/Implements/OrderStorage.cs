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
    public class OrderStorage : IOrderStorage
    {
        public void Delete(OrderBindingModel model)
        {
            var context = new InternetShopDatabase();
            var order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Заказ не найден");
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new InternetShopDatabase())
            {
                var order = context.Orders
                    .ToList()
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ? CreateModel(order) : null;
            }
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            var context = new InternetShopDatabase();
            return context.Orders
                .Where(order => order.OrderSum.Equals("оплачен скидками"))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public List<OrderViewModel> GetFullList()
        {
            using (var context = new InternetShopDatabase())
            {
                return context.Orders
                .ToList()
                .Select(CreateModel)
                .ToList();
            }
        }

        public void Insert(OrderBindingModel model)
        {
            var context = new InternetShopDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                Order order = new Order
                {
                    CustomerFIO = model.CustomerFIO,
                    OrderStatus = model.OrderStatus,
                    ProductDescription = model.ProductDescription,
                    OrderSum = model.OrderSum
                };
                context.Orders.Add(order);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(OrderBindingModel model)
        {
            var context = new InternetShopDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order == null)
                {
                    throw new Exception("Заказ не найден");
                }
                order.CustomerFIO = model.CustomerFIO;
                order.OrderStatus = model.OrderStatus;
                order.ProductDescription = model.ProductDescription;
                order.OrderSum = model.OrderSum;
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        private OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                CustomerFIO = order.CustomerFIO,
                OrderStatus = order.OrderStatus,
                ProductDescription = order.ProductDescription,
                OrderSum = order.OrderSum
            };
        }
    }
}
