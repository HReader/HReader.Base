namespace HReader.Base.Data
{
    public class Tag
    {
        public Tag(string value)
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
