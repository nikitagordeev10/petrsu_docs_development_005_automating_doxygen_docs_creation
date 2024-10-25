На основе существующего программного проекта задать комментарии для автоматической генерации документацию. Дополнительные требования: задать форматирование титульного листа документации (README.md), деление элементов кода на модули (блоки), необходимо добавить перекресных ссылок на другие источники и разделы, используйте блоки специальных комментариев (todo, note и т.д.), используйте включение элементов кода в документацию.

Возможна сдача задания на основе другого языка программирования или другого инструмента генерации документации (python,javascript,php), многие среды разработке включают этот функционал или имеются плагины/пакеты для его подключения.

# Проект "Limited Size Stack" {#mainpage}

### Описание
В этом проекте реализован стек ограниченного размера. Этот стек работает как обычный стек, однако при превышении максимального размера удаляет самый глубокий элемент в стеке. Таким образом в стеке всегда будет ограниченное число элементов.

### Пример работы

Вот пример работы такого стека с ограничением в 2 элемента:
```
// сначала стек пуст
stack.Push(10); // в стеке 10
stack.Push(20); // в стеке 10, 20
stack.Push(30); // в стеке 20, 30
stack.Push(40); // в стеке 30, 40
stack.Pop(); // возвращает 40, в стеке остаётся 30
stack.Pop(); // возвращает 30, стек после этого пуст
```

### Сложность

Операция Push имеет сложность O(1), то есть никак не зависеть от размера стека.


___

### Эффективность методов 
#### Last()

У каждой коллекции в C# доступен метод расширения Last(). Однако, работает он за O(1) только для коллекций, реализующих интерфейс IList (список с доступом к элементам по индексу). Для остальных коллекций он работает за O(N), перебирая её элементы до конца. 

___

### Устройство проекта
1. FinalizableClass.cs
2. LimitedSizeStack.cs
3. LimitedSizeStack_PerformanceTest.cs
4. LimitedSizeStack_should.cs
5. ListModel.cs
6. ListModel_PerformanceTest.cs
7. ListModel_should.cs