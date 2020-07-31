using System.Collections.Generic;

namespace SMS.Services.Infrastructure
{
    public interface IBaseService<T>
    {
        IEnumerable<T> RequestGetAll();
    }
}
