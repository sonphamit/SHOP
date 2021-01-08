using System;

namespace SharedCore.Helpers
{
    public static class CommonHelper
    {
        public static string NewGuid()
        {
            var guid = Guid.NewGuid().ToString("N");
            return guid;
        }
    }
}
