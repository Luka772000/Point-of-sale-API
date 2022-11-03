using System;
namespace POS_Backend.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProizvod Proizvodi { get; }
        int Complete();
    }
}
