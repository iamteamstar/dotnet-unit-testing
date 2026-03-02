using Xunit;
using xUnitLibrary.APP;

namespace xUnitLibrary.Test
{
	public class CalculatorTest
	{
		[Fact]//her test edilecek metot için bu attribute kullanılır. bu attribute sayesinde test metotları çalıştırılabilir hale gelir. bu attribute test metodunun bir test metodu olduğunu belirtir.
		public void TestAdd()//test meotdu erişim belirleyicisi public olmak zorunda, void olmak zorunda, parametre almamalı ve isimlendirme kurallarına uymalıdır. genellikle test edilecek metot adıyla benzer bir isimlendirme yapılır.
		{
			//Arrange:değişkinlerimi tanımlayacağımız yerdir ve değer vereceğimiz,nesne örneği oluşturacağımız yer
			int a = 5;
			int b = 6;
			//calculator classını çağırıyoruz ki bunun içindeki metodu test edebileyim
			var calculator = new Calculator(); // böylrcr arrenge aşaması bitti ilk değerlerimizi initialize ettik ve classımızdan bir nesne oluşturduk

			//Act:yukarıda initilaze ettiğimiz classa paramatreler verip test metotları çalıştıracağımız yer. burada calculator uzerinden add metodunu çalıştıcam
			var total = calculator.add(a, b); // act aşaması bitti add metodunu çalıştırdık ve sonucunu total değişkenine atadık

			//Assert:doğrulama evresidir. act evresinden çıkan sonuç benim bekleidğim sonuç mu diye kontrol edeceğim yer. burada total değişkeni benim beklediğim sonucu veriyor mu diye kontrol edeceğim
			Assert.Equal<int>(11, total);//assert içinde onalrca statik metot var. bir classı karşılaştırmak,
											//bir riski karşılaştırabilriiz. bunlardan en temeli; iki string ifadeyi karşılaştırmak,
											//iki int/double/float vs ifadeyi karşılaştırmak için kullanılacak metot "Equals" metodudur. bu metot generic bir metot olduğu için türü belirtmemiz gerekiyor. ben int türünde bir karşılaştırma yapacağım için <int> yazıyorum. ilk parametre beklediğim sonuç, ikinci parametre act aşamasından çıkan sonuç
		}                               //NotEqual metodu beklediğim sonuçla act aşamasından çıkan sonucu karşılaştırır ve eğer birbirlerine eşit değillerse test başarılı olur. eğer birbirlerine eşitlerse test başarısız olur.
	}
}