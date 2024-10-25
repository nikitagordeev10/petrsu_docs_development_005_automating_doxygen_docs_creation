/**
 * @file FinalizableClass.cs
 * @brief Описание классов Counter и FinalizableClass, используемых для тестирования LimitedSizeStack
 */

namespace LimitedSizeStack;

/**
 * @class Counter
 * @brief Счетчик, используемый для тестирования стека
 */
public class Counter {
    /**
     * @brief Текущее значение счетчика
     * @return Значение счетчика
     */
    public int Value { get; private set; }

    /**
     * @brief Конструктор класса
     * @details Инициализирует счетчик нулем
     */
    public Counter() {
        Value = 0;
    }

    /**
     * @brief Увеличение значения счетчика на 1
     */
    public void Increase() {
        Value++;
    }
}

/**
 * @class FinalizableClass
 * @brief Класс, который увеличивает значение Counter-а каждый раз, когда сборщик мусора собирает объект этого класса
 * @details Нужен, чтобы протестировать, что стек не оставляет указателей на вытесненные из стека объекты
 */
class FinalizableClass {
    /**
     * @brief Счётчик
     */
    public Counter Counter;

    /**
     * @brief Конструктор класса
     * @param counter Счётчик
     */
    public FinalizableClass(Counter counter) {
        Counter = counter;
    }

    /**
     * @brief Деструктор класса
     * @details Специальный метод, который вызывается сборщиком мусора, перед тем, как освободить память от этого объекта
     * @details Увеличивает значение счётчика на 1 при освобождении памяти
     */
    ~FinalizableClass() {
        lock (Counter) {
            Counter.Increase();
        }
    }
}