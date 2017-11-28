using System;
using System.Collections.Generic;
using System.Text;

using WarehouseManage.Common.Entities;
using WarehouseManage.DataAccess;

namespace WarehouseManage.BusinessLogic
{
    public abstract class BaseBL
    {
        ////private readonly DataAccessManager _dataAccessManager;

        protected BaseBL()
        {
            ////_dataAccessManager = DataAccessManager.Instance;
        }

        ////protected DataAccessProvider provider
        ////{
        ////    get { return _dataAccessManager.Provider; }
        ////}

    }
}
