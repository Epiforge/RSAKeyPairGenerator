using System.Collections.Generic;
using System.Linq;

namespace RSAKeyPairGenerator
{
    public static class Utilities
    {
        public static string ConvertToCSharp(IReadOnlyCollection<byte> bytes) =>
            $"new byte[] {{ {string.Join(", ", bytes.Select(b => $"0x{b:x2}"))} }}";

        public static string ConvertToHex(IReadOnlyCollection<byte> bytes) =>
            string.Join(string.Empty, bytes.Select(b => $"{b:x2}"));
    }
}
