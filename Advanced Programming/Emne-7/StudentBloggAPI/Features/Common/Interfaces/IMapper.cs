namespace StudentBloggAPI.Features.Common.Interfaces;

public interface IMapper<TModel, TDto>
{
    TDto MapToDTO(TModel entity);
    TModel MapToModel(TDto entityDTO);
}