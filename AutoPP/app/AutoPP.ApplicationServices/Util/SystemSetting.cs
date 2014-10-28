using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoPP.ApplicationServices.Util
{
    public class SystemSetting
    {
        private static SystemSetting _instance = null;

        private SystemSetting()
        {
        }

        public static SystemSetting Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SystemSetting();
                }
                return _instance;
            }
        }

        public Dictionary<string, string> Settings()
        {
            Dictionary<string, string> _settings = new Dictionary<string, string>();
            _settings.Add("ITEMS_PER_GALLERY", "3");
            _settings.Add("GALLERY_FOLDER_PATH", @"F:\MSC\Project\Media\");
            return _settings;
        }
    }
}
