﻿using InternetShopContracts.BindingModels;
using InternetShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopContracts.BusinessLogicsContracts
{
    public interface IOrderLogic
    {
        List<OrderViewModel> Read(OrderBindingModel model);
        void CreateOrUpdate(OrderBindingModel model);
        void Delete(OrderBindingModel model);
    }
}
