using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Models.EFModels;
using WP.Models.Entities;

namespace WP.Models.Interfeces
{
    public interface ISecRepository
    {
        EmployeeEntity Load(string account);
    }
}
