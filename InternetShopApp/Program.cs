using InternetShopBusinessLogic.BusinessLogic;
using InternetShopContracts.BusinessLogicsContracts;
using InternetShopContracts.StorageContracts;
using InternetShopDatabaseImplement.implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace InternetShopApp
{
    static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IOrderLogic, OrderLogic>();
            currentContainer.RegisterType<IOrderStatusLogic, OrderStatusLogic>();
            currentContainer.RegisterType<IOrderStorage, OrderStorage>();
            currentContainer.RegisterType<IOrderStatusStorage, OrderStatusStorage>();
            return currentContainer;
        }
    }
}
