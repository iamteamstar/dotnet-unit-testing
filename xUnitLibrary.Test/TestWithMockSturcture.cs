namespace xUnitLibrary.Test
{
	public class TestWithMockSturcture
	{
		/*
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
		eğer ana proje bu iki yapıdan herhangi birini uygulamıyorsa kodlar birbirine çok sıkı bir şekilde bağlıysa mocku kullanamayız. unit test yazılabilir
		fakat mock yapılamaz.



		 */
	}
}
