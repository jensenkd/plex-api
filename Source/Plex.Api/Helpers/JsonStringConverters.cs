namespace Plex.Api.Helpers
{
    using System;
    using System.Buffers;
    using System.Buffers.Text;
    using System.Globalization;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    ///
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

    /// <summary>
    ///
    /// </summary>
    public class DoubleValueConverter : JsonConverter<double>
    {
        /// <inheritdoc/>
        public override double Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                // try to parse number directly from bytes
                var span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;
                if (Utf8Parser.TryParse(span, out double number, out int bytesConsumed) && span.Length == bytesConsumed)
                {
                    return number;
                }

                // try to parse from a string if the above failed, this covers cases with other escaped/UTF characters
                if (double.TryParse(reader.GetString(), out number))
                {
                    return number;
                }
            }

            // fallback to default handling
            return reader.GetDouble();
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
        }
    }

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
                if (Utf8Parser.TryParse(span, out bool boolean, out int bytesConsumed) && span.Length == bytesConsumed)
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
        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
