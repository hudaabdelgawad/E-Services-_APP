using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IServiceRepository ServiceRepository { get;}
        public IServiceDetailsRepository ServiceDetailsRepository { get;}
        public IClienRequestRepository clienRequestRepository { get; }
       
    }
}
