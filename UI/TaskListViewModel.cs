/**
�* @file TaskListViewModel.cs
�* @brief �������� ���������� ������ TaskListViewModel.
�*/

using ReactiveUI;

namespace LimitedSizeStack.UI {
��� /**
���� * @brief ViewModel ��� ������ �����.
���� */
��� public class TaskListViewModel : ReactiveObject {
������� /**
�������� * @brief ������������ ������ ��������� � ������.
�������� */
������� public string[] Items => items;

        /**
�������� * @brief ���������, ����� �� �������� ������ ���� ��������� ��� ������.
�������� */
        public bool CanUndo => model.CanUndo();

        private readonly ListModel<string> model;
        private string[] items;

        /**
�������� * @brief �������������� ����� ��������� ������ TaskListViewModel � ��������� ������� ������.
�������� * @param listModel ������ ������.
�������� */
        public TaskListViewModel(ListModel<string> listModel) {
            model = listModel;
            Update();
        }

        /**
�������� * @brief ��������� ��������� ������� � ������.
�������� * @param item �������, ������� ����� ��������.
�������� */
        public void AddItem(string item) {
            model.AddItem(item);
            Update();
        }

        /**
�������� * @brief ������� ������� ��������������� ���������� ������� �� ������.
�������� * @param index ������ ���������� ��������.
�������� */
        public void RemoveItem(int index) {
            model.RemoveItem(index);
            Update();
        }

        /**
�������� * @brief �������� ��������� �������� � ������.
�������� */
        public void Undo() {
            model.Undo();
            Update();
        }

        /**
�������� * @brief ���������� ������� ��������������� ���������� ������� �� ���� ������� ����� � ������.
�������� * @param index ������ ������������� ��������.
�������� */
        public void MoveUpItem(int index) {
����������� //model.MoveUpItem(index);
� ����������Update();
        }

        /**
�������� * @brief �������� ������� PropertyChanged � ��������� �������� Items.
�������� */
        private void Update() {
            this.RaiseAndSetIfChanged(ref items, model.Items.ToArray(), nameof(Items));
        }
    }
}