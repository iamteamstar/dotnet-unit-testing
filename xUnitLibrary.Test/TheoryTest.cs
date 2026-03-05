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
		[InlineData(2, -2, 0)]//a,b,expectedTotal
		public void AddTestWithTheory(int a, int b, int expectedTotal)
		{
			

			myMock.Setup(x => x.add(a, b)).Returns(expectedTotal);//eğer ICalculatorService üzerinde "add" metodu çağrılırsa, bana return olarak "expectedTotali" dön diyorum
			
			// calculator = new Calculator();
			var actualTotal = calculator.add(a, b);//gerçek data

			Assert.Equal(expectedTotal, actualTotal);
		}
		[Fact]
		public void SubstractTestWithTheory()
		{
			int a = 1;
			var b = 2;
			//var calculator =new Calculator();

			var actualTotal = calculator.subtract(a, b);
			Assert.Equal(1, actualTotal);
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
			var actualSub = calculator.subtract(a, b);
			Assert.Equal(expectedSub, actualSub);
		}
		[Theory]
		[InlineData(0,3,0)]
		[InlineData(1,3,0)]
		public void ConstructorServive_MultipleValues_ReturnZeroForever(double a, double b,double expectedMultiple)
		{
			myMock.Setup(x=>x.multiple(a,b)).Returns(expectedMultiple);
		}

	}
}
