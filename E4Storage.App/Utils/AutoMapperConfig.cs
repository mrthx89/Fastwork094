﻿using AutoMapper;
using Inventory.App.Model.Entity;
using Inventory.App.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.App.Utils
{
    public class AutoMapperConfig
    {
        public IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TContact, VendorMaster>();
                cfg.CreateMap<VendorMaster, TContact>();

                cfg.CreateMap<TContact, CustomerMaster>();
                cfg.CreateMap<CustomerMaster, TContact>();

                cfg.CreateMap<TInventor, ItemMaster>();
                cfg.CreateMap<ItemMaster, TInventor>();

                cfg.CreateMap<TWarehouse, WarehouseMaster>();
                cfg.CreateMap<WarehouseMaster, TWarehouse>();

                cfg.CreateMap<TStockIn, StokMasuk>();
                cfg.CreateMap<StokMasuk, TStockIn>();
                cfg.CreateMap<TStockCard, StokMasuk>();
                cfg.CreateMap<StokMasuk, TStockCard>();

                cfg.CreateMap<TStockOut, StokKeluar>();
                cfg.CreateMap<StokKeluar, TStockOut>();
                cfg.CreateMap<TStockCard, StokKeluar>();
                cfg.CreateMap<StokKeluar, TStockCard>();

                cfg.CreateMap<TStockPengembalian, StokPengembalian>();
                cfg.CreateMap<StokPengembalian, TStockPengembalian>();
                cfg.CreateMap<TStockCard, StokPengembalian>();
                cfg.CreateMap<StokPengembalian, TStockCard>();

                cfg.CreateMap<TStockMasterData, StokMasterData>();
                cfg.CreateMap<StokMasterData, TStockMasterData>();
                cfg.CreateMap<TStockCard, StokMasterData>();
                cfg.CreateMap<StokMasterData, TStockCard>();

                cfg.CreateMap<StokKeluar, StokPengembalian>();
                cfg.CreateMap<StokPengembalian, StokKeluar>();
                cfg.CreateMap<StokMasuk, StokPengembalian>();
                cfg.CreateMap<StokPengembalian, StokMasuk>();
                cfg.CreateMap<StokMasuk, StokMasterData>();
                cfg.CreateMap<StokMasterData, StokMasuk>();
            });

            return config.CreateMapper();
        }
    }
}
