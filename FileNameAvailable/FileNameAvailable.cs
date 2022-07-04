using System;
using System.IO;

namespace RenTY
{
    /// <summary>
    /// 文件名称（路径）可用性
    /// </summary>
    public static class FileNameAvailable
    {
        /// <summary>
        /// 返回一个值：文件名称（路径）是否可用
        /// </summary>
        /// <param name="FileName">文件名称（路径）</param>
        /// <param name="Error">错误信息</param>
        /// <param name="Replaceable">可替换（默认不可替换）</param>
        /// <returns>真为可用，假为不可用</returns>
        public static Boolean GetAvailable(String FileName, out Exception Error, Boolean Replaceable = false)
        {
            Error = null; FileInfo FileObject = new FileInfo(FileName);
            //  ↓↓文件存在
            if (FileObject.Exists)
            {
                //  ↓↓可替换
                if (Replaceable)
                {
                    try
                    {
                        String TemporyFileName = $"{FileObject.DirectoryName}\\{Guid.NewGuid():D}";
                        File.Move(FileObject.FullName, TemporyFileName);
                        (FileObject.Create()).Close(); FileObject.Delete();
                        File.Move(TemporyFileName, FileObject.FullName); return true;
                    }
                    catch (Exception ex) { Error = ex; return false; }
                }
                //  ↓↓不可替换
                else { Error = new Exception("File already exists."); return false; }
            }
            //  ↓↓文件不存在
            else
            {
                try { (FileObject.Create()).Close(); FileObject.Delete(); return true; }
                catch (Exception ex) { Error = ex; return false; }
            }
        }
        /// <summary>
        /// 返回一个值：文件名称（路径）是否可用
        /// </summary>
        /// <param name="FileName">文件名称（路径）</param>
        /// <param name="Error">错误信息</param>
        /// <param name="Replaceable">可替换（默认不可替换）</param>
        /// <returns>真为可用，假为不可用</returns>
        public static Boolean GetAvailable(FileInfo FileName, out Exception Error, Boolean Replaceable = false) =>
            GetAvailable(FileName, out Error, Replaceable);
    }
}
