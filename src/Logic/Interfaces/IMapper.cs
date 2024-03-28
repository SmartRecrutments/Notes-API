namespace Logic.Interfaces
{
    public interface IMapper<in TIn, out TOut>
    {
        TOut Map(TIn model);
    }
}