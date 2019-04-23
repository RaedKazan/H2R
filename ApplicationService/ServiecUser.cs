using ApplicationDataAccess.ApplicationRepository;
using ApplicationDataAccess.ApplicationUOF;
using ApplicationDomianEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class ServiecUser : UserService
    {
        private readonly IRepository<Class3> repository;
        IUnitOfWork _unitOfWork;
        public ServiecUser(IRepository<Class3> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task Hello()
        {

            Class1 class1 = new Class1
            {
                Id = 0,
                FirstName = 123,
                LastName = 123
            };
            List<Class3> classes = new List<Class3>();
            for (int i = 0; i < 10; i++)
            {
                classes.Add(new Class3 { Id = 0, FirstName = i + 100, LastName = i + 100, });
            }
            var x = await repository.AddAsync(classes);




            // _unitOfWork.GetRepository<Class1>().Add(class1);

            //_unitOfWork.SaveChanges();
            //   _unitOfWork.GetRepository<Class1>().Update(class1);

            //   _unitOfWork.SaveChanges();

            ////   await _unitOfWork.GetRepository<Class1>().Add(classes);

        }

        public async void helloo()
        {
            List<Class1> classes = new List<Class1>();
            for (int i = 0; i < 10; i++)
            {
                classes.Add(new Class1 { Id = 0, FirstName = i + 1100, LastName = i + 100 });
            }
            await _unitOfWork.GetRepository<Class1>().Add(classes);
            _unitOfWork.SaveChanges();




        }
    }
}
