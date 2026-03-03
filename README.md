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
