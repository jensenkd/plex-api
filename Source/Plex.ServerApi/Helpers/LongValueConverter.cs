namespace Plex.ServerApi.Helpers
{
    using System;
    using System.Buffers;
    using System.Buffers.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Long Value Converter
    /// </summary>
    public class LongValueConverter : JsonConverter<long>
    {
        /// <inheritdoc/>
        public override long Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                // try to parse number directly from bytes
                var span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;
                if (Utf8Parser.TryParse(span, out long number, out int bytesConsumed) && span.Length == bytesConsumed)
                {
                    return number;
                }

                // try to parse from a string if the above failed, this covers cases with other escaped/UTF characters
                if (long.TryParse(reader.GetString(), out number))
                {
                    return number;
                }
            }

            // fallback to default handling
            return reader.GetInt64();
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
