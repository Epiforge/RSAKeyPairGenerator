using Cogs.Components;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace RSAKeyPairGenerator
{
    public class MainWindowDataContext : PropertyChangeNotifier
    {
        DisplayMode displayMode;
        bool isKeyPairGenerated;
        IReadOnlyCollection<byte> privateKey;
        IReadOnlyCollection<byte> publicKey;

        public Task GenerateKeyPairAsync() => Task.Run(() =>
        {
            using var rsa = new RSACryptoServiceProvider();
            PublicKey = rsa.ExportRSAPublicKey();
            PrivateKey = rsa.ExportRSAPrivateKey();
            IsKeyPairGenerated = true;
        });

        string GetKeyText(IReadOnlyCollection<byte> key) => DisplayMode switch
        {
            DisplayMode.CSharp => Utilities.ConvertToCSharp(key),
            DisplayMode.Hex => Utilities.ConvertToHex(key),
            _ => throw new NotSupportedException()
        };

        public string GetPrivateKeyText() => GetKeyText(PrivateKey);

        public string GetPublicKeyText() => GetKeyText(PublicKey);

        public DisplayMode DisplayMode
        {
            get => displayMode;
            set => SetBackedProperty(ref displayMode, in value);
        }

        public bool IsKeyPairGenerated
        {
            get => isKeyPairGenerated;
            private set => SetBackedProperty(ref isKeyPairGenerated, in value);
        }

        public IReadOnlyCollection<byte> PrivateKey
        {
            get => privateKey;
            private set => SetBackedProperty(ref privateKey, in value);
        }

        public IReadOnlyCollection<byte> PublicKey
        {
            get => publicKey;
            private set => SetBackedProperty(ref publicKey, in value);
        }
    }
}
