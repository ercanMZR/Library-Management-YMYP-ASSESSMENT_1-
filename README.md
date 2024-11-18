# Library Management System
Bu proje, bir Kütüphane Yönetim Sistemi geliştirilmesi amacıyla tasarlanmıştır. Projede, kitap bilgilerini yönetmek için bir ASP.NET Core Web API geliştirilmiştir. Proje, modern yazılım geliştirme prensipleri olan Katmanlı Mimari, Generic Repository, Unit of Work ve Result Pattern kullanılarak yapılandırılmıştır.
### Proje Mimarisi
Proje katmanlı mimari prensiplerine göre yapılandırılmıştır ve şu katmanlardan oluşur:
- API : Kullanıcıların API'ye eriştiği HTTP endpoint'ler burada tanımlanmıştır.CustomControllerBase ile özelleştirilmiş bir sonuç döndürme mekanizması eklenmiştir.

- SERVICE : İş mantığı burada yer alır.Result Pattern kullanılarak işlem sonuçları döndürülür.
- REPOSITORY : Veritabanı ile ilgili işlemler burada gerçekleştirilir.Generic Repository Pattern uygulanmıştır.
### Yaşam Döngüsü

* Analiz: Gereksinimler belirlendi.
* Tasarım: Katmanlı mimari tasarlandı.
* Uygulama: Repository ve Service katmanları geliştirildi.
* Test: CRUD operasyonları manuel ve otomasyon testlerine tabi tutuldu.
* Bakım: Kod iyileştirmeleri ve performans takibi yapılacaktır.


