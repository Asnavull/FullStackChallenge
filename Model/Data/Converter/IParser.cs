using System.Collections.Generic;

namespace Model.Data.Converter
{
    internal interface IParser<O, D>
    {
        D Parse(O origin);

        List<D> ParseList(List<O> origin);
    }
}