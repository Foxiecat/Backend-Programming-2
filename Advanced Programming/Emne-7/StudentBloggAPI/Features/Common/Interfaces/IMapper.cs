namespace StudentBloggAPI.Features.Common.Interfaces;

public interface IMapper<TEntity, TEntityDTO>
{
    TEntityDTO MapToDTO(TEntity entity);
    TEntity MapToModel(TEntityDTO entityDTO);
}