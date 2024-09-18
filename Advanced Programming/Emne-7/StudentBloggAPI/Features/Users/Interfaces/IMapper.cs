namespace StudentBloggAPI.Features.Users.Interfaces;

public interface IMapper<TModel, TEntity>
{
    TEntity MapToDTO(TModel model);
    TModel MapToModel(TEntity entityDTO);
}