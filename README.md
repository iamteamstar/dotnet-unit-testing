# Unit Test Nedir?
**Unit Test:** kodumuzdaki en küçük parça davranışını kod ile test etmektir.
**"Yazılım tasarımı denen şey, yazılımın ta kendisidir."** Yazılım, kanıtlanmak ister yazılan her kodun çalıştığını görmezsek
o kod yarım kalmıştır. Eğer bir yazılımı test etmek zor deniliyorsa muhtemelen yazılıma uygun olmayan veya berbat bir tasarım kullanılmıştır.
Kodun, **iş yapan bir parçasının** doğru çalışıp çalışmadığını kod yazar test etmeye unit test denir.
## Unit test, hiç konuşulmasa da ikiye ayrılır: 
**Cemant Unit Test(Çimento) :** Unit testler yazılır, bu testler katılaşır, sağlamlaşırlar ve test ettiği kodu değiştirilmez hale
getirirler. Kod değişirse, testi çöpe atmak gerekir. Çimento test, koda yapışır ve çok büyük bağımlılık oluşturur.

**Behavioral Test(Davranışsal):** TDD 'yi (Test Driven Development) kolaylaştırır. Test yazarak tasarım yapabilmemizi
sağlayan bir çeşittir. Genel olak unit test deyince aklımıza gelen davranışsal testtir.

### Kaynak
https://www.youtube.com/watch?v=pjx06exON7g

## Unit Test Frameworkleri:
**MSTest :**  Microsoft tarafından geliştirilmiştir. Paralel test yürütmeyi destekler; paralellik, Metot düzeyinde veya Sınıf düzeyinde mümkündür.

**NUnit Test :** NUnit çerçevesi kullanılarak testler hem seri hem de paralel olarak çalıştırılabilir. Paralel test yürütme, derleme, sınıf veya metot seviyesinde mümkündür.

**xUnit Test :** Open source olarak .net projelerinde kullanılır. Diğer frameworklere göre daha üstün ve kodlanması basit olandır.

## xUnit Paketleri:
**xUnit Kütüphanesi :** xUnit'in ana kütüphanesidir. Bu kütüphane içindeki metotları kullanarak unit test yazabiliyoruz.

**xUnit.runner.visualstudio :** testlerimizi çalıştırmak için kullanacağımız tool (view -> test explorer)

**Microsoft.Net.Test.Sdk :** xUnit içerisine yazmış olduğumuz testleri build edebilmek ve debug atabilmek için gerekli kütüphane.

**Coverlet.Collector :** Core cross platform olduğundan dolayı core uygulamasının da cross olması için gerekli kütüphaneTest 

Test için oluşturduğumuz templatei özünde bir class librarydir. Yani biz bir class library açıp içine bu paketleri eklersek yine test yazabiliriz. İşin aslı 
ayrı bir proje oluşturmaya da gerek yoktur, var olan bir proje üzerine de bu paketleri eklesek yine unit test yazabiliriz. Tabii çok sağlıklı olmaz. Uygun olan,
ayrı bir proje oluşturup ayrı bir proje üzerinden test edilecek projenin testlerinin burada yazılmasıdır. 

Not: Metotlarını test edeceğimiz projeyi referans olarak test projemize eklemeliyiz.

# Unit Test Aşamaları
Unit test yazmak üç aşamadan oluşur:
**Arrange :** değişkinlerimizi tanımlayacağımız yerdir ve değer vereceğimiz,nesne örneği oluşturacağımız yer
**Action :** arrenge kısmında initilaze ettiğimiz classa paramatreler verip test metotları çalıştıracağımız yer.
**Assert :**doğrulama evresidir. act evresinden çıkan sonuç benim bekleidğim sonuç mu diye kontrol edeceğim yer. 

## Assert Metotları 
Assert doğrulama evresidir. act evresinden çıkan sonuç benim bekleidğim sonuç mu diye kontrol edeceğim yer. burada total değişkeni benim beklediğim sonucu veriyor mu diye kontrol edeceğim

Assert.Equal<int>(11, total);			//assert içinde onalrca statik metot var. bir classı karşılaştırmak,
										 //bir riski karşılaştırabilriiz. bunlardan en temeli; iki string ifadeyi karşılaştırmak,
iki int/double/float vs ifadeyi karşılaştırmak için kullanılacak metot "Equals" metodudur. bu metot generic bir metot olduğu için türü belirtmemiz gerekiyor. ben int türünde bir karşılaştırma yapacağım için <int> yazıyorum. ilk parametre beklediğim sonuç, ikinci parametre act aşamasından çıkan sonuç
		}                               //NotEqual metodu beklediğim sonuçla act aşamasından çıkan sonucu karşılaştırır ve eğer birbirlerine eşit değillerse test başarılı olur. eğer birbirlerine eşitlerse test başarısız olur.


Assert.Contains("Azad", "Azad Koçak");//Constaints: ifadede azad geçip geçmediğini kontrol eder
contains metodu gerçek değerin içinde beklediğimiz değerin olup olmadığını kontrol eder			
DoesNotContain metodu gerçek değerin içinde beklediğimiz değerin olmadığını kontrol eder aynı örnekten gidersek

Assert.DoesNotContain("Azad", "Azad Koçak"); //Azad Kocakta azad geçiyor ama ben beklediğim değerin geçmemesini istediğim için test başarısız olur. Assert.Contains("Azad", "Azad Koçak"); //ifadesinde ise azad geçiyor ve ben beklediğim değerin geçmesini istediğim için test başarılı olur.
var names = new List<string>() { "Azad", "Koçak" };
Assert.DoesNotContain(names, x => x == ("Azad"));// bu örnekte names koleksiyonunun içinde azad geçiyor mu diye kontrol ediyoruz.eğer azad geçiyorsa test başarılı olur.

var regex = "^dog";
Assert.DoesNotMatch(regex, "dfgddoggy");

matches bir regex ifadesi alır ve bu ifade üzerinden eğer beklediğim değer bu regex ile uyuyorsa true döner uymazsa  false döner
^dog bu regex kodu şunu işade eder: beklenen kelime başında dog ile başlıyorsa true döner başlamıyosa yanlıştır dog$ bu regex kodu ise beklenen kelime sonunda dog ile bitiyorsa true döner bitmiyorsa false döner
^dog$ kelime içinde dog yazması gerek
DoesNotMatch ise regexe göre içinde sonunda veya başında olmadığı durumda true döner


Assert.EndsWith("Azad", "Kocak !23441 Azad");
startswith ile belirliten değerle başlayıp başlamadığının kontrolü. Gelen değer Azad Koçak. StartWith ile Azad verirsek gerçek değerde öyle başlayıp başlamadığının kontrolü yapılır
startWith ile ilk kelimeye bakar, endWith ile son kelimeye bakar


Assert.NotEmpty(new List<string>() { "asas" }); //içerideki dizin boş mu kontrolü

Assert.NotInRange(54, 4, 6);//içerisinde vermiş olduğumuz list in array in bir elemanı varsa true,daha fazla ise false döner 

Assert.Single(new List<string>() { ""});


Assert.IsType<string>("ds");//içerideki ifade string olduğu için true döner
Assert.IsNotType<int>("");
IsType: generic metottur. içerdeki ifadnin tipinin doğru olup olmadığının kontrolunu yapar 

Assert.IsAssignableFrom<IEnumerable<string>>(new List<string>());	
//mettotdan beklediğim tip [gelecek kısım :()] mutlaka  IEnumarable stringi implemente etmiş olmalı ki ona assignable olsun yani atanabilsin
Assert.IsAssignableFrom<Object>("string"); //objeden mras alan herhangi bir tip dönbebilir int,float,string, bool...


var deger = "test";
Assert.NotNull(deger);
//null içeriye vermiş olduğumuz ifademiz null ise true değilse false döner
//not null tam tersi durumdur boşsa false doluysa true

//equal:iki değeri karşılaştırmak için kullanışlır iki değer aynıysa true değilse false döner
Assert.Equal<int>(2,2);//generic kullanmak hem daha performanslı hem daha güvenli

## Mocking ve Moq Framework
Mock, uygulama içinde class veya interfacelerin davranışlarını taklit etmemizi sağlayan objelerdir.
Test içindeki kodların gerçek dünyadaymış gibi calışmasını mock kütüphanesi ile yaparız.
neden kodlarımızın gerçek dünyada gibi çalışmasına ihtiyacımız var? 
Diyelim ki ;Dıştaki bir API dan hizmet alıyoruz. Bu API sizin yerinize hesaplamaları, hesaplamaları yapıp 1 tane integer 
değer dönüyor.Örneğin http üzerinden Calculator.com üzerinde add metodu var 2/3'ü gönderiyorsunuz.Orada çok yoğun bir algoritma
kullandıktan sonra siz de bir data dönüyor.Bu dönmüş olduğu data yani API'yi bir request yaptığınız zaman
size gelecek cevabın da 5 saniye olduğunu düşünelim. Basit bir hesaplama değil, çok yoğun bir hesaplama olduğunu düşünelim.
Gerçek dünyadan bir örnek vermiş olalım Ve 5 saniyede dönüyor. Test ettiğimiz metot sayısı örneğin 4. her birine 5 sn de dönüyordu
sadece bir metodu test etmek 20 sn sürdü. ki normal şartlarda onlarca class yüzlerce metot olduğunu düşünürsek test metotlarını 
çalıştırmak saatlerimizi alır.
Mock tam burada devreye girer. Ben senin gerçek dünyadaki yerine kodlama tarafına sanal bir dünya bir ortam oluşturayım. örneğin 
add metoduna istek yaptığın zaman gerçek uygulamada, ben bu api yi çalıştırmak yerine dönecek datayı (tahmin edilen,beklenen) biliyourz.
onun yerine belirlenen bir add metodu çalışsın, gerçek bir api ye istek yapmak yerine arka tarafta sahte bir data üzerinden sonuç dönelim yani 
add metodunu TAKLİT edelim. 
Çok uzun sürecek kod bloklarımızı taklit ederek fasrklı davranmasını sağlıyoruz 
Projelermizide unit test yazarken mock kullanabilmek için projemizin nasıl bir yapıda olması gerek?
her projede mocku kullanamayız. yani bir projede unit test yazabiliriz ama mock kullanmak için projemizin bazı prensipleri
bazı design patternleri uygulamış olması gerek 

1-Abstraction: projenin soyut bir yapıda olması gerek. mümkün olduğunca bağımlılıklarımızı(Dependency) ilgili classlara bir interface olarak
geçiyor olmamız lazım. bu şekilde geçilince mockla beraber ilgili classın ortamnı taklit ediyor olabiliceğiz

2-Dependency Injection: eğer design pattern e uygulanıyorsa çok kolay biçimde mock yapılarını kullanıyor oluruz. bir desgin patterndır.
eğer projede construcotrların içierisinde interfaceler geçiyorsak ve Dependency Injection patterni uyguluyorsak çok rahatlarız
eğer ana proje bu iki yapıdan herhangi birini uygulamıyorsa kodlar birbirine çok sıkı bir şekilde bağlıysa mocku kullanamayız. unit test yazılabilir fakat mock yapılamaz.

 Şuana kadar calculator projemizde herhnagi bir prensip uygulanmamıştı. yani kodlarımız birbirine sıkı bir şekilde bağlı. mock ile taklit etmek için 
 projelerimizin abstraction ve dependency injectiona uygun olarak düzenlenmesi gerektiğinden bahsetmiştik.DI nedir peki? Bağımlılıkların constructor 
 ortamında geçilmesidir. 
1-Öncelikle soyutlama için calculator adında bir interface oluşturalım :ICalculatorService
2-sonrasonda bu interface servisi implemente edecek bir class oluşturalım :CalculatorService
3-ana sınıfımıza gidiyoruz ve di prensibini uyguluyoıruz yani ana sınıfımızın artık bir bağımlılığı olacak.
Bu sınıf consturtorunda interface çağırır
önceki hali

	public class Calculator
	{
	public int add(int a, int b)
		{
			int total = a + b;
			if (a == 0 || b == 0)

				return 0;
			return total;
		}
		}




kodun sıkı sıkı add metoduna bağlı olamsını kaldırdık.
Peki amacımız ne? Biz mock ile beraber interfacelerimizin nasıl davranış sergilediğini test etmek
# Moq Framework 
Bu test etme imkanını bize sağlayan hazır frameworkler var. yani biz elle taklit etmek yerine hazır kütüphane kullanabiliyoruz
tabiki hazır framework kullandığımız zaman extra kod yazmıyoruz, zamandan kazanıyoruz iyi test edilmiş open source bir framework 
olduğundan dolayı projelerde gönül rahatlığıyla kullanılabilir.
test zamanında dependencyleri simüle etmemizi sağlıyor. test altında sistemimizin nasıl çalıştığını izlememizi sağlıyor
	
	//bu servis hesaplama ile ilgili işlemleri yapacak ve interface metotlarını barındıracak
	public interface ICalculatorService
	{
		int add (int a,int b);
		double multiple (double a,double b);
	}
}


## Verify 

Moq frameworkunun de bazı hazır metotları vardır. Bir metodun çalışıp çalışmadığını test etmek, bir metodun iki kere mi 3 kere mi çalıştığını 
görmemizi sağlayan metotlar vardır. Verify ile bir metodun kaç kez çalıştığını eya hiç çalışmama durumunu test edebiliriz


## Throw

Throw metod üzerinden geriye hata fırlatmak için kullanılır? tamam da nedir bu, anlamı nedir?
diyelim ki gerçek projede bir servisten belli bir şarta göre gerite bir hata fırlatıyoruz. işte bu gibi durumları mock tarafında simüle etmek için kullanılır

## Callback & It.IsAny

//bir metot üzerinden callback çalıştırmak: ikinci bir metod çalıştırmak kısaca. simule edeceğimiz metot  sadece int tipi değer alışsa çalışsın, string değeri alırsa şu değeri alsın vs
//simule edilen metottan sonra .callback() şeklinde çağrılır 
//simüle edeceğimiz metotta herhangi bir değeri kabul etmek için ise It.IsAny<type> kullanılır

	/*
	[Theory]
	[InlineData(2,3,6)]	
	public void Multiple_CallbackAndIsAny(int a,int b,int expectedMultiple)
	{
	myMock.Setup(c=>c.multiple(a,b)).Returns(expectedMultiple);
	Assert.Equal(15,calculator.multiple(a,b));
	//	Assert.Equal(10,calculator.multiple(a=2,b=5)); --> işte burada hata alırız çünkü şuan a ve b değerleri 2 ve 3 dışında herhangi
	//	bir şey kabl etmiyor. yani sadece onları test ediyor. bizim bunu değiştirrip farklı sayıları da test etmemiz gerekiir
	//şimdi bu metodu yorum satırı yapıp aşağıda anlatıyorum
	}
	*/

	[Theory]
	[InlineData(2, 3, 6)]
	public void Multiple_CallbackAndIsAny(int a, int b, int expectedMultiple)
	{
	int actualMultiple=0;
	myMock.Setup(c => c.multiple(It.IsAny<int>(),It.IsAny<int>()))//burada a ve be değil, herhangi bir değeri kabul edeceğini belirten It.IsAny kullanılır. yani bu metot integer olarak herhangi bir değer alabilir
		.Callback<int,int>((x,y)=>actualMultiple=x*y);//herhangi bir integer dfeğer geldiği zaman callbakck ile şu metot çalışsın diyoruz
	calculator.multiple(a,b);
	Assert.Equal(expectedMultiple, actualMultiple);
	calculator.multiple(20, 5);
	Assert.Equal(100, actualMultiple);//callback ve iı.isAny kullanmasaydık bu şekilde birden çok equal metodu çağıramazdık
	}





	
	
	


	



	



