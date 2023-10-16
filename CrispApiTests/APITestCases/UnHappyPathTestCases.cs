using Services.HappyPaths;

namespace CRISP.APITestCases
{
	public class UnHappyPathTestCases
    {
        [Test]
        [Category("APITests")]
        //Test Case 1
        public async Task CountOfPatients()
        {
            Service service = new Service();
            var patients = await service.GetServiceResult();
            Assert.AreEqual(8, patients.Count());
        }

        [Test]
        [Category("APITests")]
        //Test Case 2
        public async Task InvalidNameForId111()
        {
            Service service = new Service();
            var patients = await service.GetServiceResult();
            var patient = patients.FirstOrDefault(x => x.Id == 111);
            Assert.AreEqual("Jack", patient.Name);
        }

        [Test]
        [Category("APITests")]
        //Test Case 3
        public async Task InvalidNameForId333()
        {
            Service service = new Service();
            var patients = await service.GetServiceResult();
            var patient = patients.FirstOrDefault(x => x.Id == 222);
            Assert.AreEqual("Mert", patient.Name);
        }

        [Test]
        [Category("APITests")]
        //Test Case 4
        public async Task InvalidAddressForId222()
        {
            Service service = new Service();
            var patients = await service.GetServiceResult();
            var patient = patients.FirstOrDefault(x => x.Id == 333);
            Assert.AreEqual("NYC", patient.Address);
        }

        [Test]
        [Category("APITests")]
        //Test Case 5
        public async Task InvalidDateOfBirthForId444()
        {
            //THIS IS A DEFECT
            //Date of Birth cannot be later than the current time.
            Service service = new Service();
            var patients = await service.GetServiceResult();
            var patient = patients.FirstOrDefault(x => x.Id == 444);
            Assert.Greater(DateTime.Now.ToShortDateString(), patient.DateOfBirth);
        }

        [Test]
        [Category("APITests")]
        //Test Case 6
        public async Task DateOfBirthLengthControl()
        {
            //THIS IS A DEFECT
            //Date of birth for ID 444 is "2023-10-16 12:13:09". This is 19 characters.
            //On the table it is "2000-03-01".
            Service service = new Service();
            var patients = await service.GetServiceResult();
            var patient = patients.FirstOrDefault(x => x.Id == 444);
            Assert.AreEqual(10, patient.DateOfBirth.Length);
        }
    }
}

