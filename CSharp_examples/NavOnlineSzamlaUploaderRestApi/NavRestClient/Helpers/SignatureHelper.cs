using Org.BouncyCastle.Crypto.Digests;
using System.Text;

namespace NavRestClient.Helpers
{
    public static class SignatureHelper
    {
        public static string CalculateSignature(string user, string requestId, string timestamp, string signatureKey)
        {
            string data = user + requestId + timestamp + signatureKey;
            byte[] bytes = Encoding.UTF8.GetBytes(data);

            var digest = new Sha3Digest(512);
            digest.BlockUpdate(bytes, 0, bytes.Length);

            byte[] result = new byte[digest.GetDigestSize()];
            digest.DoFinal(result, 0);

            return BitConverter.ToString(result).Replace("-", "").ToLowerInvariant();
        }
    }
}