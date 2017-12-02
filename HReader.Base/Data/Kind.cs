namespace HReader.Base.Data
{
    public class Kind
    {
        public static Kind Unknown { get; } = new Kind(string.Empty);

        public Kind(string value)
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
