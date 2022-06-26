using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RenTY
{
    /// <summary>
    /// 生成16字节哈希字串和简明字码
    /// </summary>
    public static class HASH16
    {
        private static readonly String FailString = String.Empty;
        private const Char FailChar = (Char)0;
        #region Region 输入输出
        /// <summary>
        /// 生成哈希字串
        /// </summary>
        /// <param name="PlainText">原文（字符串）</param>
        /// <returns></returns>
        public static String GetHash(String PlainText)
        {
            if (GetValue(Encoding.UTF8.GetBytes(PlainText), out String s, out _)) return s;
            else return FailString;
        }
        /// <summary>
        /// 生成哈希字串
        /// </summary>
        /// <param name="PlainFile">原文（文件信息）</param>
        /// <returns></returns>
        public static String GetHash(FileInfo PlainFile)
        {
            if (GetValue(File.ReadAllBytes(PlainFile.FullName), out String s, out _)) return s;
            else return FailString;
        }
        /// <summary>
        /// 生成哈希字串
        /// </summary>
        /// <param name="PlainBytes">原文（字节数组）</param>
        /// <returns></returns>
        public static String GetHash(Byte[] PlainBytes)
        {
            if (GetValue(PlainBytes, out string s, out _)) return s;
            else return FailString;
        }
        /// <summary>
        /// 生成简明字码
        /// </summary>
        /// <param name="PlainText">原文（字符串）</param>
        /// <returns></returns>
        public static Char GetKey(String PlainText)
        {
            if (GetValue(Encoding.UTF8.GetBytes(PlainText), out _, out Char c)) return c;
            else return FailChar;
        }
        /// <summary>
        /// 生成简明字码
        /// </summary>
        /// <param name="PlainFile">原文（文件信息）</param>
        /// <returns></returns>
        public static Char GetKey(FileInfo PlainFile)
        {
            if (GetValue(File.ReadAllBytes(PlainFile.FullName), out _, out Char c)) return c;
            else return FailChar;
        }
        /// <summary>
        /// 生成简明字码
        /// </summary>
        /// <param name="PlainBytes">原文（字节数组）</param>
        /// <returns></returns>
        public static Char GetKey(Byte[] PlainBytes)
        {
            if (GetValue(PlainBytes, out _, out Char c)) return c;
            else return FailChar;
        }
        #endregion
        #region Region 算法实现
        private static Boolean GetValue(byte[] PlainBytes, out String Result, out Char K)
        {
            try
            {
                // 运行SHA-512哈希变换
                Byte[] bs = SHA512.Create().ComputeHash(PlainBytes);
                // 第一组（前8字节）变换结果装入字符串
                String str = "";
                for (Int32 i = 0; i < 8; i++) str += bs[i].ToString("X2");
                // 第一组（前8字节）变换结果装入无符号长整型变量（初始化异或变量）
                UInt64 ui = Convert.ToUInt64(str, 16);
                // 从第二组（每8个字节）变换结果到最后一组，
                // 与前一次执行异或结果再进行异或运算（第一次已在上一步装入变量）
                for (Int32 i = 1; i < 8; i++)
                {
                    // 第i组（第 i*8 到 i*8+7 字节）变换结果装入字符串
                    str = "";
                    for (Int32 j = 0; j < 8; j++) str += bs[i * 8 + j].ToString("X2");
                    // 与前一次执行异或结果再进行异或运算
                    ui ^= Convert.ToUInt64(str, 16);
                }
                // 最终异或结果传递到输出变量
                Result = ui.ToString("X16");
                // SHA-512变换结果装入位数组
                BitArray ba = new BitArray(bs); Int32 l = 0;
                // 计算数组中真值的个数
                for (Int32 i = 0; i < ba.Length; i++) if (ba[i]) l += 1;
                // 将真值个数按32取模，查简明码表输出到变量
                K = Word32Table[l % 32];
                // 返回计算成功
                return true;
            }
            // 失败时，返回指定值
            catch { Result = FailString; K = FailChar; return false; }
        }
        /// <summary>
        /// 简明码表，大写字母和数字，去掉I、O、1、0
        /// </summary>
        private static readonly Char[] Word32Table = new Char[]
        { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R',
          'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '2', '3', '4', '5', '6', '7', '8', '9' };
        #endregion
    }
}
