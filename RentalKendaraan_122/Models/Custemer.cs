using System;
using System.Collections.Generic;

namespace RentalKendaraan_122.Models
{
    public partial class Custemer
    {
        public Custemer()
        {
            Peminjaman = new HashSet<Peminjaman>();
        }

        public int IdCustemer { get; set; }
        public string NamaCustemer { get; set; }
        public string Nik { get; set; }
        public string Alamat { get; set; }
        public string NoHp { get; set; }
        public int? IdGender { get; set; }

        public Gender IdGenderNavigation { get; set; }
        public ICollection<Peminjaman> Peminjaman { get; set; }
    }
}
