/* ==============================
*
* Author: 高海波
* Time：2015/8/28 17:07:13
* FileName：IISManagement
* 说明:
* ===============================
*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Microsoft.Web.Administration;

namespace IISHelpLib
{
    public class IISManagement
    {
        private static string HostName = "localhost";

        /// <summary>
        /// 获取本地IIS版本
        /// </summary>
        /// <returns></returns>
        public static string GetIIsVersion()
        {
            try
            {
                var entry = new DirectoryEntry("IIS://" + HostName + "/W3SVC/INFO");
                string version = entry.Properties["MajorIISVersionNumber"].Value.ToString();
                return version;
            }
            catch
            {
                //说明一点:IIS5.0中没有(int)entry.Properties["MajorIISVersionNumber"].Value;属性，将抛出异常 证明版本为 5.0
                return "5.0";
            }
        }

        /// <summary>
        /// 判断object对象是否为数组
        /// </summary>
        public static bool IsArray(object o)
        {
            return o is Array;
        }

        /// <summary>
        /// 获取站点名
        /// </summary>
        public static List<IISInfo> GetServerBindings()
        {
            var iisList = new List<IISInfo>();
            var entPath = String.Format("IIS://{0}/w3svc", HostName);
            var ent = new DirectoryEntry(entPath);
            foreach (DirectoryEntry child in ent.Children)
            {
                if (child.SchemaClassName.Equals("IIsWebServer", StringComparison.OrdinalIgnoreCase))
                {
                    if (child.Properties["ServerBindings"].Value != null)
                    {
                        object objectArr = child.Properties["ServerBindings"].Value;
                        string serverBindingStr;
                        if (IsArray(objectArr))//如果有多个绑定站点时
                        {
                            var objectToArr = (object[])objectArr;
                            serverBindingStr = objectToArr[0].ToString();
                        }
                        else//只有一个绑定站点
                        {
                            serverBindingStr = child.Properties["ServerBindings"].Value.ToString();
                        }
                        var iisInfo = new IISInfo
                        {
                            DomainPort = serverBindingStr,
                            SiteAppPool = child.Properties["AppPoolId"].Value.ToString()
                        };
                        iisList.Add(iisInfo);
                    }
                }
            }
            return iisList;
        }

        /// <summary>
        /// 得到网站的物理路径
        /// </summary>
        /// <param name="rootEntry">网站节点</param>
        /// <returns></returns>
        public static string GetWebsitePhysicalPath(DirectoryEntry rootEntry)
        {
            string physicalPath = "";
            foreach (DirectoryEntry childEntry in rootEntry.Children)
            {
                if ((childEntry.SchemaClassName == "IIsWebVirtualDir") && (childEntry.Name.ToLower() == "root"))
                {
                    if (childEntry.Properties["Path"].Value != null)
                    {
                        physicalPath = childEntry.Properties["Path"].Value.ToString();
                    }
                    else
                    {
                        physicalPath = "";
                    }
                }
            }
            return physicalPath;
        }

        /// <summary>
        /// 判断程序池是否存在
        /// </summary>
        /// <param name="appPoolName">程序池名称</param>
        /// <returns>true存在 false不存在</returns>
        private static bool IsAppPoolName(string appPoolName)
        {
            bool result = false;
            var apppools = new DirectoryEntry("IIS://" + HostName + "/W3SVC/AppPools");
            foreach (DirectoryEntry getdir in apppools.Children)
            {
                if (getdir.Name.Equals(appPoolName))
                {
                    result = true;
                }
            }
            return result;
        }


        /// <summary>
        /// 创建应用程序池（II7\IIS6通用）
        /// </summary>
        /// <param name="appPoolName">应用程序池名称</param>
        /// <param name="managedRuntimeVersion">.net版本</param>
        /// <param name="managedPipelineMode">托管管道模式：1：经典，0：集成</param>
        /// <returns></returns>
        public static bool CommonCreateAppPool(string appPoolName, string managedRuntimeVersion = "v4.0", string managedPipelineMode = "0")
        {
            bool flag = false;
            if (!IsAppPoolName(appPoolName))
            {
                try
                {
                    DirectoryEntry newpool;
                    var apppools = new DirectoryEntry("IIS://" + HostName + "/W3SVC/AppPools");
                    newpool = apppools.Children.Add(appPoolName, "IIsApplicationPool");
                    newpool.Properties["ManagedRuntimeVersion"].Value = managedRuntimeVersion;//.net版本
                    newpool.Properties["ManagedPipelineMode"].Value = managedPipelineMode;//托管管道模式：1：经典，0：集成
                    newpool.CommitChanges();
                    flag = true;
                }
                catch
                {
                    flag = false;
                }
            }
            return flag;
        }
        /// <summary>
        /// 创建应用程序池（针对IIS7）
        /// </summary>
        /// <param name="appPoolName"></param>
        /// <param name="managedRuntimeVersion"></param>
        /// <param name="managedPipelineMode"></param>
        public static bool CreateAppPoolForIis7(string appPoolName, string managedRuntimeVersion = "v4.0", string managedPipelineMode = "0")
        {
            bool flag;
            var iisManager = new ServerManager();
            ApplicationPool newPool = iisManager.ApplicationPools[appPoolName];
            if (newPool == null)
            {
                iisManager.ApplicationPools.Add(appPoolName);
                newPool = iisManager.ApplicationPools[appPoolName];
                newPool.Name = appPoolName;
                newPool.ManagedPipelineMode = managedPipelineMode == "0" ? ManagedPipelineMode.Integrated : ManagedPipelineMode.Classic;
                newPool.ManagedRuntimeVersion = managedRuntimeVersion;
                newPool.AutoStart = true;
                iisManager.CommitChanges();
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 获取应用程序池列表
        /// </summary>
        /// <returns></returns>
        public static List<string> AppPoolList()
        {
            var iisManager = new ServerManager();
            var applicationPools = iisManager.ApplicationPools;
            return applicationPools.Select(pool => pool.Name).ToList();
        }

        /// <summary>
        /// 获取应用程序池信息
        /// </summary>
        /// <param name="appPoolName">应用程序池名称</param>
        /// <returns></returns>
        public static string[] GetAppPoolInfo(string appPoolName)
        {
            var iisManager = new ServerManager();
            var strarr = new string[2];
            ApplicationPool newPool = iisManager.ApplicationPools[appPoolName];
            strarr[0] = newPool.ManagedRuntimeVersion;
            strarr[1] = newPool.ManagedPipelineMode.ToString();
            return strarr;
        }


        /// <summary>
        /// 删除指定程序池
        /// </summary>
        /// <param name="AppPoolName">程序池名称</param>
        /// <returns>true删除成功 false删除失败</returns>
        private bool DeleteAppPool(string AppPoolName)
        {
            bool result = false;
            var appPools = new DirectoryEntry("IIS://localhost/W3SVC/AppPools");
            foreach (DirectoryEntry getdir in appPools.Children)
            {
                if (getdir.Name.Equals(AppPoolName))
                {
                    try
                    {
                        getdir.DeleteTree();
                        result = true;
                    }
                    catch
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 建立程序池后关联相应应用程序及虚拟目录
        /// </summary>
        public static void SetAppToPool(string appname, string poolName)
        {
            //获取目录
            var getdir = new DirectoryEntry("IIS://localhost/W3SVC");
            foreach (DirectoryEntry getentity in getdir.Children)
            {
                if (getentity.SchemaClassName.Equals("IIsWebServer"))
                {
                    //设置应用程序程序池 先获得应用程序 在设定应用程序程序池
                    //第一次测试根目录
                    foreach (DirectoryEntry getchild in getentity.Children)
                    {
                        if (getchild.SchemaClassName.Equals("IIsWebVirtualDir"))
                        {
                            //找到指定的虚拟目录.
                            foreach (DirectoryEntry getsite in getchild.Children)
                            {
                                if (getsite.Name.Equals(appname))
                                {
                                    //【测试成功通过】
                                    getsite.Properties["AppPoolId"].Value = poolName;
                                    getsite.CommitChanges();
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 创建虚拟目录网站
        /// </summary>
        /// <param name="webSiteName">网站名称</param>
        /// <param name="physicalPath">物理路径</param>
        /// <param name="domainPort">站点+端口，如192.168.1.23:90</param>
        /// <param name="isCreateAppPool">是否创建新的应用程序池</param>
        /// <returns></returns>
        public static int CreateWebSite(string webSiteName, string physicalPath, string domainPort, bool isCreateAppPool)
        {
            DirectoryEntry root = new DirectoryEntry("IIS://" + HostName + "/W3SVC");
            // 为新WEB站点查找一个未使用的ID
            int siteID = 1;
            foreach (DirectoryEntry e in root.Children)
            {
                if (e.SchemaClassName == "IIsWebServer")
                {
                    int ID = Convert.ToInt32(e.Name);
                    if (ID >= siteID) { siteID = ID + 1; }
                }
            }
            // 创建WEB站点
            DirectoryEntry site = (DirectoryEntry)root.Invoke("Create", "IIsWebServer", siteID);
            site.Invoke("Put", "ServerComment", webSiteName);
            site.Invoke("Put", "KeyType", "IIsWebServer");
            site.Invoke("Put", "ServerBindings", domainPort + ":");
            site.Invoke("Put", "ServerState", 2);
            site.Invoke("Put", "FrontPageWeb", 1);
            site.Invoke("Put", "DefaultDoc", "Default.html");
            site.Invoke("Put", "ServerAutoStart", 1);
            site.Invoke("Put", "ServerSize", 1);
            site.Invoke("SetInfo");
            // 创建应用程序虚拟目录
            DirectoryEntry siteVDir = site.Children.Add("Root", "IISWebVirtualDir");
            siteVDir.Properties["AppIsolated"][0] = 2;
            siteVDir.Properties["Path"][0] = physicalPath;
            siteVDir.Properties["AccessFlags"][0] = 513;
            siteVDir.Properties["FrontPageWeb"][0] = 1;
            siteVDir.Properties["AppRoot"][0] = "LM/W3SVC/" + siteID + "/Root";
            siteVDir.Properties["AppFriendlyName"][0] = "Root";

            if (isCreateAppPool)
            {
                DirectoryEntry apppools = new DirectoryEntry("IIS://" + HostName + "/W3SVC/AppPools");
                DirectoryEntry newpool = apppools.Children.Add(webSiteName, "IIsApplicationPool");
                newpool.Properties["AppPoolIdentityType"][0] = "4"; //4
                newpool.Properties["ManagedPipelineMode"][0] = "0"; //0:集成模式 1:经典模式
                newpool.CommitChanges();
                siteVDir.Properties["AppPoolId"][0] = webSiteName;
            }
            siteVDir.CommitChanges();
            site.CommitChanges();
            return siteID;
        }

        /// <summary>
        /// 创建站点应用程序
        /// </summary>
        /// <param name="siteName">站点名称</param>
        /// <param name="applicationName">应用程序名称</param>
        /// <param name="applicationpath">应用程序路径</param>
        public static void CreateApplication(string siteName, string applicationName, string applicationpath)
        {
            var iisManager = new ServerManager();
            iisManager.Sites[siteName].Applications.Add("/" + applicationName, applicationpath);
            iisManager.CommitChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="iisInfo"></param>
        public static bool CreateSite(IISInfo iisInfo)
        {
            bool flag = false;
            if (Int32.Parse(GetIIsVersion()) > 6)//IIS 7
            {
                var serverManager = new ServerManager();
                Site site = serverManager.Sites.Add(iisInfo.SiteName, iisInfo.BindingProtocol, iisInfo.DomainPort + iisInfo.SiteIpAdress, iisInfo.SitePhysicalPath);
                site.Applications["/"].ApplicationPoolName = iisInfo.SiteAppPool;
                site.ServerAutoStart = true;
                serverManager.CommitChanges();
                if (iisInfo.AppCollection.Count > 0)
                {
                    foreach (var variable in iisInfo.AppCollection)
                    {
                        CreateApplication(iisInfo.SiteName, variable.Substring(variable.LastIndexOf('\\') + 1), variable);
                    }
                }
                flag = true;
            }
            else//IIS 6及以下
            {

            }
            return flag;
        }

        /// <summary>
        /// 启动\停止站点
        /// </summary>
        /// <param name="siteName">站点名称</param>
        /// <returns></returns>
        public static string StartOrStopWeb(string siteName)
        {
            string siteInfo = string.Empty;
            var iisManager = new ServerManager();
            var site = iisManager.Sites[siteName];
            if (site.State == ObjectState.Started)
            {
                siteInfo = "启动";
                site.Stop();
            }
            else
            {
                siteInfo = "停止";
                site.Start();
            }
            return siteInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IISInfo> SiteInfos()
        {
            var iisManager = new ServerManager();
            var iisInfos = new ObservableCollection<IISInfo>();
            string operation = string.Empty;
            Func<string, string> serverstate = (state) =>
            {
                string stateinfo = string.Empty;
                switch (state)
                {
                    case "Started":
                        stateinfo = "运行中";
                        operation = "停止";
                        break;
                    case "Stopped":
                        stateinfo = "未运行";
                        operation = "启动";
                        break;
                }
                return stateinfo;
            };
            foreach (var site in iisManager.Sites)
            {
                var iisInfo = new IISInfo() { SiteName = site.Name, RunState = serverstate(site.State.ToString()), Operation = operation};
                iisInfo.IisCmd = new CommandObject(iisInfo.OperationCommand);
                iisInfos.Add(iisInfo);
            }
            return iisInfos;
        }

    }
}
