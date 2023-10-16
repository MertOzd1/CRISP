using Services.HappyPaths;

namespace CRISP.APITestCases
{
	public class HappyPathTestCases
	{
		[Test]
		[Category("APITests")]
        //Test Case 1
		public async Task CountOfPatients()
		{
			Service service = new Service();
            var patients = await service.GetServiceResult();
            Assert.AreEqual(4, patients.Count());
        }
        
        [Test]
        [Category("APITests")]
        //Test Case 2
        public async Task NameControlForId111()
        {
            Service service = new Service();
            var patients = await service.GetServiceResult();
            var patient = patients.FirstOrDefault(x => x.Id == 111);
            Assert.AreEqual("Jenn D.", patient.Name);
        }

        [Test]
        [Category("APITests")]
        //Test Case 3
        public async Task AddressControlForId222()
        {
            Service service = new Service();
            var patients = await service.GetServiceResult();
            var patient = patients.FirstOrDefault(x => x.Id == 222);
            Assert.AreEqual("MD", patient.Address);
        }

        [Test]
        [Category("APITests")]
        //Test Case 4
        public async Task AddressControlForId444()
        {
            Service service = new Service();
            var patients = await service.GetServiceResult();
            var patient = patients.FirstOrDefault(x => x.Id == 444);
            Assert.AreEqual("Valley State", patient.Address);
        }
        [Test]
        [Category("APITests")]
        //Test Case 5
        public async Task DateOfBirthControlForId333()
        {
            Service service = new Service();
            var patients = await service.GetServiceResult();
            var patient = patients.FirstOrDefault(x => x.Id == 333);
            Assert.AreEqual("1966-04-01", patient.DateOfBirth);
        }

        [Test]
        [Category("APITests")]
        //Test Case 6
        public async Task DateOfBirthLengthControl()
        {
            Service service = new Service();
            var patients = await service.GetServiceResult();
            var patient = patients.FirstOrDefault(x => x.Id == 333);
            Assert.AreEqual(10, patient.DateOfBirth.Length);
        }
    }
}

