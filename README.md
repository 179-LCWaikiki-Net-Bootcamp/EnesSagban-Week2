# Lcw-EcommerceApi

Projenin Database'i CodeFirst yaklaşımı ile data'ları ilgili Northwind Api'lerinden çekilerek oluşturuldu.
Database'inde Product, Category ve Supplier olarak 3 tablo oluşturuldu. Product tablosu ile diğer 2 tablo arasında 'OneToMany' ilişkisi var.

Katmanlı mimari uygulanarak geliştirildi. 'Core' katmanında 'BaseEntity' ve CRUD metotları generic olarak tanımlandı.
BLL'deki Service ve DAL'daki Repository'ler Constructor Dependency Injection ile oluşturulup Program.cs'e 'AddScoped' olarak eklendi.

Model katmanında tanımlanan Entity'ler 'AutoMapper' kullanılarak ilgili 'ViewModel'e maplandiken sonra UI'da kullanıldı.
Katmanlı mimariye uygun olarak geliştirildiğinden istenilirse BLL katmanı doğrudan mevcut MVC katamanını da besleyebilir.
Burada araya bir katman eklemek daha uygun olacağından 'ServiceLayer' oluşturmak için API'ye aktarıldı.

Tüm Controller'larda 

* Get/All
* Get/id
* Create
* Update
* Delete
* Search 

işlemleri yapılabilmektedir.

* Ayrıca Category ve Supplier için girilen Id'e göre ilgili Product'lar listelenebilmektedir.

![Category](https://www.linkpicture.com/q/Category.png)

![Product](https://www.linkpicture.com/q/Product.png)

![Supplier](https://www.linkpicture.com/q/Supplier.png)
