using System;
using System.Collections.Generic;

namespace RentalKendaraan_122.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Custemer = new HashSet<Custemer>();
        }

        public int IdGender { get; set; }
        public string NamaGender { get; set; }

        public ICollection<Custemer> Custemer { get; set; }
    }
}
