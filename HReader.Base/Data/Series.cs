namespace HReader.Base.Data
{
    public class Series
    {
        public Series(string value)
        {
            Value = value;
        }

        public string Value { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return Value ?? "<null>";
        }
    }
}
