namespace Plex.ServerApi.Helpers
{
    using System;
    using System.Buffers;
    using System.Buffers.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    ///
    /// </summary>
    public class IntValueConverter : JsonConverter<int>
    {
        /// <inheritdoc />
        public override int Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                // try to parse number directly from bytes
                var span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;
                if (Utf8Parser.TryParse(span, out int number, out int bytesConsumed) && span.Length == bytesConsumed)
                {
                    return number;
                }

                // try to parse from a string if the above failed, this covers cases with other escaped/UTF characters
                if (int.TryParse(reader.GetString(), out number))
                {
                    return number;
                }
            }

            // fallback to default handling
            return reader.GetInt32();
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
