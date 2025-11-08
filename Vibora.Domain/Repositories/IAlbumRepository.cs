using Vibora.Domain.Entities;

namespace Vibora.Domain.Repositories;

public interface IAlbumRepository
{
    Task Add(Album album);
    Task<Album> GetById(Guid id);
    Task<IEnumerable<Album>> GetAll();
    Task Delete(Album album);
}
