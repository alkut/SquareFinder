## Задание 1 
Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. Дополнительно к работоспособности оценим:

Юнит-тесты

Легкость добавления других фигур

Вычисление площади фигуры без знания типа фигуры в compile-time

Проверку на то, является ли треугольник прямоугольным

### Решение

Решение представляет собой статический класс [SquareFinder](https://github.com/alkut/SquareFinder/blob/master/SquareFinder/SquareFinder.cs), в котором реализованы два варианта статического метода, вычисляющего площадь фигуры. 


### Юнит-тесты

Тесты можно найти в проекте [Tests](https://github.com/alkut/SquareFinder/tree/master/Tests) - отдельно тестируются классы [Circle](https://github.com/alkut/SquareFinder/blob/master/Tests/TestCircle.cs) и [Triangle](https://github.com/alkut/SquareFinder/blob/master/Tests/TestTriangle.cs). Тесты используют NUnit Test.

### Добавление новых фигур

Чтобы добавить новую фигуру, добавьте класс, реализующий интерфейс [IFigure](https://github.com/alkut/SquareFinder/blob/master/SquareFinder/Figures/IFigure.cs). Для корректной работы необходимо, чтобы в классе был реализован дефолтный конструтор, конструктор с аргументом params double[] и публичный метод double FindSquare().

### Вычисление площади фигуры без знания типа фигуры в compile-time

Проект [RunTime](https://github.com/alkut/SquareFinder/blob/master/RunTime/Program.cs) представляет собой консольное приложение, демонстрирующее работоспособность метода нахождения площади без знания типа фигуры на этапе компиляции.

### Проверка на то, является ли треугольник прямоугольным

В классе [Triangle](https://github.com/alkut/SquareFinder/blob/master/SquareFinder/Figures/Triangle.cs) реализован метод bool IsRight() - определяющий, является ли треугольник прямоугольным. 

## Задание 2


В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

### Решение

Так как схема базы данных не была указана, в файле [ManyToMany.sql](https://github.com/alkut/SquareFinder/blob/master/SquareFinder/ManyToMany.sql) была описана предложенная мною схема, запросы на заполнение всех таблиц, а также искомый запрос.
<br/> *Прим*. Чтобы исполнить запрос, создайте базу данных TestDB, либо измените первую строчку в скрипте : USE TestDB;