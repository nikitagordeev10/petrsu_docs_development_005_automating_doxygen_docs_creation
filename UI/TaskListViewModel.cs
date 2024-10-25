/**
 * @file TaskListViewModel.cs
 * @brief Содержит объявление класса TaskListViewModel.
 */

using ReactiveUI;

namespace LimitedSizeStack.UI {
    /**
     * @brief ViewModel для списка задач.
     */
    public class TaskListViewModel : ReactiveObject {
        /**
         * @brief Неизменяемый массив элементов в списке.
         */
        public string[] Items => items;

        /**
         * @brief Указывает, может ли операция отмены быть выполнена для списка.
         */
        public bool CanUndo => model.CanUndo();

        private readonly ListModel<string> model;
        private string[] items;

        /**
         * @brief Инициализирует новый экземпляр класса TaskListViewModel с указанной моделью списка.
         * @param listModel Модель списка.
         */
        public TaskListViewModel(ListModel<string> listModel) {
            model = listModel;
            Update();
        }

        /**
         * @brief Добавляет указанный элемент в список.
         * @param item Элемент, который нужно добавить.
         */
        public void AddItem(string item) {
            model.AddItem(item);
            Update();
        }

        /**
         * @brief Удаляет элемент соответствующий указанному индексу из списка.
         * @param index Индекс удаляемого элемента.
         */
        public void RemoveItem(int index) {
            model.RemoveItem(index);
            Update();
        }

        /**
         * @brief Отменяет последнюю операцию в списке.
         */
        public void Undo() {
            model.Undo();
            Update();
        }

        /**
         * @brief Перемещает элемент соответствующий указанному индексу на одну позицию вверх в списке.
         * @param index Индекс перемещаемого элемента.
         */
        public void MoveUpItem(int index) {
            //model.MoveUpItem(index);
            Update();
        }

        /**
         * @brief Вызывает событие PropertyChanged и обновляет свойство Items.
         */
        private void Update() {
            this.RaiseAndSetIfChanged(ref items, model.Items.ToArray(), nameof(Items));
        }
    }
}