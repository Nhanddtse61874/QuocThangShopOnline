using Persistence.EnitityModel;

namespace LogicHandler.RepositoryInterface
{
    public interface IImageStorageRepository
    {
        Task AddAsync(ImageStorage entity);

        Task AddRangeAsync(IEnumerable<ImageStorage> entities);

        Task DeleteAsync(int id);

        void DeleteRange(List<ImageStorage> entities);

        Task ModifyAsync(ImageStorage entity);
    }
}
