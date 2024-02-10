SELECT TPurchase.*,
                                            TWarehouse.Code CodeGudang,
                                            TWarehouse.[Name] Gudang,
                                            TContact.Code CodeVendor,
                                            TContact.[Name] Vendor,
                                            TContact.[Address] AddressVendor,
                                            UserEntri.Nama UserEntri,
                                            UserEdit.Nama UserEdit,
                                            UserHapus.Nama UserHapus
                                            FROM TPurchase(NOLOCK)
                                            LEFT JOIN TWarehouse(NOLOCK) ON TPurchase.IDWarehouse = TWarehouse.ID
                                            LEFT JOIN TContact(NOLOCK) ON TPurchase.IDVendor = TContact.ID
                                            LEFT JOIN TUser(NOLOCK) UserEntri ON TPurchase.IDUserEntri = UserEntri.ID
                                            LEFT JOIN TUser(NOLOCK) UserEdit ON TPurchase.IDUserEdit = UserEdit.ID
                                            LEFT JOIN TUser(NOLOCK) UserHapus ON TPurchase.IDUserHapus = UserHapus.ID
                                            WHERE TPurchase.ID=@ID
                                            ORDER BY TPurchase.ID;
                                          SELECT TPurchaseDtl.*,
                                            TInventor.PLU,
                                            TInventor.[Desc],
                                            TUOM.Satuan
                                            FROM TPurchaseDtl(NOLOCK)
                                            LEFT JOIN TInventor(NOLOCK) ON TPurchaseDtl.IDInventor = TInventor.ID
                                            LEFT JOIN TUOM(NOLOCK) ON TPurchaseDtl.IDUOM = TUOM.ID
                                            WHERE TPurchaseDtl.IDPurchase=@ID
                                            ORDER BY TPurchaseDtl.NoUrut;