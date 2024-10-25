/**
 * @file LimitedSizeStack.cs
 * @brief Описание класса LimitedSizeStack<T>, реализующего стек ограниченного размера
 * @tparam T Тип элементов стека
 */

using DynamicData;
using System;

/**
 * @namespace LimitedSizeStack
 * @brief Постранство имен для класса LimitedSizeStack<T>
 */

namespace LimitedSizeStack {

    /**
     * @class LimitedSizeStack<T>
     * @brief Реализация стека ограниченного размера
     * @tparam T Тип элементов стека
     */
    public class LimitedSizeStack<T> {

        /**
         * @brief Массив элементов стека
         */
        private T[] items;
        /**
         * @brief Позиция вершины стека
         */
        private int top = 0;
        /**
         * @brief Размер стека
         */
        private int stackSize = 0;

        /**
         * @brief Конструктор класса
         * @param undoLimit Ограничение размера стека
         * @details Создает массив items размера undoLimit, состоящий из элементов типа T
         */
        public LimitedSizeStack(int undoLimit) {
            items = new T[undoLimit];
        }

        /**
         * @brief Добавление элемента на вершину стека
         * @param item Элемент, добавляемый на вершину стека
         * @link https://en.wikipedia.org/wiki/Stack_(abstract_data_type) Стек (википедия)
         * @warning Если ограничение размера стека 0, то ничего не добавляем
         * @bug Если стек заполнен до конца, то добавленный элемент перезапишет первый добавленный элемент
         */
        public void Push(T item) {
            // Если ограничение размера стека 0, то ничего не добавляем
            if (items.Length == 0)
                return;
            ///@note Иначе, добавить элемент на вершину стека (DropOutStack)
            items[top] = item;
            top = (top + 1) % items.Length;
            // Если стек заполнен не до конца, то запомнить размер
            if (stackSize < items.Length)
                stackSize++;
        }

        /**
        * @brief Удаление элемента с вершины стека
        * @return Элемент, удаленный с вершины стека
        * @throw InvalidOperationException если стек пуст
        * @code
        * // Пример использования:
        * Stack<int> stack = new Stack<int>();
        * int popped = stack.Pop();
        * @endcode
        */
        public T Pop() {
            // Если стек пуст, то выдаём ошибку
            if (stackSize == 0)
                throw new System.InvalidOperationException("Stack is empty");
            // Иначе, удалить элемент с вершины стка (DropOutStack)
            top = ((items.Length - 1) + top) % items.Length;
            stackSize--;
            return items[top];
        }



        /**
         * @brief Текущий размер стека
         * @return размер стека
         */
        public int Count {
            get {
                return stackSize;
            }
        }
    }
}