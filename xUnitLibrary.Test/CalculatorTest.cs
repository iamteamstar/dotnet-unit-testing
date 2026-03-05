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
			var calculator =new CalculatorService(); // böylrcr arrenge aşaması bitti ilk değerlerimizi initialize ettik ve classımızdan bir nesne oluşturduk

			//Act:yukarıda initilaze ettiğimiz classa paramatreler verip test metotları çalıştıracağımız yer. burada calculator uzerinden add metodunu çalıştıcam
			var total = calculator.add(a, b); // act aşaması bitti add metodunu çalıştırdık ve sonucunu total değişkenine atadık

			//Assert:doğrulama evresidir. act evresinden çıkan sonuç benim bekleidğim sonuç mu diye kontrol edeceğim yer. burada total değişkeni benim beklediğim sonucu veriyor mu diye kontrol edeceğim
			Assert.Equal<int>(11, total);//assert içinde onalrca statik metot var. bir classı karşılaştırmak,
										 //bir riski karşılaştırabilriiz. bunlardan en temeli; iki string ifadeyi karşılaştırmak,
										 //iki int/double/float vs ifadeyi karşılaştırmak için kullanılacak metot "Equals" metodudur. bu metot generic bir metot olduğu için türü belirtmemiz gerekiyor. ben int türünde bir karşılaştırma yapacağım için <int> yazıyorum. ilk parametre beklediğim sonuç, ikinci parametre act aşamasından çıkan sonuç
		}                               //NotEqual metodu beklediğim sonuçla act aşamasından çıkan sonucu karşılaştırır ve eğer birbirlerine eşit değillerse test başarılı olur. eğer birbirlerine eşitlerse test başarısız olur.


		[Fact]
		public void TestMethodsContain()
		{
			//	Assert.Contains("Azad", "Azad Koçak");//Constaints: ifadede azad geçip geçmediğini kontrol eder
			//contains metodu gerçek değerin içinde beklediğimiz değerin olup olmadığını kontrol eder			
			//DoesNotContain metodu gerçek değerin içinde beklediğimiz değerin olmadığını kontrol eder aynı örnekten gidersek
			//Assert.DoesNotContain("Azad", "Azad Koçak"); Azad Kocakta azad geçiyor ama ben beklediğim değerin geçmemesini istediğim için test başarısız olur. Assert.Contains("Azad", "Azad Koçak");
			//ifadesinde ise azad geçiyor ve ben beklediğim değerin geçmesini istediğim için test başarılı olur.

			var names = new List<string>() { "Azad", "Koçak" };
			Assert.DoesNotContain(names, x => x == ("ahmet"));// bu örnekte names koleksiyonunun içinde azad geçiyor mu diye kontrol ediyoruz.
														//eğer azad geçiyorsa test başarılı olur. eğer azad geçmiyorsa test başarısız olur.

			//bekledğim değer, beklediğin değerin geçip geçmediğinin kontrol edileceği gerçek değer

		}

		[Fact]
		public void TestMethodsMatch()
		{
			//matches bir regex ifadesi alır ve bu ifade üzerinden eğer beklediğim değer bu regex ile uyuyorsa true döner uymazsa  false döner
			//^dog bu regex kodu şunu işade eder: beklenen kelime başında dog ile başlıyorsa true döner başlamıyosa yanlıştır dog$ bu regex kodu ise beklenen kelime sonunda dog ile bitiyorsa true döner bitmiyorsa false döner
			//^dog$ kelime içinde dog yazması gerek
			//DoesNotMatch ise regexe göre içinde sonunda veya başında olmadığı durumda true döner

			var regex = "^dog";
			Assert.DoesNotMatch(regex, "dfgddoggy");
		}

		//startswith ile belirliten değerle başlayıp başlamadığının kontrolü. Gelen değer Azad Koçak. StartWith ile Azad verirsek gerçek değerde öyle başlayıp başlamadığının kontrolü yapılır
		//startWith ile ilk kelimeye bakar, endWith ile son kelimeye bakar
		[Fact]
		public void TestMethodsEndsStart()
		{
			Assert.EndsWith("Azad", "Kocak !23441 Azad");
		}
		//içerideki dizin boş mu kontrolü
		[Fact]
		public void TestMethodsEmpty()
		{
			Assert.NotEmpty(new List<string>() { "asas" });
		}
		//gelen değerin belli bir aralıkta olup olmadığını kontrol eder. örneğin gelen değer 2. bu gelen değer 1 ile 5 aralığında mı teyit edilir
		[Fact]
		public void TestMethodsInRange()//herhangi bir metot parametre almıyorsa fact attribute ü kullanır. parametre aldığında başka attribute kullanır
		{
			Assert.NotInRange(54, 4, 6);
		}
		//içerisinde vermiş olduğumuz list in array in bir elemanı varsa true,daha fazla ise false döner 
		[Fact]
		public void TestMethodsSingle()
		{
			//Assert.Single(new List<string>() { "asas" ,"sdsad"});
			Assert.Single(new List<string>() { ""});

			//Assert.Single<string>(new List<string>() { "azad","sdsad"});
		}
		//IsType: generic metottur. içerdeki ifadnin tipinin doğru olup olmadığının kontrolunu yapar 
		[Fact]
		public void TestMethodsIsType()
		{
			Assert.IsType<string>("ds");//içerideki ifade string olduğu için true döner
			Assert.IsNotType<int>("");
		}
		[Fact]
		public void TestMethodsIsAssignableFrom()
		{
			//bir tipin bir tipe referans verip veremeyeceğini test eder. Eğer bir tip başka bir tipe referans verilebiliyorsa geriye true veremiyorsa false döner
			Assert.IsAssignableFrom<IEnumerable<string>>(new List<string>());//mettotdan beklediğim tip [gelecek kısım :()] mutlaka  IEnumarable stringi implemente etmiş olmalı ki ona assignable olsun yani atanabilsin
			Assert.IsAssignableFrom<Object>("string");//objeden mras alan herhangi bir tip dönbebilir int,float,string, bool...
		}
		[Fact]
		public void TestMethodsNull()
		{
			//null içeriye vermiş olduğumuz ifademiz null ise true değilse false döner
			//not null tam tersi durumdur boşsa false doluysa true
			var deger = "test";
			Assert.NotNull(deger);
		}
		[Fact]
		public void TestMethodsEqual()
		{
			//equal:iki değeri karşılaştırmak için kullanışlır iki değer aynıysa true değilse false döner
			Assert.Equal<int>(2,2);//generic kullanmak hem daha performanslı hem daha güvenli
		}
		[Fact]
		public void TestMethodsTrue()
		{
			Assert.True(true);
		}
	}
}