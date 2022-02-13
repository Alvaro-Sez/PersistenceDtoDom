using Productora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productora.Services
{
    public interface IBulkDataService
    {
        Task<OperationResult> BulkData(string jsonString);
    }
}
