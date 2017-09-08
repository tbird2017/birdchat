using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdChat_Lib
{
   public static class StringExtension
    {
        public static string CropUntilMsgEndSign(this string s)
        {
            return  s.Substring(0, s.IndexOf(Settings.Default.MsgEndString));
        }

        public static string CropUntilLeftChatSign(this string s)
        {
            return s.Substring(0, s.IndexOf(Settings.Default.LeftChatString));
        }
    }
}
