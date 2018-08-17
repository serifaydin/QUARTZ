using CL_ItemTransferModule.Model;
using CL_Modules;
using System;
using System.Collections.Generic;

namespace CL_ItemTransferModule.Manager
{
    public class ItemTransferManager
    {
        private ServiceProcess.ItemTransferService itemJsonService = new ServiceProcess.ItemTransferService();

        public async void ItemListMethod()
        {
            ServiceResult result = await itemJsonService.GetItemFullList();
            Console.WriteLine("Service bağlantısı başarılı geçti.");
        }
    }
}