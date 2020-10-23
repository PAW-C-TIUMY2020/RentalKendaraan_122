using System;
using System.Collections.Generic;

namespace RentalKendaraan_122.Models
{
    public partial class Pengembalian
    {
        public int IdPengembalian { get; set; }
        public DateTime? TglPengembalian { get; set; }
        public int? IdPeminjaman { get; set; }
        public int? IdKondisiKendaraan { get; set; }
        public int? Denda { get; set; }

        public KondisiKendaraan IdKondisiKendaraanNavigation { get; set; }
        public Peminjaman IdPeminjamanNavigation { get; set; }
    }
}
