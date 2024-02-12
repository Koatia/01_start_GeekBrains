## Итоговая контрольная работа по основному блоку

*Задача:* Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

### Описание решения

#### Цель:
Разработка программы на языке C#, которая фильтрует массив строк, оставляя только те строки, длина которых меньше или равна 3 символам.

Блок-схема алгоритма решения приведена в файле [algorithm_flowchart](algorithm_flowchart.png).

#### Шаги реализации:

1. **Инициализация исходного массива строк:**
   - Программа начинается с объявления и инициализации массива строк. Этот массив задан статически в коде.
   - Пример исходного массива: `string[] originalArray = ["apple", "cat", "dog", "banana", "sky", "cup"];`

2. **Подсчёт подходящих строк:**
   - Инициализируется переменная `count` для подсчета количества строк, удовлетворяющих условию (длина <= 3 символа).
   - Программа перебирает каждый элемент исходного массива. Для каждой строки проверяется, удовлетворяет ли она условию (длина строки <= 3).
   - Если строка удовлетворяет условию, значение `count` увеличивается на 1.

3. **Создание нового массива:**
   - На основе полученного значения `count`, инициализируется новый массив строк `filteredArray` с размером, равным `count`.
   - Этот массив будет использоваться для хранения строк, удовлетворяющих условию.

4. **Заполнение нового массива:**
   - Программа снова перебирает элементы исходного массива.
   - Каждая строка, которая удовлетворяет условию (длина <= 3), добавляется в `filteredArray`.
   - Используется переменная `index` для отслеживания текущей позиции в `filteredArray`, куда будет добавлена следующая подходящая строка.

5. **Вывод результата:**
   - После заполнения `filteredArray`, программа выводит элементы обоих массивов на экран (в формате, приведенном в примере к заданию), что демонстрирует результат фильтрации.

### Реализация

Код программы на C# размещен в папке [dotnet](dotnet/Program.cs).

Эта программа эффективно фильтрует исходный массив строк, создавая новый массив, который содержит только те строки, длина которых не превышает 3 символа.