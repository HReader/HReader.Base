namespace HReader.Base.Data
{
    public class Character
    {
        public Character(string value)
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
