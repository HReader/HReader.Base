namespace HReader.Base.Data
{
    public class Artist
    {
        public Artist(string value)
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
