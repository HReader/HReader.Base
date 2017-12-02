namespace HReader.Base.Data
{
    public class Language
    {
        public static Language Unknown { get; } = new Language(string.Empty);

        public Language(string value)
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
