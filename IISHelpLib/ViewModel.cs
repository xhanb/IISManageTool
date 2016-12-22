/* ==============================
*
* Author: 高海波
* Time：2015/10/9 16:56:23
* FileName：ViewModel
* 说明:
* ===============================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IISHelpLib
{
    /// <summary>
    /// 
    /// </summary>
    public class ViewModel
    {
        public IEnumerable<IISInfo> SiteInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ViewModel()
        {
            this.SiteInfo = IISManagement.SiteInfos();
        }
    }
}
