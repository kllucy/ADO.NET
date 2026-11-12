using car_k;

string connectionString = "Data Source=Car.db";

CarRepository_ carRepository = new CarRepository_(connectionString);

var car1 = new Car { brand = "Hundai", model = "solaris", Date = "2021-01-01", price = 2343535 };
var car1 = new Car { brand = "Hundai", model = "solaris", Date = "2021-01-01", price = 2343535 };
var car1 = new Car { brand = "Hundai", model = "solaris", Date = "2021-01-01", price = 2343535 };





//Модель данных - класс Car, описывающий сущность автомобиля
//Репозиторий - CarRepository, инкапсулирующий всю логику работы с бд (CRUD)
//Точка входа - Program, деионстрирующий все методы.

//Car (идентификатор, марка, модель, год выпуска, стоимость и метод для красивого вывода)

//В точке входа (инициализация бд, добавить 3 авто, вывести список авто, изменить цену и модель у одного из авто, удалить авто, вывести новый список)
//Microsoft.Data.Sqlite
