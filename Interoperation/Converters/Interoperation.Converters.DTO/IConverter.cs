namespace Interoperation.Converters.DTO
{
    public interface IConverter<TSource, TTarget>
    {
        TTarget Convert(TSource source);
    }
}
