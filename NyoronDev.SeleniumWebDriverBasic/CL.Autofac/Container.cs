using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using OpenQA.Selenium;
using PO.Factory;
using PO.Factory.Contracts;

namespace CL.Autofac
{
    /// <summary>
    /// IoC with Autofac
    /// </summary>
    public static class Container
    {
        //Properties
        #region .: Properties

        public static IContainer BuildContainer { get; set; }

        #endregion

        //Constructor

        /// <summary>
        /// Initializes the <see cref="Container"/> class.
        /// </summary>
        static Container()
        {
            var c = new ContainerBuilder();

            c.RegisterType<Index>().As<IIndex>();
            c.RegisterType<Managerhomepage>().As<IManagerhomepage>();

            BuildContainer = c.Build();
        }
    }
}
