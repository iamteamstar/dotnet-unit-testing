using Moq;
using Xunit;
using xUnitLibrary.APP;

namespace xUnitLibrary.Test
{
	public class TheoryTest
	{
		/*
		 Bir metotta [Fact] attribute kullanarak iki şey söyelmiş oluyoruz: o metodun bir test metotu olacağını belirtiyoruz
		ve ikincisi de bu test metodunun parametre almayacağını belirtmiş oluyoruz.
		Peki test metotlarım paremetre alırsa ne olacak? Örneğin bir metot dışardan parametre alıyor ve bizim gönderiğimiz
		parametrelere göre uygun sonuçlar üretiyor mu üretmiyor mu testi gerçekleştirmek istiyoruz. Bunun için iki attribute kullanılır
		[Theory]
		[InlineData](param-1,param-2,param-3) :bu iki birbirine bağlı attribute kullanılır
		[Fact] in tam tersidir. Fact parametre almayan metotlarda kullanılırken theory de metot, parametre almak zorundadır. Parametreli 
		metoda geçmek için ise InlineData kullanılır. Bununla beraber metot içersine değişkenlere gönderiyoruz. sınırı yoktur 3 tane de yazabilir
		ve testin 3 kez çalışmasını sağlayabilriiz. farklı datalara karşı farklı sonuçları bu şekilde görebilriz
		 */
		public Calculator calculator { get; set; }
		public Mock<ICalculatorService> myMock { get; set; }
		public TheoryTest()
		{
				 myMock = new Mock<ICalculatorService>();//test edeceğimiz metodun olduğu sınıfın miras aldığı interface. test edeceğimiz metot ile ilgili işlemleri
														//yaptığımız kısım CalculatorServis sınıfında. bu metot nerde? Calculator classı yani ana sınıfımızda.
														//bizim ana clasımız CalculatorServis üzerinden add metodu çalıştııryor. bu add metodunun çalışabilmesi için
														//Calculator constructorının ICalculatorServisi implemente etmiş bir classa ihtiyacı var..--> CalculatorService
			this.calculator = new Calculator(myMock.Object);//burada bizden istediğ, parametre olan ICalculatorServise. bu servisi yukarıda
															//oluşturuğumuz mock nesnesi üzerinden vereceğiz: myMock.Object Artık Calculator nesnemiz ayağa kalktı ama sahte taklit ettiğim mock nesnesi ile

		}

		[Theory]
		[InlineData(2, 4, 6)]
		public void AddTestWithTheory(int a, int b, int expectedTotal)
		{
			myMock.Setup(x => x.add(a, b)).Returns(expectedTotal);//eğer ICalculatorService üzerinde "add" metodu çağrılırsa, bana return olarak "expectedTotali" dön diyorum
			Assert.Equal(expectedTotal, calculator.add(a, b));
		}
		[Fact]
		public void SubstractTestWithTheory()
		{
			int a = 1;
			var b = 2;
			//var calculator =new Calculator();
			myMock.Setup(x=>x.subtract(a, b)).Returns(a+b);
			var actualTotal = calculator.subtract(a, b);
			Assert.Equal(a+b, actualTotal);
		}
		/*
		 Test Method İsimlendirme
			Test metodunun ismi o metodun yapmış olduğu işi tek bir bakışta anlatmalıdır. O yüzden isimlendirme 
			açıklayıcı hem de tutarlı olmalıdır. Best practice olarak : MethodName_StateUnderTest_ExpectedBehavior
			yani TestEdilecekMetodAdı_TestAltındakiDurum_BeklenenDavranış
			add_simpleValues_returnTotalValue
			Application_WithUnderAge_TransferredToAutoRejected
        */
		[Theory]
		[InlineData(2, 4, 6)]
		[InlineData(2, -2, 0)]
		public void Add_CollectionValues_ReturnTotalValue(int a, int b, int expectedTotal)
		{
			myMock.Setup(x => x.add(a, b)).Returns(expectedTotal);
			var actualTotal = calculator.add(a, b);
			Assert.Equal<int>(expectedTotal, actualTotal);
		}
		[Theory]
		[InlineData(2, 0, 0)]
		[InlineData(0, 5, 0)]//ikisinden biri 0 sa sonuç direkt 0 olmalı o yüzden burada testten geçemeyecek
		public void Add_ZeroValues_ReturnZeroValue(int a, int b, int expectedTotal)
		{
			var actualTotal = calculator.add(a, b);
			Assert.Equal<int>(expectedTotal, actualTotal);
		}
		[Theory]
		[InlineData(-5, 3, 2)]
		[InlineData(4, -8, 4)]
		[InlineData(-4, -8, 4)]
		[InlineData(-25, 50, 25)]
		public void Substract_NotNegativeValue_ReturnAbsoluteValue(int a, int b, int expectedSub)
		{
			myMock.Setup(x=>x.subtract(a,b)).Returns(expectedSub);
			var actualSub = calculator.subtract(a, b);
			Assert.Equal(expectedSub, actualSub);
		}
		[Theory]
		[InlineData(0,3,0)]
		[InlineData(1,3,3)]
		[InlineData(1,null,0)] //Sınıflar birbiriyle doğru konuşuyor mu testi...
		public void ConstructorServive_MultipleValues_ReturnMultiplication(int a, int b,int expectedMultiple)
		{
			var calculator = new CalculatorService();
			var actual = calculator.multiple(a, b);
			Assert.Equal(expectedMultiple, actual);
		}
		/*Moq frameworkunun de bazı hazır metotları vardır. Bir metodun çalışıp çalışmadığını test etmek, bir metodun iki kere mi 3 kere mi çalıştığını 
		görmemizi sağlayan metotlar vardır. Verify ile bir metodun kaç kez çalıştığını eya hiç çalışmama durumunu test edebiliriz
		*/
		[Theory]
		[InlineData(0,3,3)]
		public void Add_SimpleValues_ReturnTotalValues(int a, int b,int expectedTotal)
		{
			myMock.Setup(x=>x.add(a,b)).Returns(expectedTotal);
			var result = calculator.add(a, b);//add metodunun yalnız bir kere çalışmasını garanti etmek istiyorum. Eğer iki kez çalışırsa test başarısız olsun
			Assert.Equal(expectedTotal, result);
			myMock.Verify(x=>x.add(a,b),Times.Once);    //myMock üzerinden doğrula(neyi? -- > add metotdunun doğru çalışması için times.once bu metot bir kez çalışsın diyoruz.
														//never dediğimiz zaman hiç çalışmamış olmaısnı test ediyorum.yani bu test çalıştığı zaman add metodu hiç çalışmazsa testten geçecek metot çağrılmazsa testten geçecek
														//myMock.Verify(x=>x.add(a,b),Times.AtLeast(2) //metodun en az iki kere çalışması için ise AtLeast(istenen)

																//en fazla 2 kere çalışması için ise myMock.Verify(x=>x.add(a,b),Times.AtMost(2)
}
	}
}
