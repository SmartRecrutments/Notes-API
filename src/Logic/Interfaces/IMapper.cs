namespace Logic.Interfaces
{
    public interface IMapper<In, Out>
    {
        Out Map(In model);
    }
}