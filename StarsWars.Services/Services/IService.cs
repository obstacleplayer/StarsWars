using System;
using System.Collections.Generic;
using System.Text;

namespace StarsWars.Services.Services
{
    public interface IService<T> where T : class
    {
        T Get();
    }
}
