using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static Phone Map(PhoneDto x)
    {
        return new()
        {
            Number = x.number,
            Last4Digits = x.last_4_digits,
            CountryCallingCode = x.country_calling_code,
            Valid = x.valid
        };
    }

    public static PhoneDto Map(Phone x)
    {
        return new()
        {
            number = x.Number,
            last_4_digits = x.Last4Digits,
            country_calling_code = x.CountryCallingCode,
            valid = x.Valid
        };
    }
}
