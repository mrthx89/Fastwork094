using AutoMapper;
using Inventory.App.Helper;
using Inventory.App.Model;
using Inventory.App.Model.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Utils
{
    public class Constant
    {
        public static string NamaApplikasi = "Inventory System";
        public static AppSetting appSetting = null;
        public static TUser UserLogin = null;
        public static LayoutsHelper layoutsHelper = new LayoutsHelper(Path.Combine(Environment.CurrentDirectory, "System", "Layouts"));
        public static IMapper mapper = new AutoMapperConfig().Configure(); // Buat instance mapper
        public static bool EditReport = false;

        public enum TypeTransaction
        {
            stokIn = 1,
            stokPengembalian = 2,
            stokMasterData = 3,
            stokOut = 4
        }

        //ID Jenis Transaksi
        public static Guid stokInType = Guid.Parse("C889E2DF-D056-4DAD-B935-E47921035811");
        public static Guid stokPengembalianType = Guid.Parse("B536F89C-FA4E-4F7B-AFDB-5B323546D10E");
        public static Guid stokMasterDataType = Guid.Parse("991D2F92-C02D-4A2A-8A5F-F19E3DAD08C5");
        public static Guid stokOutType = Guid.Parse("6652E843-6C01-4CD0-9F9C-5111565D7844");
        public static Guid stokSaldoAwal = Guid.Parse("D6022513-AFD4-4A67-9F47-594E43D5F220");
        public static Guid stokPembelian = Guid.Parse("7c51a7c6-2b13-4c4a-9e01-9bc5e4158d5f");
        public static Guid stokReturPembelian = Guid.Parse("5e9d58b1-492f-4d13-912c-20f2cc88c031");
        public static Guid stokManifest = Guid.Parse("53D49883-9C2D-4384-98AF-0178EEC25CAF");
        public static Guid stokPenjualan = Guid.Parse("ea1f6c54-6f13-4a71-98cb-f2f3f54de7b9");
        public static Guid stokReturPenjualan = Guid.Parse("60a9be41-40e2-42f4-9a5e-7c2ebec7a377");

        //IDWarehouse
        public static Guid warehouse = Guid.Parse("53EC3BB6-9249-4840-8BAB-EA8A30BFCAD1");

        //SuperAdmin
        public static Guid sysAdmin = Guid.Parse("EC82D19B-14AD-41E6-90BE-ED2B17855BF3");
    }
}
