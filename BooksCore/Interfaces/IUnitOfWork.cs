using System;
using System.Threading.Tasks;

namespace RollBack_Core.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}