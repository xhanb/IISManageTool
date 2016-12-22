/* ==============================
*
* Author: 高海波
* Time：2015/10/9 16:19:52
* FileName：NotificationObject
* 说明:
* ===============================
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using IISHelpLib.Annotations;

namespace IISHelpLib
{
    /// <summary>
    /// 
    /// </summary>
   public class NotificationObject:INotifyPropertyChanged
    {
       /// <summary>
       /// 
       /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

       /// <summary>
       /// 
       /// </summary>
       /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
