/* ==============================
*
* Author: 高海波
* Time：2015/8/28 14:10:34
* FileName：SysInfo
* 说明:
* ===============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IISHelpLib
{
    /// <summary>
    /// 系统信息帮助类
    /// </summary>
    public static class SysInfo
    {
        /// <summary>
        /// 获取系统信息
        /// </summary>
        /// <returns></returns>
        public static string GetSystemInfo()
        {
            var bitOperating = Environment.Is64BitOperatingSystem ? "64位" : "32位";
            return Environment.OSVersion.VersionString + "  " + bitOperating;
        }

        
        /// <summary>
        /// 获取已安装.NET Framework 版本
        /// </summary>
        /// <returns></returns>
        public static string GetDotNetVersions()
        {
            DirectoryInfo[] directories = new DirectoryInfo(Environment.SystemDirectory + @"\..\Microsoft.NET\Framework").GetDirectories("v?.?.*");
            string list = directories.Any() ? directories.Aggregate("", (current, info2) => current + (info2.Name.Substring(1) + "、")) : "暂无";
            return list.Substring(0, list.Length - 1);
        }
    }
}
