using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleSingletonDI.Singleton
{
    public sealed class SingletonSealed
    {
        private static readonly SingletonSealed instance = new SingletonSealed();
        
        private SingletonSealed(){}

        public static SingletonSealed Instance
        {
            get 
            {
                return instance; 
            }
        }
    }
}