using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnWatch.Models
{
    [Table("SystemSetting")]
    public class SystemSetting
    {
        [Key]
        
        public string SettingKey { get; set; }

        public string SettingValue { get; set; }

        public string SettingDescription { get; set; }

    }
}