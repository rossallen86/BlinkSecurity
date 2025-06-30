using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;


public static partial class BlinkMapper
{
    public static Accessories Map(AccessoriesDto x)
    {
        return new()
        {
            Storm = Map(x.storm),
            Rosie = Map(x.rosie),
            Superior = Map(x.superior)
        };
    }
};