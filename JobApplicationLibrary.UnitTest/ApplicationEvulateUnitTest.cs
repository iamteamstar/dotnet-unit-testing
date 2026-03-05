using JobApplicationLibrary.Models;

namespace JobApplicationLibrary.UnitTest
{
	public class ApplicationEvulateUnitTest
	{
		//Test Explorer i açtýðýmýz zaman sistem içindeki bütün test attribute üne sahip olan metotlarý bulur ve gösterir 
		//bu projeyi test edeceðimiz için UNIT TEST solutionda da referansa proje referans olarak eklenmeli
		//[Test]
		//public void Test1()//bu þekilde baþýna [Test] attribute gelmeli, public void olmalý ve ismi olmalý
		//{
		//	Assert.Fail("this test failed");//bu da otomatik olarak fail eder. hata sonucunu parametersi ile mesaj olarak dönebiliyoruz
		//}

		//Ýsimlendirme: UnitOfWork_Condition_ExpectedResult(beklenen sonuç)
		[Test]
		public void Application_WithUnderAge_TransferredToAutoRejected()//Application yani baþvuruyu test ediyoruz(çalýþma alanýmýz),Parametrenin test edilmesi, olmasý gerekendan daha düþük bir yaþ gönderildiðinde, bu durumda nasýl sonuçlanmasý gerektiði
		{
			// 3 bölümümüz olucak:
			//Arrange:ayarlama yapýlýr. Ne yapmak istiyoruz? ApplicationEvulator classýnýn altýndaki Evulate metodunu test etmek istiyoruz. Bu sýnýftan bir instance oluþturmamýz gerek
			var evulator = new ApplicationEvulator();
			var form = new JobApplication()
			{
				Applicant = new Applicant()
				{
					Age = 17
				}
			};

			//Action:iþlem yapýlýr
			var appResult = evulator.Evulate(form);

			//Assert
			Assert.That(appResult, Is.EqualTo(ApplicationResult.AutoRejected));//AreEqual:assertin içerisine iki tane parametre göndereceðim ve  bunlarýn birbirine eþit olup olmadýðýna bakacaðým
		}


		[Test]

		public void Application_WithNotechStack_TransferredToAutoRejected()//hiçbir benzerlik oraný olmadýðýnda(yeteneklerde) beklediðim sonucu test ediyorum.
		{
			// 3 bölümümüz olucak:
			//Arrange:ayarlama yapýlýr. Ne yapmak istiyoruz? ApplicationEvulator classýnýn altýndaki Evulate metodunu test etmek istiyoruz. Bu sýnýftan bir instance oluþturmamýz gerek
			var evulator = new ApplicationEvulator();
			var form = new JobApplication()
			{
				Applicant = new Applicant(),
				TechStackList = new System.Collections.Generic.List<string>() { "" }//boþ gönderdik.

			};

			//Action:iþlem yapýlýr
			var appResult = evulator.Evulate(form);

			//Assert
			Assert.That(appResult, Is.EqualTo(ApplicationResult.AutoRejected));
		}
		[Test]
		public void Application_WithTechStackAndExperience_TransferredToAutoAccepted()
		{
			//Arrange:ayarlama yapýlýr. 
			var evulator = new ApplicationEvulator();
			var form = new JobApplication()
			{
				Applicant = new Applicant(),
				TechStackList = new System.Collections.Generic.List<string>
				{
					"C#", "RabbitMQ", "Microservice", ".Net", "MSSQL" //skiller tamamen uyuþuyor
				
				},
				YearsOfExperience = 8
			};

			//Action:iþlem yapýlýr
			var appResult = evulator.Evulate(form);

			//Assert
			Assert.That(appResult, Is.EqualTo(ApplicationResult.AutoRejected));//AreEqual:assertin içerisine iki tane parametre göndereceðim ve  bunlarýn birbirine eþit olup olmadýðýna bakacaðým
		}

		// Remove ExpectedResult from TestCase, and fix the test method to use [TestCase] with Assert
		[TestCase(2, 3)]
		public void Calculator_AddSimpleValues_ReturnAdd(int a, int b)
		{
			var evulator = new Calculator();
			var actualTotal = evulator.add(a, b);
			Assert.That(actualTotal, Is.EqualTo(a + b));
		}
	}
}