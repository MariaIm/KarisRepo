using KarisMissionChoir.Contract;
using KarisMissionChoir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarisMissionChoir.DAL
{
    public class KarisMissionChoirUow : IKarisMissionChoirUow, IDisposable
    {
        private KarisMissionChoirContext context = new KarisMissionChoirContext();

        private Repository<Address> addressRepository;
        public Repository<Address> AddressRepository
        {
            get
            {

                if (this.addressRepository == null)
                {
                    this.addressRepository = new Repository<Address>(context);
                }
                return addressRepository;
            }
        }

        private Repository<ApplicationUser> applicationUserRepository;
        public Repository<ApplicationUser> ApplicationUserRepository
        {
            get
            {

                if (this.applicationUserRepository == null)
                {
                    this.applicationUserRepository = new Repository<ApplicationUser>(context);
                }
                return applicationUserRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
