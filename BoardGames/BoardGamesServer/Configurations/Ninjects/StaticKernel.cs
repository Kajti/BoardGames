﻿using System.Reflection;
using Ninject;
using Ninject.Parameters;

namespace BoardGamesServer.Configurations
{
    internal sealed class StaticKernel
    {
        private static readonly StaticKernel instance = new StaticKernel();

        private IKernel kernelGet;

        public StaticKernel()
        {
            kernelGet = new StandardKernel();
            kernelGet.Load(Assembly.GetExecutingAssembly());
        }

        public static T Get<T>()
        {
            return instance.kernelGet.Get<T>();
        }

        public static T Get<T>(ConstructorArgument argument)
        {
            return instance.kernelGet.Get<T>(argument);
        }

        public static T Get<T>(string variableName, object value)
        {
            return instance.kernelGet.Get<T>(new ConstructorArgument(variableName, value));
        }
    }
}
