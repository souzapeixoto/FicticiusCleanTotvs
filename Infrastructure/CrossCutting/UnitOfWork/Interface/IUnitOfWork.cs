namespace Infrastructure.CrossCutting.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        void Atached(object entity);
        void Detached(object entity);
        int Commit();
        void Dispose();
    }
}
