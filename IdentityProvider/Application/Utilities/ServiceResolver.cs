using Elect.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Utilities
{
    public delegate IService ServiceResolver(string key);

    public interface IService { }

    [ScopedDependency]
    public class ServiceA : IService { }
    [ScopedDependency]
    public class ServiceB : IService { }
}
