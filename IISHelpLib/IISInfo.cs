using System;
using System.Collections.Generic;

namespace IISHelpLib
{
    /// <summary>
    /// IIS实体类
    /// </summary>
    public class IISInfo : NotificationObject
    {
        private string _domainPort;
        private string _siteAppPool;
        private string _siteIpAdress;
        private string _siteName = "SiteName";
        private string _sitePhysicalPath;
        private string _bindingProtocol;
        private List<string> _appCollection;
        private string _runState;
        private string _operation;

        /// <summary>
        /// 端口
        /// </summary>
        public string DomainPort
        {
            get { return _domainPort; }
            set
            {
                if (value == _domainPort) return;
                _domainPort = value;
                OnPropertyChanged("DomainPort");
            }
        }

        /// <summary>
        /// 应用程序池
        /// </summary>
        public string SiteAppPool
        {
            get { return _siteAppPool; }
            set
            {
                if (value == _siteAppPool) return;
                _siteAppPool = value;
                OnPropertyChanged("SiteAppPool");
            }
        }

        /// <summary>
        /// IP地址
        /// </summary>
        public string SiteIpAdress
        {
            get { return _siteIpAdress; }
            set
            {
                if (value == _siteIpAdress) return;
                _siteIpAdress = value;
                OnPropertyChanged("SiteIpAdress");
            }
        }

        /// <summary>
        /// 网站名称
        /// </summary>
        public string SiteName
        {
            get { return _siteName; }
            set
            {
                if (value == _siteName) return;
                _siteName = value;
                OnPropertyChanged("SiteName");
            }
        }

        /// <summary>
        /// 网站物理路径
        /// </summary>
        public string SitePhysicalPath
        {
            get { return _sitePhysicalPath; }
            set
            {
                if (value == _sitePhysicalPath) return;
                _sitePhysicalPath = value;
                OnPropertyChanged("SitePhysicalPath");
            }
        }

        /// <summary>
        /// 绑定协议
        /// </summary>
        public string BindingProtocol
        {
            get { return _bindingProtocol; }
            set
            {
                if (value == _bindingProtocol) return;
                _bindingProtocol = value;
                OnPropertyChanged("BindingProtocol");
            }
        }

        /// <summary>
        /// 应用程序集合
        /// </summary>
        public List<string> AppCollection
        {
            get { return _appCollection; }
            set
            {
                if (Equals(value, _appCollection)) return;
                _appCollection = value;
                OnPropertyChanged("AppCollection");
            }
        }

        /// <summary>
        /// 站点运行状态
        /// </summary>
        public string RunState
        {
            get { return _runState; }
            set
            {
                if (value == _runState) return;
                _runState = value;
                OnPropertyChanged("RunState");
            }
        }

        /// <summary>
        /// 操作
        /// </summary>
        public string Operation
        {
            get { return _operation; }
            set
            {
                if (value == _operation) return;
                _operation = value;
                OnPropertyChanged("Operation");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandObject IisCmd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void OperationCommand(object obj)
        {
            var sitename = obj.ToString();
            Operation = IISManagement.StartOrStopWeb(sitename);
            if (Operation=="启动")
            {
                RunState = "未运行";
            }
            else
            {
                RunState = "运行中";
            }

        }


    }
}