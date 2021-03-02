namespace Plex.Api.Helpers
{
    using System;
    using System.Buffers;
    using System.Buffers.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    ///
    /// </summary>
    public class BooleanValueConverter : JsonConverter<bool>
    {
        /// <inheritdoc />
        public override bool Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                if (string.Equals("1", reader.GetString(), StringComparison.OrdinalIgnoreCase) ||
                    string.Equals("0", reader.GetString(), StringComparison.OrdinalIgnoreCase))
                {
                    return Convert.ToBoolean(Convert.ToInt16(reader.GetString()));
                }

                // try to parse number directly from bytes
                var span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;
                if (Utf8Parser.TryParse(span, out bool boolean, out var bytesConsumed) && span.Length == bytesConsumed)
                {
                    return boolean;
                }

                // try to parse from a string if the above failed, this covers cases with other escaped/UTF characters
                if (bool.TryParse(reader.GetString(), out boolean))
                {
                    return boolean;
                }
            }

            // fallback to default handling
            return reader.GetBoolean();
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) =>
            writer.WriteStringValue(value.ToString());
    }
}
