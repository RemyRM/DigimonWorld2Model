namespace DW2ModelParser.Interfaces
{
    internal interface ICoordinate
    {
        short X { get; }
        short Y { get; }
        short Z { get; }

        string ToHexString();
    }
}
