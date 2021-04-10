namespace MapperLibrary.Interfaces
{
    public interface IMapperType<in TSource, out TDestination>
    {
        TDestination Map(TSource T);
    }
}
