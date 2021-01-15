using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UroomManager.Repository;

namespace UroomManager.Services
{
    public class TestService
    {
        private TestRepository testRepository;

        public TestService()
        {
            testRepository = new TestRepository();
        }

        public void testServicePost() 
        {
            testRepository.testInsert();
        }
    }
}
