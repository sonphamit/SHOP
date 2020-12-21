using System;

namespace Core.Helpers
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
