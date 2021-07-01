using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.PortableExecutable;

namespace ServerInfo
{
    public static class Utils
    {
        public static string FromBytesToString(long byteCount)
        {
                string[] suf = { "B", "KiB", "MiB", "GiB", "TiB", "PiB", "EiB" }; //Longs run out around EB
                if (byteCount == 0)
                {
                    return "0" + suf[0];
                }
                long bytes = Math.Abs(byteCount);
                int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
                double num = Math.Round(bytes / Math.Pow(1024, place), 1);
                return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        public static string FromBitsToString(long bitCount)
        {
                string[] suf = { "b", "Kb", "Mb", "Gb", "Tb", "Pb", "Eb" }; //Longs run out around EB
                if (bitCount == 0)
                {
                    return "0" + suf[0];
                }
                long bits = Math.Abs(bitCount);
                int place = Convert.ToInt32(Math.Floor(Math.Log(bits, 1024)));
                double num = Math.Round(bits / Math.Pow(1024, place), 1);
                return (Math.Sign(bitCount) * num).ToString() + suf[place];
        }

        public static string FromBitsToStringSpeed(long bitCount) => FromBitsToString(bitCount) + "ps";
        public static string FromBytesToStringSpeed(long byteCount) => FromBytesToString(byteCount) + "/s";
    
        public static string RemoveUnit(string data)
        {
            string s = "";
            foreach(char c in data.ToCharArray())
            {
                if (char.IsDigit(c) || c == '.')
                {
                    s += c;
                }
            }
            return s;
        }

        public static string ConcatenateStrings(IEnumerable<string> strings)
        {
            string s = "";
            foreach(string str in strings)
            {
                s += str + ", ";
            }
            return s.Remove(s.Length - 2);
        }
    }
}
