using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Windows.Models
{
   public enum Institution
    {
        [InstitutionInfo(Alias ="MTs Kafila")]
        MTS_KAFILA,
        [InstitutionInfo(Alias = "MAS Kafila")]
        MAS_KAFILA,
        [InstitutionInfo(Alias = "MTs Al-Kahfi")]
        MTS_ALKAHFI,
        [InstitutionInfo(Alias = "MTs Fullday")]
        MTS_FULLDAY,
        [InstitutionInfo(Alias = "YKT")]
        YAYASAN_KAFILA_THOYIBA


    }
}
