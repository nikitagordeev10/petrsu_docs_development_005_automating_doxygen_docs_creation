/**
 * @file ListModel.cs
 * @brief Описание класса ListModel<TItem>, используемого в организации списка с возможностью отката действий
 */

using Avalonia.Utilities;
using System;
using System.Collections.Generic;

namespace LimitedSizeStack {
    /**
     * @class ListModel<TItem>
     * @brief Организация списка с возможностью отката действий
     * @tparam TItem Тип элементов списка
     */
    public class ListModel<TItem> {
        /**
         * @brief Свойство, содержащее элементы списка
         * @return Список элементов
         */
        public List<TItem> Items { get; }
        
         ///@brief Предел количества откатываемых действий 
        public int UndoLimit;

        /// @brief Стек действий для отмены последнего действия
        private LimitedSizeStack<Action> undoActions;

        /**
         * @brief Конструктор класса
         * @param undoLimit Предел количества откатываемых действий
         */
        public ListModel(int undoLimit) {
            Items = new List<TItem>();
            UndoLimit = undoLimit;
            undoActions = new LimitedSizeStack<Action>(undoLimit);
        }

        /**
         * @brief Конструктор класса, принимающий список элементов
         * @param items Список элементов
         * @param undoLimit Предел количества откатываемых действий
         */
        public ListModel(List<TItem> items, int undoLimit) {
            Items = items;
            UndoLimit = undoLimit;
            undoActions = new LimitedSizeStack<Action>(undoLimit);
        }

        /**
         * @brief Добавление нового элемента в список
         * @param item Добавляемый элемент
         * @code
         * var model = new ListModel<int>();
         * model.AddItem(42);
         * @endcode
         */
        public void AddItem(TItem item) {
            Items.Add(item);
            AddUndoAction(new Action(RemoveItemFromList));
        }

        /**
         * @brief Удаление элемента из списка по индексу
         * @param index Индекс удаляемого элемента
         */
        public void RemoveItem(int index) {
            var item = Items[index];
            Items.RemoveAt(index);
            Action undoAction = InsertItemAtIndex;

            /// @brief Локальная функция добавления элемента на прежнее место
            void InsertItemAtIndex() {
                Items.Insert(index, item);
            }
            AddUndoAction(undoAction);
        }

        /**
         * @brief Проверка на возможность выполнения операции отмены
         * @return true, если в списке undoActions есть элемент, иначе - false
         */
        public bool CanUndo() {
            return undoActions.Count > 0;
        }

        /// @brief Отмена последнего действия 
        public void Undo() {
            if (CanUndo()) {
                var action = undoActions.Pop();
                action.Invoke();
            }
        }

        /**
         * @brief Добавление действия отмены последнего действия в стек
         * @param action Действие для отмены последнего действия
         */
        private void AddUndoAction(Action action) {
            undoActions.Push(action);
        }

        /// @brief Удаление последнего элемента из списка
        private void RemoveItemFromList() {
            Items.RemoveAt(Items.Count - 1);
        }
    }
}