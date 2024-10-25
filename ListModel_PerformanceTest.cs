/**
 * @file ListModel_PerformanceTest.cs
 * @brief Файл с юнит-тестами производительности класса ListModel.
 */

using NUnit.Framework;

namespace LimitedSizeStack;

[TestFixture]
class ListModel_PerformanceTest {
    /**
     * @brief Тест для проверки того, что не нужно хранить все состояния модели.
     * @see ListModel
     * @ingroup tests
     */
    [Test, Timeout(500)]
    [Description("Не нужно хранить все состояния модели")]
    public void AntiStupidTest() {
        var undoLim = 30000;
        var model = new ListModel<int>(undoLim);
        for (var i = 0; i < undoLim; ++i) {
            model.AddItem(0);
        }
        Assert.AreEqual(undoLim, model.Items.Count);
    }

    /**
    * @todo Тест на проверку скорости выполнения метода `AddItem()` при добавлении большого количества элементов к модели.
    * @ingroup tests
    */

    /**
    * @todo Тест на проверку корректности добавления элементов в модель с использованием метода `AddItem()`.
    * @remark Для данного теста требуется также написать тест на проверку удаления элементов из модели с использованием метода RemoveItem().
    * @ingroup tests
    */

    /**
    * @todo Тест на проверку корректности добавления элементов в модель и их удаления с использованием метода `RemoveItem()`.
    * @ingroup tests
    */

    /**
    * @todo Тест на проверку скорости выполнения метода `RemoveItem()` при удалении элементов из модели с различными индексами.
    * @ingroup tests
    */

    /**
    * @todo  Тест на проверку того, что после выполнения нескольких операций добавления и удаления элементов из модели и отмены этих операций методом `Undo()`, в модели будет содержаться исходный список элементов.
    * @ingroup tests
    */

}