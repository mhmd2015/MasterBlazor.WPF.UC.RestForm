using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterBlazor.WPF.UC.RestForm
{
    public class ComboBoxItemData
    {
        public int Id { get; set; }
        public string SiteUrl { get; set; }
        public string ApiUrl { get; set; }
        public string DisplayValue
        {
            get { return $"{Id} - {SiteUrl} - {ApiUrl}"; }
        }
    }
}
