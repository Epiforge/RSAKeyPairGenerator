using Cogs.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace RSAKeyPairGenerator
{
    public class MainWindowDataContext : PropertyChangeNotifier
    {
        DisplayMode displayMode;
        bool isKeyPairGenerated;
        KeyMode keyMode;
        IReadOnlyCollection<byte> privateKey;
        IReadOnlyCollection<byte> privateCspBlob;
        IReadOnlyCollection<byte> publicKey;
        IReadOnlyCollection<byte> publicCspBlob;

        public Task GenerateKeyPairAsync() => Task.Run(() =>
        {
            using var rsa = new RSACryptoServiceProvider();
            PublicKey = rsa.ExportRSAPublicKey();
            PublicCspBlob = rsa.ExportCspBlob(false);
            PrivateKey = rsa.ExportRSAPrivateKey();
            PrivateCspBlob = rsa.ExportCspBlob(true);
            IsKeyPairGenerated = true;
        });

        string GetKeyText(IReadOnlyCollection<byte> key) => DisplayMode switch
        {
            DisplayMode.CSharp => Utilities.ConvertToCSharp(key),
            DisplayMode.Hex => Utilities.ConvertToHex(key),
            _ => throw new NotSupportedException()
        };

        public string GetPrivateKeyText() => GetKeyText(KeyMode switch
        {
            KeyMode.CspBlob => PrivateCspBlob,
            KeyMode.Raw => PrivateKey,
            _ => throw new NotSupportedException()
        });

        public string GetPublicKeyText() => GetKeyText(KeyMode switch
        {
            KeyMode.CspBlob => PublicCspBlob,
            KeyMode.Raw => PublicKey,
            _ => throw new NotSupportedException()
        });

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

        public KeyMode KeyMode
        {
            get => keyMode;
            set => SetBackedProperty(ref keyMode, in value);
        }

        public IReadOnlyCollection<byte> PrivateKey
        {
            get => privateKey;
            private set => SetBackedProperty(ref privateKey, in value);
        }

        public IReadOnlyCollection<byte> PrivateCspBlob
        {
            get => privateCspBlob;
            private set => SetBackedProperty(ref privateCspBlob, in value);
        }

        public IReadOnlyCollection<byte> PublicKey
        {
            get => publicKey;
            private set => SetBackedProperty(ref publicKey, in value);
        }

        public IReadOnlyCollection<byte> PublicCspBlob
        {
            get => publicCspBlob;
            private set => SetBackedProperty(ref publicCspBlob, in value);
        }
    }
}
