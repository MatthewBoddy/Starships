// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("xl5biIoMQk588T6SN1tEJFRH3cpG0x+1Jj7sCoFvGY2oWUK4d2ao/a3wW//cKgbSu4icP45gcOoFT2ffUEVdYhcfluIyYclApyePUQOgSBmkJykmFqQnLCSkJycm+94ePHVRjxakJwQWKyAvDKBuoNErJycnIyYlzXiKamDW2xx7kKcHG8dRZI5gGe1XjJjCpVQrJtRTIqMgI6Oa1BArJ+DaQdRzjZrIRe4g2AjRWFysbWkhyoAMjKCcweWNKg1k24zcq5goAUZa1Q23UnDU9FYbGvliz0N378swvTEigBGX9Dlx0TbphQJQEkT4f5s7/E3UumzVol+oZ9QIP1QS1JWIGngRh20CSIQVjZMPiFx6UAz+5+pMnVYUXBrF+LugByQlJyYn");
        private static int[] order = new int[] { 10,3,11,9,9,10,10,8,13,10,12,13,13,13,14 };
        private static int key = 38;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
